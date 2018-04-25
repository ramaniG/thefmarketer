from django.db import models

# Create your models here.

class Users(models.Model):
    """This represent the registered users."""
    FB = 'FB'
    EM = 'EM'
    GO = 'GO'

    AUTHTYPES = (
        (FB, 'Facebook'),
        (EM, 'Email'),
        (GO, 'Google'),
    )

    fname = models.CharField(max_length=255, blank=False, unique=True)
    lname = models.CharField(max_length=255, blank=False, unique=True)
    email = models.EmailField(max_length=500, blank=False, unique=True)
    contactno = models.CharField(max_length=255, blank=True)
    authtype = models.CharField(max_length=2, choices=AUTHTYPES, default=EM)
    password = models.CharField(max_length=50, blank=True)
    showemail = models.NullBooleanField(blank=True)
    showcontactno = models.NullBooleanField(blank=True)
    verified = models.BooleanField(blank=True)
    lastLogin = models.DateTimeField(blank=True)
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)


    def __str__(self):
        """Return a human readable representation of the model instance."""
        return "{}".format(self.fname + ' ' + self.lname)

class Consultant(models.Model):
    """This represent the registered consultant."""
    E1 = 'E1'
    E2 = 'E2'
    P1 = 'P1'
    P2 = 'P2'

    CONTACTOPTIONS = (
        (E1, 'Primary Email'),
        (E2, 'Secondary Email'),
        (P1, 'Primary Contact No'),
        (P2, 'Secondary Contact No'),
    )

    fname = models.CharField(max_length=255, blank=False)
    lname = models.CharField(max_length=255, blank=False)
    email1 = models.EmailField(max_length=500, blank=False, unique=True)
    contactno1 = models.CharField(max_length=255, blank=True)
    email2 = models.EmailField(max_length=500, blank=True)
    contactno2 = models.CharField(max_length=255, blank=True)
    password = models.CharField(max_length=50, blank=False)
    preferedcontact1 = models.CharField(max_length=2, blank=False, choices=CONTACTOPTIONS)
    preferedcontact2 = models.CharField(max_length=2, blank=False, choices=CONTACTOPTIONS)
    verified = models.BooleanField(blank=True)
    lastLogin = models.DateTimeField(blank=True)
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

    def __str__(self):
        """Return a human readable representation of the model instance."""
        return "{}".format(self.fname + ' ' + self.lname)

class ConsultantCoverage(models.Model):
    JH = 'JH'
    KH = 'KH'
    KN = 'KN'
    KL = 'KL'
    LA = 'LA'
    ME = 'ME'
    NS = 'NS'
    PH = 'PH'
    PK = 'PK'
    PL = 'PL'
    PG = 'PG'
    PJ = 'PJ'
    SA = 'SA'
    SK = 'SK'
    SL = 'SL'
    TE = 'TE'

    STATES = (
        (JH, 'Johor'),
        (KH, 'Kedah'),
        (KN, 'Kelantan'),
        (KL, 'Kuala Lumpur'),
        (LA, 'Labuan'),
        (ME, 'Melaka'),
        (NS, 'Negeri Sembilan'),
        (PH, 'Pahang'),
        (PK, 'Perak'),
        (PL, 'Perlis'),
        (PG, 'Pulau Pinang'),
        (PJ, 'Putrajaya'),
        (SA, 'Sabah'),
        (SK, 'Sarawak'),
        (SL, 'Selangor'),
        (TE, 'Terengganu'),
    )

    consultant = models.ForeignKey(
        Consultant,
        related_name='coverages',
        on_delete=models.CASCADE,
    )
    state = models.CharField(max_length=2, choices=STATES, default=KL)
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

    def __str__(self):
        """Return a human readable representation of the model instance."""
        return "{}".format(self.consultant + ' : ' + state)

class ConsultantServices(models.Model):
    """This class will list down all the available Consultant + Service available"""
    FP = 'FP'
    LI = 'LI'
    IN = 'IN'
    TF = 'TF'
    WW = 'WW'

    SERVICES = (
        (FP, 'Financial Planner'),
        (LI, 'Life Insurance'),
        (IN, 'Investments'),
        (TF, 'Trust Fund'),
        (WW, 'Will Writing'),
    )

    SM = 'SM'
    SE = 'SE'
    ME = 'ME'
    MH = 'MH'
    HI = 'HI'

    CLIENTSCALE = (
        (SM, 'Small (< 10)'),
        (SE, 'Small to Medium (> 50)'),
        (ME, 'Medium (> 100)'),
        (MH, 'Medium to High (> 150)'),
        (HI, 'High (> 200)'),
    )

    consultant = models.ForeignKey(
        Consultant,
        related_name='services',
        on_delete=models.CASCADE,
    )
    service = models.CharField(max_length=2, choices=SERVICES, default=FP)
    company = models.CharField(max_length=255, blank=True)
    registrationno = models.CharField(max_length=255, blank=True)
    active = models.BooleanField(blank=False)
    activesince = models.DateTimeField()
    yearsofexpirience = models.IntegerField()
    clientscale = models.CharField(max_length=2, choices=CLIENTSCALE, default=SM)
    proof = models.ImageField(upload_to='proof/')
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

    def __str__(self):
        """Return a human readable representation of the model instance."""
        return "{}".format(self.consultant + ' : ' + service)

class Request(models.Model):
    FP = 'FP'
    LI = 'LI'
    IN = 'IN'
    TF = 'TF'
    WW = 'WW'

    SERVICES = (
        (FP, 'Financial Planner'),
        (LI, 'Life Insurance'),
        (IN, 'Investments'),
        (TF, 'Trust Fund'),
        (WW, 'Will Writing'),
    )

    consultant = models.ForeignKey(
        Consultant,
        on_delete=models.CASCADE,
    )
    user = models.ForeignKey(
        Users,
        on_delete=models.CASCADE,
    )
    service = models.CharField(max_length=2, choices=SERVICES)
    reviewsubmited = models.BooleanField(blank=False)
    active = models.BooleanField(blank=False)
    completed = models.BooleanField(blank=False)
    message = models.TextField(blank=True)
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

class Review(models.Model):
    request = models.ForeignKey(
        Users,
        on_delete=models.CASCADE,
    )
    stars = models.IntegerField()
    message = models.TextField(blank=True)
    public = models.BooleanField(blank=False)
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

class Chat(models.Model):
    FC = 'FC'
    US = 'UC'

    USERTYPE = (
        (FC, 'Consultant'),
        (US, 'User'),
    )

    request = models.ForeignKey(
        Users,
        on_delete=models.CASCADE,
    )
    message = models.TextField(blank=True)
    read = models.BooleanField(blank=False)
    usertype = models.CharField(max_length=2, choices=USERTYPE)
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

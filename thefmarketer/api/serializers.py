from rest_framework import serializers
from .models import Users,Consultant,ConsultantCoverage,ConsultantServices,Request,Review,Chat

class LoginSerializer(serializers.Serializer):
    '''email = serializers.EmailField()'''
    email = serializers.CharField(max_length=200)
    password = serializers.CharField(max_length=100)

class SearchSerializer(serializers.Serializer):
    service = serializers.CharField(max_length=2,allow_blank=True)
    location = serializers.CharField(max_length=2,allow_blank=True)
    name = serializers.CharField(max_length=100,allow_blank=True)
    rating = serializers.IntegerField()

class UsersSerializer(serializers.ModelSerializer):
    """Serializer to map the Model instance into JSON format."""

    class Meta:
        """Meta class to map serializer's fields with the model fields."""
        model = Users
        fields = ('id',
            'fname',
            'lname',
            'email' ,
            'contactno',
            'authtype',
            'password',
            'showemail',
            'showcontactno',
            'verified',
            'lastLogin',
            'created',
            'modified'
        )
        read_only_fields = ('created', 'modified')

class ConsultantCoverageSerializer(serializers.ModelSerializer):
    """Serializer to map the Model instance into JSON format."""

    class Meta:
        """Meta class to map serializer's fields with the model fields."""
        model = ConsultantCoverage
        fields = ('id',
            'consultant',
            'state',
            'created',
            'modified'
        )
        read_only_fields = ('created', 'modified')

class ConsultantServicesSerializer(serializers.ModelSerializer):
    """Serializer to map the Model instance into JSON format."""

    class Meta:
        """Meta class to map serializer's fields with the model fields."""
        model = ConsultantServices
        fields = ('id',
            'consultant',
            'service',
            'company',
            'registrationno',
            'active',
            'activesince',
            'yearsofexpirience',
            'clientscale',
            'proof',
            'created',
            'modified'
        )
        read_only_fields = ('created', 'modified')

class ConsultantSerializer(serializers.ModelSerializer):
    """Serializer to map the Model instance into JSON format."""
    coverages = ConsultantCoverageSerializer(many=True,read_only=True)
    services = ConsultantServicesSerializer(many=True,read_only=True)

    class Meta:
        """Meta class to map serializer's fields with the model fields."""
        model = Consultant
        fields = ('__all__')
        read_only_fields = ('created', 'modified')

class RequestSerializer(serializers.ModelSerializer):
    """Serializer to map the Model instance into JSON format."""

    class Meta:
        """Meta class to map serializer's fields with the model fields."""
        model = Request
        fields = ('id',
            'consultant',
            'user',
            'service',
            'reviewsubmited',
            'active',
            'completed',
            'message',
            'created',
            'modified'
        )
        read_only_fields = ('created', 'modified')

class ReviewSerializer(serializers.ModelSerializer):
    """Serializer to map the Model instance into JSON format."""

    class Meta:
        """Meta class to map serializer's fields with the model fields."""
        model = Review
        fields = ('id',
            'request',
            'stars',
            'message',
            'public',
            'created',
            'modified'
        )
        read_only_fields = ('created', 'modified')

class ChatSerializer(serializers.ModelSerializer):
    """Serializer to map the Model instance into JSON format."""

    class Meta:
        """Meta class to map serializer's fields with the model fields."""
        model = Chat
        fields = ('id',
            'request',
            'message',
            'read',
            'usertype',
            'created',
            'modified'
        )
        read_only_fields = ('created', 'modified')

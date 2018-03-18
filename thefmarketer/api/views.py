from .models import Users,Consultant,ConsultantCoverage,ConsultantServices,Request,Review,Chat
from .serializers import UsersSerializer,ConsultantSerializer,ConsultantCoverageSerializer,ConsultantServicesSerializer,RequestSerializer,ReviewSerializer,ChatSerializer
from rest_framework import generics

'''Users'''
class UsersList(generics.ListCreateAPIView):
    queryset = Users.objects.all()
    serializer_class = UsersSerializer

class UsersDetail(generics.RetrieveUpdateDestroyAPIView):
    queryset = Users.objects.all()
    serializer_class = UsersSerializer

'''Consultant'''
class ConsultantList(generics.ListCreateAPIView):
    queryset = Consultant.objects.all()
    serializer_class = ConsultantSerializer

class ConsultantDetail(generics.RetrieveUpdateDestroyAPIView):
    queryset = Consultant.objects.all()
    serializer_class = ConsultantSerializer

'''ConsultantCoverage'''
class ConsultantCoverageList(generics.ListCreateAPIView):
    queryset = ConsultantCoverage.objects.all()
    serializer_class = ConsultantCoverageSerializer

class ConsultantCoverageDetail(generics.RetrieveUpdateDestroyAPIView):
    queryset = ConsultantCoverage.objects.all()
    serializer_class = ConsultantCoverageSerializer

'''ConsultantServices'''
class ConsultantServicesList(generics.ListCreateAPIView):
    queryset = ConsultantServices.objects.all()
    serializer_class = ConsultantServicesSerializer

class ConsultantServicesDetail(generics.RetrieveUpdateDestroyAPIView):
    queryset = ConsultantServices.objects.all()
    serializer_class = ConsultantServicesSerializer

'''Request'''
class RequestList(generics.ListCreateAPIView):
    queryset = Request.objects.all()
    serializer_class = RequestSerializer

class RequestDetail(generics.RetrieveUpdateDestroyAPIView):
    queryset = Request.objects.all()
    serializer_class = RequestSerializer

'''Review'''
class ReviewList(generics.ListCreateAPIView):
    queryset = Review.objects.all()
    serializer_class = ReviewSerializer

class ReviewDetail(generics.RetrieveUpdateDestroyAPIView):
    queryset = Review.objects.all()
    serializer_class = ReviewSerializer

'''Chat'''
class ChatList(generics.ListCreateAPIView):
    queryset = Chat.objects.all()
    serializer_class = ChatSerializer

class ChatDetail(generics.RetrieveUpdateDestroyAPIView):
    queryset = Chat.objects.all()
    serializer_class = ChatSerializer

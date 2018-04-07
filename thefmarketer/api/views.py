from .models import Users,Consultant,ConsultantCoverage,ConsultantServices,Request,Review,Chat
from .serializers import LoginSerializer,UsersSerializer,ConsultantSerializer,ConsultantCoverageSerializer,ConsultantServicesSerializer,RequestSerializer,ReviewSerializer,ChatSerializer
from rest_framework import generics
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework import status
from django.core.exceptions import ObjectDoesNotExist
from rest_framework.renderers import JSONRenderer

'''Login'''
class Login(APIView):
    def post(self, request, format=None):
        serializer = LoginSerializer(data=request.data, many=False)
        if serializer.is_valid():
            try:
                '''print(serializer.data)
                print(serializer.data['email'])
                print(serializer.data['password'])'''
                user = Users.objects.get(email = serializer.data['email'], password = serializer.data['password'])
                '''user = Users()
                user.fname = 'Heloooo'
                user.password = ""'''
                usersSerializer = UsersSerializer(user)
                return Response(usersSerializer.data, status=status.HTTP_200_OK)
            except ObjectDoesNotExist:
                return Response(status=status.HTTP_204_NO_CONTENT)
        else:
            return Response(status=status.HTTP_400_BAD_REQUEST)

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

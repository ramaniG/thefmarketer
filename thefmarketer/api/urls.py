from django.conf.urls import url, include
from rest_framework.urlpatterns import format_suffix_patterns
from .views import Login
from .views import Search
from .views import UsersList,UsersDetail
from .views import ConsultantList,ConsultantDetail
from .views import ConsultantCoverageList,ConsultantCoverageDetail
from .views import ConsultantServicesList,ConsultantServicesDetail
from .views import RequestList,RequestDetail
from .views import ReviewList,ReviewDetail
from .views import ChatList,ChatDetail

urlpatterns = [
    url(r'^search/$', Search.as_view()),
    url(r'^login/$', Login.as_view()),
    url(r'^users/$', UsersList.as_view()),
    url(r'^user/(?P<pk>[0-9]+)/$', UsersDetail.as_view()),
    url(r'^consultants/$', ConsultantList.as_view()),
    url(r'^consultant/(?P<pk>[0-9]+)/$', ConsultantDetail.as_view()),
    url(r'^coverages/$', ConsultantCoverageList.as_view()),
    url(r'^coverage/(?P<pk>[0-9]+)/$', ConsultantCoverageDetail.as_view()),
    url(r'^services/$', ConsultantServicesList.as_view()),
    url(r'^service/(?P<pk>[0-9]+)/$', ConsultantServicesDetail.as_view()),
    url(r'^requests/$', RequestList.as_view()),
    url(r'^request/(?P<pk>[0-9]+)/$', RequestDetail.as_view()),
    url(r'^reviews/$', ReviewList.as_view()),
    url(r'^review/(?P<pk>[0-9]+)/$', ReviewDetail.as_view()),
    url(r'^chats/$', ChatList.as_view()),
    url(r'^chat/(?P<pk>[0-9]+)/$', ChatDetail.as_view()),
]

urlpatterns = format_suffix_patterns(urlpatterns)

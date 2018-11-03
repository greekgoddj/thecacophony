from django.urls import path

from . import views

urlpatterns = [
    path('', views.index, name='index'),
    path('jquery.kontrol.js', views.kontrol, name='jquery.kontrol.js'),
]

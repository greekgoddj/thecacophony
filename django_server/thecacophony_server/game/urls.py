from django.urls import path

from . import views

urlpatterns = [
    path('', views.index, name='index'),
    path('uploaduserinput', views.upload_user_input, name="upload"),
    path('getuserinputvalues', views.get_user_input_values, name="getuserinputvalues"),
]

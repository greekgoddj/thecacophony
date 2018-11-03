from django.urls import path

from . import views

urlpatterns = [
    path('', views.index, name='index'),
    path('jquery.kontrol.js', views.kontrol, name='jquery.kontrol.js'),

    path('uploaduserinput', views.upload_user_input, name="upload"),
    path('getuserinputvalues', views.get_user_input_values, name="getuserinputvalues"),

    path('registergameserver', views.register_game_server, name="registergameserver"),
    path('getgameserver', views.get_game_server, name="getgameserver"),
]

from django.http import HttpResponse
from django.template import loader

def index(request):
    template = loader.get_template('game/index.html')
    context = {}
    return HttpResponse(template.render(context, request))

# Store user input values transiently.
# They'll be lost when restarting the server.
# Probably a hack, not how Django is supposed to work.
userControls = {}

def upload_user_input(request):
    value = request.GET.get('value', '')
    username = request.GET.get('username', '')
    userControls[username] = value
    return HttpResponse("Uploading user: %s value: %s" % (username, value))

def get_user_input_values(request):
    output = ", ".join(["%s: %s" % (user, value) for user, value in userControls.items()])
    return HttpResponse(output)

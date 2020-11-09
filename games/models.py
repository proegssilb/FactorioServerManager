from django.db import models
from django.conf import settings

# Create your models here.
class Game(models.Model):
    name = models.CharField(max_length=255)
    description = models.TextField()

    serverIdentity = models.ForeignKey(settings.AUTH_USER_MODEL, on_delete=models.SET_NULL, null=True, related_name='games_running')
    players = models.ManyToManyField(settings.AUTH_USER_MODEL, related_name='games_playing')
    admins = models.ManyToManyField(settings.AUTH_USER_MODEL, related_name='games_admining')



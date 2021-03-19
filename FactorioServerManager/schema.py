import graphene
from graphene_django.types import DjangoObjectType, ObjectType
from games.models import Game

class GameType(DjangoObjectType):
    class Meta:
        model = Game

class Query(ObjectType):
    game = graphene.Field(GameType, id=graphene.Int())
    games = graphene.List(GameType)

    def resolve_game(self, info, **kwargs):
        id = kwargs.get('id')

        if id is not None:
            return Game.objects.get(pk=id)
        
        return None
    
    def resolve_games(self, info, **kwargs):
        return Game.objects.all()

#TODO: Mutations

schema = graphene.Schema(query=Query)
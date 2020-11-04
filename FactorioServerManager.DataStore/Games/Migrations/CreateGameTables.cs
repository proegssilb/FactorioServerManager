using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.DataStore.Games.Migrations
{
    [Migration(2020, 11, 01, 5000, 200)]
    public class CreateGameTables : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("factoriogames")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("name").AsString().Unique()
                .WithColumn("description").AsString();

            Create.Table("game_owners")
                .WithColumn("gameid").AsInt64().ForeignKey("factoriogames", "id")
                .WithColumn("userid").AsInt64().ForeignKey("users", "id");

            Create.Table("game_players")
                .WithColumn("gameid").AsInt64().ForeignKey("factoriogames", "id")
                .WithColumn("userid").AsInt64().ForeignKey("users", "id");
        }
    }

    [Migration(2020, 11, 03, 5000, 100)]
    public class ReworkGamePlayerRelationships : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("playertypes")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().Unique()
                .WithColumn("description").AsString();

            var insertExpression = Insert.IntoTable("playertypes");

            foreach (GameMemberTypes memberType in Enum.GetValues(typeof(GameMemberTypes)))
            {
                insertExpression.Row(new { id = (int)memberType, name = Enum.GetName(typeof(GameMemberTypes), memberType), description = "" });
            }

            Create.Table("game_members")
                .WithColumn("gameid").AsInt64().ForeignKey("factoriogames", "id")
                .WithColumn("userid").AsInt64().ForeignKey("users", "id")
                .WithColumn("membertype").AsInt32().NotNullable();

            Delete.Table("game_owners");
            Delete.Table("game_players");
        }
    }
}

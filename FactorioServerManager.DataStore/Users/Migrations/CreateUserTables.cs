using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.DataStore.Users.Migrations
{
    [Migration(2020, 11, 01, 5000, 0)]
    public class CreateUserTables : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("identifier").AsString().Unique().NotNullable()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("icon").AsString().NotNullable();

            Create.Table("factorioidentities")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("userid").AsInt64().NotNullable()
                .WithColumn("username").AsString().NotNullable()
                .WithColumn("token").AsString().Nullable();

            Create.ForeignKey("fk_factorioidentities_users")
                .FromTable("factorioidentities").ForeignColumn("userid")
                .ToTable("users").PrimaryColumn("id");
        }
    }
}

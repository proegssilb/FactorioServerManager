using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.DataStore.Calendars.Migrations
{
    [Migration(2020, 11, 01, 5000, 100)]
    class CreateCalendarTables : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("calendars")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("link").AsString().Unique()
                .WithColumn("name").AsString().Unique()
                .WithColumn("description").AsString();
        }
    }
}

using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitedPlaces.Store.SQLiteDatabase.Migrations
{
    [Migration(20231005001)]
    public class InitialTables_20231005001
    {
        public override void Down()
        {
            Delete.Table("Employees");
            Delete.Table("Companies");
        }
        public override void Up()
        {
            Create.Table("Companies")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Address").AsString(60).NotNullable()
                .WithColumn("Country").AsString(50).NotNullable();
            Create.Table("Employees")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("Position").AsString(50).NotNullable()
                .WithColumn("CompanyId").AsGuid().NotNullable().ForeignKey("Companies", "Id");
        }
    }
}

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatainMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from MembershipTypes");
            Sql("Insert into MembershipTypes (Id,SignUpFee,DurationByMonth,Discount,Name) values(1,0,0,0,'Pay As You Go')");
            Sql("Insert into MembershipTypes (Id,SignUpFee,DurationByMonth,Discount,Name) values(2,30,1,10,'Monthly')");
            Sql("Insert into MembershipTypes (Id,SignUpFee,DurationByMonth,Discount,Name) values(3,90,3,20,'Quarterly')");
            Sql("Insert into MembershipTypes (Id,SignUpFee,DurationByMonth,Discount,Name) values(4,300,12,30,'Annualy')");
        }
        
        public override void Down()
        {
        }
    }
}

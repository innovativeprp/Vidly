namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes (Id,SignUpFee,DurationByMonth,Discount) values(1,0,0,0)");
            Sql("Insert into MembershipTypes (Id,SignUpFee,DurationByMonth,Discount) values(2,30,1,10)");
            Sql("Insert into MembershipTypes (Id,SignUpFee,DurationByMonth,Discount) values(3,90,3,20)");
            Sql("Insert into MembershipTypes (Id,SignUpFee,DurationByMonth,Discount) values(4,300,12,30)");
        }
        
        public override void Down()
        {
        }
    }
}

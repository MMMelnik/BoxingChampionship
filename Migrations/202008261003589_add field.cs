namespace BoxingChampionship.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class addfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Battles", "AmountOfRounds", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Battles", "AmountOfRounds");
        }
    }
}

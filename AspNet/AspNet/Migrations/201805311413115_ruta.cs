namespace AspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ruta : DbMigration
    {
        public override void Up()
        {
           CreateTable(
                "dbo.Administrator",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Ime = c.String(maxLength: 30),
                        Prezime = c.String(maxLength: 30),
                        Username = c.String(maxLength: 30),
                        Pass = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dojava",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Mjesto = c.String(maxLength: 30),
                        VrijemeDojave = c.DateTime(),
                        TrajanjeDojave = c.Int(),
                        Posiljalac = c.Int(),
                        ZadnjiIzmjenio = c.Int(),
                        Korisnik_ID = c.Int(),
                        Korisnik_ID1 = c.Int(),
                        Korisnik_ID2 = c.Int(),
                        Korisnik1_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Korisnik", t => t.Korisnik_ID)
                .ForeignKey("dbo.Korisnik", t => t.Korisnik_ID1)
                .ForeignKey("dbo.Korisnik", t => t.Korisnik_ID2)
                .ForeignKey("dbo.Korisnik", t => t.Korisnik1_ID)
                .Index(t => t.Korisnik_ID)
                .Index(t => t.Korisnik_ID1)
                .Index(t => t.Korisnik_ID2)
                .Index(t => t.Korisnik1_ID);
            
            CreateTable(
                "dbo.Korisnik",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Ime = c.String(maxLength: 30),
                        Prezime = c.String(maxLength: 30),
                        Username = c.String(maxLength: 30),
                        Pass = c.String(maxLength: 30),
                        Email = c.String(maxLength: 30),
                        BrojDojava = c.Int(),
                        BrojAktivnihDojava = c.Int(),
                        SlikaProfila = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ruta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.String(),
                        Kraj = c.String(),
                        VrijemePutovanja = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);    
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dojava", "Korisnik1_ID", "dbo.Korisnik");
            DropForeignKey("dbo.Dojava", "Korisnik_ID2", "dbo.Korisnik");
            DropForeignKey("dbo.Dojava", "Korisnik_ID1", "dbo.Korisnik");
            DropForeignKey("dbo.Dojava", "Korisnik_ID", "dbo.Korisnik");
            DropIndex("dbo.Dojava", new[] { "Korisnik1_ID" });
            DropIndex("dbo.Dojava", new[] { "Korisnik_ID2" });
            DropIndex("dbo.Dojava", new[] { "Korisnik_ID1" });
            DropIndex("dbo.Dojava", new[] { "Korisnik_ID" });
            DropTable("dbo.Ruta");
            DropTable("dbo.Korisnik");
            DropTable("dbo.Dojava");
            DropTable("dbo.Administrator");
        }
    }
}

namespace Biblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoautores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.autors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                    Nacionalidad = c.String(),
                })
                .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.Libroes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(),
            //            Año = c.Int(nullable: false),
            //            Editorial_Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Editorials", t => t.Editorial_Id)
            //    .Index(t => t.Editorial_Id);

            //CreateTable(
            //    "dbo.Editorials",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Libroautors",
                c => new
                    {
                        Libro_Id = c.Int(nullable: false),
                        autor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Libro_Id, t.autor_Id })
                .ForeignKey("dbo.Libroes", t => t.Libro_Id, cascadeDelete: true)
                .ForeignKey("dbo.autors", t => t.autor_Id, cascadeDelete: true)
                .Index(t => t.Libro_Id)
                .Index(t => t.autor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libroes", "Editorial_Id", "dbo.Editorials");
            DropForeignKey("dbo.Libroautors", "autor_Id", "dbo.autors");
            DropForeignKey("dbo.Libroautors", "Libro_Id", "dbo.Libroes");
            DropIndex("dbo.Libroautors", new[] { "autor_Id" });
            DropIndex("dbo.Libroautors", new[] { "Libro_Id" });
            DropIndex("dbo.Libroes", new[] { "Editorial_Id" });
            DropTable("dbo.Libroautors");
            DropTable("dbo.Editorials");
            DropTable("dbo.Libroes");
            DropTable("dbo.autors");
        }
    }
}

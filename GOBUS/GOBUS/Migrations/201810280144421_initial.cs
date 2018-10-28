namespace GOBUS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cita",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlacaNumero = c.String(nullable: false, maxLength: 10, unicode: false, storeType: "nvarchar"),
                        FechaCita = c.DateTime(nullable: false, precision: 0),
                        IdCliente = c.Int(nullable: false),
                        IdSucursal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.Sucursale", t => t.IdSucursal, cascadeDelete: true)
                .Index(t => t.IdCliente)
                .Index(t => t.IdSucursal);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Apellidos = c.String(nullable: false, maxLength: 100, unicode: false, storeType: "nvarchar"),
                        Direccion = c.String(nullable: false, maxLength: 200, unicode: false, storeType: "nvarchar"),
                        Telefono = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sucursale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Direcion = c.String(nullable: false, maxLength: 100, unicode: false, storeType: "nvarchar"),
                        Telefono = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        Encargado = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreServicio = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Descripcion = c.String(nullable: false, maxLength: 100, unicode: false, storeType: "nvarchar"),
                        Costo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cita", "IdSucursal", "dbo.Sucursale");
            DropForeignKey("dbo.Cita", "IdCliente", "dbo.Cliente");
            DropIndex("dbo.Cita", new[] { "IdSucursal" });
            DropIndex("dbo.Cita", new[] { "IdCliente" });
            DropTable("dbo.Servicio");
            DropTable("dbo.Sucursale");
            DropTable("dbo.Cliente");
            DropTable("dbo.Cita");
        }
    }
}

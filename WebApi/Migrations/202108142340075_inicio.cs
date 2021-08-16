namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DtmCadastro = c.DateTime(nullable: false),
                        SNome = c.String(nullable: false, maxLength: 4000),
                        SEmail = c.String(nullable: false, maxLength: 4000),
                        SAldeia = c.String(nullable: false, maxLength: 4000),
                        BAtivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DtmCadastro = c.DateTime(nullable: false),
                        BAtivo = c.Boolean(nullable: false),
                        DtmPedido = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        DValorPedido = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DDesconto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DtmAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PedidoItens",
                c => new
                    {
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Item = c.Int(nullable: false),
                        ProdutoValorUn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProdutoQuantidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.PedidoId, t.ProdutoId })
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DtmCadastro = c.DateTime(nullable: false),
                        BAtivo = c.Boolean(nullable: false),
                        SNome = c.String(nullable: false, maxLength: 4000),
                        SDescricao = c.String(nullable: false, maxLength: 4000),
                        DValor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SPathFoto = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoItens", "PedidoId", "dbo.Pedidos");
            DropIndex("dbo.PedidoItens", new[] { "PedidoId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.PedidoItens");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Clientes");
        }
    }
}

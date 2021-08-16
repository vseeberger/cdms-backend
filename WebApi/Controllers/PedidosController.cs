using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PedidosController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/Pedidos
        public IQueryable<Pedido> GetPedidos()
        {
            return db.Pedidos;
        }

        // GET: api/Pedidos/5
        [ResponseType(typeof(Pedido))]
        public async Task<IHttpActionResult> GetPedido(int id)
        {
            Pedido pedido = await db.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        // PUT: api/Pedidos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPedido(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido.Id)
            {
                return BadRequest();
            }

            db.Entry(pedido).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pedidos
        [ResponseType(typeof(Pedido))]
        public async Task<IHttpActionResult> PostPedido(Pedido pedido)
        {
            Pedido novoPedido = new Pedido()
            {
                ClienteId = pedido.ClienteId,
                DDesconto = pedido.DDesconto,
                DValorPedido = pedido.DValorPedido,
                DValorTotal = pedido.DValorTotal
            };
            db.Pedidos.Add(novoPedido);
            await db.SaveChangesAsync();

            int i = 0;
            foreach (var item in pedido.Produtos)
            {
                db.PedidoItens.Add(new PedidoItens()
                {
                    Item = i++,
                    PedidoId = novoPedido.Id,
                    ProdutoId = item.ProdutoId,
                    ProdutoQuantidade = item.ProdutoQuantidade,
                    ProdutoValorUn = item.ProdutoValorUn
                });
            }
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidos/5
        [ResponseType(typeof(Pedido))]
        public async Task<IHttpActionResult> DeletePedido(int id)
        {
            Pedido pedido = await db.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            db.Pedidos.Remove(pedido);
            await db.SaveChangesAsync();

            return Ok(pedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoExists(int id)
        {
            return db.Pedidos.Count(e => e.Id == id) > 0;
        }
    }
}
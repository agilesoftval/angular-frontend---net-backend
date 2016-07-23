using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AngularDemo.Models;

namespace AngularDemo.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ShoppingAppDbContext _db = new ShoppingAppDbContext();

        public IQueryable<ProductImageVm> GetProductImages(int pageSize = 10)
        {
            var model = _db.ProductImage.AsQueryable();

            return model.Select(ProductImageVm.Select).Take(pageSize);
        }

        [ResponseType(typeof(ProductImageVm))]
        public async Task<IHttpActionResult> GetProductImage(int id)
        {
            var model = await _db.ProductImage.Select(ProductImageVm.Select).FirstOrDefaultAsync(x => x.ImageId == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProductImage(int id, ProductImageVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ImageId)
            {
                return BadRequest();
            }

            _db.Entry(model).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductImageExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ProductImageVm))]
        public async Task<IHttpActionResult> PostProductImage(ProductImageVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.ProductImage.Add(model);
            await _db.SaveChangesAsync();
            var ret = await _db.ProductImage.Select<ProductImage, ProductImageVm>(ProductImageVm.Select).FirstOrDefaultAsync(x => x.ImageId == model.ImageId);
            return CreatedAtRoute("ShoppingApi", new { id = model.ImageId }, model);
        }

        [ResponseType(typeof(ProductImageVm))]
        public async Task<IHttpActionResult> DeleteProductImage(int id)
        {
            var model = await _db.ProductImage.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _db.ProductImage.Remove(model);
            await _db.SaveChangesAsync();
            var ret = await _db.ProductImage.Select<ProductImage, ProductImageVm>(ProductImageVm.Select).FirstOrDefaultAsync(x => x.ImageId == model.ImageId);
            return Ok(ret);
        }

        private bool ProductImageExists(int id)
        {
            return _db.ProductImage.Count(e => e.ImageId == id) > 0;
        }

        public IQueryable<ProductVm> GetProducts(int pageSize = 10)
        {
            var model = _db.Products.AsQueryable();

            return model.Select(ProductVm.Select).Take(pageSize);
        }

        [ResponseType(typeof(ProductVm))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var model = await _db.Products.Select(ProductVm.Select).FirstOrDefaultAsync(x => x.ProductId == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutProduct(int id, ProductVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ProductId)
            {
                return BadRequest();
            }

            _db.Entry(model).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ProductVm))]
        public async Task<IHttpActionResult> PostProduct(ProductVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Products.Add(model);
            await _db.SaveChangesAsync();
            var ret = await _db.Products.Select(ProductVm.Select).FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
            return CreatedAtRoute("ShoppingApi", new { id = model.ProductId }, model);
        }

        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            var model = await _db.Products.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _db.Products.Remove(model);
            await _db.SaveChangesAsync();
            var ret = await _db.Products.Select(ProductVm.Select).FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
            return Ok(ret);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return _db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}
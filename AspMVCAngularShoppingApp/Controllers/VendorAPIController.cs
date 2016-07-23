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
    public class VendorController : ApiController
    {
        private readonly ShoppingAppDbContext _db = new ShoppingAppDbContext();

        public IQueryable<VendorVm> GetVendors(int pageSize = 10)
        {
            var model = _db.Vendors.AsQueryable();

            return model.Select(VendorVm.Select).Take(pageSize);
        }

        [ResponseType(typeof(Vendor))]
        public async Task<IHttpActionResult> GetVendor(int id)
        {
            var model = await _db.Vendors.Select(VendorVm.Select).FirstOrDefaultAsync(x => x.VendorId == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutVendor(int id, VendorVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.VendorId)
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
                if (!VendorExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Vendor))]
        public async Task<IHttpActionResult> PostVendor(VendorVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Vendors.Add(model);
            await _db.SaveChangesAsync();
            var ret = await _db.Vendors.Select(VendorVm.Select).FirstOrDefaultAsync(x => x.VendorId == model.VendorId);
            return CreatedAtRoute("DefaultApi", new { id = model.VendorId }, model);
        }

        [ResponseType(typeof(Vendor))]
        public async Task<IHttpActionResult> DeleteVendor(int id)
        {
            var model = await _db.Vendors.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _db.Vendors.Remove(model);
            await _db.SaveChangesAsync();
            var ret = await _db.Vendors.Select(VendorVm.Select).FirstOrDefaultAsync(x => x.VendorId == model.VendorId);
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

        private bool VendorExists(int id)
        {
            return _db.Vendors.Count(e => e.VendorId == id) > 0;
        }
    }
}
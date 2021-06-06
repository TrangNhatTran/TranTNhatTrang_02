using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using TranTNhatTrang_02.Models;

namespace TranTNhatTrang_02.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using TranTNhatTrang_02.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<SanPham>("SanPhams");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SanPhamsController : ODataController
    {
        private LTQLDb db = new LTQLDb();

        // GET: odata/SanPhams
        [EnableQuery]
        public IQueryable<SanPham> GetSanPhams()
        {
            return db.SanPhams;
        }

        // GET: odata/SanPhams(5)
        [EnableQuery]
        public SingleResult<SanPham> GetSanPham([FromODataUri] int key)
        {
            return SingleResult.Create(db.SanPhams.Where(sanPham => sanPham.MaSanPham == key));
        }

        // PUT: odata/SanPhams(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<SanPham> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SanPham sanPham = db.SanPhams.Find(key);
            if (sanPham == null)
            {
                return NotFound();
            }

            patch.Put(sanPham);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(sanPham);
        }

        // POST: odata/SanPhams
        public IHttpActionResult Post(SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SanPhams.Add(sanPham);
            db.SaveChanges();

            return Created(sanPham);
        }

        // PATCH: odata/SanPhams(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<SanPham> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SanPham sanPham = db.SanPhams.Find(key);
            if (sanPham == null)
            {
                return NotFound();
            }

            patch.Patch(sanPham);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(sanPham);
        }

        // DELETE: odata/SanPhams(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            SanPham sanPham = db.SanPhams.Find(key);
            if (sanPham == null)
            {
                return NotFound();
            }

            db.SanPhams.Remove(sanPham);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanPhamExists(int key)
        {
            return db.SanPhams.Count(e => e.MaSanPham == key) > 0;
        }
    }
}

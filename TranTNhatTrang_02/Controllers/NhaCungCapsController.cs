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
    builder.EntitySet<NhaCungCap>("NhaCungCaps");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class NhaCungCapsController : ODataController
    {
        private LTQLDb db = new LTQLDb();

        // GET: odata/NhaCungCaps
        [EnableQuery]
        public IQueryable<NhaCungCap> GetNhaCungCaps()
        {
            return db.NhaCungCaps;
        }

        // GET: odata/NhaCungCaps(5)
        [EnableQuery]
        public SingleResult<NhaCungCap> GetNhaCungCap([FromODataUri] int key)
        {
            return SingleResult.Create(db.NhaCungCaps.Where(nhaCungCap => nhaCungCap.MaNhaCungCap == key));
        }

        // PUT: odata/NhaCungCaps(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<NhaCungCap> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(key);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            patch.Put(nhaCungCap);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaCungCapExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(nhaCungCap);
        }

        // POST: odata/NhaCungCaps
        public IHttpActionResult Post(NhaCungCap nhaCungCap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhaCungCaps.Add(nhaCungCap);
            db.SaveChanges();

            return Created(nhaCungCap);
        }

        // PATCH: odata/NhaCungCaps(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<NhaCungCap> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(key);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            patch.Patch(nhaCungCap);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaCungCapExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(nhaCungCap);
        }

        // DELETE: odata/NhaCungCaps(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            NhaCungCap nhaCungCap = db.NhaCungCaps.Find(key);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            db.NhaCungCaps.Remove(nhaCungCap);
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

        private bool NhaCungCapExists(int key)
        {
            return db.NhaCungCaps.Count(e => e.MaNhaCungCap == key) > 0;
        }
    }
}

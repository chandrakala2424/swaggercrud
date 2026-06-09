using System.Linq;
using System.Web.Http;
using SwaggerCRUD.Models;

namespace SwaggerCRUD.Controllers
{
    //[Authorize]
    public class ProductsController : ApiController
    {
        AppDbContext db = new AppDbContext();

        public IHttpActionResult Get()
        {
            return Ok(db.Products.ToList());
        }

        public IHttpActionResult Post(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();

            return Ok("Product Added");
        }

        public IHttpActionResult Put(int id, Product p)
        {
            var data = db.Products.Find(id);

            if (data == null)
                return NotFound();
                                                    
            data.Name = p.Name;
            data.Price = p.Price;

            db.SaveChanges();

            return Ok("Updated");
        }

        public IHttpActionResult Delete(int id)
        {
            var data = db.Products.Find(id);

            if (data == null)
                return NotFound();

            db.Products.Remove(data);
            db.SaveChanges();

            return Ok("Deleted");
        }
    }
}
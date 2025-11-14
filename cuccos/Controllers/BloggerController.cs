using cuccos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cuccos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Blogger> GetAllRecord()
        {
            using (var context = new BlogDbContext())
            {
                var bloggers = context.Bloggers.ToList();

                if (bloggers != null)
                {
                    return Ok(bloggers);
                }

                return BadRequest(new { message = "Sikertelen lekérdezés." });
            }

        }

        [HttpPost]
        public ActionResult<Blogger> AddNewRecord(Blogger blogger)
        {
            using (var context = new BlogDbContext())
            {
                var newBlogger = new Blogger()
                {
                    name = blogger.name,
                    email = blogger.email,
                    regtime = blogger.regtime,
                    modtime = blogger.modtime
                };

                if (newBlogger != null)
                {
                    context.Bloggers.Add(newBlogger);
                    context.SaveChanges();
                    return StatusCode(201, newBlogger);
                }

                return BadRequest(new { message = "Sikertelen feltöltés." });
            }
        }

        [HttpGet("byId")]
        public ActionResult<Blogger> GetRecordById(int id)
        {
            using (var context = new BlogDbContext())
            {
                var blogger = context.Bloggers.FirstOrDefault(blogger => blogger.id == id);

                if (blogger != null)
                {
                    return Ok(new { message = "Sikeres lekérdezés", result = blogger });
                }

                return NotFound(new { meassage = "Nincs ilyen id!" });
            }

        }

        [HttpDelete]
        public ActionResult DeleteRecord(int id)
        {
            using (var context = new BlogDbContext())
            {
                var blogger = context.Bloggers.FirstOrDefault(blogger => blogger.id == id);

                if (blogger != null)
                {
                    context.Bloggers.Remove(blogger);
                    context.SaveChanges();
                    return Ok(new { message = "Sikeres törlés." });
                }

                return NotFound(new { meassage = "Nincs mit törölni!" });
            }
        }

        [HttpPut]
        public ActionResult PutRecord(int id, UpdateBloggerDto updateBloggerDto)
        {
            using (var context = new BlogDbContext())
            {
                var exitstingBlogger = context.Bloggers.FirstOrDefault(blogger => blogger.id == id);

                if (exitstingBlogger != null)
                {
                    exitstingBlogger.name = updateBloggerDto.name;
                    exitstingBlogger.email = updateBloggerDto.email;

                    context.Bloggers.Update(exitstingBlogger);
                    context.SaveChanges();

                    return Ok(new { message = "Sikeres frisítés." });
                }

                return NotFound(new { meassage = "Nincs mit frissíteni!" });
            }
        }

        [HttpGet("count")]
        public ActionResult<int> GetBloggerCount()
        {
            using (var context = new BlogDbContext())
            {
                int bloggerCount = context.Bloggers.Count();
                return Ok(bloggerCount);
            }
        }
        [HttpGet("NevEsEmail")]
        public ActionResult<IEnumerable<GetNameEmail>> GetNevEmail()
        {
            using (var context = new BlogDbContext())
            {
                var nevekEsEmailek = context.Bloggers.Select(b => new GetNameEmail{name = b.name, email = b.email}).ToList();

                if (nevekEsEmailek != null)
                {
                    return Ok(nevekEsEmailek);
                }

                return BadRequest(new { message = "Sikertelen a bloggerek neveinek lekérdezése." });
            }
        }
    }
}

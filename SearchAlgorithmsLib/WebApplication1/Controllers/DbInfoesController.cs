using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DbInfoesController : ApiController
    {
        private dataContext db = new dataContext();

        // GET: api/DbInfoes
        public IQueryable<DbInfo> GetDbInfoes()
        {
            DbSet<DbInfo> check = db.DbInfoes;
            System.Diagnostics.Debug.WriteLine(check.First().Username);
            return db.DbInfoes;
        }

        // GET: api/DbInfoes/5
        /*   [ResponseType(typeof(DbInfo))]
           public async Task<IHttpActionResult> GetDbInfo(int id)
           {
               DbInfo dbInfo = await db.DbInfoes.FindAsync(id);
               if (dbInfo == null)
               {
                   return NotFound();
               }

               return Ok(dbInfo);
           }*/

        // GET: api/DbInfoes/5
        //get info according name and password
        [ResponseType(typeof(DbInfo))]
        public async Task<IHttpActionResult> GetDbInfo(string name,int password)
        {
            DbInfo dbInfo = await db.DbInfoes.FindAsync(name,password);
            if (dbInfo == null)
            {
                return NotFound();
            }

            return Ok(dbInfo);
        }

        // PUT: api/DbInfoes/5
      /*  [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDbInfo(int id, DbInfo dbInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dbInfo.Password)
            {
                return BadRequest();
            }

            db.Entry(dbInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/

        // POST: api/DbInfoes
        [ResponseType(typeof(DbInfo))]
        public async Task<IHttpActionResult> PostDbInfo(DbInfo dbInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DbInfoes.Add(dbInfo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DbInfoExists(dbInfo.Password))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dbInfo.Username,dbInfo.Password }, dbInfo);
        }

        // POST: api/DbInfoes
        [ResponseType(typeof(DbInfo))]
        public async Task<IHttpActionResult> UpdateWinsAndLose(string name, int password,int action)
        {
            DbInfo dbInfo = await db.DbInfoes.FindAsync(name, password);
            if (dbInfo == null)
            {
                return NotFound();
            }
           // Delete(name, password);
            if (action > 0)
            {
                dbInfo.Wins++;
            }
            else
            {
                dbInfo.Losses++;
            }
            db.DbInfoes.AddOrUpdate(
    new Models.DbInfo { Username = "dan", Password = 123, Email = "inb@gmail.com", Losses = 1, Wins = 2 });
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dbInfo.Username, dbInfo.Password }, dbInfo);
        }

        private void Delete(string name, int password)
        {
            DbInfo dbInfo =db.DbInfoes.Find(name, password);
            db.DbInfoes.Remove(dbInfo);
            db.SaveChangesAsync();
        }

     /*   // DELETE: api/DbInfoes/5
        [ResponseType(typeof(DbInfo))]
           public async Task<IHttpActionResult> DeleteDbInfo(string name, int password)
           {
               DbInfo dbInfo = await db.DbInfoes.FindAsync(name,password);
               if (dbInfo == null)
               {
                   return NotFound();
               }

               db.DbInfoes.Remove(dbInfo);
               await db.SaveChangesAsync();

               return Ok(dbInfo);
           }

           protected override void Dispose(bool disposing)
           {
               if (disposing)
               {
                   db.Dispose();
               }
               base.Dispose(disposing);
           }*/

        private bool DbInfoExists(int id)
        {
            return db.DbInfoes.Count(e => e.Password == id) > 0;
        }
    }
}
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
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Controllers
{
    public class DbInfoesController : ApiController
    {
        private dataContext db = new dataContext();

        // GET: api/DbInfoes
        //get info according name and password
        [ResponseType(typeof(DbInfo))]
        public IHttpActionResult GetLogin(string name, string password)
        {
            System.Diagnostics.Debug.WriteLine(name);
            string ComputePassword = ComputeHash(password);

            DbInfo dbInfo = db.DbInfoes.Find(name, ComputePassword);
            if (dbInfo == null)
            {
                return NotFound();
            }

            return Ok(dbInfo);
        }

        // GET: api/DbInfoes
        //get the db list of all players
        public IQueryable<DbInfo> GetDbInfoes()
        {
            DbSet<DbInfo> check = db.DbInfoes;
            System.Diagnostics.Debug.WriteLine("wrong get" + check.First().Username);
            return db.DbInfoes;
        }

        // POST: api/DbInfoes
        //get new player and insert it to the db
        [ResponseType(typeof(DbInfo))]
        public async Task<IHttpActionResult> PostDbInfo(DbInfo dbInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string ComputePassword = ComputeHash(dbInfo.Password);
            dbInfo.Password = ComputePassword;
            db.DbInfoes.Add(dbInfo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = dbInfo.Username,dbInfo.Password }, dbInfo);
        }

        // POST: api/DbInfoes
        //update the lost and win points
        [ResponseType(typeof(DbInfo))]
        public async Task<IHttpActionResult> PostUpdateWinsAndLose(string name, string password,int action)
        {
            string ComputePassword = ComputeHash(password);
            DbInfo dbInfo = await db.DbInfoes.FindAsync(name, ComputePassword);
            if (dbInfo == null)
            {
                return NotFound();
            }
            if (action > 0)
            {
                dbInfo.Wins++;
            }
            else
            {
                dbInfo.Losses++;
            }
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dbInfo.Username, dbInfo.Password }, dbInfo);
        }
        //delete player
        private void Delete(string name, int password)
        {
            DbInfo dbInfo =db.DbInfoes.Find(name, password);
            db.DbInfoes.Remove(dbInfo);
            db.SaveChangesAsync();
        }
        //hash punction
        string ComputeHash(string input)
        {
            SHA1 sha = SHA1.Create();
            byte[] buffer = Encoding.ASCII.GetBytes(input);
            byte[] hash = sha.ComputeHash(buffer);
            string hash64 = Convert.ToBase64String(hash);
            return hash64;
        }
    }
}
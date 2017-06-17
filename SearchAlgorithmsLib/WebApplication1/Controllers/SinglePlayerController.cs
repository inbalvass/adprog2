using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class SinglePlayerController : ApiController
    {
        public SinglePlayerModel spm;

        public SinglePlayerController()
        {
        }

        public IHttpActionResult GetSinglePlayer(string name,int rows,int cols)
        {
            spm = new SinglePlayerModel(name,rows,cols);
            return Ok(spm);
        }
    }
}

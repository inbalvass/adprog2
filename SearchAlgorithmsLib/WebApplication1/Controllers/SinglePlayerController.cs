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
        //public string Name = "k";
        public SinglePlayerModel spm;

        public SinglePlayerController()
        {
           spm = new SinglePlayerModel("k");
        }

        public SinglePlayerModel GetName()
        {
            return spm;
        }

        public IHttpActionResult GetSinglePlayer(string name)
        {
            SinglePlayerModel spmn = new SinglePlayerModel(name);
            return Ok(spmn);
        }
    }
}

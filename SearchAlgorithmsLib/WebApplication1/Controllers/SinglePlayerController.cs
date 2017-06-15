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
            spm= new SinglePlayerModel("h", 1, 2);
        }

        public SinglePlayerModel GetName()
        {
            return spm;
        }

        public IHttpActionResult GetSinglePlayer(string name)
        {
            SinglePlayerModel spmn = new SinglePlayerModel(name, 1,2);
            return Ok(spmn);
        }

        public IHttpActionResult GetSinglePlayer(string name,int rows,int cols)
        {
            SinglePlayerModel spmn = new SinglePlayerModel(name,rows,cols);
            return Ok(spmn);
        }
    }
}

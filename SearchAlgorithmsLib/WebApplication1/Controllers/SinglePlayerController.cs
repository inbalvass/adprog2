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
        public SinglePlayerModel spm = new SinglePlayerModel();

        public IHttpActionResult GetMaze(string name,int rows,int cols)
        {
            string mazeStr = spm.GetMazeStr(name, rows, cols);
            return Ok(mazeStr);
        }

        public IHttpActionResult GetSolution(string name, string algo)
        {
            int algoNum = 0;
            if (algo == "DFS")
                algoNum = 1;

            
            string solution = spm.GetSolution(name, algoNum);
            //string solution = "232323232111";
            return Ok(solution);
        }
    }
}

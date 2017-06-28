using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
    /// <summary>
    /// a controller for the single player
    /// </summary>
    public class SinglePlayerController : ApiController
    {
        /// <summary>
        /// single player model, containing the data
        /// </summary>
        public SinglePlayerModel spm = new SinglePlayerModel();

        /// <summary>
        /// get maze request. returns the maze string (010111...)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public IHttpActionResult GetMaze(string name,int rows,int cols)
        {
            string mazeStr = spm.GetMazeStr(name, rows, cols);
            return Ok(mazeStr);
        }

        /// <summary>
        /// get the solution of the maze (12321...)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="algo"></param>
        /// <returns></returns>
        public IHttpActionResult GetSolution(string name, string algo)
        {
            //mapping the algorithm string to the number
            int algoNum = 0;
            if (algo == "DFS")
                algoNum = 1;
            //asking for solution
            string solution = spm.GetSolution(name, algoNum);
            return Ok(solution);
        }
    }
}

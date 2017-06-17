using MazeGeneratorLib;
using MazeLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Models
{
    public class SinglePlayerModel
    {
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public SinglePlayerModel(string name, int rows, int cols)
        {
            this.Name = name;
            this.Rows = rows;
            this.Cols = cols;
        }

        public string GetSinglePlayers()
        {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            Maze maze = mazeGenerate.Generate(Rows, Cols);
            maze.Name = Name;
            string mazeStr = maze.ToJSON();
            return mazeStr;
        }
    }
}
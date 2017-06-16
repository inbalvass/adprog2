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
        //public Maze MyMaze { get; set; }
       //  public string MazeJSON { get; set; }
        public string MazeStr { get; set; }

        public SinglePlayerModel(string name,int rows,int cols)
        {
            Name = name;
            Rows = rows;
            Cols = cols;
            //       DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            //        Maze maze = mazeGenerate.Generate(rows, cols);
            Maze maze = new Maze(rows, cols);
            maze.Name = name;
            //   maze[3, 3] = CellType.Free;

            //string MazeJSON = maze.ToJSON();
            //dynamic data = JsonConvert.DeserializeObject(MazeJSON);
            ////data["Maze"]
            //MazeStr = data["Maze"];
            JObject jmaze = JObject.Parse(maze.ToJSON());
            MazeStr = jmaze.GetValue("Maze").ToString();
            
        }
    }
}
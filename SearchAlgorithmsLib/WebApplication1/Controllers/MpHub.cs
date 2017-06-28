using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebApplication1.Models;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace WebApplication1
{
    [HubName("mpHub")]
    public class MpHub : Hub
    {
        //the model that saves the data
        private MpModel model = new MpModel();
       
        /// <summary>
        ///start the game function that add the player and maze to the dictionaries.
        /// </summary>
        /// <param name="mazeName"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public void StartGame(string mazeName, int rows, int cols)
        {
            List<string> ids = new List<string>();
            ids.Add(Context.ConnectionId);
            MpModel.MazeNamesToPlayers.Add(mazeName, ids);
            Maze maze = model.CreateMaze(mazeName, rows, cols);
            Clients.Client(Context.ConnectionId).message("waiting");
        }

        /// <summary>
        /// joining an existing game
        /// </summary>
        /// <param name="mazeName"></param>
        public void JoinGame(string mazeName)
        {
            MpModel.MazeNamesToPlayers[mazeName].Add(Context.ConnectionId);

            //notify clients for starting the game and sending the maze json
            Clients.Client(MpModel.MazeNamesToPlayers[mazeName][0]).message("startPlay");
            Clients.Client(MpModel.MazeNamesToPlayers[mazeName][1]).message("startPlay");

            Maze maze = MpModel.NamesToMazes[mazeName];
            Clients.Client(MpModel.MazeNamesToPlayers[mazeName][0]).drawMazes(maze.ToJSON());
            Clients.Client(MpModel.MazeNamesToPlayers[mazeName][1]).drawMazes(maze.ToJSON());
        }

        /// <summary>
        /// send the list of mazes names available, to present to the user.
        /// </summary>
        public void GetMazesList()
        {
            //add to the list only the games with less than 2 players
            List<string> availableGames = new List<string>();
            foreach(string name in MpModel.MazeNamesToPlayers.Keys)
            {
                if (MpModel.MazeNamesToPlayers[name].Count < 2)
                    availableGames.Add(name);
            }
            Clients.Client(Context.ConnectionId).getMazesList(availableGames);
        }
        /// <summary>
        /// broadcast the two players the move
        /// </summary>
        public void Move(string mazeName, string move)
        {
            Clients.Client(MpModel.MazeNamesToPlayers[mazeName][0]).message(move);
            Clients.Client(MpModel.MazeNamesToPlayers[mazeName][1]).message(move);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

namespace server
{
    /// <summary>
    /// this interface defines a model for the MVC pattern.
    /// </summary>
    interface IModel
    {
        /// <summary>
        /// this function generates a maze for single player
        /// </summary>
        /// <param name="name"> the maze name</param>
        /// <param name="rows">the number of rows</param>
        /// <param name="cols"> the number of colomns</param>
        /// <returns></returns>
        Maze GenerateMaze(string name, int rows, int cols);
        /// <summary>
        /// 
        /// this function solves the maze for a single player.
        /// </summary>
        /// <param name="name">the name of the maze to solve</param>
        /// <param name="algorithm">the algorithm to solve the maze with</param>
        /// <returns></returns>
        String SolveMazeCommand(string name, int algorithm);
        /// <summary>
        /// this function starts a MultiPlayer game.
        /// </summary>
        /// <param name="name">name of the game</param>
        /// <param name="rows">rows in the maze</param>
        /// <param name="cols">columns in the maze</param>
        /// <param name="game">the game</param>
        /// <returns></returns>
        string StartMazeCommand(string name, int rows, int cols, IMultiGame game);
        /// <summary>
        /// this function lists all the possible games to join to.
        /// </summary>
        /// <returns></returns>
        string ListCommand();
        /// <summary>
        /// this function join a player to an existing game.
        /// </summary>
        /// <param name="name">the name of the game.</param>
        /// <returns></returns>
        IMultiGame JoinCommand(string name);
        /// <summary>
        /// this function play a move of a player in a multiplater game.
        /// </summary>
        /// <param name="move">up/down etc..</param>
        /// <returns></returns>
        string PlayCommand(string move);
        /// <summary>
        /// this function close the connection of the client to the server and the game.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IMultiGame CloseCommand(string name);
        Dictionary<string, IMultiGame> GetMultyGames();
    }
}

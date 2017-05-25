using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MazeLib;
using Newtonsoft.Json;

namespace WPF
{
    /// <summary>
    /// this class represents a client.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// TcpClient of the client and his port to contact the server.
        /// </summary>
        private TcpClient client;
        private int port;
        private string PlayCommand;
        private bool changedCommand;

        private string resualt;
        private bool changedresualt;

        /// <summary>
        /// a constructor.
        /// </summary>
        /// <param name="port"> the port to contact the server.</param>
        public Client()
        {
            client = new TcpClient();
            this.port = Properties.Settings.Default.Port;
            PlayCommand = "not a command";
            changedCommand = false;
            this.changedresualt = false;
            resualt= "not a command";

        }

        /// <summary>
        /// set the play command
        /// </summary>
        /// <param name="command">the new command</param>
        public void setPlayCommand(string command)
        {
            this.PlayCommand = command;
            this.changedCommand = true;
        }

        /// <summary>
        /// function for the single orders-generate,solve,list
        /// </summary>
        /// <param name="commands">the command to send the server</param>
        /// <returns></returns>
        public string StartSingle(string commands)
        {
            string command = commands;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.IP), port);
            client.Connect(ep);
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                // Send data to server
                writer.Write(command);
                string result = reader.ReadString();
                //close the connection
                Stop();
                return result;
            }
        }

        /// <summary>
        /// set the result
        /// </summary>
        /// <param name="res"></param>
        public void setResault(string res)
        {
            this.resualt = res;
            this.changedresualt = true;
        }

        /// <summary>
        /// get the result
        /// </summary>
        /// <returns></returns>
        public string getResault()
        {
            this.changedresualt = false;
            return this.resualt;
        }

        /// <summary>
        /// check if we get new result
        /// </summary>
        /// <returns></returns>
        public bool isResualtChanged()
        {
            return this.changedresualt;
        }

        /// <summary>
        /// get the play command
        /// </summary>
        /// <returns></returns>
        public string getPlayCommand()
        {
            this.changedCommand = false;
            return this.PlayCommand;
        }

        /// <summary>
        /// function for the multy player commands- start, join,play,close
        /// </summary>
        /// <param name="commands">the command to send the server</param>
        public void StartMulty(string commands)
        {
            string command = commands;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.IP), port);
            client.Connect(ep);
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    // Send data to server
                    writer.Write(command);

                    //create the new task for writing to the server
                    Task t = new Task(() =>
                    {
                        while (true)
                        {
                            while (!this.changedCommand)
                            {
                                //wait until a command is send
                                Thread.Sleep(50);
                            }
                            this.changedCommand = false;
                            command = getPlayCommand();
                            writer.Write(command);

                            if (command.StartsWith("close") || command == "b")
                            {
                                //end the task
                                break;
                            }
                        }
                    });

                    while (true)
                    {
                        string result = reader.ReadString();
                        
                        if (result.Contains("close"))
                        {
                            this.setResault("connection is closed");

                            //if i didnt send the close command then need to close the second task
                            if (!command.StartsWith("close"))
                            {
                                command = "b";
                                setPlayCommand("b");
                                this.setResault1("connection is closed");
                            }
                            //so the task end first
                            Thread.Sleep(100);
                            break;
                        }
                        this.setResault1(result);

                        if (command.StartsWith("start") || command.StartsWith("join"))
                        {
                            //change the command to not include start or it keep enetring the if
                            command = "not command";
                            t.Start();
                        }
                    }
                    Stop();
                }
            }).Start();
        }

        /// <summary>
        /// create delegate for the event
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
        /// <summary>
        /// create the event
        /// </summary>
        public event EventHandler<PlayerMovedEventArgs> PlayerMoved;

        /// <summary>
        /// function for set the result and send event about it
        /// </summary>
        /// <param name="res"></param>
        public void setResault1(string res)
        {
            string move;
            Direction direction = Direction.Left;
            if (res == "connection is closed")
            {
                move = "initialize";
            }
            else
            {
                dynamic data = JsonConvert.DeserializeObject(res);
                move = data["Direction"]; 
            }

            if (move == "up") { direction = Direction.Up; }
            else if (move == "down") { direction = Direction.Down; }
            else if (move == "right") { direction = Direction.Right; }
            else if (move == "left") { direction = Direction.Left; }
            else { direction = Direction.Unknown; }

            this.resualt = res;
            this.changedresualt = true;

            PlayerMoved?.Invoke(this, new PlayerMovedEventArgs(direction));
        }

        /// <summary>
        /// close the connection to the server.
        /// </summary>
        public void Stop()
        {
            client.Close();
        }
    }
}

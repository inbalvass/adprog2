using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WPF
{
    /// <summary>
    /// this class represents a client.
    /// </summary>
    class Client
    {
        /// <summary>
        /// TcpClient of the client and his port to contact the server.
        /// </summary>
        private TcpClient client;
        private int port;

        /// <summary>
        /// a constructor.
        /// </summary>
        /// <param name="port"> the port to contact the server.
        /// </param>
        public Client()
        {
            client = new TcpClient();
            this.port = Properties.Settings.Default.Port;
        }

        //for orders: generate,solve,list
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
        /// this function starts the client and establish the connection to the server.
        /// </summary>
        /// <param name="commands">the command to the server.
        /// </param>
        /// 
        //את זה צריך לשנות שיהיה למולטי

            //כדי שהמשחק יתקיים צריך שכל הזמן יהיה קשר. כדי שכל הזמן יהיה קשר צריך שהלולאה הפנימית תתקיים. כדי שהיא
            // תתקיים צריך גם שזה ישאר בפונקציה הזו כל הזמן אבל שגם יהיה אפשר לקבל ממנה כל פעם את המידע שמתקבל.
            // לדעתי יש 2 אפשרויות: 1) להוציא את כל הפונקציה החוצה ולשים אותה איפה שהמולטי גיים יהיה.
            //2) להוסיף פונציה סט שבה כל הזמן נעדכן את המידע שהוחזר כרגע ואז נקרא משם כל הזמן במולטי גיים בלולאה.
            //אבל זה יצור ביזי ווטינג. מצד שני הפתרון הראשון לא משהו כי זה יכנס במקום לא קשור בקוד.
            //נעשה 2 פונקציות סט- אחת לפקודה שרוצים להכניס והשנייה לתוצאה שהתקבלה. 
            //ואז פה נעשה לולאה של מתי לקרוא ובמולטי גיים נעשה לולאה של מתי לקרוא את הפתרון.
            //דרך נוספתת זה אולי לעשות ליסנר לשניהם?
        public void StartMulty(string commands)
        {
            string command = commands;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            client.Connect(ep);
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {             
                    while (true)
                {
                    // Send data to server
                    writer.Write(command);
                    // Get result from server. if this is a play or close command so don't wait for answer
                    if (!command.StartsWith("play") && !command.StartsWith("close"))
                    {
                        string result = reader.ReadString();
                        if (command != "b")
                        {
                            Console.WriteLine(result);
                        }
                    }

                    if (command.StartsWith("start") || command.StartsWith("join"))
                    {
                        new Task(() =>
                        {
                            while (true)
                            {
                                string result = reader.ReadString();
                                Console.WriteLine(result);

                                if (result.Contains("close"))
                                {
                                    // after the other client closed the connection this client still
                                    //has to react with some flag of closing.
                                    Console.WriteLine("connection closed. type b to continue");
                                    break;
                                }
                            }
                        }).Start();
                    }
                    if (command.StartsWith("close") || command == "b")

                    {
                        //so the task closed first
                        Thread.Sleep(100);
                        Console.WriteLine("client close");
                        //close the connection
                        Stop();
                        break;
                    }
                    //את זה צריך לשנות שלא יקרא מהקונסול אלא שיקבל את המידע כאשר שולחם לו
                    Console.WriteLine("write your command");
                    command = Console.ReadLine();
                }
            }
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

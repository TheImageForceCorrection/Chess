using System.Reflection;
using System.Threading;
using Chess.Utilities.JsonSerialization;
using Chess.Networking.BaseConnection.ConnectionInterface;
using Chess.Game.GameInterface;

namespace Chess.Networking.GameConnection
{
    public sealed class Server
    {
        public IGame Game { get; set; }
        private readonly IConnection connection;
        private Thread readingThread;

        public bool IsServerRunning { get; private set; }

        public Server(IConnection connection)
        {
            this.connection = connection;
        }

        public void Start()
        {
            IsServerRunning = true;
            readingThread = new Thread(ListeningClientRequests);
            readingThread.Start();
        }

        public void Stop()
        {
            IsServerRunning = false;
        }

        public void CloseConnection()
        {
            IsServerRunning = false;
            readingThread.Join();
        }
        public void ListeningClientRequests()
        {
            int attemptsCounter = 0;
            while (IsServerRunning)
            {
                string request;
                if ((request = connection.Read()) != "")
                {
                    attemptsCounter = 0;
                    connection.Write(ProcessRequest(request));
                }
                else if (attemptsCounter >= 30)
                    Game.Disconnect();
                else
                {
                    attemptsCounter++;
                    Thread.Sleep(50);
                }
            }
            connection.Close();
        }

        public string ProcessRequest(string request)
        {
            var jsonRequest = JsonRequest.Parse(request);
            object response = InvokeMethod(jsonRequest.MethodName, jsonRequest.DeserializedArgs);
            return JsonResponse.SerializeResponse(response);
        }

        public object InvokeMethod(string methodName, object[] args)
        {
            if (methodName == "GameAndServerState")
            {
                var gameAndServerState = Game.GetType().InvokeMember(methodName,
                    BindingFlags.InvokeMethod | BindingFlags.GetProperty, null, Game, args)
                        as GameAndServerState;
                return gameAndServerState;
            }

            return Game.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.GetProperty, null, Game, args);
        }
    }
}
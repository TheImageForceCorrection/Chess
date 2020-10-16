using System.Threading;
using Chess.Networking.BaseConnection.ConnectionInterface;
using Chess.Utilities.JsonSerialization;

namespace Chess.Networking.GameConnection
{
    public sealed class Client
    {
        private readonly IConnection connection;
        private readonly object connectionLock;

        public Client(IConnection connection)
        {
            this.connection = connection;
            connectionLock = new object();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void InvokeMethod(string methodName, object[] args)
        {
            lock (connectionLock)
            {
                SendRequest(JsonRequest.FormInvokationRequest(methodName, args));
                WaitingForResponse();
            }
        }

        public ReturnType InvokeMethod<ReturnType>(string methodName, object[] args)
        {
            string response;
            lock (connectionLock)
            {
                SendRequest(JsonRequest.FormInvokationRequest(methodName, args));
                response = WaitingForResponse();
            }
            return JsonResponse.DeserializeResponse<ReturnType>(response);
        }

        public void SendRequest(string request)
        {
            connection.Write(request);
        }

        public string WaitingForResponse()
        {
            string response;

            for (int i = 0; i < 30; i++)
            {
                if ((response = connection.Read()) != "")
                {
                    return response;
                }
                else
                    Thread.Sleep(50);
            }

            throw new ConnectionException("Fail to get response");
        }

    }

}

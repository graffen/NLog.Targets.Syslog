// Licensed under the BSD license
// See the LICENSE file in the project root for more information

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace FakeSyslogServer
{
    internal abstract class StateObject
    {
        private const int BufferSize = 65535;
        private readonly Socket receiveSocket;

        protected MemoryStream Buffer { get; }

        protected StateObject(Socket socket)
        {
            receiveSocket = socket;
            Buffer = new MemoryStream(BufferSize);
        }

        public void BeginReceive(AsyncCallback readCallback)
        {
            receiveSocket.BeginReceive(Buffer.GetBuffer(), (int)Buffer.Length, BufferSize - (int)Buffer.Length, SocketFlags.None, readCallback, this);
        }

        public void EndReceive(IAsyncResult asyncResult, AsyncCallback readCallback, Action<string> receivedStringAction)
        {
            var bytesRead = EndReceive(asyncResult);

            if (bytesRead <= 0)
                return;

            var bufferToString = BufferToString(0, (int)Buffer.Length + bytesRead);
            HandleFirstReceive(Buffer);
            HandleChunks(bufferToString, receivedStringAction);
            BeginReceive(readCallback);
        }

        protected abstract void HandleFirstReceive(MemoryStream ms);

        protected abstract void HandleChunks(string receivedString, Action<string> receivedStringAction);

        private string BufferToString(int position, int bytesRead)
        {
            return Encoding.UTF8.GetString(Buffer.GetBuffer(), position, bytesRead);
        }

        private int EndReceive(IAsyncResult asyncResult)
        {
            return receiveSocket.EndReceive(asyncResult);
        }

        public void Dispose()
        {
            receiveSocket.Dispose();
        }
    }
}
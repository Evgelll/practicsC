using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace CRM.Services
{
    public class OrderNotificationServer
    {
        private const string PipeName = "CRMOrderPipe";

        public async Task StartSendingOrderNotificationsAsync(string orderMessage)
        {
            using (var pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.Out))
            {
                await pipeServer.WaitForConnectionAsync();
                using (var writer = new StreamWriter(pipeServer) { AutoFlush = true })
                {
                    await writer.WriteLineAsync(orderMessage);
                }
            }
        }
    }
}
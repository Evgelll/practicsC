using System;
using System.IO; // Для StreamWriter
using System.IO.Pipes;
using System.Threading.Tasks;

namespace CRMOrderServer
{
    class Program
    {
        private const string PipeName = "CRMOrderPipe"; // То же имя, что в CRMViewModel

        static async Task Main(string[] args)
        {
            Console.WriteLine("Запуск сервера Named Pipes...");
            await StartSendingOrderNotificationsAsync("Новый заказ #3 на сумму 3000");
            Console.WriteLine("Уведомление отправлено. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }

        public static async Task StartSendingOrderNotificationsAsync(string orderMessage)
        {
            using (var pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.Out))
            {
                Console.WriteLine("Ожидание подключения клиента...");
                await pipeServer.WaitForConnectionAsync();
                using (var writer = new StreamWriter(pipeServer) { AutoFlush = true })
                {
                    await writer.WriteLineAsync(orderMessage);
                }
            }
        }
    }
}
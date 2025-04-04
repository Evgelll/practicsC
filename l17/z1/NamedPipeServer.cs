using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

public class NamedPipeServer
{
    private const string PipeName = "NewRequestsPipe";

    public async Task SendMessageAsync(string message)
    {
        using (var pipe = new NamedPipeServerStream(PipeName, PipeDirection.Out))
        {
            await pipe.WaitForConnectionAsync();
            var bytes = Encoding.UTF8.GetBytes(message);
            await pipe.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
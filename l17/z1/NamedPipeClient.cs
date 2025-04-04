using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

public class NamedPipeClient
{
    private const string PipeName = "NewRequestsPipe";

    public async Task<string> ReadMessageAsync()
    {
        using (var pipe = new NamedPipeClientStream(".", PipeName, PipeDirection.In))
        {
            await pipe.ConnectAsync();
            var buffer = new byte[256];
            var bytesRead = await pipe.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }
    }
}
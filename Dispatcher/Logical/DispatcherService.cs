using Microsoft.AspNetCore.Mvc;

namespace Dispatcher.Logical;

public class DispatcherService : IDispatcherService
{
    public async Task<FileResult> ReceiveFileAsync(Guid messageId)
    {
        throw new NotImplementedException();
    }

    public void SendUrl(string url, Guid messageId)
    {
        throw new NotImplementedException();
    }
}
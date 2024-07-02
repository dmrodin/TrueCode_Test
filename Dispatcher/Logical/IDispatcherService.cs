using Microsoft.AspNetCore.Mvc;

namespace Dispatcher.Logical;

public interface IDispatcherService
{
    public void SendUrl(string url, Guid messageId);
    public Task<FileResult> ReceiveFileAsync(Guid messageId);
}
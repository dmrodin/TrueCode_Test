// Создаем подключение к RabbitMQ
// Настраиваем на прослушивание очереди запросов от Диспетчера
// Получаем сообщение
// Помещаем в очередь ответ 

using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Node;
using Node.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory
{
    HostName = "localhost"          // Вынести в файл настроек
};

var connection = await factory.CreateConnectionAsync();

var chanel = await connection.CreateChannelAsync();

await chanel.QueueDeclareAsync("DispatcherQueue", false, false, false);

var consumer = new EventingBasicConsumer(chanel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    Message message = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(body));
    
    var file = ServiceHelper.SendUrlForHandle(message.Url);
    
    ServiceHelper.SendFileToDispatcher(file, message.Id);
};
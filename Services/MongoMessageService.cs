using ChatApp.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Services
{
    public class MongoMessageService:IMessageService
    {
        private readonly IMongoCollection<Message> _messages;

        public MongoMessageService(IChatAppDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessagesCollectionName);
        }
        public async Task<List<Message>> GetMessages()
        {
            return await _messages.Find(mess => true).ToListAsync();
        }
        public string AddMessage(Message message)
        {
            try
            {
                //message.TimeStamp = DateTime.Now;//Blazor sayfasında alındı
                _messages.InsertOne(message);
            }
            catch (Exception e)
            {
                return "Not Created: " + e.Message;
            }
            return "OK";
        }
    }
}

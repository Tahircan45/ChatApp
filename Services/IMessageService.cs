using ChatApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ChatApp.Services
{
    interface IMessageService
    {
        public  Task<List<Message>> GetMessages();
        public string AddMessage(Message message);
    }
}

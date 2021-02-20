using ChatApp.Data;
using ChatApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Services
{
    public class SqlMessageService:IMessageService
    {
        private ChatDbContext _context;
        public SqlMessageService(ChatDbContext context) {
            _context = context;
        }
        public async Task<List<Message>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }
        public  string AddMessage(Message message) {
            try {
                message.TimeStamp = DateTime.Now;
                _context.Messages.Add(message);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                return  "Not Created: "+e.Message;
            }
            return  "OK";
        }
    }
}

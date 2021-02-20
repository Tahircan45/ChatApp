using ChatApp.Model;
using Microsoft.EntityFrameworkCore;


namespace ChatApp.Data
{
    public class ChatDbContext:DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }
        public DbSet<Message> Messages { get; set; }
    }
}

using System.Data.Entity;

namespace ChatSignalR.Models
{
    public class ChatContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<Message> Messages { get; set; }  
    }
}
using System.Collections.Generic;

namespace ChatSignalR.Models
{
  public interface IChatRepository
  {
     void AddUser(User user);
     void AddMessage(Message mes);
     void AddUserConnectionId(User user,string id);
     User GetbyName(string name);
      User CheckLoginPassword(string login, string password);
     IEnumerable<User> GetAllUsers();
  }
}

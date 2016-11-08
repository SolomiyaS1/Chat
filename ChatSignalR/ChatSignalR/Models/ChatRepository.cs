using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace ChatSignalR.Models
{
    public class ChatRepository : IChatRepository
    {
        public ChatContext Db = new ChatContext();

        public void AddUser(User user)
        {
            if (Db.Users.FirstOrDefault(u => u.Name == user.Name) != null)
            {
                throw new UserException("This login is already taken");
            }

            if (Db.Users.FirstOrDefault(u => u.Email == user.Email) != null)
            {
                throw new UserException("User with this email already exists");
            }
            Db.Users.Add(user);
            Db.SaveChanges();
        }            
        public void AddMessage(Message mes)
        {
            Db.Messages.Add(mes);
            Db.SaveChanges();
        }
        public void AddUserConnectionId(User user, string id)
        {
            User Current = Db.Users.FirstOrDefault(u => u.Id == user.Id);
            Current.ConnectionId = id;
        }

       public User GetbyName(string name)
       {
           return Db.Users.FirstOrDefault(u => u.Name == name);
       }
        public IEnumerable<User> GetAllUsers()
        {
            return Db.Users;
        }

        public User CheckLoginPassword(string login, string password)
        {
            return Db.Users.FirstOrDefault(u => u.Name == login && u.Password == password);         
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatSignalR.Models
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message) { }
    }
}
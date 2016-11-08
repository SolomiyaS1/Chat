using System;
using System.ComponentModel.DataAnnotations;

namespace ChatSignalR.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Message must be from 1 to 250 symbols")]
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
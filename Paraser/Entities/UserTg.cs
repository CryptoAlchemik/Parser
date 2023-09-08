using Paraser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserTg : BaseAudioEntity
    {
        public long ChatId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public bool IsAdmin { get; set; } = false;
        public bool IsKicked { get; set; } = false;

        public bool Notification { get; set; } = true;

        public List<Service> Services { get; set; } = new List<Service>();



    }
}

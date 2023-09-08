using Paraser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service : BaseAudioEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Geo { get; set; }
        public int Rating { get; set; }
        public TypeService ServiceType { get; set; }
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public List<UserTg> Users { get; set; } = new List<UserTg>();
        public decimal Price { get; set; }
    }
}

using Paraser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MessageBot : BaseAudioEntity
    {
        public string MessageName { get; set; }
        public string MessageBody { get; set; }
        public string? MessageImg { get; set; }
    }
}

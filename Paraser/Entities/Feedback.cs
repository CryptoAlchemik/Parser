using Paraser.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback : BaseAudioEntity
    {
        public string UserFeedback { get; set; }
        public long ChatId { get; set; }

        public int? Rating { get; set; }
    }
}

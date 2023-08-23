using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraser.Common
{
    public abstract class BaseAudioEntity : BaseEntity
    {
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}

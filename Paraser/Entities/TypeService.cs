using Paraser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TypeService : BaseAudioEntity
    {
        public string TypeName { get; set; }
        public List<SubType>? SubTypes { get; set; }

    }
}

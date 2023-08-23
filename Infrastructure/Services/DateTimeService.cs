using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class DateTimeService : IGetTime
    {
        public DateTime NowTime => DateTime.UtcNow;
    }
}

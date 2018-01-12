using Practice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Services
{
    public class RealTimeProvider : iTimeProvider
    {
        public DateTime Now { get => DateTime.Now; set => throw new NotImplementedException(); }
    }
}

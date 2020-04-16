using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EweDash.Models
{
    public class NetflixModel
    {
        public String Count { get; set; }

        public List<NetflixObject> Items { get; set; }
    }

    public class NetflixObject
    {
        public String Title { get; set; }
        public String Type { get; set; }
        public String Released { get; set; }

    }
}
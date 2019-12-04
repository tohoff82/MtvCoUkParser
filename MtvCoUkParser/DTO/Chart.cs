using System;
using System.Collections.Generic;
using System.Text;

namespace MtvCoUkParser.DTO
{
    public class Chart
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IDictionary<int, Track> PlayList  {get; set;}
    }
}

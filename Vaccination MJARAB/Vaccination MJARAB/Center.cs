using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_MJARAB
{
    class Center
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public List<string> Vaccines { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int PeriodTime { get; set; }
        public int Capacity { get; set; }
        public int Xcordinate { get; set; }
        public int Ycordinate { get; set; }

        public Center(string name, string province, List<string> vaccines, int start, int end, int periodTime, int capacity, int xcordinate, int ycordinate)
        {
            Name = name;
            Province = province;
            Vaccines = vaccines;
            Start = start;
            End = end;
            PeriodTime = periodTime;
            Capacity = capacity;
            Xcordinate = xcordinate;
            Ycordinate = ycordinate;
        }
        public Center(string name)
        {
            Name = name;
        }
    }
}

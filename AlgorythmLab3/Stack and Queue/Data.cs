using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab3.Stack_and_Queue
{
    public class Data
    {
        public List<double> XValues;
        public List<double> YValues;
        public string Name;
        public Data(List<double> xValues, List<double> yValues, string name)
        {
            XValues = xValues;
            YValues = yValues;
            Name = name;
        }
    }
}

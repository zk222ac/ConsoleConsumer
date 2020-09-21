using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleConsumer
{
    public class AreaRec
    {
        public int Length { get; set; }
        public int Width { get; set; }

        // empty constructor
        public AreaRec()
        {

        }
        // parametric constructor 
        public AreaRec(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Length);
            sb.Append(",");
            sb.Append(Width);
            return sb.ToString();
        }
    }
}

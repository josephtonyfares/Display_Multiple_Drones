using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_TESTC
{
    class Visual_Element
    {
        public int Start_X;
        public int Start_Y;
        public Vis_Element_Type ElementType;


        public enum Vis_Element_Type
        {
            unspecified,
            arc,
            box,
            icon,
            line,
            text
        }
    }
  

    
}

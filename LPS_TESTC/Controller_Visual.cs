using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LPS_TESTC
{
    class Controller_Visual
    {
        public class toGameplan
        {
            public void Draw_Elements_on_Image(Point orign,
                                               SortedDictionary<int, Visual_Element> elements,
                                               ref Image img )
            {
                if (elements is null)
                    return;

                Point current_location = orign;
                bool first = true;
                foreach (var element in elements.Values)
                {
                    element.Start_X = current_location.X;
                    element.Start_Y = current_location.Y;
                    current_location = Draw_on_Image(element,ref img);
                }  
            }


            public Point Draw_on_Image(Visual_Element elem, ref Image img)
            {

                Point endPoint = elem.Origin;

                Graphics g;
                g = Graphics.FromImage(img);

                switch (elem.ElementType)
                {
                    case var @case when @case == Visual_Element.Vis_Element_Type.arc:
                        {
                            draw(elem, g, endPoint);
                            break;
                        }

                    case var case1 when case1 == Vis_Element_Type.box:
                        {
                            Box.Draw(elem, g, endPoint);
                            break;
                        }

                    case var case2 when case2 == Vis_Element_Type.icon:
                        {
                            Icon.Draw(elem, g, endPoint);
                            break;
                        }

                    case var case3 when case3 == Vis_Element_Type.line:
                        {
                            Line.Draw(elem, g, endPoint);
                            break;
                        }

                    case var case4 when case4 == Vis_Element_Type.text:
                        {
                            System.Text.Draw(elem, g, endPoint);
                            break;
                        }
                }

            g.Dispose();
            return endPoint;
            }


        }
    }
}

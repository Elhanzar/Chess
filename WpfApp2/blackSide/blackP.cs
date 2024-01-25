using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp2
{
    public class blackP
    {
        public List<int> x1 = new List<int>();
        public List<int> y1 = new List<int>();
        public void XY(ref List<int> xx, ref List<int> yy)
        {
            xx = x1;
            yy = y1;
        }

        public bool Run1(UIElement uIElement, int x, int y)
        {
            if (Grid.GetColumn(uIElement) == x & Grid.GetRow(uIElement) == y + 1)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                    return true;
                }
            }
            return false;
        }
        public void Run2(UIElement uIElement, int x, int y)
        {
            if (Grid.GetColumn(uIElement) == x & Grid.GetRow(uIElement) == y + 2)
            {
                //MessageBox.Show(uIElement.GetType().ToString());
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
        }
        public void RunRight(UIElement uIElement, int x, int y)
        {
            if (Grid.GetColumn(uIElement) == x - 1 & Grid.GetRow(uIElement) == y + 1)
            {
                if (uIElement.GetType() == typeof(Image))
                {
                    if (!uIElement.IsEnabled)
                    {
                        y1.Add(Grid.GetRow(uIElement));
                        x1.Add(Grid.GetColumn(uIElement));
                    }
                }
            }
        }
        public void RunLeft(UIElement uIElement, int x, int y)
        {
            if (Grid.GetColumn(uIElement) == x + 1 & Grid.GetRow(uIElement) == y + 1)
            {
                if (uIElement.GetType() == typeof(Image))
                {
                    if (!uIElement.IsEnabled)
                    {
                        y1.Add(Grid.GetRow(uIElement));
                        x1.Add(Grid.GetColumn(uIElement));
                    }
                }
            }
        }
    }
}

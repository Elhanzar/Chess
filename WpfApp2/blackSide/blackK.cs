﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp2.blackSide
{
    internal class blackK
    {
        public List<int> x1 = new List<int>();
        public List<int> y1 = new List<int>();
        public void XY(ref List<int> xx, ref List<int> yy)
        {
            xx = x1;
            yy = y1;
        }
        public void Run(UIElement uIElement, int x, int y)
        {
            if (Grid.GetColumn(uIElement) == x && Grid.GetRow(uIElement) == y + 1)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
            if (Grid.GetColumn(uIElement) == x && Grid.GetRow(uIElement) == y - 1)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
            if (Grid.GetColumn(uIElement) == x + 1 && Grid.GetRow(uIElement) == y)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
            if (Grid.GetColumn(uIElement) == x - 1 && Grid.GetRow(uIElement) == y)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
            if (Grid.GetColumn(uIElement) == x - 1 && Grid.GetRow(uIElement) == y - 1)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
            if (Grid.GetColumn(uIElement) == x - 1 && Grid.GetRow(uIElement) == y + 1)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
            if (Grid.GetColumn(uIElement) == x + 1 && Grid.GetRow(uIElement) == y + 1)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
            if (Grid.GetColumn(uIElement) == x + 1 && Grid.GetRow(uIElement) == y - 1)
            {
                if (uIElement.GetType() == typeof(Label))
                {
                    x1.Add(Grid.GetColumn(uIElement));
                    y1.Add(Grid.GetRow(uIElement));
                }
            }
        }
        public void RunKill(UIElement uIElement, int x, int y)
        {
            if (Grid.GetColumn(uIElement) == x && Grid.GetRow(uIElement) == y + 1)
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
            if (Grid.GetColumn(uIElement) == x && Grid.GetRow(uIElement) == y - 1)
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
            if (Grid.GetColumn(uIElement) == x + 1 && Grid.GetRow(uIElement) == y)
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
            if (Grid.GetColumn(uIElement) == x - 1 && Grid.GetRow(uIElement) == y)
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
            if (Grid.GetColumn(uIElement) == x - 1 && Grid.GetRow(uIElement) == y - 1)
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
            if (Grid.GetColumn(uIElement) == x - 1 && Grid.GetRow(uIElement) == y + 1)
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
            if (Grid.GetColumn(uIElement) == x + 1 && Grid.GetRow(uIElement) == y + 1)
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
            if (Grid.GetColumn(uIElement) == x + 1 && Grid.GetRow(uIElement) == y - 1)
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

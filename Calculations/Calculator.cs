using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public double AddDouble(double a, double b) => a + b;
        public List<int> FindNumbers => new List<int> { 1, 1, 2, 3, 5, 8, 13 };

        public bool IsOdd(int value) => value % 2 == 1;
    }
}

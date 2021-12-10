using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Лабараторна_1
{
    class Service
    {
        private int day = 1;
        private double allInfluence = 0;

        async public void InitProgram(Graphics graphics)
        {
            day = 1;
            allInfluence = 0;
            Employee employee = new Employee();
            Point currentPoint = new Point(0, 399);

            do
            {
                await Task.Delay(100);
                double influense = InfomationInfluence.GetInfluence(day);
                employee.GeneralInfluencesStrait += influense;
                allInfluence += influense;
                Point point = GetPoint();
                graphics.DrawLine(Pens.Black, currentPoint, point);
                currentPoint = point;
                day++;
            } 
            while (employee.InfluencesLevel != 4 && day <= 30);
        }

        private Point GetPoint()
        {
            Point point = new Point();
            point.X = 52 * day;
            point.Y = Convert.ToInt32(399 - 2 * allInfluence * 100.0);

            return point;
        }
    }
}

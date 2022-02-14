using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesMoshCourse
{
    public class DemeritPointsCalculator
    {
        private const int SpeedLimit = 60;

        public static int CalculateDemeritPoints(int speed)
        {
            if(speed <= 0)
                throw new ArgumentOutOfRangeException();

            if (speed < SpeedLimit)
                return 0;

            const int KmPerDemeritPoint = 5;
            var demeritPoints = (speed - SpeedLimit) / KmPerDemeritPoint;

            return demeritPoints;
        }
    }
}

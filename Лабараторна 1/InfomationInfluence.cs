using System;

namespace Лабараторна_1
{
    static class InfomationInfluence
    {
        private static double[] BossInfluense = new double[] { 0.6, 0.8 };
        private static int BossInfluenseTimes = 5;

        private static double[] Сoordinator1Influense = new double[] { 0.3, 0.4 };
        private static int Сoordinator1InfluenseTimes = 8;

        private static double[] Сoordinator2Influense = new double[] { 0.2, 0.3 };
        private static int Сoordinator2InfluenseTimes = 10;

        public static double GetInfluence(int day)
        {
            Random random = new Random();
            double strait = 0;

            if (day % 6 == 0)
            {
                strait += random.NextDouble() * (BossInfluense[1] - BossInfluense[0]) + BossInfluense[0];
            }
            if (day % 4 == 0)
            {
                strait += (random.NextDouble() * (Сoordinator1Influense[1] - Сoordinator1Influense[0]) + Сoordinator1Influense[0]) * 0.9;
            }
            if (day % 3 == 0)
            {
                strait += (random.NextDouble() * (Сoordinator2Influense[1] - Сoordinator2Influense[0]) + Сoordinator2Influense[0]) * 0.8;
            }
            return strait;
        }
    }
}

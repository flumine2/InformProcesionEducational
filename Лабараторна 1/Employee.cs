namespace Лабараторна_1
{
    class Employee
    {
        private double generalInfluencesStrait = 0;
        private int influencesLevel = 0;

        public int InfluencesLevel { get => influencesLevel; }

        public double GeneralInfluencesStrait
        {
            get => generalInfluencesStrait;
            set
            {
                EmployeeUpperCheck(value - generalInfluencesStrait);
                generalInfluencesStrait = value + generalInfluencesStrait;
            }
        }

        public void EmployeeUpperCheck(double strait)
        {
            if (influencesLevel == 0)
            {
                UpperCheckLevelZero(strait);
            }
            else if (influencesLevel == 1)
            {
                UpperCheckLevelOne(strait);
            }
            else if (influencesLevel == 2)
            {
                UpperCheckLevelTwo(strait);
            }
            else if (influencesLevel == 3)
            {
                UpperCheckLevelThree(strait);
            }
        }

        private void UpperCheckLevelZero(double strait)
        {
            double possibleStrait = generalInfluencesStrait + strait;
            if (possibleStrait >= 0.3 && possibleStrait < 0.5)
            {
                influencesLevel = 1;
                generalInfluencesStrait -= 0.3;
            }
            else if (possibleStrait >= 0.5 && possibleStrait < 0.8)
            {
                influencesLevel = 2;
                generalInfluencesStrait -= 0.5;
            }
            else if (possibleStrait >= 0.8)
            {
                influencesLevel = 3;
                generalInfluencesStrait -= 0.8;
            }
        }

        private void UpperCheckLevelOne(double strait)
        {
            double possibleStrait = generalInfluencesStrait + strait;
            if (possibleStrait >= 0.2 && possibleStrait < 0.5)
            {
                influencesLevel = 2;
                generalInfluencesStrait -= 0.2;
            }
            else if (possibleStrait >= 0.5 && possibleStrait < 0.7)
            {
                influencesLevel = 3;
                generalInfluencesStrait -= 0.5;
            }
            else if (possibleStrait >= 0.7)
            {
                influencesLevel = 4;
            }
        }

        private void UpperCheckLevelTwo(double strait)
        {
            double possibleStrait = generalInfluencesStrait + strait;
            if (possibleStrait >= 0.4 && possibleStrait < 0.6)
            {
                influencesLevel = 3;
                generalInfluencesStrait -= 0.4;
            }
            else if (possibleStrait >= 0.6)
            {
                influencesLevel = 4;
            }
        }

        private void UpperCheckLevelThree(double strait)
        {
            double possibleStrait = generalInfluencesStrait + strait;
            if (possibleStrait >= 0.1)
            {
                influencesLevel = 4;
            }
        }
    }
}

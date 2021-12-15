using System.Threading.Tasks;

namespace Лабараторна_2
{
    class Service
    {
        private const int waitingTime = 1000;
        private bool streetChangerWorking;
        private bool crossChangerWorking;
        private Value street;
        private Value state;

        public delegate void OnChangeState(Value state);
        public event OnChangeState ChangeState;

        public void StartProgram() => ChangeStreetTimerStart();

        public void StopProgram()
        {
            streetChangerWorking = false;
            crossChangerWorking = false;
        }

        private async void ChangeStreetTimerStart()
        {
            streetChangerWorking = true;
            while (streetChangerWorking)
            {
                ChangeStreet();
                await Task.Delay(waitingTime);
            }
        }

        private void ChangeStreet()
        {
            if (street == Value.A) street = Value.B;
            else street = Value.A;
            state = street;
            ChangeState?.Invoke(state);
        }

        public void AllowCrossOver()
        {
            streetChangerWorking = false;
            CrossOverTimerStart();
        }

        private async void CrossOverTimerStart()
        {
            crossChangerWorking = true;
            while (crossChangerWorking)
            {
                CrossOver();
                await Task.Delay(waitingTime);
            }
        }

        private void CrossOver()
        {
            if (state == Value.C) state = Value.D;
            else if (state == Value.D) state = Value.N;
            else state = Value.C;
            if (state is Value.N)
            {
                crossChangerWorking = false;
                ChangeStreetTimerStart();
            }
            else
            {
                ChangeState?.Invoke(state);
            }
        }
    }
}

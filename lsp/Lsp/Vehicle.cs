namespace Lsp
{
    public abstract class Vehicle
    {
        private bool engineStarted = false;

        public void StartEngine()
        {
            engineStarted = true;
        }

        public bool EngineIsStarted()
        {
            return engineStarted;
        }

        public void StopEngine()
        {
            engineStarted = false;
        }

        public abstract void FillUpWithFuel();

        public abstract void ChargeBattery();


    }
}
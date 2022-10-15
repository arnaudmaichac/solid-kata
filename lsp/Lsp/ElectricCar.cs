namespace Lsp
{
    public class ElectricCar : Vehicle
    {

        private const int BATTERY_FULL = 100;
        private int batteryLevel;

        public override void FillUpWithFuel()
        {
            throw new InvalidOperationException("It's an electric car");
        }

        public override void ChargeBattery()
        {
            batteryLevel = BATTERY_FULL;
        }

        public int BatteryLevel()
        {
            return batteryLevel;
        }
    }
}
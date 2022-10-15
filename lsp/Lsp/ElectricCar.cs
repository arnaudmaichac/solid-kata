namespace Lsp
{
    public class ElectricCar : Vehicle, IElectricityPowered
    {

        private const int BATTERY_FULL = 100;
        private int batteryLevel;

        public void ChargeBattery()
        {
            batteryLevel = BATTERY_FULL;
        }

        public int BatteryLevel()
        {
            return batteryLevel;
        }
    }
}
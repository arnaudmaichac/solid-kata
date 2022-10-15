namespace Lsp
{
    public class PetrolCar : Vehicle
    {
        private const int FUEL_TANK_FULL = 100;
        private int fuelTankLevel = 0;

        public override void FillUpWithFuel()
        {
            this.fuelTankLevel = FUEL_TANK_FULL;
        }

        public override void ChargeBattery()
        {
            throw new InvalidOperationException("A petrol car cannot be recharged");
        }

        public int FuelTankLevel()
        {
            return fuelTankLevel;
        }
    }
}
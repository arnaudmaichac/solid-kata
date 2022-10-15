namespace Lsp
{
    public class PetrolCar : Vehicle, IPetrolPowered
    {
        private const int FUEL_TANK_FULL = 100;
        private int fuelTankLevel = 0;

        public void FillUpWithFuel()
        {
            this.fuelTankLevel = FUEL_TANK_FULL;
        }

        public int FuelTankLevel()
        {
            return fuelTankLevel;
        }
    }
}
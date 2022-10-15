using Xunit;

namespace Lsp.Test
{
    public class FillingStationShould
    {
        private const int FULL = 100;
        private readonly FillingStation fillingStation = new FillingStation();

        [Fact]
        public void Refuel_A_Petrol_Car()
        {
            PetrolCar car = new PetrolCar();

            fillingStation.Refuel(car);

            Assert.Equal(FULL, car.FuelTankLevel());
        }

        [Fact]
        public void Recharge_An_Electric_Car()
        {
            ElectricCar car = new ElectricCar();

            fillingStation.Charge(car);

            Assert.Equal(FULL, car.BatteryLevel());
        }
    }
}
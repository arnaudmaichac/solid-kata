namespace Lsp
{
    public class FillingStation
    {
        public void Refuel(PetrolCar petrolCar)
        {
            petrolCar.FillUpWithFuel();
        }

        public void Charge(ElectricCar electricCar)
        {
            electricCar.ChargeBattery();
        }
    }
}
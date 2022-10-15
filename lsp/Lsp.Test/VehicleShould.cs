using Xunit;

namespace Lsp.Test
{
    public class VehicleShould
    {
        [Fact]
        public void Start_Engine()
        {
            Vehicle vehicle = new TestableVehicle();

            vehicle.StartEngine();

            Assert.True(vehicle.EngineIsStarted());
        }

        [Fact]
        public void Stop_Engine()
        {
            Vehicle vehicle = new TestableVehicle();

            vehicle.StartEngine();
            vehicle.StopEngine();

            Assert.False(vehicle.EngineIsStarted());
        }

        public class TestableVehicle : Vehicle
        {
        }
    }
}
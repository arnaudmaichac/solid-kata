namespace Isp
{
    public class Bird : IRunning, IFlying
    {
        public void Run()
        {
            Console.Write("Bird is running");
        }

        public void Fly()
        {
            Console.Write("Bird is flying");
        }
    }
}
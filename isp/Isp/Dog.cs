namespace Isp
{
    public class Dog : IRunning, IBarking
    {
        public void Run()
        {
            Console.Write("Dog is running");
        }

        public void Bark()
        {
            Console.Write("Dog is barking");
        }
    }
}
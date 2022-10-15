namespace Isp
{
    public class Bird : IAnimal
    {
        public void Bark() { }

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
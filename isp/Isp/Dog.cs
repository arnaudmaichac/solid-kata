namespace Isp
{
    public class Dog : IAnimal
    {
        public void Fly()
        {

        }

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
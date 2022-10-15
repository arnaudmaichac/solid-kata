using Xunit;

namespace Isp.Test
{
    [Collection("Sequential")]
    public class DogShould : IDisposable
    {
        private readonly StringWriter consoleContent;

        private readonly Dog dog = new Dog();

        public DogShould()
        {
            consoleContent = new StringWriter();
            Console.SetOut(consoleContent);
        }

        [Fact]
        public void Run()
        {
            dog.Run();

            Assert.Equal("Dog is running", consoleContent.ToString());
        }

        [Fact]
        public void Bark()
        {
            dog.Bark();

            Assert.Equal("Dog is barking", consoleContent.ToString());
        }

        public void Dispose()
        {
            consoleContent.Dispose();
        }
    }
}
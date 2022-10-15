using Xunit;

namespace Isp.Test
{
    [Collection("Sequential")]
    public class BirdShould : IDisposable
    {
        private readonly StringWriter consoleContent;

        private readonly Bird bird = new Bird();

        public BirdShould()
        {
            consoleContent = new StringWriter();
            Console.SetOut(consoleContent);
        }

        [Fact]
        public void Run()
        {
            bird.Run();

            Assert.Equal("Bird is running", consoleContent.ToString());
        }

        [Fact]
        public void Fly()
        {
            bird.Fly();

            Assert.Equal("Bird is flying", consoleContent.ToString());
        }

        public void Dispose()
        {
            consoleContent.Dispose();
        }
    }
}
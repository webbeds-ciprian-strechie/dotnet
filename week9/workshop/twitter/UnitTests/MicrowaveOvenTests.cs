using _6.Twitter.Interfaces;
using System;
using Moq;
using Xunit;
using _6.Twitter.Models;

namespace UnitTests
{
 
    public class MicrowaveOvenTests
    {
        Mock<IWriter> mockWriter;
        Mock<ITweetRepository> mockRepository;
        Mock<MicrowaveOven> microwaveOven;
        public MicrowaveOvenTests()
        {
            this.mockWriter = new Mock<IWriter>();
            this.mockRepository = new Mock<ITweetRepository>();
        }

        [Fact]
        public void SendTweetToServerShouldCallSaveTweet()
        {
            var myString = "my test";

            MicrowaveOven microwaveOven = new MicrowaveOven(this.mockWriter.Object, this.mockRepository.Object);

            microwaveOven.SendTweetToServer(myString);

            this.mockRepository.Verify(mr => mr.SaveTweet(It.IsAny<string>()), Times.Once);
        }
    }
}

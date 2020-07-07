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

        public MicrowaveOvenTests()
        {
            this.mockWriter = new Mock<IWriter>();
            this.mockRepository = new Mock<ITweetRepository>();
        }

        [Fact]
        public void Test_SendTweetToServerShouldSendTheMessageToItsServer()
        {
            //prepare
            var message = "test";
            this.mockRepository.Setup(o => o.SaveTweet(It.IsAny<string>())).Callback((string mess) => message = mess);
            var classUnderTest = new MicrowaveOven(this.mockWriter.Object, this.mockRepository.Object);
            //act
            classUnderTest.SendTweetToServer("My message!");
            //check
            this.mockRepository.Verify(o => o.SaveTweet("My message!"), Times.Exactly(1));
            Assert.Equal("My message!", message);
        }
        [Fact]
        public void Test_WriteTweetShouldCallItsWriterWithTheTweetsMessage()
        {
            //prepare
            var message = string.Empty;
            this.mockWriter.Setup(o => o.WriteLine(It.IsAny<string>())).Callback((string mess) => message = mess);
            var classUnderTest = new MicrowaveOven(this.mockWriter.Object, this.mockRepository.Object);
            //act
            classUnderTest.WriteTweet("My message!");
            //check
            this.mockWriter.Verify(o => o.WriteLine(It.IsAny<string>()), Times.Exactly(1));
            Assert.Equal("My message!", message);
        }
        [Fact]
        public void WriteTweetShouldCallItsWriterWithTheTweetsMessage()
        {
            // Arrange
            const string Message = "Test";
            this.mockWriter.Setup(w => w.WriteLine(It.IsAny<string>()));
            var tweetRepo = new Mock<ITweetRepository>();
            var microwaveOven = new MicrowaveOven(this.mockWriter.Object, tweetRepo.Object);
            // Act
            microwaveOven.WriteTweet(Message);
            // Assert
            this.mockWriter.Verify(w => w.WriteLine(It.Is<string>(s => s == Message)),
                $"Tweet is not given to the {typeof(MicrowaveOven)}'s writer");
        }
    }
}

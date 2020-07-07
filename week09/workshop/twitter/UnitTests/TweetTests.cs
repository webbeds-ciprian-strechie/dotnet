using _6.Twitter.Interfaces;
using _6.Twitter.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class TweetTests
    {
        [Fact]
        public void Test_ReceiveMessageShouldInvokeItsClientToWriteTheMessage()
        {
            var clientMock = new Mock<IClient>();
            var classUnderTest = new Tweet(clientMock.Object);

            classUnderTest.ReceiveMessage("My message!");

            clientMock.Verify(o => o.WriteTweet("My message!"), Times.Exactly(1));
        }

        [Fact]
        public void Test_ReceiveMessageShouldInvokeItsClientToSendTheMessageToTheServer()
        {
            var clientMock = new Mock<IClient>();
            var classUnderTest = new Tweet(clientMock.Object);

            classUnderTest.ReceiveMessage("My message!");

            clientMock.Verify(o => o.SendTweetToServer("My message!"), Times.Exactly(1));
        }
    }
}

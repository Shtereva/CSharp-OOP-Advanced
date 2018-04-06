using System;
using Moq;
using NUnit.Framework;

public class TwiterTests
{
    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void MessageCannotBeNullOrEmpty(string message)
    {
        Assert.Throws<ArgumentException>(() => new Tweet(message));
    }

    [Test]
    public void SendMessageToSomeServer()
    {
        var messageMock = new Mock<IMessage>();

        messageMock.Setup(x => x.Message)
            .Returns("Hello World");

        var clientMock = new Mock<IReciever>();
        clientMock.Setup(x => x.SendMessage(It.IsAny<IMessage>()))
            .Returns(messageMock.Object.Message);

        string message = clientMock.Object.SendMessage(messageMock.Object);

        messageMock.Verify();
        clientMock.Verify();

        Assert.AreEqual("Hello World", message);
    }
}

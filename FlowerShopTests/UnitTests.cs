using NUnit.Framework;
using FlowerShop;
using NSubstitute;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            //ARRANGE
            Order o = Substitute.For<Order>();
            IOrderDAO iod = Substitute.For<IOrderDAO>();
            IOrder io = Substitute.For<IOrder>();

            //ACT
            o.Deliver();

            //ASSERT
            iod.DidNotReceive().SetDelivered(io);

        }
    }
}
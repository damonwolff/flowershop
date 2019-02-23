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
            IClient c = Substitute.For<IClient>();
            IOrderDAO dao = Substitute.For<IOrderDAO>();
            IOrder io = Substitute.For<IOrder>();
            IOrder o = new Order(dao,c);

            //ACT
            o.Deliver(dao, io);

            //ASSERT
            dao.Received().SetDelivered(io);

        }
    }
}
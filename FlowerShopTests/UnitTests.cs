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

        [Test]
        public void Test2() {

            //ARRANGE
            IClient c = Substitute.For<IClient>();
            IOrderDAO dao = Substitute.For<IOrderDAO>();
            IOrder io = Substitute.For<IOrder>();
            Order o = Substitute.For<Order>(dao, c);
            IFlowerDAO fdao = Substitute.For<IFlowerDAO>();
            Flower f = Substitute.For<Flower>(fdao, "Rose", 100, 1);

            //ACT
            f = new Flower(fdao, "Rose", 100, 1);
            o = new Order(dao, c);
            o.AddFlowers(fdao, f, 1);
           
            //ASSERT
            Assert.AreEqual(120, o.Price);

        }


    }
}
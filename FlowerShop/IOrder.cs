using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public interface IOrder
    {
        void Deliver(IOrderDAO dao, IOrder io);
        double Price { get; }
        double Profit { get; }
        IReadOnlyList<IFlower> Ordered { get; }
        void AddFlowers(IFlowerDAO fdao,Flower flower, int n);
        IClient Client { get; }
    }
}

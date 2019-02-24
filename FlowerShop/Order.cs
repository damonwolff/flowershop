using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<Flower> flowers;
        private bool isDelivered = false;
        public int Id { get; }

        // should apply a 20% mark-up to each flower.
        public double Price {
            get {
                double price = 0;
                foreach(Flower f in flowers) {
                    price = price +f.Cost * 1.2;
                }
                return price;
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            Id = dao.AddOrder(client);
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<Flower>();
            this.isDelivered = isDelivered;
            Client = client;
            Id = dao.AddOrder(client);
            
        }

        public void AddFlowers(IFlowerDAO fdao, Flower flower, int n)
        {
            flower = new Flower(fdao,flower.Description, flower.Cost, flower.Stock);
            flowers = new List<Flower>();
            flowers.Add(flower);
        }

        public void Deliver(IOrderDAO dao, IOrder io)
        {
            dao.SetDelivered(io);
        }
    }
}

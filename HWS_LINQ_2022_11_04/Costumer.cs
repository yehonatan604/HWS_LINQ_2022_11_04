namespace HWS_LINQ_2022_11_04
{
    public class Costumer
    {
        //properties
        public string Name { get; private set; }
        public Agent MyAgent { get; private set; }
        public List<Order> MyOrders { get; private set; }
        public int OrdersAvarage { get; private set; }
        //ctor
        public Costumer(string name, Agent agent)
        {
            Name = name;
            MyAgent = agent;
            MyOrders = new();

            //generate orders & prices
            List<int> MyOrdersPrices = new List<int>();
            for (int i = 0; i < new Random().Next(1,5); i++)
            {
                MyOrders.Add(new Order());
                MyOrdersPrices.Add(MyOrders[i].Price);
            }

            //find the avarge of orders
            OrdersAvarage = (int)MyOrdersPrices.Average();
        }
    }
}

namespace HWS_LINQ_2022_11_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------Exercise 4--------------\n");

            List<int> intsList = new() { 4, 8, 90, 86, 2 };

            List<string> stringIntsList = intsList.Select(x => x.ToString() + ", ").ToList(); //method syntax

            stringIntsList = (from ints in intsList
                              select ints.ToString() + ", ").ToList(); //query syntax

            stringIntsList.ForEach(x => Console.Write(x));

            Console.WriteLine("\n---------------Exercise 5--------------\n");

            List<string> stringsList1 = new()
            {
                "Appotaquille",
                "EpoxiiFoundation",
                "Wiz",
                "Pawa",
                "Wazzapp"
            };

            List<string> stringsList2 = stringsList1.Where(x => x.Length > 4).ToList(); //method syntax

            stringsList2 = (from strings in stringsList1
                            where strings.Length > 4
                            select strings).ToList(); //query syntax

            stringsList2.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\n---------------Exercise 6--------------\n");

            List<string> OrderedStringInts = stringIntsList
                                             .OrderBy(x => x).ToList()
                                             .Concat(stringIntsList
                                             .Where(y => y != stringIntsList.Max())
                                             .OrderByDescending(y => y)).ToList(); //method syntax

            OrderedStringInts = (from x in stringIntsList
                                 orderby x
                                 select x).Concat
                                ((from y in stringIntsList
                                  where y != stringIntsList.Max()
                                  orderby y
                                  select y).Reverse()).ToList();//query syntax



            OrderedStringInts.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            List<string> OrderedStrings = stringsList2.OrderBy(x => x).ToList()
                                          .Concat(stringsList2
                                          .OrderByDescending(y => y)
                                          .Where(y => y != stringsList2.Max())
                                          .OrderByDescending(y => y)).ToList(); //method syntax;

            OrderedStrings = (from x in stringsList2
                              orderby x
                              select x).Concat
                             ((from y in stringsList2
                               where y != stringsList2.Max()
                               orderby y
                               select y).Reverse()).ToList();//query syntax

            OrderedStrings.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\n---------------Exercise 7a--------------\n");

            List<int> nums1 = new() { 1, 4, 7, 92 };
            List<int> nums2 = new() { 26, 3, 4, 7 };

            List<int> handeledNums = nums1.Intersect(nums2).ToList();

            handeledNums.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\n---------------Exercise 7b--------------\n");

            handeledNums = nums1.Except(nums2).ToList();
            handeledNums.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\n---------------Exercise 7c--------------\n");

            handeledNums = nums1.Except(nums2).Concat(nums2.Except(nums1)).OrderBy(x => x).ToList();
            handeledNums.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\n---------------Exercise 7d--------------\n");

            int firstNumBiggerThen12 = handeledNums.Where(x => x > 12).Select(x => x).First();//method syntax

            firstNumBiggerThen12 = (from x in handeledNums where x > 12 select x).First();//query syntax

            Console.WriteLine(firstNumBiggerThen12);

            Console.WriteLine("\n---------------Exercise 7e--------------\n");

            Console.WriteLine(nums1.Concat(nums2).Max());

            Console.WriteLine("\n---------------Exercise 8--------------\n");

            List<Agent> agents = new()
            {
                new("Johnny Swift"),
                new("Don Cashback"),
                new("Rob M. Now")
            };
            List<Costumer> costumers = new()
            {
                new("John E. Doe", agents[new Random().Next(agents.Count)]),
                new("Dona Primadona", agents[new Random().Next(agents.Count)]),
                new("Vaskez Zanzibar", agents[new Random().Next(agents.Count)]),
                new("Joe Paamoni", agents[new Random().Next(agents.Count)]),
                new("Primus E. Wallet", agents[new Random().Next(agents.Count)])
            };

            var clientsVsAgents = costumers.Join(costumers, x => x.Name, y => y.Name, (costumer, MyAgent) =>
                                                 new
                                                 {
                                                     costumer = costumer.Name,
                                                     MyAgent = costumer.MyAgent.Name
                                                 }); //method syntax

            clientsVsAgents = from costumer in costumers
                              join agent in agents on costumer.MyAgent equals agent
                              select new
                              {
                                  costumer = costumer.Name,
                                  MyAgent = costumer.MyAgent.Name
                              }; //query syntax


            foreach (var client in clientsVsAgents)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine("\n---------------Exercise 9--------------\n");

            var clientsVsOrders = costumers.GroupJoin(costumers, x => x.Name, y => y.Name, (costumer, MyOrders) => 
                                  new 
                                  { 
                                      costumer = costumer.Name, 
                                      MyOrders = costumer.MyOrders.Count 
                                  }); //method syntax

            var clientsVsOrders2 = from costumer in costumers
                                   join orders in costumers on costumer.MyOrders.Count equals orders.MyOrders.Count
                                   group orders by costumer into g
                                   select new { g.Key.Name, MyOrders = g.Key.MyOrders.Count };// query syntax

            foreach (var client in clientsVsOrders2)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine("\n---------------Exercise 10--------------\n");

            foreach (Costumer costumer in costumers)
            {
                Console.WriteLine($"Name: {costumer.Name}, Orders:{costumer.MyOrders.Count} \n");
                for (int i = 0; i < costumer.MyOrders.Count; i++)
                {
                    Console.WriteLine($"Order {i + 1}: { costumer.MyOrders[i].Price}$");
                }
                Console.WriteLine();
            }

            var moreThenTwoOrders_500Worth = from cost in costumers
                                             where cost.MyOrdersAvarage > 500 && cost.MyOrders.Count > 2
                                             from order in cost.MyOrders
                                             group order by cost.Name into g
                                             select new { name = g.Key }; // query syntax

            Console.WriteLine("costumers with more then 2 orders 500$ worth:\n");

            foreach (var var in moreThenTwoOrders_500Worth)
            {
                Console.WriteLine(var);
            }
        }
    }
}

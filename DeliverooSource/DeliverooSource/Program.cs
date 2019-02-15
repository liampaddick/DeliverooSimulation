using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverooSource
{
    //main class
    class Program
    {
        //entry point function
        static void Main(string[] args)
        {
            bool serverActive = false;

            //list of restaurants
            List<Restaurant> restaurantList = new List<Restaurant>();
            //list of customers
            List<Customer> customerList = new List<Customer>();
            //list of orders
            List<Order> orderList = new List<Order>();
            //list of riders
            List<Rider> riderList = new List<Rider>();

            //TESTING 
            ////////
            restaurantList.Add(CreateRestaurant("Restaurant 1", "RE5 T1", 2, 2));
            restaurantList.Add(CreateRestaurant("Restaurant 2", "RE5 T2", 2, 5));
            Console.WriteLine("RESTAURANTS: ");
            for (int i = 0; i < restaurantList.Count; i++)
            {
                Console.WriteLine("Restaurant ID: " + restaurantList[i].GetID());
                Console.WriteLine("Restaurant Name: " + restaurantList[i].GetRestaurantName());
                Console.WriteLine("Restaurant Address: " + restaurantList[i].GetRestaurantAddress());
                Console.WriteLine("Restaurant xCo: " + restaurantList[i].GetXCo());
                Console.WriteLine("Restaurant yCo: " + restaurantList[i].GetYCo());
                Console.WriteLine("Restaurant Open: " + restaurantList[i].GetOpen());
                Console.WriteLine(" ");
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            customerList.Add(CreateCustomer("Customer 1", "CU5 T1", 3, 1));
            customerList.Add(CreateCustomer("Customer 2", "CU5 T2", 3, 6));
            Console.WriteLine("CUSTOMERS: ");
            for (int i = 0; i < customerList.Count; i++)
            {
                Console.WriteLine("Customer ID: " + customerList[i].GetId());
                Console.WriteLine("Customer Name: " + customerList[i].GetName());
                Console.WriteLine("Customer Address: " + customerList[i].GetAddress());
                Console.WriteLine("Customer xCo: " + customerList[i].GetXCo());
                Console.WriteLine("Customer yCo: " + customerList[i].GetYCo());
                Console.WriteLine(" ");
            }


            Console.WriteLine(" ");
            Console.WriteLine(" ");


            riderList.Add(CreateRider("Rider 1", 6, 2));
            riderList.Add(CreateRider("Rider 1", 6, 5));
            Console.WriteLine("RIDERS: ");
            for (int i = 0; i < riderList.Count; i++)
            {
                Console.WriteLine("Rider ID: " + riderList[i].GetId());
                Console.WriteLine("Rider Name: " + riderList[i].GetName());
                Console.WriteLine("Rider xCo: " + riderList[i].GetXCo());
                Console.WriteLine("Rider yCo: " + riderList[i].GetYCo());
                Console.WriteLine(" ");
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            orderList.Add(CreateOrder(0, 0));
            orderList.Add(CreateOrder(1, 1));
            Console.WriteLine("ORDERS: ");
            for (int i = 0; i < orderList.Count; i++)
            {
                Console.WriteLine("Order ID: " + orderList[i].GetOrderID());
                Console.WriteLine("Customer ID: " + orderList[i].GetCustomerID());
                Console.WriteLine("Restaurant ID: " + orderList[i].GetRestaurantID());
                Console.WriteLine(" ");
            }

            Console.ReadLine();

            ////////
        }
        //These functions are used to test the initilisation of the various classes. this code is no longer functional and needs to be removed
        /*static List<Restaurant> TestRestaurant()
        {
            List<Restaurant> restaurantList = new List<Restaurant> { };
            for (int i = 0; i < 5; i++)
            {
                Restaurant tempRestaurant = new Restaurant { };
                string tempRestaurantName = "Restaurant " + i;
                float tempX = 3.14f * i;
                float tempY = 6.734f * i;
                tempRestaurant.InitRestaurant(i, tempRestaurantName, tempX, tempY, true);
                restaurantList.Add(tempRestaurant);
            }
            return restaurantList;
        }
        static void OutputRestaurantList(List<Restaurant> RestaurantList)
        {
            Console.WriteLine("------------Output Restaurant Details------------");

            for (int i = 0; i < RestaurantList.Count(); i++)
            {
                Console.WriteLine("Restaurant id: " + RestaurantList[i].GetID());
                Console.WriteLine("Restaurant name: " + RestaurantList[i].GetRestaurantName());
                Console.WriteLine("Restaurant Xco: " + RestaurantList[i].GetXCo());
                Console.WriteLine("Restaurant Yco: " + RestaurantList[i].GetYCo());
                Console.WriteLine("Restaurant Open: " + RestaurantList[i].GetOpen());
                Console.WriteLine(" ");
            }
        }
        static List<Customer> TestCustomer()
        {
            List<Customer> customerList = new List<Customer> { };
            for (int i = 0; i < 5; i++)
            {
                Customer tempCustomer = new Customer { };
                string tempCustomerFirstName = "FirstName " + i;
                string tempCustomerLastName = "LastName " + i;
                float tempXCo = 7.14f * i;
                float tempYCo = 82.6f * i;

                tempCustomer.InitCustomer(i, tempCustomerFirstName, tempCustomerLastName, tempXCo, tempYCo);
                customerList.Add(tempCustomer);
            }
            return customerList;
        }
        static void OutputCustomerList(List<Customer> customerList)
        {
            Console.WriteLine("------------Output Customer Details------------");
            for (int i = 0; i < customerList.Count(); i++)
            {
                Console.WriteLine("Customer ID: " + customerList[i].GetId());
                Console.WriteLine("Customer FirstName: " + customerList[i].GetFirstName());
                Console.WriteLine("Customer LastName: " + customerList[i].GetLastName());
                Console.WriteLine("Customer xCo: " + customerList[i].GetXCo());
                Console.WriteLine("Customer yCo: " + customerList[i].GetYCo());
                Console.WriteLine(" ");
            }
        }
        static List<Order> TestOrder()
        {
            List<Order> orderList = new List<Order> { };

            for (int i = 0; i < 5; i++)
            {
                Order tempOrder = new Order { };
                tempOrder.InitOrder(i, 0, i, false, false, false, false);
                orderList.Add(tempOrder);
            }
            return orderList;
        }
        static void OutputOrderList(List<Order> orderList)
        {
            Console.WriteLine("------------Output Order Details------------");

            for (int i = 0; i < orderList.Count(); i++)
            {
                Console.WriteLine("Order number: " + orderList[i].GetOrderID());
                Console.WriteLine("Rider ID: " + orderList[i].GetRiderID());
                Console.WriteLine("Restaurant ID: " + orderList[i].GetRestaurantID());
                Console.WriteLine("Customer ID: " + orderList[i].GetCustomerID());
                Console.WriteLine("Restaurant accepted: " + orderList[i].GetRestaurantAccepted());
                Console.WriteLine("Rider assigned: " + orderList[i].GetRiderAssigned());
                Console.WriteLine("Food collected: " + orderList[i].GetFoodCollected());
                Console.WriteLine("food delivered: " + orderList[i].GetFoodDelivered());
                Console.WriteLine(" ");
            }
        }
        static List<Rider> TestRider()
        {
            List<Rider> riderList = new List<Rider> { };

            for (int i = 0; i < 5; i++)
            {
                Rider tempRider = new Rider { };
                string tempName = "Rider" + i;
                float tempXCo = 89.14f * i;
                float tempYCo = 27.16f * i;
                tempRider.InitRider(i, tempName, tempXCo, tempYCo, true);
                riderList.Add(tempRider);
            }

            return riderList;
        }
        static void OutputRiderList(List<Rider> riderList)
        {
            Console.WriteLine("------------Output Rider Details------------");
            for (int i = 0; i < riderList.Count; i++)
            {
                Console.WriteLine("Rider ID: " + riderList[i].GetId());
                Console.WriteLine("Rider Name: " + riderList[i].GetName());
                Console.WriteLine("XCo: " + riderList[i].GetXCo());
                Console.WriteLine("YCo: " + riderList[i].GetYCo());
                Console.WriteLine("Rider is Active: " + riderList[i].GetOnline());
                Console.WriteLine(" ");
            }
        }*/

        static bool InitServer() // placeholder for now, finished form will draw from text file
        {
            return true;
        }
        static bool ServerShutdown() //Copy all data to text file so that it can be loaded once the server has been restarted
        {
            return false;
        }

        static List<Rider> GetAvailableRiders(List<Rider> riderList)
        {
            List<Rider> tempRiderList = new List<Rider> { };
            List<Rider> availableRiderList = new List<Rider> { };
            for (int i = 0; i < tempRiderList.Count(); i++)
            {
                if (tempRiderList[i].GetOnline() == true)
                {
                    if (tempRiderList[i].GetCurrentlyDelivering() == false)
                    {
                        availableRiderList.Add(tempRiderList[i]);
                    }
                }
            }

            return availableRiderList;
        }

        static float FindDistance(float x1, float y1, float x2, float y2) //this can be used for finding the distance between a rider and the restaurant as well as the distance from the resaurant to the customer
        {
            double distance = 0.0f;

            distance = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));

            return (float)distance;

        }
        static Rider FindClosestRider(List<Rider> availableRiders, float restaurantX, float restaurantY, float customerX, float customerY)
        {
            Rider shortestRider = new Rider("temp", 0.0f, 0.0f); // these values will be overwritten on the first run of the for loop
            List<Rider> tempRiderList = availableRiders;
            float tempDistanceToRestaurant = 0.0f;
            float tempDistanceToCustomer = 0.0f;
            float tempOverallDistance = 0.0f;
            float shortestOverallDistance = 0.0f;

            //find distance to customer once before the loop as this will stay the same and doesn not need to be calculated everytime
            tempDistanceToCustomer = FindDistance(restaurantX, restaurantY, customerX, customerY);

            for (int i = 0; i < tempRiderList.Count(); i++)
            {
                if (i == 0)
                {
                    tempDistanceToRestaurant = FindDistance(tempRiderList[i].GetXCo(), tempRiderList[i].GetYCo(), restaurantX, restaurantY);
                    tempOverallDistance = tempDistanceToRestaurant + tempDistanceToCustomer;
                    shortestOverallDistance = tempOverallDistance;
                    shortestRider = tempRiderList[i];
                }
                else
                {

                    //find distance from rider to the restaurant
                    tempDistanceToRestaurant = FindDistance(tempRiderList[i].GetXCo(), tempRiderList[i].GetYCo(), restaurantX, restaurantY);
                    tempOverallDistance = tempDistanceToRestaurant + tempDistanceToCustomer;

                    if (tempOverallDistance < shortestOverallDistance)
                    {
                        shortestOverallDistance = tempOverallDistance;
                        shortestRider = tempRiderList[i];
                    }
                }
            }
            return shortestRider;
        }
        static float FindVectorXDistance(float riderX, float destinationX)
        {
            //find difference between rider and destination on the X vectors

            float tempXDistance = riderX - destinationX;
            return tempXDistance;
        }
        static float FindVectorYDistance(float riderY, float destinationY)
        {
            //find difference between rider and destination on the Y vectors

            float tempYDistance = riderY - destinationY;
            return tempYDistance;
        }
        static Rider UpdateRiderDistance(Rider riderToUpdate, float destinationX, float destinationY, float xDistance, float yDistance)
        {
            Rider tempRider = riderToUpdate;
            float riderX = tempRider.GetXCo();
            float riderY = tempRider.GetYCo();

            if (riderX > destinationX)
            {
                // sub distance
                float distance = riderX - xDistance;
                tempRider.SetXCo(distance);
            }
            else
            {
                // add distance
                float distance = riderX + xDistance;
                tempRider.SetXCo(distance);
            }

            if (riderY > destinationY)
            {
                // sub distance
                float distance = riderY - yDistance;
                tempRider.SetYCo(distance);
            }
            else
            {
                // add distance
                float distance = riderY + yDistance;
                tempRider.SetYCo(distance);
            }
            return tempRider;
        }

        static Order CreateOrder(int restaurantID, int customerID)
        {
            Order tempOrder = new Order(restaurantID, customerID);
            return tempOrder;
        }
        static Restaurant CreateRestaurant(string restaurantName, string restaurantAddress, float xCo, float yCo)
        {
            Restaurant tempRestaurant = new Restaurant(restaurantName, restaurantAddress, xCo, yCo);
            return tempRestaurant;
        }
        static Rider CreateRider(string riderName, float xCo, float yCo)
        {
            Rider tempRider = new Rider(riderName, xCo, yCo);
            return tempRider;
        }
        static Customer CreateCustomer(string name, string address, float xCo, float yCo)
        {
            Customer tempCustomer = new Customer(name, address, xCo, yCo);
            return tempCustomer;
        } 
    }
    class Order
    {
        int localOrderID;
        int localRestaurantID;
        int localRiderID;
        int localCustomerID;

        bool localRestaurantAccepted;
        bool localRiderAssigned;
        bool localFoodCollected;
        bool localFoodDelivered;

        //this will be incremented every time an Order object is made the constructor will add to this number and the ID of the Order object will be set accordingly. 
        public static int orderCount;

        public Order(int restaurantID, int customerID)
        {
            //constructor to initialise the order
            localOrderID = orderCount;
            localRestaurantID = restaurantID;
            localCustomerID = customerID;

            orderCount++;
        }

        public int GetOrderID()
        {
            return localOrderID;
        }

        public void SetRestaurantID(int restaurantID)
        {
            localRestaurantID = restaurantID;
        }
        public int GetRestaurantID()
        {
            return localRestaurantID;
        }

        public void SetRiderID(int riderID)
        {
            localRiderID = riderID;
        }
        public int GetRiderID()
        {
            return localRiderID;
        }

        public void SetCustomerID(int customerID)
        {
            localCustomerID = customerID;
        }
        public int GetCustomerID()
        {
            return localCustomerID;
        }

        public void SetRestaurantAccepted(bool accepted)
        {
            localRestaurantAccepted = accepted;
        }
        public bool GetRestaurantAccepted()
        {
            return localRestaurantAccepted;
        }

        public void SetRiderAssigned(bool assigned)
        {
            localRiderAssigned = assigned;
        }
        public bool GetRiderAssigned()
        {
            return localRiderAssigned;
        }

        public void SetFoodCollected(bool collected)
        {
            localFoodCollected = collected;
        }
        public bool GetFoodCollected()
        {
            return localFoodCollected;
        }

        public void SetFoodDelivered(bool delivered)
        {
            localFoodDelivered = delivered;
        }
        public bool GetFoodDelivered()
        {
            return localFoodDelivered;
        }
    }
    class Restaurant
    {
        int localRestaurantID;
        string localRestaurantName;
        string localRestaurantAddress;
        float localXCo;
        float localYCo;
        bool localOpen;

        //this will be incremented every time a Restaurant object is made the constructor will add to this number and the ID of the restaurant object will be set accordingly. 
        public static int restaurantCount;

        public Restaurant(string restaurantName, string restaurantAddress, float xCo, float yCo)
        {
            //constructor for the restaurant
            localRestaurantID = restaurantCount;
            localRestaurantName = restaurantName;
            localRestaurantAddress = restaurantAddress;
            localXCo = xCo;
            localYCo = yCo;            
            restaurantCount++;

        }
        public int GetID()
        {
            return localRestaurantID;
        }
        public string GetRestaurantName()
        {
            return localRestaurantName;
        }
        public string GetRestaurantAddress()
        {
            return localRestaurantAddress;
        }
        public float GetXCo()
        {
            return localXCo;
        }
        public float GetYCo()
        {
            return localYCo;
        }
        public void SetOpen(bool open)
        {
            localOpen = open;
        }
        public bool GetOpen()
        {
            return localOpen;
        }
    }
    class Rider
    {
        int localId;
        string localRiderName;
        float localXCo;
        float localYCo;
        float distanceFromDestination;
        bool localOnline;
        bool localIsDelivering;
        int localAssignedOrder;

        //this will be incremented every time a rider object is made the constructor will add to this number and the ID of the Rider object will be set accordingly. 
        public static int riderCount;

        public Rider(string riderName, float xCo, float yCo)
        {
            //constructor for the rider
            localId = riderCount;
            localRiderName = riderName;
            localXCo = xCo;
            localYCo = yCo;
            riderCount++;

        }

        public int GetId()
        {
            return localId;
        }

        public string GetName()
        {
            return localRiderName;
        }

        public void SetXCo(float xCo)
        {
            localXCo = xCo;
        }
        public float GetXCo()
        {
            return localXCo;
        }

        public void SetYCo(float yCo)
        {
            localYCo = yCo;
        }
        public float GetYCo()
        {
            return localYCo;
        }

        public void SetOnline(bool online)
        {
            localOnline = online;
        }
        public bool GetOnline()
        {
            return localOnline;
        }

        public void SetAssignedOrder(int orderID)
        {
            localAssignedOrder = orderID;
        }
        public int GetAssignedOrder()
        {
            return localAssignedOrder;
        }

        public void SetCurrentlyDelivering(bool delivering)
        {
            localIsDelivering = delivering;
        }
        public bool GetCurrentlyDelivering()
        {
            return localIsDelivering;
        }
    }
    class Customer
    {
        int localId;
        string localName;
        string localAddress;
        float localXCo;
        float localYCo;
        int localOrderID;

        //this will be incremented every time a customer object is made the constructor will add to this number and the ID of the Customer object will be set accordingly. 
        public static int customerCount;

        public Customer(string customerName, string customerAddress, float xCo, float yCo)
        {
            //constructor for the Customer
            localId = customerCount;
            localName = customerName;
            localAddress = customerAddress;
            localXCo = xCo;
            localYCo = yCo;

            customerCount++;

        }

        public int GetId()
        {
            return localId;
        }

        public string GetName()
        {
            return localName;
        }

        public string GetAddress()
        {
            return localAddress;
        }

        public float GetXCo()
        {
            return localXCo;
        }

        public float GetYCo()
        {
            return localYCo;
        }

        public void SetOrderID(int orderID)
        {
            localOrderID = orderID;
        }
        public int SetOrderID()
        {
            return localOrderID;
        }
    }
}

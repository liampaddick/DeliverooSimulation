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
            bool serverActive = true;

            //list of restaurants
            List<Restaurant> restaurantList = new List<Restaurant>();
            //list of customers
            List<Customer> customerList = new List<Customer>();
            //list of orders
            List<Order> orderList = new List<Order>();
            //list of riders
            List<Rider> riderList = new List<Rider>();

            //Add all known restaraunts to restaraunt list
            customerList = TestCustomer();

            //Add all known riders to restaraunt list
            riderList = TestRider();

            //add all known customers to customer list
            customerList = TestCustomer();

            Console.WriteLine("This will simulate a deliveroo order system");
            while (serverActive == true)
            {

            }

            //Restaurant init test
            //restaurantList = TestRestaurant();
            //OutputRestaurantList(restaurantList);
            //End of test

            //customer init test
            //customerList = TestCustomer();
            //OutputCustomerList(customerList);
            //end of test

            //order init test
            //orderList = TestOrder();
            //OutputOrderList(orderList);
            //end of test

            //rider init test
            //riderList = TestRider();
            //OutputRiderList(riderList);
            //end of test
        }
        //These functions are used to test the initilisation of the various classes. They have been filled with placeholders for now
        static List<Restaurant> TestRestaurant()
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
                Console.WriteLine("Order number: " + orderList[i].GetOrderNumber());
                Console.WriteLine("Rider ID: " + orderList[i].GetRiderId());
                Console.WriteLine("Restaurant ID: " + orderList[i].GetRestaurantId());
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
        }

        static void ServerShutdown() //Copy all data to text file so that it can be loaded once the server has been restarted
        {

        }

        static void GetAvailableRiders(List<Rider> riderList)
        {
            List<Rider> availableRiders = new List<Rider> { };

            for (int i = 0; i < riderList.Count(); i++)
            {
                if (riderList[i].GetOnline() == true)
                {

                }
            }
        }
        static Rider FindClosestRider(List<Rider> availableRiders, float restaurantX, float restaurantY)
        {
            Rider closestRider = new Rider { };
            float tempRiderX;
            float tempRiderY;
            float shortestDistance = 0.0f;
            float currentDistance;

            for (int i = 0; i < availableRiders.Count(); i++)
            {
                tempRiderX = availableRiders[i].GetXCo();
                tempRiderY = availableRiders[i].GetYCo();

                currentDistance = ((tempRiderX - restaurantX) * (tempRiderX - restaurantX)) + ((tempRiderY - restaurantY) * (tempRiderY - restaurantY));

                if (currentDistance < shortestDistance)
                {
                    shortestDistance = currentDistance;
                    closestRider = availableRiders[i];
                    currentDistance = 0.0f;
                }
            }

            return closestRider;
        }
        static Order CreateOrder(Restaurant restarauntOrderedFrom, Customer orderingCustomer)
        {
            Order tempOrder = new Order { };
            return tempOrder;
        }
    }
    class Order
    {
        int localOrderNumber;
        int localRiderID;
        int localRestaurantID;

        bool localRestaurantAccepted;
        bool localRiderAssigned;
        bool localFoodCollected;
        bool localFoodDelivered;


        public void SetOrderNumber(int amountOfOrders)
        {
            localOrderNumber = amountOfOrders + 1;
        }
        public int GetOrderNumber()
        {
            return localOrderNumber;
        }

        public void SetRiderId(int riderId)
        {
            localRiderID = riderId;
        }
        public int GetRiderId()
        {
            return localRiderID;
        }

        public void SetRestaurantId(int RestaurantId)
        {
            localRestaurantID = RestaurantId;
        }
        public int GetRestaurantId()
        {
            return localRestaurantID;
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


        public void InitOrder(int orderNumber, int riderID, int RestaurantID, bool RestaurantAccepted, bool riderAssigned, bool foodCollected, bool foodDelivered)
        {
            localOrderNumber = orderNumber;
            localRiderID = riderID;
            localRestaurantID = RestaurantID;

            localRestaurantAccepted = RestaurantAccepted;
            localRiderAssigned = riderAssigned;
            localFoodCollected = foodCollected;
            localFoodDelivered = foodDelivered;
        }
    }
    class Restaurant
    {
        int localId;
        string localRestaurantName;
        float localXCo;
        float localYCo;
        bool localOpen;

        public void SetID(int id)
        {
            localId = id;
        }
        public int GetID()
        {
            return localId;
        }

        public void SetRestaurantName(string RestaurantName)
        {
            localRestaurantName = RestaurantName;
        }
        public string GetRestaurantName()
        {
            return localRestaurantName;
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

        public void SetOpen(bool open)
        {
            localOpen = open;
        }
        public bool GetOpen()
        {
            return localOpen;
        }

        public void InitRestaurant(int id, string name, float xCo, float yCo, bool open)
        {
            localId = id;
            localRestaurantName = name;
            localXCo = xCo;
            localYCo = yCo;
            localOpen = open;
        }

    }
    class Rider
    {
        int localId;
        string localRiderName;
        float localXCo;
        float localYCo;
        bool localOnline;

        public void SetId(int id)
        {
            localId = id;
        }
        public int GetId()
        {
            return localId;
        }

        public void SetName(string riderName)
        {
            localRiderName = riderName;
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

        public void InitRider(int id, string riderName, float xCo, float yCo, bool online)
        {
            SetId(id);
            SetName(riderName);
            SetXCo(xCo);
            SetYCo(yCo);
            SetOnline(online);
        }
    }
    class Customer
    {
        int LocalId;
        string localFirstName;
        string localLastName;
        float localXCo;
        float localYCo;

        public void SetId(int id)
        {
            LocalId = id;
        }
        public int GetId()
        {
            return LocalId;
        }

        public void SetFirstName(string firstName)
        {
            localFirstName = firstName;
        }
        public string GetFirstName()
        {
            return localFirstName;
        }

        public void SetLastName(string lastName)
        {
            localLastName = lastName;
        }
        public string GetLastName()
        {
            return localLastName;
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

        public void InitCustomer(int id, string firstName, string lastName, float xCo, float yCo)
        {
            SetId(id);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetXCo(xCo);
            SetYCo(yCo);
        }
    }
}

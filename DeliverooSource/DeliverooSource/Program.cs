﻿using System;
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

            //add restaurant to list
            restaurantList.Add(CreateRestaurant(0, "Restaurant1", "R3ST 0N3", 4, 2, true));
            //add riders to list
            riderList.Add(CreateRider(0, "Jim Jiminson", 2, 2, true, false));
            riderList.Add(CreateRider(1, "Dave Davidson", 14, 2, true, false));
            //add customers to list
            customerList.Add(CreateCustomer(0, "Steve Stevinson", "CU5T 0M1", 4, 6));
            customerList.Add(CreateCustomer(1, "Nate Nateinson", "CU5T 0M2", 10, 2));

            orderList.Add(CreateOrder(0, restaurantList[0].GetID(), customerList[0].GetId(), false));
            orderList.Add(CreateOrder(1, restaurantList[0].GetID(), customerList[1].GetId(), false));

            InitServer();

            Console.WriteLine("This will simulate a deliveroo order system");
            while (serverActive == true)
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //PLACE THIS INSIDE FUNCTION
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                for (int i = 0; i < orderList.Count(); i++)
                {
                    if (orderList[i].GetRiderAssigned() == false)
                    {
                        Restaurant tempRestaurant = new Restaurant { };
                        for (int j = 0; j < restaurantList.Count(); j++)
                        {
                            if (orderList[i].GetRestaurantID() == restaurantList[j].GetID())
                            {
                                tempRestaurant = restaurantList[j];
                            }
                        }
                        Customer tempCustomer = new Customer { };
                        for (int j = 0; j < customerList.Count(); j++)
                        {
                            if (orderList[i].GetCustomerID() == customerList[j].GetId())
                            {
                                tempCustomer = customerList[j];
                            }
                        }
                        Rider tempRiderToAssign;
                        tempRiderToAssign = FindClosestRider(riderList, tempRestaurant.GetXCo(), tempRestaurant.GetYCo(), tempCustomer.GetXCo(), tempCustomer.GetYCo());
                        orderList[i].SetRiderID(tempRiderToAssign.GetId());
                        orderList[i].SetRiderAssigned(true); 
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                }
            }
        }
        //These functions are used to test the initilisation of the various classes. They have been filled with placeholders for now
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
            Rider shortestRider = new Rider { };
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

        static Order CreateOrder(int id, int restaurantID, int customerID, bool initBools)
        {
            Order tempOrder = new Order { };
            tempOrder.SetOrderID(id);
            tempOrder.SetRestaurantID(restaurantID);
            tempOrder.SetCustomerID(customerID);
            tempOrder.SetRestaurantAccepted(initBools);
            tempOrder.SetRiderAssigned(initBools);
            tempOrder.SetFoodCollected(initBools);
            tempOrder.SetFoodDelivered(initBools);
            return tempOrder;
        }
        static Restaurant CreateRestaurant(int id, string restaurantName, string restaurantAddress, float xCo, float yCo, bool open)
        {
            Restaurant tempRestaurant = new Restaurant { };
            tempRestaurant.SetID(id);
            tempRestaurant.SetRestaurantName(restaurantName);
            tempRestaurant.SetRestaurantAddress(restaurantAddress);
            tempRestaurant.SetXCo(xCo);
            tempRestaurant.SetYCo(yCo);
            tempRestaurant.SetOpen(open);
            return tempRestaurant;
        }
        static Rider CreateRider(int id, string riderName, float xCo, float yCo, bool online, bool isDelivering)
        {
            Rider tempRider = new Rider { };
            tempRider.SetId(id);
            tempRider.SetName(riderName);
            tempRider.SetXCo(xCo);
            tempRider.SetYCo(yCo);
            tempRider.SetOnline(online);
            tempRider.SetCurrentlyDelivering(isDelivering);
            return tempRider;
        }
        static Customer CreateCustomer(int id, string name, string address, float xCo, float yCo)
        {
            Customer tempCustomer = new Customer { };
            tempCustomer.SetId(id);
            tempCustomer.SetName(name);
            tempCustomer.SetAddress(address);
            tempCustomer.SetXCo(xCo);
            tempCustomer.SetYCo(yCo);
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


        public void SetOrderID(int amountOfOrders)
        {
            localOrderID = amountOfOrders + 1;
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
        int localId;
        string localRestaurantName;
        string localRestaurantAddress;
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

        public void SetRestaurantAddress(string RestaurantAddress)
        {
            localRestaurantAddress = RestaurantAddress;
        }
        public string GetRestaurantAddress()
        {
            return localRestaurantAddress;
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
    }
    class Rider
    {
        int localId;
        string localRiderName;
        float localXCo;
        float localYCo;
        bool localOnline;
        bool localIsDelivering;
        int localAssignedOrder;

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

        public void SetId(int id)
        {
            localId = id;
        }
        public int GetId()
        {
            return localId;
        }

        public void SetName(string name)
        {
            localName = name;
        }
        public string GetName()
        {
            return localName;
        }

        public void SetAddress(string address)
        {
            localAddress = address;
        }
        public string GetAddress()
        {
            return localAddress;
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

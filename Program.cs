using SmartDeliveryManagementSystem;
using static SmartDeliveryManagementSystem.DeliveryAddress;
using static SmartDeliveryManagementSystem.DeliveryAddress.Shipment;

namespace SmartDeliveryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 A
            //  is a struct (a value type) ,Modifying the copied variable will not affect the original variable.


            // 1 B
            // is a class (a reference type) Modifying the object through either variable will
            // affect both, as they share the same underlying data.


            // 2 A
            // 1- Public Fields 2- Lack of Data Validation 3- No Read-Only Control 

            // 2 b 
            // Private fields hide internal implementation details
            // Public properties provide controlled access through get and set accessors 




       
                // a. Create a DeliveryCenter
                DeliveryCenter center = new DeliveryCenter();

                // b & c. Read data for 3 shipments from user
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine($"Enter Shipment {i} Data");

                    Console.Write("Tracking Code: ");
                    string code = Console.ReadLine() ?? string.Empty;

                    Console.Write("Description: ");
                    string desc = Console.ReadLine() ?? string.Empty;

                    Console.Write("Weight: ");
                    double.TryParse(Console.ReadLine(), out double weight);

                    Console.Write("Delivery Fee: ");
                    decimal.TryParse(Console.ReadLine(), out decimal fee);

                    Console.Write("City: ");
                    string city = Console.ReadLine() ?? string.Empty;

                    Console.Write("Street: ");
                    string street = Console.ReadLine() ?? string.Empty;

                    Console.Write("Building Number: ");
                    int.TryParse(Console.ReadLine(), out int bNum);

                    DeliveryAddress addr = new DeliveryAddress(city, street, bNum);
                    Shipment shipment = new Shipment(code, desc, weight, fee, addr);

                    if (center.AddShipment(shipment))
                    {
                        Console.WriteLine("Shipment added successfully.");
                    }
                }

                // d. Print shipments using integer indexer
                Console.WriteLine(" All Shipments ");
                for (int i = 0; i < 3; i++)
                {
                    center[i].PrintShipment();
                    Console.WriteLine();
                }

                // e & f & g. Search for shipment using string indexer
                Console.Write("Enter a tracking code to search: ");
                string searchCode = Console.ReadLine() ?? string.Empty;

                Shipment? foundShipment = center[searchCode];
                if (foundShipment.HasValue && !string.IsNullOrEmpty(foundShipment.Value.TrackingCode))
                {
                    Console.WriteLine($"Shipment found: {foundShipment.Value.TrackingCode} - " +
                        $"{foundShipment.Value.Description}");
                }
                else
                {
                    Console.WriteLine("Shipment not found.");
                }

                // h. Demonstrate DeliveryAddress struct copy behavior
                Console.WriteLine(" Struct Copy Test ");
                DeliveryAddress originalAddress = new DeliveryAddress("Cairo", "Tahrir Street", 15);
                DeliveryAddress copiedAddress = originalAddress;

                copiedAddress.Street = "Makram Ebeid Street";
                copiedAddress.BuildingNumber = 20;

                Console.WriteLine($"Original Address: {originalAddress.GetFullAddress()}");
                Console.WriteLine($"Copied Address: {copiedAddress.GetFullAddress()}");
            }
        }
    }





        
    


    

using System;

namespace SmartDeliveryManagementSystem
{
    // 1. DeliveryAddress Struct
    public struct DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuildingNumber;

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public string GetFullAddress()
        {
            return $"{BuildingNumber} {Street}, {City}";
        }

        // 2. Shipment struct

        public struct Shipment
        {

            private string trackingCode;
            private string description;
            private double weight;
            private decimal deliveryFee;


            public string TrackingCode
            {
                get => trackingCode;
                private set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        trackingCode = value;
                }
            }
            public string Description
            {
                get => description;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        description = value;
                }
            }

            public double Weight
            {
                get => weight;
                set
                {
                    if (value > 0)
                        weight = value;
                }
            }

            public decimal DeliveryFee
            {
                get => deliveryFee;
                private set
                {
                    if (value > 0)
                        deliveryFee = value;
                }
            }
            public DeliveryAddress Destination { get; set; }

            public decimal EstimatedCost => DeliveryFee + ((decimal)Weight * 5m);

            public Shipment(string trackingCode)
            {
                this.trackingCode = !string.IsNullOrWhiteSpace(trackingCode) ? trackingCode : "UNKNOWN";
                this.description = "Unknown";
                this.weight = 1;
                this.deliveryFee = 50;
                this.Destination = default;
            }

            public Shipment(string trackingCode, string description, double weight, decimal deliveryFee,
                DeliveryAddress destination)
            {
                this.trackingCode = !string.IsNullOrWhiteSpace(trackingCode) ? trackingCode : "UNKNOWN";
                this.description = !string.IsNullOrWhiteSpace(description) ? description : "Unknown";
                this.weight = weight > 0 ? weight : 1;
                this.deliveryFee = deliveryFee > 0 ? deliveryFee : 50;
                this.Destination = destination;
            }

            // Methods
            public void UpdateDeliveryFee(decimal newFee)
            {
                if (newFee > 0)
                {
                    DeliveryFee = newFee;
                }
            }

            public void PrintShipment()
            {
                Console.WriteLine($"Tracking Code: {TrackingCode}");
                Console.WriteLine($"Description: {Description}");
                Console.WriteLine($"Weight: {Weight} KG");
                Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
                Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
                Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
            }


            // 3. DeliveryCenter Struct
            public struct DeliveryCenter
            {
                private Shipment[] shipments;
                private int count;

                public DeliveryCenter()
                {
                    shipments = new Shipment[10];
                    count = 0;
                }

                // Integer Indexer
                public Shipment this[int index]
                {
                    get
                    {
                        if (shipments != null && index >= 0 && index < count)
                            return shipments[index];
                        return default;
                    }
                    set
                    {
                        if (shipments != null && index >= 0 && index < count)
                            shipments[index] = value;
                    }
                }

                // String Indexer 

                public Shipment? this[string trackingCode]
                {
                    get
                    {
                        if (shipments == null) return null;

                        for (int i = 0; i < count; i++)
                        {
                            if (shipments[i].TrackingCode.Equals(trackingCode, StringComparison.OrdinalIgnoreCase))
                            {
                                return shipments[i];
                            }
                        }
                        return null;
                    }
                }

                // AddShipment Method
                public bool AddShipment(Shipment shipment)
                {
                    if (shipments == null)
                    {
                        shipments = new Shipment[10];
                        count = 0;
                    }

                    if (count < shipments.Length)
                    {
                        shipments[count] = shipment;
                        count++;
                        return true;
                    }
                    return false;
                }

            }
        }
    }
}
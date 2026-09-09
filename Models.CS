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

        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksopark
{
    public class Car
    {
        public string Model { get; set; }
        public bool IsOnTrip { get; set; }
        public DateTime TripStartTime { get; set; }
        public List<TimeSpan> Trip { get; set; }

        public Car(string model)
        {
            Model = model;
            IsOnTrip = false;
            Trip = new List<TimeSpan>();
        }

        public TimeSpan TotalTime
        {
            get
            {
                TimeSpan total = TimeSpan.Zero;
                foreach (var trip in Trip)
                {
                    total += trip;
                }
                return total;
            }
        }

        public override string ToString()
        {
            string status = IsOnTrip ? "На выезде" : "В парке";
            return $"{Model} ({status})";
        }
    }
}

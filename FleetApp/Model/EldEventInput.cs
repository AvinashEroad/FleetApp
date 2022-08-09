using System;

namespace FleetApp.Model
{
    public class EldEventInput
    {
        public int EventType { get; set; }

        public int EventCode { get; set; }

        public DateTime? EventDate { get; set; }

        public DateTime? EventTime { get; set; }

        public string VehicleDistance { get; set; }

        public string EngineHours { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string CmvPowerUnitNumber { get; set; }

        public string EldUserName { get; set; }
    }
}

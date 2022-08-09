using FleetApp.Model;
using Imarda.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using static FleetApp.Helper.Constants;

namespace FleetApp.Helper
{
    public static class EldEventInputHelper
    {
        public static (string eventDataCheckSumString, string eventDataCheckSum) GetEventDataCheck(EldEventInput input)
        {
            try
            {
                var eventDate = (input.EventDate ?? DateTime.UtcNow).ToString(ELDUtils.EldDateFormat);
                var eventTime = (input.EventTime ?? DateTime.UtcNow).TimeOfDay.ToString(ELDUtils.EldTimeFormat);
                var eventDataCheckSumString = GetEventDataCheckSumString(input.EventType, input.EventCode, eventDate, eventTime, input.VehicleDistance, input.EngineHours, input.Latitude, input.Longitude, input.CmvPowerUnitNumber, input.EldUserName);
                var eventDataCheckSum = ELDUtils.GetEventDataCheckAsString(eventDataCheckSumString);
                return (eventDataCheckSumString, eventDataCheckSum);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return ($"{InvalidRequestMessage} for EventDataCheckSumString", $"{InvalidRequestMessage} for EventDataCheckSum");
            }
        }

        private static string GetEventDataCheckSumString(params object[] values)
        {
            return $"{new StringBuilder(string.Join(string.Empty, values))}";
        }

        public static string GetLineDataCheck(string dataElements)
        {
            try
            {
                return ELDUtils.GetLineDataCheck(dataElements);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return InvalidRequestMessage;
            }
        }

        public static string GetFileDataCheck(string lineDataChecks)
        {
            try
            {
                var lineDataCheckByteList = new List<byte>();
                var lineDataCheckHexaStringList = lineDataChecks.Split(',');
                foreach (var lineDataCheckHexaString in lineDataCheckHexaStringList)
                {
                    var lineDataCheck = byte.Parse(lineDataCheckHexaString, NumberStyles.HexNumber);
                    lineDataCheckByteList.Add(lineDataCheck);
                }
                return ELDUtils.GetFileDataCheck(lineDataCheckByteList.ToArray());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return InvalidRequestMessage;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BowlingSYS_Tests.Settings
{
    public class Settings
    {
        public static string UserServiceUrl { get; } = "http://localhost:5000/Api/UserDetails";
        public static string BookingServiceUrl { get; } = "http://localhost:5003/Api/Booking";
        public static string ViewServiceUrl { get; } = "http://localhost:5006/Api/Panels";
        public static string MakeBookingServiceUrl { get; } = "http://localhost:5010/Api/MakeBooking";
        public static string BowlingSysFrontend { get; } = "http://localhost:3000/";


    }
}
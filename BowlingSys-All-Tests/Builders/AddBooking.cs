using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingSys.Contracts.BookingDtos;

namespace BowlingSys_All_Tests.Builders
{
    public class AddBooking
    {
        public Guid UserID { get; set; }
        public decimal BookingCost { get; set; }
        public string BookingTime { get; set; }
        public int NumOfShoes { get; set; }

        public AddBooking(Guid userID, decimal bookingCost, string bookingTime, int numOfShoes)
        {
            UserID = userID;
            BookingCost = bookingCost;
            BookingTime = bookingTime;
            NumOfShoes = numOfShoes;
        }
        public MakeBookingDto MakeBookingBuilder()
        {
            return new MakeBookingDto
            {
                UserId = UserID,
                BookingDate = DateTime.Now,
                BookingCost = BookingCost,
                BookingStatus = "B", 
                BookingTime = BookingTime,
                LaneId = 1, 
                NumOfShoes = NumOfShoes,
            };
        }
    }

}

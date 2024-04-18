using System;
using System.Collections.Generic;

namespace PhoenixDataAccess.Models
{
    public partial class RoomService
    {
        public string EmployeeNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string OutsourcingCompany { get; set; } = null!;
        public TimeSpan? MondayRoasterStart { get; set; }
        public TimeSpan? MondayRoasterFinish { get; set; }
        public TimeSpan? TuesdayRoasterStart { get; set; }
        public TimeSpan? TuesdayRoasterFinish { get; set; }
        public TimeSpan? WednesdayRoasterStart { get; set; }
        public TimeSpan? WednesdayRoasterFinish { get; set; }
        public TimeSpan? ThursdayRoasterStart { get; set; }
        public TimeSpan? ThursdayRoasterFinish { get; set; }
        public TimeSpan? FridayRoasterStart { get; set; }
        public TimeSpan? FridayRoasterFinish { get; set; }
        public TimeSpan? SaturdayRoasterStart { get; set; }
        public TimeSpan? SaturdatRoasterFinish { get; set; }
        public TimeSpan? SundayRoasterStart { get; set; }
        public TimeSpan? SundayRoasterFinish { get; set; }
    }
}

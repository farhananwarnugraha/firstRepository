﻿using System;
using System.Collections.Generic;

namespace PhoenixDataAccess.Models
{
    public partial class Guest
    {
        public Guest()
        {
            Reservations = new HashSet<Reservation>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = null!;
        public string Citizenship { get; set; } = null!;
        public string IdNumber { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}

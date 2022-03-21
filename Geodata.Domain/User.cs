using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoEvents.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string? City { get; set; }
        public string Sex { get; set; }
    }
}

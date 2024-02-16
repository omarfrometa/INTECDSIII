using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEC.Project2.Entities
{
    public class PersonEntity
    {
        public string Id { get; set; }
        public string Cedula { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set;}
        public DateTime DOB { get; set;}
        public string BirthPlace { get; set;}
        public string NationalityId { get; set;}
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set;}
        public string BloodTypeId { get; set;}
        public string CivilStatusId { get; set; }
        public string OccupationId { get; set; }
        public bool IsDead { get; set; }
        public DateTime? DeadDate { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

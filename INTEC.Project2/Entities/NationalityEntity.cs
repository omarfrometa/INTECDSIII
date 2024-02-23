using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEC.Project2.Entities
{
    public class NationalityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
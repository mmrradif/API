using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalAPI.Database_Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public decimal Salary { get; set; }

        public bool IsManager { get; set; }
    }
}
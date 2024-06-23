using System.ComponentModel.DataAnnotations;

namespace Jobmatch.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public String Requirment { get; set; }
        public string Address { get; set; }


        public float Salary { get; set; }
        [Required]
        public string Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

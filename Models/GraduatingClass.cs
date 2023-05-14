using System.ComponentModel.DataAnnotations;

namespace AdminMNS.API.Models
{
	public class GraduatingClass : DatabaseTable
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
	}
}

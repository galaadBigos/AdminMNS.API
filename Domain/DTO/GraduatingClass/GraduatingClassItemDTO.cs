using AdminMNS.API.Models;
using System.ComponentModel.DataAnnotations;

namespace AdminMNS.API.Domain.DTO
{
	public class GraduatingClassItemDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

        public GraduatingClassItemDTO()
        {
            
        }

        public GraduatingClassItemDTO(GraduatingClass graduatingClass)
        {
            Id = graduatingClass.Id;
			Name = graduatingClass.Name;
			StartDate = graduatingClass.StartDate;
			EndDate = graduatingClass.EndDate;
        }
    }
}

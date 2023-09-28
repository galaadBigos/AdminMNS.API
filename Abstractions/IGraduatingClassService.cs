using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Models;

namespace AdminMNS.API.Abstractions
{
	public interface IGraduatingClassService
	{
		IEnumerable<GraduatingClass>? GetGraduatingClasses();
		GraduatingClass? GetGraduatingClassById(int id);
		public void PostNewGraduatingClass(GraduatingClassItemDTO graduatingClass);
		void DeleteGraduatingClassById(int id);
		void UpdateGraduatingClass(GraduatingClassItemDTO graduatingClass);
	}
}

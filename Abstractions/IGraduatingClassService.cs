using AdminMNS.API.Models;

namespace AdminMNS.API.Abstractions
{
	public interface IGraduatingClassService
	{
		IEnumerable<GraduatingClass>? GetGraduatingClasses();
		GraduatingClass? GetGraduatingClassById(int id);
	}
}

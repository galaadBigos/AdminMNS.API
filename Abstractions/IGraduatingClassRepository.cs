using AdminMNS.API.Models;

namespace AdminMNS.API.Abstractions
{
	public interface IGraduatingClassRepository
	{
		GraduatingClass? GetGraduatingClass(int id);
		IEnumerable<GraduatingClass>? GetGraduatingClasses();
	}
}

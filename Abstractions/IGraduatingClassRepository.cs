using AdminMNS.API.Models;

namespace AdminMNS.API.Abstractions
{
	public interface IGraduatingClassRepository
	{
		void DeleteGraduatingClass(int id);
		public GraduatingClass? GetGraduatingClass(int id);
		public IEnumerable<GraduatingClass>? GetGraduatingClasses();
		public void PostGraduatingClass(GraduatingClass graduatingClass);
		void UpdateGraduatingClass(GraduatingClass graduatingClass);
	}
}

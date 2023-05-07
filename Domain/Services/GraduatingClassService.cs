using AdminMNS.API.Abstractions;
using AdminMNS.API.Models;

namespace AdminMNS.API.Domain.Services
{
	public class GraduatingClassService : IGraduatingClassService
	{
		private readonly IGraduatingClassRepository _graduatingClassRepository;

		public GraduatingClassService(IGraduatingClassRepository graduatingClassRepository)
		{
			_graduatingClassRepository = graduatingClassRepository;
		}

		public IEnumerable<GraduatingClass>? GetGraduatingClasses()
		{
			return _graduatingClassRepository.GetGraduatingClasses();
		}

		public GraduatingClass? GetGraduatingClassById(int id)
		{
			return _graduatingClassRepository.GetGraduatingClass(id);
		}
	}
}

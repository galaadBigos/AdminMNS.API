using AdminMNS.API.Abstractions;
using AdminMNS.API.App_Code.Helpers;
using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Models;
using AdminMNS.API.Repository;

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

		public void PostNewGraduatingClass(GraduatingClassItemDTO graduatingClassItemDTO)
		{
			GraduatingClass graduatingClass = GraduatingClassHelper.GenerateGraduationgClassFromItemDTO(graduatingClassItemDTO);
			_graduatingClassRepository.PostGraduatingClass(graduatingClass);
		}
		public void UpdateGraduatingClass(GraduatingClassItemDTO graduatingClassItemDTO)
		{
			GraduatingClass graduatingClass = GraduatingClassHelper.GenerateGraduationgClassFromItemDTO(graduatingClassItemDTO);
			_graduatingClassRepository.UpdateGraduatingClass(graduatingClass);
		}

		public void DeleteGraduatingClassById(int id)
		{
			_graduatingClassRepository.DeleteGraduatingClass(id);
		}
	}
}

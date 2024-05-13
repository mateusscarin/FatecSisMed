using System;
using FatecSisMed.Web.Models;

namespace FatecSisMed.Web.Services.Interfaces
{
	public interface IEspecialidadeService
	{
        Task<IEnumerable<EspecialidadeViewModel>> GetAllEspecialidades();
        Task<EspecialidadeViewModel>
            FindEspecialidadeById(int id);
        Task<EspecialidadeViewModel>
            CreateEspecialidade(EspecialidadeViewModel especialidadeViewModel);
        Task<EspecialidadeViewModel>
            UpdateEspecialidade(EspecialidadeViewModel especialidadeViewModel);
        Task<bool> DeleteEspecialidadeById(int id);
    }
}


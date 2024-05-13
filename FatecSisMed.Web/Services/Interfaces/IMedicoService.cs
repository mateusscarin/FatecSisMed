using System;
using FatecSisMed.Web.Models;

namespace FatecSisMed.Web.Services.Interfaces
{
	public interface IMedicoService
	{
        Task<IEnumerable<MedicoViewModel>> GetAllMedicos();
        Task<MedicoViewModel> FindMedicoById(int id);
        Task<MedicoViewModel>
            CreateMedico(MedicoViewModel medicoViewModel);
        Task<MedicoViewModel>
            UpdateMedico(MedicoViewModel medicoViewModel);
        Task<bool> DeleteMedicoById(int id);
    }
}


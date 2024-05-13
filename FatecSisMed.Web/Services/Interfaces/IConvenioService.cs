using System;
using FatecSisMed.Web.Models;

namespace FatecSisMed.Web.Services.Interfaces
{
	public interface IConvenioService
	{
        Task<IEnumerable<ConvenioViewModel>>
            GetAllConvenios();
        Task<ConvenioViewModel> FindConvenioById(int id);
        Task<ConvenioViewModel>
            CreateConvenio(ConvenioViewModel convenioViewModel);
        Task<ConvenioViewModel>
            UpdateConvenio(ConvenioViewModel convenioViewModel);
        Task<bool> DeleteConvenioById(int id);
    }
}


using SGSWebApp.Application.Common.DTOs;
using SGSWebApp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSWebApp.Application.Common.Interfaces.Repositories
{
    public interface IContainerRepository
    {
        Task<ContainerDTO> GetContainerById(Guid containerId);
        Task<PageViewModel<ContainerDTO>> GetContainersList(int page = 1);
        Task AddContainer(ContainerDTO containerDTO);
        Task UpdateContainer(ContainerDTO containerDTO);
        Task DeleteContainer(Guid containerId);
    }
}

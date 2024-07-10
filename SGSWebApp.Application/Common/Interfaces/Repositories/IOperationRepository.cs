using SGSWebApp.Application.Common.DTOs;
using SGSWebApp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSWebApp.Application.Common.Interfaces.Repositories
{
    public interface IOperationRepository
    {
        Task<PageViewModel<OperationDTO>> GetOperationsByContainerId(Guid containerId, int page = 1);
        Task<PageViewModel<OperationDTO>> GetOperationsList(int page = 1);
        Task AddOperation(OperationDTO operationDTO);
        Task UpdateOperation(OperationDTO operationDTO);
        Task DeleteOperation(Guid operationId);
    }
}

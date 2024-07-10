using Mapster;
using Microsoft.EntityFrameworkCore;
using SGSWebApp.Application.Common.DTOs;
using SGSWebApp.Application.Common.Interfaces.Repositories;
using SGSWebApp.Application.Common.Models;
using SGSWebApp.Core.Data;
using SGSWebApp.Infrastructure.Data;
using System.ComponentModel;

namespace SGSWebApp.Infrastructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly ApplicationDbContext _context;
        public OperationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOperation(OperationDTO operationDTO)
        {
            var operation = new Operation(
                operationDTO.StartDate,
                operationDTO.EndDate,
                operationDTO.OperationType,
                operationDTO.OperatorName,
                operationDTO.InspectionLocation,
                operationDTO.ContainerId
            );

            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOperation(Guid operationId)
        {
            if (operationId == Guid.Empty) throw new Exception(message: "Guid is Empty");

            var operation = await _context.Operations.SingleOrDefaultAsync(x => x.Id == operationId);

            if (operation == null) throw new Exception(message: "Operation with such 'Id' doesn't exist");

            _context.Operations.Remove(operation);
            await _context.SaveChangesAsync();
        }

        public async Task<PageViewModel<OperationDTO>> GetOperationsByContainerId(Guid containerId, int page = 1)
        {
            if (containerId == Guid.Empty) throw new Exception(message: "Guid is Empty");
            
            int pageSize = 10;

            IQueryable<Operation> queryOperations = _context.Operations.Where(x => x.ContainerId == containerId);

            PageViewModel<OperationDTO> pageView = new PageViewModel<OperationDTO>(await queryOperations.CountAsync(), page, pageSize);

            queryOperations = queryOperations
                .Skip(10 * (page - 1))
                .Take(10);

            pageView.Items = queryOperations.ToList().Adapt<IReadOnlyCollection<OperationDTO>>();
            return pageView;
        }

        public async Task<PageViewModel<OperationDTO>> GetOperationsList(int page = 1)
        {
            int pageSize = 10;

            IQueryable<Operation> queryOperations = _context.Operations;

            PageViewModel<OperationDTO> pageView = new PageViewModel<OperationDTO>(await queryOperations.CountAsync(), page, pageSize);

            queryOperations = queryOperations
                .Skip(10 * (page - 1))
                .Take(10);

            pageView.Items = queryOperations.ToList().Adapt<IReadOnlyCollection<OperationDTO>>();
            return pageView;
        }

        public async Task UpdateOperation(OperationDTO operationDTO)
        {
            var operation = await _context.Operations.SingleOrDefaultAsync(x => x.Id == operationDTO.Id);
            
            if (operation == null) throw new Exception(message: "Operation with such Id doesn't exist");

            operation.StartDate = operationDTO.StartDate;
            operation.EndDate = operationDTO.EndDate;
            operation.OperationType = operationDTO.OperationType;
            operation.OperatorName = operationDTO.OperatorName;
            operation.InspectionLocation = operationDTO.InspectionLocation;
            operation.ContainerId = operationDTO.ContainerId;

            await _context.SaveChangesAsync();
        }
    }
}

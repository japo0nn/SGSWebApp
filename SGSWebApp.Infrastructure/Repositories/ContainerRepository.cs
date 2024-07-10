using SGSWebApp.Application.Common.DTOs;
using SGSWebApp.Application.Common.Interfaces.Repositories;
using SGSWebApp.Core.Data;
using SGSWebApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Mapster;
using SGSWebApp.Application.Common.Models;

namespace SGSWebApp.Infrastructure.Repositories
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly ApplicationDbContext _context;

        public ContainerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddContainer(ContainerDTO containerDTO)
        {
            Container container = new Container(
                containerDTO.Number,
                containerDTO.Type,
                containerDTO.Length,
                containerDTO.Width,
                containerDTO.Height,
                containerDTO.Weight,
                containerDTO.IsEmpty,
                containerDTO.ArrivalDate
            );

            await _context.Containers.AddAsync(container);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContainer(Guid containerId)
        {
            if (containerId == Guid.Empty) throw new Exception(message: "Guid is Empty");

            var container = await _context.Containers.SingleOrDefaultAsync(x => x.Id == containerId);

            if (container == null) throw new Exception(message: "Container with such Id doesn't exist");

            _context.Containers.Remove(container);
            await _context.SaveChangesAsync();
        }

        public async Task<ContainerDTO> GetContainerById(Guid containerId)
        {
            if (containerId == Guid.Empty) throw new Exception(message: "Guid is Empty");

            var container = await _context.Containers.SingleOrDefaultAsync(x => x.Id == containerId);

            if (container == null) throw new Exception(message: "Container with such Id doesn't exist");

            return container.Adapt<ContainerDTO>();
        }

        public async Task<PageViewModel<ContainerDTO>> GetContainersList(int page = 1)
        {
            int pageSize = 10;

            IQueryable<Container> queryContainers = _context.Containers;

            PageViewModel<ContainerDTO> pageView = new PageViewModel<ContainerDTO>(queryContainers.Count(), page, pageSize);

            queryContainers = queryContainers
                .Skip(10 * (page - 1))
                .Take(10);

            pageView.Items = queryContainers.ToList().Adapt<IReadOnlyCollection<ContainerDTO>>();

            return pageView;
        }

        public async Task UpdateContainer(ContainerDTO containerDTO)
        {
            var container = await _context.Containers.SingleOrDefaultAsync(x => x.Id == containerDTO.Id);

            if (container == null) throw new Exception(message: "Container with such Id doesn't exist");

            container.Number = containerDTO.Number;
            container.ArrivalDate = containerDTO.ArrivalDate;
            container.Height = containerDTO.Height;
            container.Width = containerDTO.Width;
            container.Weight = containerDTO.Weight;
            container.Length = containerDTO.Length;
            container.IsEmpty = containerDTO.IsEmpty;
            container.Type = containerDTO.Type;

            await _context.SaveChangesAsync();
        }
    }
}

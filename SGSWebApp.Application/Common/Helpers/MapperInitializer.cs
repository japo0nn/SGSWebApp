using Mapster;
using SGSWebApp.Application.Common.DTOs;
using SGSWebApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSWebApp.Application.Common.Helpers;
public static class MapperInitializer
{
    public static void Configure()
    {
        TypeAdapterConfig<Container, ContainerDTO>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Number, src => src.Number)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Length, src => src.Length)
            .Map(dest => dest.Width, src => src.Width)
            .Map(dest => dest.Height, src => src.Height)
            .Map(dest => dest.Weight, src => src.Weight)
            .Map(dest => dest.IsEmpty, src => src.IsEmpty)
            .Map(dest => dest.ArrivalDate, src => src.ArrivalDate);

        TypeAdapterConfig<Operation, OperationDTO>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.EndDate, src => src.EndDate)
            .Map(dest => dest.OperationType, src => src.OperationType)
            .Map(dest => dest.OperatorName, src => src.OperatorName)
            .Map(dest => dest.InspectionLocation, src => src.InspectionLocation)
            .Map(dest => dest.ContainerId, src => src.ContainerId);
    }
}

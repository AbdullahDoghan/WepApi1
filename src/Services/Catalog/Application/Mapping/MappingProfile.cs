using Application.Features.Catalog.Commands.CreateNewCatalog;
using Application.Features.Catalog.Commands.UpdateCatalog;
using Application.Features.Catalog.Queries.GetCatalogList;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogEntity, CatalogVm>().ReverseMap();
            CreateMap<CatalogEntity, CreateNewCatalogCommand>().ReverseMap();
            CreateMap<CatalogEntity, UpdateCatalogCommand>().ReverseMap();
        }
    }
}

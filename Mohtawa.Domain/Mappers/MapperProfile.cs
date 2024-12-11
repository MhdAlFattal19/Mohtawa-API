using AutoMapper;
using Mohtawa.Domain.DTOs;
using Mohtawa.Domain.Models;
using Mohtawa.Domain.Requests;

namespace Mohtawa.Domain.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>();
            CreateMap<Book,BookDTO>();
        }
    }
}

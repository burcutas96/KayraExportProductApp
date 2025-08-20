using Entity.Abstract;
using Entity.Dtos;
using System.Security.Principal;

namespace API.Dtos
{
    public class ApiDataResponse<TDto> : ApiResponse where TDto : class, IDto, new()
    {
        public TDto Data { get; set; }
    }
}

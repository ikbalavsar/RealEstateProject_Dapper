using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Models.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();

        void CreatePopularLocation(CreatePopularLocationDto PopularLocationDto);
        void DeletePopularLocation(int id);

        void UpdatePopularLocation(UpdatePopularLocationDto PopularLocationDto);
        Task<GetPopularLocationDto> GetPopularLocation(int id);
    }
}

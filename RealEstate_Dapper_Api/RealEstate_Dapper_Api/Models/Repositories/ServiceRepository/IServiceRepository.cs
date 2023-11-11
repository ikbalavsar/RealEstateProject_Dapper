using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Models.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto serviceDto);
        void DeleteService(int id);

        void UpdateCategory(UpdateServiceDto serviceDto);
        Task<GetByIDServiceDto> GetService(int id);
    }
}

using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Models.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        public readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }
        public async void CreateService(CreateServiceDto serviceDto)
        {
            string query = "insert into Service (ServiceName, ServiceStatus) values (@serviceName, @serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", serviceDto.ServiceName);
            parameters.Add("@serviceStatus", serviceDto.ServiceStatus);
        
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); //Ekleme silme ve güncelleme işlemi için kullandığımız method ExecuteAsync

            }
        }

        public async void DeleteService(int id)
        {
            string query = "Delete From Service Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {

            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query); //listeleme için QueryAsync kullanıyoruz. 
                return values.ToList();
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string query = "Select * From Service Where ServiceID = @serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);

            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateService(UpdateServiceDto serviceDto)
        {
            string query = "Update Service set ServiceName = @serviceName, ServiceStatus = @serviceStatus " +
                          "where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", serviceDto.ServiceName);
            parameters.Add("@serviceStatus", serviceDto.ServiceStatus);
            parameters.Add("@serviceID", serviceDto.ServiceID);
           

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

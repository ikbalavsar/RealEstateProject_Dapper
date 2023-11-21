using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Models.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        public readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto PopularLocationDto)
        {
            string query = "insert into PopularLocation (CityName, ImageUrl) values (@cityName, @imgUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", PopularLocationDto.CityName);
            parameters.Add("@imgUrl", PopularLocationDto.ImageUrl);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); //Ekleme silme ve güncelleme işlemi için kullandığımız method ExecuteAsync

            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocation Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query); //listeleme için QueryAsync kullanıyoruz. 
                return values.ToList();
            }
        }

        public async Task<GetPopularLocationDto> GetPopularLocation(int id)
        {
            string query = "Select * From PopularLocation Where LocationID = @locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);

            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetPopularLocationDto>(query, parameters);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto PopularLocationDto)
        {
            string query = "Update PopularLocation set CityName = @cityName, ImageUrl = @imageUrl " +
                                     "where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", PopularLocationDto.CityName);
            parameters.Add("@imageUrl", PopularLocationDto.ImageUrl);
            parameters.Add("@locationID", PopularLocationDto.LocationID);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

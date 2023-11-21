using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Models.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        public readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }


        public async void CreateBottomGrid(CreateBottomGridDto bottomGridDto)
        {
            string query = "insert into BottomGrid (Icon, Title, Description) values " +
                "(@icon, @title, @description)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@description", bottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); //Ekleme silme ve güncelleme işlemi için kullandığımız method ExecuteAsync

            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridID=@bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query); //listeleme için QueryAsync kullanıyoruz. 
                return values.ToList();
            }
        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridID = @bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridId", id);

            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
        {
            string query = "Update BottomGrid set Icon = @icon, Title = @title, Description= @description " +
                         "where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@description", bottomGridDto.Description);
            parameters.Add("@bottomGridID", bottomGridDto.BottomGridID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

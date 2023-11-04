using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Models.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); //Ekleme silme ve güncelleme işlemi için kullandığımız method ExecuteAsync

            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        { 

            string query = "Select * From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query); //listeleme için QueryAsync kullanıyoruz. 
                return values.ToList();
            }
        
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID = @categoryID"; 
            var parameters = new DynamicParameters();   
            parameters.Add("@categoryID" , id);

            using(var connection = _context.CreateConnection()) {
            
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category set CategoryName = @categoryName, CategoryStatus = @categoryStatus " +
                "where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryId); 

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters); 
            }
        }
    }
}

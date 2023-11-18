using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Models.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async void CreateEmployee(CreateEmployeeDto employeeDto)
        {
            string query = "insert into Employee (Name, Title, Mail, PhoneNumber,ImageUrl, Status) values" +
                " (@name,@title, @mail,@phoneNumber,@imageUrl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", employeeDto.Name);
            parameters.Add("@title", employeeDto.Title);
            parameters.Add("@mail", employeeDto.Mail);
            parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
            parameters.Add("@imageUrl", employeeDto.ImageUrl);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); //Ekleme silme ve güncelleme işlemi için kullandığımız method ExecuteAsync

            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {

            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query); //listeleme için QueryAsync kullanıyoruz. 
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            string query = "Select * From Employee Where EmployeeID = @employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);

            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            string query = "Update Employee set Name = @name, Title = @title , Mail = @mail, PhoneNumber = @phoneNumber, ImageUrl = @imageUrl, Status = @status"  +
                "where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", employeeDto.EmployeeID);
            parameters.Add("@name", employeeDto.Name);
            parameters.Add("@title", employeeDto.Title);
            parameters.Add("@mail", employeeDto.Mail);
            parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
            parameters.Add("@imageUrl", employeeDto.ImageUrl);
            parameters.Add("@status", employeeDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); //Ekleme silme ve güncelleme işlemi için kullandığımız method ExecuteAsync

            }
        }
    }
}

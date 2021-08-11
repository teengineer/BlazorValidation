using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorValidation.Data
{
    public class DataAccessLayer
    {
        public IConfiguration Configuration;
        private const string EMPLOYEE_DATABASE = "employeeDatabase";
        private const string SELECT_EMPLOYEE = "select * from employee";
        public DataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public List<Employee> GetEmployees()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(EMPLOYEE_DATABASE)))
            {
                db.Open();
                IEnumerable<Employee> result = db.Query<Employee>(SELECT_EMPLOYEE);
                return result.ToList();
            }
        }

        public int GetEmployeesCount()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(EMPLOYEE_DATABASE)))
            {
                db.Open();
                int result = db.ExecuteScalar<int>("select count(*) from employee");
                return result;
            }
        }

        public async Task AddEmployeesAsync(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(EMPLOYEE_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("insert into employee (Code, Name, Surname) values (@Code, @Name, @Surname)", employee);
            }
        }

        public async Task UpdateEmployeesAsync(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(EMPLOYEE_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update employee set Code=@Code, Name=@Name, Surname=@Surname where id=@Id", employee);
            }
        }

        public async Task RemoveEmployeesAsync(int employeeId)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(EMPLOYEE_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from employee Where id=@employeeId", new { Id = employeeId });
            }
        }
    }
}

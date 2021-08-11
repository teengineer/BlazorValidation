using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorValidation.Data
{
    public class DataAdaptor
    {
        private DataAccessLayer _dataLayer;
        public DataAdaptor(DataAccessLayer DataAccessLayer)
        {
            _dataLayer = DataAccessLayer;
        }

        public int Read( string key = null)
        {
            List<Employee> bugs = _dataLayer.GetEmployees();
            int count = _dataLayer.GetEmployeesCount();
            return count;
        }
        public Employee Get()
        {
            List<Employee> employees = _dataLayer.GetEmployees();
            return employees.FirstOrDefault();
        }
        //public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        //{
        //    await _dataLayer.AddEmployeesAsync(data as Employee);
        //    return data;
        //}

        //public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        //{
        //    await _dataLayer.UpdateEmployeesAsync(data as Employee);
        //    return data;
        //}

        //public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        //{
        //    await _dataLayer.RemoveEmployeesAsync(Convert.ToInt32(primaryKeyValue));
        //    return primaryKeyValue;
        //}
    }
}

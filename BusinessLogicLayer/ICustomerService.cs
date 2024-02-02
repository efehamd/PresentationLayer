using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BusinessLogicLayer
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        //Task<Customer> GetCustomerByIdAsync(int id);
        //Task<Customer> AddCustomerByNameAsync(Customer customer);
        //Task UpdateCustomerAsync(Customer customer);
        //Task DeleteCustomerAsync(int id);
    }
}

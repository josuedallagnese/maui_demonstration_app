using MauiDemonstrationApp.Core;

namespace MauiDemonstrationApp.Models
{
    public class CustomerRepository
    {
        private readonly DatabaseProvider _databaseProvider;

        public CustomerRepository(DatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            await _databaseProvider.InitAsync();

            var customers = await _databaseProvider.Database
                .Table<Customer>()
                .ToListAsync();

            return customers;
        }

        public async Task<Customer> Get(int id)
        {
            await _databaseProvider.InitAsync();

            var customer = await _databaseProvider.Database
                .Table<Customer>()
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            return customer;
        }

        public async Task<Customer> Add(Customer customer)
        {
            await _databaseProvider.InitAsync();

            await _databaseProvider.Database.InsertAsync(customer);

            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            await _databaseProvider.InitAsync();

            await _databaseProvider.Database.UpdateAsync(customer);

            return customer;
        }

        public async Task<Customer> AddOrUpdate(Customer customer)
        {
            await _databaseProvider.InitAsync();

            if (customer.Id > 0)
                return await Update(customer);

            return await Add(customer);
        }

        public async Task Delete(Customer customer)
        {
            await _databaseProvider.InitAsync();

            await _databaseProvider.Database.DeleteAsync(customer);
        }
    }
}

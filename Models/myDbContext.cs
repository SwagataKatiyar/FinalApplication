using FinalApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalApplication.Data
{
    public class myDbContext : IdentityDbContext<ApplicationClass>
    {
        public myDbContext(DbContextOptions<myDbContext> options) : base(options)
        {

        }

        public DbSet<AccountModel> UsersTable { get; set; }

        public DbSet<EmployeeModel> EmployeesDetails { get; set; }

        public DbSet<FinalApplication.Models.ChangePasswordModel> ChangePasswordModel { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AspNetBoilerPlate.Authorization.Roles;
using AspNetBoilerPlate.Authorization.Users;
using AspNetBoilerPlate.MultiTenancy;

namespace AspNetBoilerPlate.EntityFrameworkCore
{
    public class AspNetBoilerPlateDbContext : AbpZeroDbContext<Tenant, Role, User, AspNetBoilerPlateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AspNetBoilerPlateDbContext(DbContextOptions<AspNetBoilerPlateDbContext> options)
            : base(options)
        {
        }
    }
}

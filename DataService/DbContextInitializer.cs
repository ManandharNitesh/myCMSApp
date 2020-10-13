using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using FunctionalService;
namespace DataService
{
    //always something by default
   public static class DbContextInitializer
    {
        public static async Task Initialize(DataProtectionKeysContext dataProtectionKeysContext, ApplicationDbContext applicationDbContext, IFunctionalSvc functionalSvc)
        {
            //Check if data protection keys Context is created
            //Check if  ApplicationDbContedxt is created

            await dataProtectionKeysContext.Database.EnsureCreatedAsync();
            await applicationDbContext.Database.EnsureCreatedAsync();

            //check  if db contains any user, If DB is not empty , then DB has been already seeded

            if (applicationDbContext.ApplicationUsers.Any())
            {
                return;
            }


            //If empty create Admin and App user
            await functionalSvc.CreateDefaultAdminUser(); //async add await

            await functionalSvc.CreateDefaultUser();

        }
    }
}

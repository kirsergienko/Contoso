
using System.Data.Entity;

namespace Contoso.Models
{
    public class MyDbContext : DbContext
    {

        public DbSet<ByDeviceAndMonth> ByDevicesAndMonths { get; set; }

        public DbSet<LoggedInFromMoreThanOneDevice> LoggedInFromMoreThanOneDevices { get; set; }

        public DbSet<RegistrationByMonth> RegistrationsByMonth { get; set; }

        public DbSet<SessionDuration> SessionsDuration { get; set; }

        public DbSet<SessionForHour> SessionsForHour { get; set; }

        public DbSet<UserWithNewCountry> UsersWithNewCountry { get; set; }
    }

    public class MyDbInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.RegistrationsByMonth.Add(new RegistrationByMonth { Month = "December", NumberOfUsers = 6, Year = 2001 });

            context.RegistrationsByMonth.Add(new RegistrationByMonth { Month = "December", NumberOfUsers = 98, Year = 2001 });

            context.RegistrationsByMonth.Add(new RegistrationByMonth { Month = "December", NumberOfUsers = 98, Year = 1998 });

            context.RegistrationsByMonth.Add(new RegistrationByMonth { Month = "January", NumberOfUsers = 5, Year = 1025 });

            base.Seed(context);
        }
    }
}
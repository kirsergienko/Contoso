
using System;
using System.Collections.Generic;
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

    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.RegistrationsByMonth.AddRange(new List<RegistrationByMonth>
            {
                new RegistrationByMonth { Year = 2020, Month = 8, NumberOfUsers = 13},
                new RegistrationByMonth { Year = 2020, Month = 9, NumberOfUsers = 5},
                new RegistrationByMonth { Year = 2020, Month = 10, NumberOfUsers = 7},
                new RegistrationByMonth { Year = 2021, Month = 1, NumberOfUsers = 9},
                new RegistrationByMonth { Year = 2021, Month = 2, NumberOfUsers = 6},
                new RegistrationByMonth { Year = 2021, Month = 7, NumberOfUsers = 32},
            });
            context.ByDevicesAndMonths.AddRange(new List<ByDeviceAndMonth>
            {
                new ByDeviceAndMonth {Year=2020, Month= 8, DeviceType="Laptop", NumberOfUsers=10},
                new ByDeviceAndMonth {Year=2020, Month= 8, DeviceType="Mobile phone", NumberOfUsers=3},
                new ByDeviceAndMonth {Year=2020, Month= 9, DeviceType="Laptop", NumberOfUsers=5},
                new ByDeviceAndMonth {Year=2021, Month= 7, DeviceType="Laptop", NumberOfUsers=15},
                new ByDeviceAndMonth {Year=2021, Month= 7, DeviceType="Mobile phone", NumberOfUsers=8},
                new ByDeviceAndMonth {Year=2021, Month= 7, DeviceType="Tablet", NumberOfUsers=9},

            });
            context.SessionsForHour.AddRange(new List<SessionForHour>
            {
                new SessionForHour{ Hour = DateTime.Parse("2021-07-01 13:00:00"), MaxSessions = 3 },
                new SessionForHour{ Hour = DateTime.Parse("2021-07-01 14:00:00"), MaxSessions = 23 },
                new SessionForHour{ Hour = DateTime.Parse("2021-07-01 15:00:00"), MaxSessions = 19 },
                new SessionForHour{ Hour = DateTime.Parse("2021-07-01 16:00:00"), MaxSessions = 10 },
                new SessionForHour{ Hour = DateTime.Parse("2021-07-01 17:00:00"), MaxSessions = 15 },
                new SessionForHour{ Hour = DateTime.Parse("2021-07-01 18:00:00"), MaxSessions = 8 },
            });
            context.LoggedInFromMoreThanOneDevices.AddRange(new List<LoggedInFromMoreThanOneDevice>
            {
                  new LoggedInFromMoreThanOneDevice { UserName = "John Doe", DeviceName = "John's Laptop",
                  LoginTime = DateTime.Parse("2021-07-01 17:35:18")},
                  new LoggedInFromMoreThanOneDevice {UserName = "John Doe", DeviceName = "John's Mobile phone",
                  LoginTime = DateTime.Parse("2021-07-01 17:55:47")},
                  new LoggedInFromMoreThanOneDevice {UserName = "Kathy Johnson", DeviceName = "My Macbook",
                  LoginTime = DateTime.Parse("2021-07-01 18:11:23")},
                  new LoggedInFromMoreThanOneDevice {UserName = "Kathy Johnson", DeviceName = "My IPhone",
                  LoginTime = DateTime.Parse("2021-07-01 18:13:26")},
                  new LoggedInFromMoreThanOneDevice {UserName = "Kathy Johnson", DeviceName = "My IPad",
                  LoginTime = DateTime.Parse("2021-07-01 18:29:31")},
            });
            context.SessionsDuration.AddRange(new List<SessionDuration>
            {
                new SessionDuration { Date = DateTime.Parse("2021-06-29"), Hour = 0,
                    DurationInMinutes = 500, TotalDuration= 500},
                new SessionDuration { Date = DateTime.Parse("2021-06-29"), Hour = 1,
                    DurationInMinutes = 342, TotalDuration= 842},
                new SessionDuration { Date = DateTime.Parse("2021-06-29"), Hour = 2,
                    DurationInMinutes = 100, TotalDuration= 942},
                new SessionDuration { Date = DateTime.Parse("2021-06-29"), Hour = 23,
                    DurationInMinutes = 154, TotalDuration= 15643},
                new SessionDuration { Date = DateTime.Parse("2021-06-30"), Hour = 0,
                    DurationInMinutes = 100, TotalDuration= 100},
                new SessionDuration { Date = DateTime.Parse("2021-06-30"), Hour = 1,
                    DurationInMinutes = 200, TotalDuration= 300},
                new SessionDuration { Date = DateTime.Parse("2021-07-01"), Hour = 0,
                    DurationInMinutes = 450, TotalDuration= 450},
                new SessionDuration { Date = DateTime.Parse("2021-07-01"), Hour = 1,
                    DurationInMinutes = 200, TotalDuration= 650},
                new SessionDuration { Date = DateTime.Parse("2021-07-01"), Hour = 18,
                    DurationInMinutes = 100, TotalDuration= 21350},
            });
            context.UsersWithNewCountry.AddRange(new List<UserWithNewCountry>
            {
                new UserWithNewCountry { UserName = "John Doe", Country = "Switzerland",
                LoginTime = DateTime.Parse("2021-07-01 17:35:18")},
                new UserWithNewCountry { UserName = "Kathy Johnson", Country = "Turkey",
                LoginTime = DateTime.Parse("2021-07-01 18:11:23")},
            });
            base.Seed(context);
        }
    }
}
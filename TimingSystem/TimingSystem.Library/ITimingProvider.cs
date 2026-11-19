using Microsoft.EntityFrameworkCore;
using TimingSystem.Library.Tables;

namespace TimingSystem.Library
{
    public interface ITimingProvider
    {
        public Task<Time> Start(int driverNum);

        public Task<Time> Stop(Time currentRun, int cones, bool dnf);
    }

    public class TimingProvider(TimingSystemDbContext db) : ITimingProvider
    {
        private readonly TimingSystemDbContext db = db;

        public async Task<Time> Start(int driverNum)
        {
            return new Time
            {
                DriverKey = (await db.Drivers.FirstAsync(_ => _.Number == driverNum)).DriverKey
            };
        }

        public async Task<Time> Stop(Time currentRun, int cones, bool dnf)
        {
            currentRun.Cones = cones;
            currentRun.Dnf = dnf;
            db.Add(currentRun);
            await db.SaveChangesAsync();
            return currentRun;
        }
    }
}

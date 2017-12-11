using Dashboard.Logic.DbModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.Logic.Repository
{
    public class LogInfoRepository
    {
        private DashboardContext Context { get; set; }

        public LogInfoRepository(DashboardContext dashboardContext)
        {
            Context = dashboardContext;
        }

        public async Task<IEnumerable<LogInfo>> GetAll()
        {
            return await Context.LogInfo.AsNoTracking().ToListAsync();
        }

        public async Task<LogInfo> Get(int id)
        {
            return await Context.LogInfo.FindAsync(id);
        }

        public async Task<int> Insert(LogInfo info)
        {
            await Context.AddAsync(info);
            return info.Id;
        }
    }
}

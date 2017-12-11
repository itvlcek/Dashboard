using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Logic.Repository;
using Dashboard.Shared.Model;
using Dashboard.ViewModel;
using Dashboard.Converters;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Dashboard.Controllers
{
    [Produces("application/json")]
    [Route("api/Data")]
    [Authorize]
    public class DataController : Controller
    {
        private LogInfoRepository LogInfoRepository { get; set; }

        private LogInfoConverter LogInfoConverter { get; set; }

        public DataController(LogInfoRepository logInfoRepository, LogInfoConverter converter)
        {
            LogInfoRepository = logInfoRepository;
            LogInfoConverter = converter;
        }

        // GET: api/Data
        [HttpGet]
        public async Task<IEnumerable<LogInfoViewModel>> Get()
        {
            return (await LogInfoRepository.GetAll()).Select(LogInfoConverter.Convert); 
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<LogInfoViewModel> Get(int id)
        {
            return LogInfoConverter.Convert(await LogInfoRepository.Get(id));
        }
        
        // POST: api/Data
        [HttpPost]
        public async Task Post([FromBody]LogObject log)
        {
            await LogInfoRepository.Insert(LogInfoConverter.Convert(log));
        }
    }
}

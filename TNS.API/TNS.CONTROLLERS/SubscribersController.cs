using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNS.API.TNS.DTO;
using TNS.Database;

namespace TNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly PostgresContext _context;

        public SubscribersController(PostgresContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscriber(SubscriberDTO subscriberDTO) 
        {
        
        }
    }
}

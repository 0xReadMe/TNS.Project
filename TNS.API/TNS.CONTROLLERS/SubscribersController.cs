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
        private readonly SubscriberService _subscriberService;

        public SubscriberController(SubscriberService subscriberService) 
        {
            _subscriberService = subscriberService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscriber(SubscriberDTO subscriberDTO) 
        {
            
        }
    }
}

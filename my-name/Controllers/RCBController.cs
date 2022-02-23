using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_name.Data.Services;
using my_name.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_name.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RCBController : ControllerBase
    {
        public RCBService _rcbService;
        public RCBController(RCBService rcbService)
        {
            _rcbService = rcbService;
        }

        [HttpPost("add-RCB")]
        public IActionResult AddRCB([FromBody]RCBVM rcb)
        {
            _rcbService.AddRCB(rcb);
            return Ok();
        }

        [HttpGet("get-RCB")]
        public IActionResult GetRCB()
        {
            var allRCB=_rcbService.GetRCB();
            return Ok(allRCB);
        }

        [HttpGet("get-RCB/{id}")]
        public IActionResult GetRCBbyId(int id)
        {
            var rcb = _rcbService.GetRCBbyId(id);
            return Ok(rcb);
        }

        [HttpPut("update-RCB/{id}")]
        public IActionResult UpdateRCB(int id,[FromBody]RCBVM rcb)
        {
            _rcbService.UpdateRCB(id, rcb);
            return Ok();
        }

        [HttpDelete("delete-RCB/{id}")]
        public IActionResult DeleteRCB(int id)
        {
            _rcbService.DeleteRCB(id);
            return Ok();
        }

    }
}

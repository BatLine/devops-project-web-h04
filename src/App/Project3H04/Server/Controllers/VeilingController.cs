using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Project3H04.Shared.DTO;
using Project3H04.Shared.Veilingen;

namespace Project3H04.Server.Controllers {
    //TODO: [Authorize] overal toevoegen?
    [AllowAnonymous]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class VeilingController : ControllerBase {
        private readonly IVeilingService _veilingService;

        public VeilingController(IVeilingService veilingService) {
            this._veilingService = veilingService;
        }

        [HttpGet("{id}"), ActionName("Get")]
        public Task<Veiling_DTO> Get(int id) {
            return _veilingService.GetVeilingById(id);
        }

        [HttpPut("{id}"), ActionName("AddBodToVeiling")]
        public Task<bool> AddBodToVeiling(int veilingId, Bod_DTO bod) {
            return _veilingService.AddBodToVeiling(bod, veilingId);
        }

        [HttpPut("{id}"), ActionName("AddBodToKunstwerk")]
        public Task<bool> AddBodToKunstwerk(int kunstwerkId, Bod_DTO bod) {
            return _veilingService.AddBodToKunstwerk(bod, kunstwerkId);
        }

        [HttpPost, ActionName("Create")]
        public Task<bool> Create(Veiling_DTO veiling) {
            return _veilingService.CreateVeiling(veiling);
        }
    }
}

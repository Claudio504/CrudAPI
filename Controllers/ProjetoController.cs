using Microsoft.AspNetCore.Mvc;
using WebAPI_CrudTarget.Models;
using WebAPI_CrudTarget.Service.ProjetoService;

namespace WebAPI_CrudTarget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoInterface _projetoInterface;
        public ProjetoController(IProjetoInterface projetoInterface)
        {
            _projetoInterface = projetoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> GetProjetos()
        {
            return Ok( await _projetoInterface.GetProjetos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProjetoModel>>> GetProjetoById(int id)
        {
            ServiceResponse<ProjetoModel> serviceResponse = await _projetoInterface.GetProjetoById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> CreateProjeto(ProjetoModel novoProjeto)
        {
            return Ok(await _projetoInterface.CreateProjeto(novoProjeto));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> UpdateProjeto(ProjetoModel editadoProjeto)
        {
            ServiceResponse<List<ProjetoModel>> serviceResponse = await _projetoInterface.UpdateProjeto(editadoProjeto);

            return Ok(serviceResponse);
        }


        [HttpPut("inativaProjeto/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> InativaProjeto(int id)
        {
            ServiceResponse<List<ProjetoModel>> serviceResponse = await _projetoInterface.InativaProjeto(id);

            return Ok(serviceResponse);

        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> DeleteProjeto(int id)
        {
            ServiceResponse<List<ProjetoModel>> serviceResponse = await _projetoInterface.DeleteProjeto(id);

            return Ok(serviceResponse);

        }

    }
}

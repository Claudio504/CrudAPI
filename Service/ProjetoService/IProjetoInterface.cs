using WebAPI_CrudTarget.Models;

namespace WebAPI_CrudTarget.Service.ProjetoService
{
    public interface IProjetoInterface
    {
        Task<ServiceResponse<List<ProjetoModel>>> GetProjetos();
        Task<ServiceResponse<List<ProjetoModel>>> CreateProjeto(ProjetoModel novoProjeto);
        Task<ServiceResponse<ProjetoModel>> GetProjetoById(int id);
        Task<ServiceResponse<List<ProjetoModel>>> UpdateProjeto(ProjetoModel editadoProjeto);
        Task<ServiceResponse<List<ProjetoModel>>> DeleteProjeto(int id);
        Task<ServiceResponse<List<ProjetoModel>>> InativaProjeto(int id);
    }
}

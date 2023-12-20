using Microsoft.EntityFrameworkCore;
using WebAPI_CrudTarget.DataContext;
using WebAPI_CrudTarget.Models;

namespace WebAPI_CrudTarget.Service.ProjetoService
{
    public class ProjetoService : IProjetoInterface
    {
        private readonly ApplicationDbContext _context;
        public ProjetoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProjetoModel>>> CreateProjeto(ProjetoModel novoProjeto)
        {
            ServiceResponse<List<ProjetoModel>> serviceResponse = new ServiceResponse<List<ProjetoModel>>();

            try
            {
                if(novoProjeto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novoProjeto.DataDeCriacao = DateTime.Now.ToLocalTime();
                novoProjeto.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Add(novoProjeto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Projetos.ToList();


            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProjetoModel>>> DeleteProjeto(int id)
        {
            ServiceResponse<List<ProjetoModel>> serviceResponse = new ServiceResponse<List<ProjetoModel>>();

            try
            {
                ProjetoModel projeto = _context.Projetos.FirstOrDefault(x => x.Id == id);

                if (projeto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Projeto não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Projetos.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ProjetoModel>> GetProjetoById(int id)
        {
            ServiceResponse<ProjetoModel> serviceResponse = new ServiceResponse<ProjetoModel>();

            try
            {
                ProjetoModel projeto = _context.Projetos.FirstOrDefault(x => x.Id == id);

                if(projeto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Projeto não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = projeto;

            }
            catch(Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProjetoModel>>> GetProjetos()
        {
            ServiceResponse<List<ProjetoModel>> serviceResponse = new ServiceResponse<List<ProjetoModel>>();

            try
            {
                serviceResponse.Dados = _context.Projetos.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }catch(Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<ProjetoModel>>> InativaProjeto(int id)
        {
            ServiceResponse<List<ProjetoModel>> serviceResponse = new ServiceResponse<List<ProjetoModel>>();

            try
            {
                ProjetoModel projeto = _context.Projetos.FirstOrDefault(x => x.Id == id);

                if(projeto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Projeto não localizado!";
                    serviceResponse.Sucesso = false;
                } else
                {
                    projeto.Ativo = false;
                    projeto.DataDeAlteracao = DateTime.Now.ToLocalTime();

                    _context.Projetos.Update(projeto);
                    await _context.SaveChangesAsync();
                    serviceResponse.Dados = _context.Projetos.ToList();
                }

            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProjetoModel>>> UpdateProjeto(ProjetoModel editadoProjeto)
        {
            ServiceResponse<List<ProjetoModel>> serviceResponse = new ServiceResponse<List<ProjetoModel>>();

            try
            {
                ProjetoModel projeto = _context.Projetos.AsNoTracking().FirstOrDefault(x => x.Id == editadoProjeto.Id);

                if (projeto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Projeto não localizado!";
                    serviceResponse.Sucesso = false;
                }


                projeto.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Projetos.Update(editadoProjeto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Projetos.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}

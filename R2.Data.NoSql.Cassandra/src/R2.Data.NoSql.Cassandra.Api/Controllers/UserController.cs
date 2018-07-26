using Microsoft.AspNetCore.Mvc;
using R2.Data.NoSql.Cassandra.Api.Domain.Interface;
using R2.Data.NoSql.Cassandra.Api.Domain.Model;
using System;
using System.Threading.Tasks;

namespace R2.Data.NoSql.Cassandra.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : BaseController
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Response(await _repository.Executar("SELECT * FROM usuario;"));
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Response(await _repository.Executar($"SELECT * FROM usuario WHERE id = {id};"));
        }

        [HttpPost]
        public IActionResult Post([FromBody]User value)
        {
            try
            {
                if (value == null)
                    return Response(null, new Exception("Requisicao invalida!"));

                _repository.Executar(
                    "INSERT INTO usuario (id, nome) values (?, ?)",
                    new object[] { value.Id, value.Nome });

                return Response(value);
            }
            catch (Exception e)
            {
                return Response(null, e);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value) || id == Guid.Empty)
                    return Response(null, new Exception("Requisição inválida!"));

                _repository.Executar(
                    "UPDATE usuario SET nome = ? WHERE id = ?",
                    new object[] { value, id });

                return Response(value);
            }
            catch (Exception e)
            {
                return Response(null, e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _repository.Executar(
                    "DELETE FROM usuario WHERE id = ?",
                    new object[] { id });

                return Response(id);
            }
            catch (Exception e)
            {
                return Response(null, e);
            }
        }
    }
}
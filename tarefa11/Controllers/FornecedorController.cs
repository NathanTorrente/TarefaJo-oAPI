using API___Tarefa1.Models;
using API___Tarefa1.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API___Tarefa1.Controllers
{
    [Route("fornecedores")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly List<Fornecedor> listaFornecedores = new List<Fornecedor>();
        public FornecedorController()
        {
            if (!listaFornecedores.Any())
            {
                listaFornecedores.Add(new Fornecedor
                {
                   
                    NomeFantasia = "Nathan",
                    RazaoSocial = "Empresa",
                    CNPJ = "Masculino",
                    Endereco = "Rua Castelo Branco"
                });

                listaFornecedores.Add(new Fornecedor
                {
                    NomeFantasia = "João",
                    RazaoSocial = "EmpresaX",
                    CNPJ = "Masculino",
                });
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaFornecedores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var fornecedor = listaFornecedores.FirstOrDefault(f => f.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FornecedorDTO fornecedorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoFornecedor = new Fornecedor
            {
                Id = Guid.NewGuid(),
                NomeFantasia = fornecedorDTO.NomeFantasia,
                RazaoSocial = fornecedorDTO.RazaoSocial,
                CNPJ = fornecedorDTO.CNPJ,
                Endereco = fornecedorDTO.Endereco,
                Cidade = fornecedorDTO.Cidade,
                Estado = fornecedorDTO.Estado,
                Telefone = fornecedorDTO.Telefone,
                Email = fornecedorDTO.Email,
                Responsavel = fornecedorDTO.Responsavel
            };

            listaFornecedores.Add(novoFornecedor);

            return StatusCode(StatusCodes.Status201Created, novoFornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] FornecedorDTO fornecedorDTO)
        {
            var fornecedorExistente = listaFornecedores.FirstOrDefault(f => f.Id == id);

            if (fornecedorExistente == null)
            {
                return NotFound();
            }

            fornecedorExistente.NomeFantasia = fornecedorDTO.NomeFantasia;
            fornecedorExistente.RazaoSocial = fornecedorDTO.RazaoSocial;
            fornecedorExistente.CNPJ = fornecedorDTO.CNPJ;
            fornecedorExistente.Endereco = fornecedorDTO.Endereco;
            fornecedorExistente.Cidade = fornecedorDTO.Cidade;
            fornecedorExistente.Estado = fornecedorDTO.Estado;
            fornecedorExistente.Telefone = fornecedorDTO.Telefone;
            fornecedorExistente.Email = fornecedorDTO.Email;
            fornecedorExistente.Responsavel = fornecedorDTO.Responsavel;

            return Ok(fornecedorExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var fornecedor = listaFornecedores.FirstOrDefault(f => f.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            listaFornecedores.Remove(fornecedor);
            return Ok(fornecedor);
        }
    }
}

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
                    Id = 1,
                    NomeFantasia = "DentalFocus",
                    RazaoSocial = "Bradent",
                    CNPJ = "23.131.878/0001-61",
                    Endereco = "Rua João de Oliveira",
                    Cidade = "Ouro Preto do Oeste",
                    Estado = "Rondônia",
                    Telefone = "(69) 99359-3403",
                    Email = "nathanrocha749@gmail.com",
                    Responsavel = "Nathan"                
               
                });

                listaFornecedores.Add(new Fornecedor
                {
                    Id = 2,
                    NomeFantasia = "UNIClinica",
                    RazaoSocial = "DentCler",
                    CNPJ = "61.626.022/0001-56",
                    Endereco = "R. Café Filho, 68 - União",
                    Cidade = "Ouro Preto do Oeste",
                    Estado = "Rondônia",
                    Telefone = "(69) 3461-1475",
                    Email = "uniclinica3237@gmail.com",
                    Responsavel = "Riviane"
                });
            }
        }


        [HttpGet]           // GET
        public IActionResult Get()
        {
            return Ok(listaFornecedores);
        }

        [HttpGet("{id}")]       // GET com ID
        public IActionResult GetById(int id)
        {
            var fornecedor = listaFornecedores.FirstOrDefault(f => f.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        [HttpPost]          //POST
        public IActionResult Post([FromBody] FornecedorDTO fornecedorDTO)
        {
            

            var novoFornecedor = new Fornecedor
            {
                Id = fornecedorDTO.Id,
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

        [HttpPut("{id}")]           //PUT
        public IActionResult Put(int id, [FromBody] FornecedorDTO fornecedorDTO)
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

        [HttpDelete("{id}")]    // DELETE
        public IActionResult Delete(int id)
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

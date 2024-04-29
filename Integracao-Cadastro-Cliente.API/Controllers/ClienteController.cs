using Integracao_Cadastro_Cliente.API.Repositories;
using Integracao_Cadastro_Cliente.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integracao_Cadastro_Cliente.API.DTOs;

namespace Integracao_Cadastro_Cliente.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly IClienteRepository _repo;
		private readonly ILogradouroRepository _logradouro_repo;
		private readonly IClientLogradouroRepository _cli_logr_repo;

		public ClienteController(
			IClienteRepository clienteRepository,
			ILogradouroRepository logradouroRepository,
			IClientLogradouroRepository cli_logr_repo
			)
		{
			_repo = clienteRepository;
			_logradouro_repo = logradouroRepository;
			_cli_logr_repo = cli_logr_repo;
		}
		// GET: api/<ClienteController>
		[HttpGet]
		public ActionResult<List<ClienteDTO>> Listar_Todos_Clientes()
		{


			var clientes = _repo.GetClientWithAddress();

			var query_clientes = new List<ClienteDTO>();
			var query_logradouro = new List<EnderecoDTO>();

			var endereco = new EnderecoDTO();

			foreach (var cliente in clientes)
			{
				var cliente_dto = new ClienteDTO();
				cliente_dto.Id = cliente.Id;
				cliente_dto.Email = cliente.Email;
				cliente_dto.Nome = cliente.Nome;



				if (cliente.ClienteLogradouros.Count != 0)
				{
					foreach (var item in cliente.ClienteLogradouros)
					{

						var pesquisa_informacoes_logradouro = _logradouro_repo.FindOne(item.ClienteId);

						endereco.Cidade = pesquisa_informacoes_logradouro.Cidade;
						endereco.Complemento = pesquisa_informacoes_logradouro.Complemento;
						endereco.Endereco = pesquisa_informacoes_logradouro.Endereco;
						endereco.Estado = pesquisa_informacoes_logradouro.Estado;
						endereco.Numero = pesquisa_informacoes_logradouro.Numero;

						cliente_dto.Logradouros.Add(endereco);
					}
				}

				query_clientes.Add(cliente_dto);
			}
			return Ok(query_clientes);

		}

		// GET api/<ClienteController>/5
		[HttpGet("{id}")]
		public ActionResult<ClienteDTO> Exibir_Cliente(long id)
		{

			var cliente = _repo.Get(id);
			var cliente_dto = new ClienteDTO();
			var endereco = new EnderecoDTO();

			cliente_dto.Id = cliente.Id;
			cliente_dto.Email = cliente.Email;
			cliente_dto.Nome = cliente.Nome;

			if (cliente.ClienteLogradouros.Count != 0)
				foreach (var item in cliente.ClienteLogradouros)
				{
					var pesquisa_informacoes_logradouro = _logradouro_repo.FindOne(item.ClienteId);

					endereco.Cidade = pesquisa_informacoes_logradouro.Cidade;
					endereco.Complemento = pesquisa_informacoes_logradouro.Complemento;
					endereco.Endereco = pesquisa_informacoes_logradouro.Endereco;
					endereco.Estado = pesquisa_informacoes_logradouro.Estado;
					endereco.Numero = pesquisa_informacoes_logradouro.Numero;

					cliente_dto.Logradouros.Add(endereco);
				}

			return Ok(cliente_dto);
		}


		// POST api/<ClienteController>
		[HttpPost]
		public ActionResult<ClienteDTO> Registrar([FromBody] ClienteDTO clienteRq)
		{
			if (clienteRq.Email != null)
			{
				var check_email_already_registered =
					_repo.CheckIfEmailAlreadyExists(clienteRq.Email);

				if (clienteRq != null)
				{
					if (!check_email_already_registered)
					{
						var novo_registro = new Cliente();


						novo_registro.Email = clienteRq.Email;
						novo_registro.Nome = clienteRq.Nome;

						_repo.Create(novo_registro);
						_repo.Save();

						long novo_registro_id = novo_registro.Id;
						long novo_endereco_id = 0;

						foreach (var item in clienteRq.Logradouros)
						{
							var novo_endereco = new Logradouro();
							novo_endereco.Cidade = item.Cidade;
							novo_endereco.Complemento = item.Complemento;
							novo_endereco.Endereco = item.Endereco;
							novo_endereco.Numero = item.Numero;

							_logradouro_repo.Create(novo_endereco);
							_logradouro_repo.Save();

							novo_endereco_id = novo_endereco.LogradouroId;
						}

						_cli_logr_repo.CreateRelations(novo_registro,novo_registro_id, novo_endereco_id);

						return Ok(novo_registro);

					}
				}


			}
			return BadRequest();
		}

			
		// PUT api/<ClienteController>/5
		[HttpPut("editar/{Id}")]
		public ActionResult<ClienteDTO> Alterar(long id, [FromBody] ClienteAlterarDTO clienteRq)
		{
			var pesquisa_cliente = _repo.Get(id);

			if(pesquisa_cliente== null)
			{
				return NotFound();
			}

			var dados_alterar = new Cliente();
			dados_alterar.Nome	= clienteRq.Nome;
			dados_alterar.Email = clienteRq.Email;

			_repo.Create(dados_alterar);
			_repo.Save();

			return Ok(dados_alterar);

		}
		
		
		// DELETE api/<ClienteController>/5
		[HttpDelete("excluir/{id}")]
		public ActionResult<string> Delete(long id)
		{
			var pesquisa_cliente = _repo.Get(id);

			if (pesquisa_cliente == null)
			{
				return NotFound("Cliente não encontrado");
			}

			var cliente_excluir = pesquisa_cliente;

			_repo.Delete(cliente_excluir);
			_repo.Save();

			return Ok("Cliente Excluido");
		} 
		
		
	}
}

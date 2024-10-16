using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Enums;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FinancasApp.Domain.Services
{
    public class ContaDomainService : IContaDomainService
    {
        private readonly IContaRepository _contaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ContaDomainService(IContaRepository contaRepository, ICategoriaRepository categoriaRepository)
        {
            _contaRepository = contaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public ContaResponseDto Criar(ContaRequestDto dto, Guid usuarioId)
        {
            var categoria = _categoriaRepository.GetById(dto.CategoriaId.Value, usuarioId);
            if (categoria == null)
                throw new ApplicationException("Categoria não encontrada para inclusão de conta.");

            var conta = new Conta
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Data = dto.Data,
                Valor = dto.Valor,
                Tipo = dto.Tipo == 1 ? TipoConta.Receber : dto.Tipo == 2 ? TipoConta.Pagar : null,
                CategoriaId = dto.CategoriaId,
                UsuarioId = usuarioId
            };

            _contaRepository.Add(conta);

            return new ContaResponseDto
            {
                Id = conta.Id,
                Nome = conta.Nome,
                Data = conta.Data,
                Valor = conta.Valor,
                Tipo = (int) conta.Tipo,
                Categoria = new CategoriaResponseDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                }
            };
        }

        public ContaResponseDto Alterar(Guid id, ContaRequestDto dto, Guid usuarioId)
        {
            var categoria = _categoriaRepository.GetById(dto.CategoriaId.Value, usuarioId);
            if (categoria == null)
                throw new ApplicationException("Categoria não encontrada para edição de conta.");

            var conta = _contaRepository.GetById(id, usuarioId);
            if (conta == null)
                throw new ApplicationException("Conta não encontrada para edição.");

            conta.Nome = dto.Nome;
            conta.Data = dto.Data;
            conta.Valor = dto.Valor;
            conta.Tipo = dto.Tipo == 1 ? TipoConta.Receber : dto.Tipo == 2 ? TipoConta.Pagar : null;
            conta.CategoriaId = dto.CategoriaId;

            _contaRepository.Update(conta);

            return new ContaResponseDto
            {
                Id = conta.Id,
                Nome = conta.Nome,
                Data = conta.Data,
                Valor = conta.Valor,
                Tipo = (int)conta.Tipo,
                Categoria = new CategoriaResponseDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                }
            };
        }

        public ContaResponseDto Excluir(Guid id, Guid usuarioId)
        {
            var conta = _contaRepository.GetById(id, usuarioId);
            if (conta == null)
                throw new ApplicationException("Conta não encontrada para exclusão.");

            _contaRepository.Delete(conta);

            return new ContaResponseDto
            {
                Id = conta.Id,
                Nome = conta.Nome,
                Data = conta.Data,
                Valor = conta.Valor,
                Tipo = (int)conta.Tipo,
                Categoria = new CategoriaResponseDto
                {
                    Id = conta.Categoria.Id,
                    Nome = conta.Categoria.Nome
                }
            };
        }

        public List<ContaResponseDto> Consultar(Guid usuarioId, DateTime dataMin, DateTime dataMax)
        {
            var lista = new List<ContaResponseDto>();

            foreach (var item in _contaRepository.GetAll(usuarioId, dataMin, dataMax))
            {
                lista.Add(new ContaResponseDto 
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Data = item.Data,
                    Valor = item.Valor,
                    Tipo = (int)item.Tipo,
                    Categoria = new CategoriaResponseDto
                    {
                        Id = item.Categoria.Id,
                        Nome = item.Categoria.Nome
                    }
                });
            }

            return lista;
        }

        public ContaResponseDto? ObterPorId(Guid id, Guid usuarioId)
        {
            var conta = _contaRepository.GetById(id, usuarioId);
            if (conta == null)
                throw new ApplicationException("Conta não encontrada.");

            return new ContaResponseDto
            {
                Id = conta.Id,
                Nome = conta.Nome,
                Data = conta.Data,
                Valor = conta.Valor,
                Tipo = (int)conta.Tipo,
                Categoria = new CategoriaResponseDto
                {
                    Id = conta.Categoria.Id,
                    Nome = conta.Categoria.Nome
                }
            };
        }
    }
}

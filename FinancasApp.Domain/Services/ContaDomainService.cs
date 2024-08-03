using AutoMapper;
using FinancasApp.Domain.Dtos;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    /// <summary>
    /// Classe para implementar os serviços de domínio da entidade da conta
    /// </summary>
    public class ContaDomainService : IContaDomainService
    {
        private readonly IContaRepository? _contaRepository;
        private readonly IMapper? _mapper;

        public ContaDomainService(IContaRepository? contaRepository, IMapper? mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public ContaResponseDto? Criar(ContaRequestDto dto)
        {
            var conta = _mapper?.Map<Conta>(dto);

            var contaValidation = new ContaValidation();
            var result = contaValidation.Validate(conta);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _contaRepository?.Add(conta);

            return _mapper?.Map<ContaResponseDto>(conta);            
        }

        public ContaResponseDto? Alterar(Guid id, ContaRequestDto dto)
        {
            var conta = _contaRepository?.GetById(id);

            if (conta == null)
                throw new InvalidOperationException("Conta não encontrada.");

            conta.Nome = dto.Nome;
            conta.Valor = dto.Valor;
            conta.Data = dto.Data;
            conta.Descricao = dto.Descricao;
            conta.Tipo = (TipoConta?) dto.Tipo;

            var contaValidation = new ContaValidation();
            var result = contaValidation.Validate(conta);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _contaRepository?.Update(conta);

            return _mapper?.Map<ContaResponseDto>(conta);
        }

        public ContaResponseDto? Excluir(Guid id)
        {
            var conta = _contaRepository?.GetById(id);

            if (conta == null)
                throw new InvalidOperationException("Conta não encontrada.");

            _contaRepository?.Delete(conta);

            return _mapper?.Map<ContaResponseDto>(conta);
        }

        public List<ContaResponseDto>? Consultar(DateTime dataMin, DateTime dataMax)
        {
            var contas = _contaRepository?.Get(dataMin, dataMax);
            return _mapper?.Map<List<ContaResponseDto>>(contas);
        }

        public ContaResponseDto? ObterPorId(Guid id)
        {
            var conta = _contaRepository?.GetById(id);
            return _mapper?.Map<ContaResponseDto>(conta);
        }
    }
}

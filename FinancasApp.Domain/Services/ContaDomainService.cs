using AutoMapper;
using FinancasApp.Domain.Contracts.Repositories;
using FinancasApp.Domain.Contracts.Services;
using FinancasApp.Domain.Models.Dtos;
using FinancasApp.Domain.Models.Entities;
using FinancasApp.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    public class ContaDomainService : IContaDomainService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ContaDomainService(IContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public ContaResponseDto Criar(ContaRequestDto request, Guid usuarioId)
        {
            var conta = _mapper.Map<Conta>(request);
            conta.Id = Guid.NewGuid();
            conta.UsuarioId = usuarioId;

            _contaRepository.Add(conta);

            var response = _mapper.Map<ContaResponseDto>(conta);
            return response;
        }

        public ContaResponseDto Alterar(Guid id, ContaRequestDto request)
        {
            var conta = _contaRepository.GetById(id);
            if (conta == null)
                throw new ApplicationException("Conta não encontrada. Verifique o ID informado.");

            conta.Nome = request.Nome;
            conta.Data = request.Data;
            conta.Valor = request.Valor;
            conta.Tipo = (TipoConta) request.Tipo;

            _contaRepository.Update(conta);

            var response = _mapper.Map<ContaResponseDto>(conta);
            return response;
        }

        public ContaResponseDto Excluir(Guid id)
        {
            var conta = _contaRepository.GetById(id);
            if (conta == null)
                throw new ApplicationException("Conta não encontrada. Verifique o ID informado.");

            _contaRepository.Delete(conta);

            var response = _mapper.Map<ContaResponseDto>(conta);
            return response;
        }

        public List<ContaResponseDto> Consultar(DateTime dataMin, DateTime dataMax, Guid usuarioId)
        {
            var contas = _contaRepository.GetByDatas(dataMin, dataMax, usuarioId);

            var response = _mapper.Map<List<ContaResponseDto>>(contas);
            return response;
        }

        public ContaResponseDto? ObterPorId(Guid id)
        {
            var conta = _contaRepository.GetById(id);

            var response = _mapper.Map<ContaResponseDto>(conta);
            return response;
        }
    }
}

using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    public class CategoriaDomainService : ICategoriaDomainService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaDomainService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public CategoriaResponseDto Criar(CategoriaRequestDto dto, Guid usuarioId)
        {
            var categoria = new Categoria
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                UsuarioId = usuarioId
            };

            _categoriaRepository.Add(categoria);
            
            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }

        public CategoriaResponseDto Alterar(Guid id, CategoriaRequestDto dto, Guid usuarioId)
        {
            var categoria = _categoriaRepository.GetById(id, usuarioId);
            if (categoria == null)
                throw new ApplicationException("Categoria não encontrada para edição.");

            categoria.Nome = dto.Nome;

            _categoriaRepository.Update(categoria);

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }

        public CategoriaResponseDto Excluir(Guid id, Guid usuarioId)
        {
            var categoria = _categoriaRepository.GetById(id, usuarioId);
            if (categoria == null)
                throw new ApplicationException("Categoria não encontrada para exclusão.");

            _categoriaRepository.Delete(categoria);

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }

        public List<CategoriaResponseDto> Consultar(Guid usuarioId)
        {
            var lista = new List<CategoriaResponseDto>();

            foreach (var item in _categoriaRepository.GetAll(usuarioId))
            {
                lista.Add(new CategoriaResponseDto
                {
                    Id = item.Id,
                    Nome = item.Nome
                });
            }

            return lista;
        }

        public CategoriaResponseDto? ObterPorId(Guid id, Guid usuarioId)
        {
            var categoria = _categoriaRepository.GetById(id, usuarioId);
            if (categoria == null)
                throw new ApplicationException("Categoria não encontrada.");

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }
    }
}

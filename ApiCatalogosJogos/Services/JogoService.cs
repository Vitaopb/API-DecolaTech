using ApiCatalogosJogos.Enitites;
using ApiCatalogosJogos.Exceptions;
using ApiCatalogosJogos.InputModel;
using ApiCatalogosJogos.ViewModel;
using ApiCatalogosJogos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogosJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();
        }

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null)
                return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
                throw new JogoJaCadastradoException();

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            await _jogoRepository.Inserir(jogoInsert);

            return new JogoViewModel
            {
                Id = jogoInsert.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task Atualizar(Guid id, JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.Preco = preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Remover(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null)
                throw new JogoNaoCadastradoException();

            await _jogoRepository.Remover(id);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }

        Task<List<JogoViewModel>> IJogoService.Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        Task<JogoViewModel> IJogoService.Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task<List<JogoViewModel>> IJogoService.Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        Task<JogoViewModel> IJogoService.Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task<List<JogoViewModel>> IJogoService.Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        Task<JogoViewModel> IJogoService.Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task<List<JogoViewModel>> IJogoService.Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        Task<JogoViewModel> IJogoService.Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<JogoViewModel> IJogoService.Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task IJogoService.Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task IJogoService.Atualizar(Guid id, double preco)
        {
            throw new NotImplementedException();
        }

        Task IJogoService.Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

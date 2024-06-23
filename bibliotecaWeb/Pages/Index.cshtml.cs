using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BibliotecaApp.Models;
using BibliotecaApp.Services;
using System;
using System.Collections.Generic;

namespace bibliotecaWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LivroService _livroService;

        public IndexModel(ILogger<IndexModel> logger, LivroService livroService)
        {
            _logger = logger;
            _livroService = livroService;
        }

        public List<Livro> Livros { get; private set; }

        public IActionResult OnGet()
        {
            Livros = _livroService.ObterTodos();
            return Page();
        }

        public IActionResult OnPost(string titulo, int anoPublicacao)
        {
            var livro = new Livro
            {
                Titulo = titulo,
                AnoPublicacao = anoPublicacao
            };

            try
            {
                _livroService.Adicionar(livro, new List<int>());
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao cadastrar livro: {ex.Message}");
                return Page();
            }
        }

        public IActionResult OnGetBuscar(int idBusca)
        {
            var livro = _livroService.ObterPorId(idBusca);
            if (livro == null)
            {
                _logger.LogInformation($"Livro com ID {idBusca} não encontrado.");
                return RedirectToPage();
            }

            Livros = new List<Livro> { livro };
            return Page();
        }
    }
}

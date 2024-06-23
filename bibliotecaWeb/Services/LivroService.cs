using BibliotecaApp.Data;
using BibliotecaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp.Services
{
    public class LivroService
    {
        private readonly BibliotecaContext _context;

        public LivroService(BibliotecaContext context)
        {
            _context = context;
        }

        public List<Livro> ObterTodos()
        {
            return _context.Livros
                .Include(l => l.AutorLivros)
                .ThenInclude(al => al.Autor)
                .ToList();
        }

        public Livro ObterPorId(int id)
        {
            return _context.Livros
                .Include(l => l.AutorLivros)
                .ThenInclude(al => al.Autor)
                .FirstOrDefault(l => l.LivroId == id);
        }

        public void Adicionar(Livro livro, List<int> autorIds)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();

            foreach (var autorId in autorIds)
            {
                _context.AutorLivros.Add(new AutorLivro { LivroId = livro.LivroId, AutorId = autorId });
            }
            _context.SaveChanges();
        }

        public void Atualizar(Livro livro, List<int> autorIds)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();

            var currentAutores = _context.AutorLivros.Where(al => al.LivroId == livro.LivroId).ToList();
            _context.AutorLivros.RemoveRange(currentAutores);
            _context.SaveChanges();

            foreach (var autorId in autorIds)
            {
                _context.AutorLivros.Add(new AutorLivro { LivroId = livro.LivroId, AutorId = autorId });
            }
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro != null)
            {
                var autorLivros = _context.AutorLivros.Where(al => al.LivroId == id).ToList();
                _context.AutorLivros.RemoveRange(autorLivros);
                _context.Livros.Remove(livro);
                _context.SaveChanges();
            }
        }

        public List<Livro> ObterTodosComAutores()
        {
            return _context.Livros
                .Include(l => l.AutorLivros)
                .ThenInclude(al => al.Autor)
                .ToList();
        }

    }
}

using BibliotecaApp.Data;
using BibliotecaApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp.Services
{
    public class AutorService
    {
        private readonly BibliotecaContext _context;

        public AutorService(BibliotecaContext context)
        {
            _context = context;
        }

        public List<Autor> ObterTodos()
        {
            return _context.Autores.ToList();
        }

        public Autor ObterPorId(int id)
        {
            return _context.Autores.Find(id);
        }

        public void Adicionar(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }

        public void Atualizar(Autor autor)
        {
            _context.Autores.Update(autor);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var autor = _context.Autores.Find(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                _context.SaveChanges();
            }
        }
    }
}

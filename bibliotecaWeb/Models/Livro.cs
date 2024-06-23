using System.Collections.Generic;

namespace BibliotecaApp.Models
{
    public class Livro
    {
        public int LivroId { get; set; }  // Ajustei o nome da propriedade para LivroId
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }
        public List<AutorLivro> AutorLivros { get; set; } = new List<AutorLivro>();
    }
}

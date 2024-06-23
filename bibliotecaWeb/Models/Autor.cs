using System;
using System.Collections.Generic;

namespace BibliotecaApp.Models
{
    public class Autor
    {
        public int AutorId { get; set; } 
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<AutorLivro> AutorLivros { get; set; } = new List<AutorLivro>();
    }
}

using BibliotecaApp.Models;
using BibliotecaApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _livroService;

        public LivrosController(LivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var livros = _livroService.ObterTodosComAutores();
            return Ok(livros);
        }

        [HttpGet("{id}", Name = "GetLivro")]
        public IActionResult GetById(int id)
        {
            var livro = _livroService.ObterPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LivroCriacaoDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados do livro não podem ser nulos");
            }

            try
            {
                _livroService.Adicionar(dto.Livro, dto.AutorIds);
                return CreatedAtRoute("GetLivro", new { id = dto.Livro.LivroId }, dto.Livro);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar o livro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LivroAtualizacaoDto dto)
        {
            if (id != dto.Livro.LivroId)
            {
                return BadRequest("Ids não correspondem");
            }

            try
            {
                _livroService.Atualizar(dto.Livro, dto.AutorIds);
                return Ok(dto.Livro);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar o livro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _livroService.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar o livro: {ex.Message}");
            }
        }
    }

    public class LivroCriacaoDto
    {
        public Livro Livro { get; set; }
        public List<int> AutorIds { get; set; }
    }

    public class LivroAtualizacaoDto
    {
        public Livro Livro { get; set; }
        public List<int> AutorIds { get; set; }
    }
}

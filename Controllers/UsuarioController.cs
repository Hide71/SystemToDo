﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemToDo.Models;
using SystemToDo.Repositorios.Interfaces;

namespace SystemToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodos()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.GetAllUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>>BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>>Adicionar([FromBody]UsuarioModel user)
        {
            UsuarioModel usuario = await _usuarioRepositorio.AddUsuario(user);
            return Ok(usuario);
        }
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemToDo.Models;
using SystemToDo.Repositorios.Interfaces;

namespace SystemToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodos()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.GetAllTarefa();
            return Ok(tarefas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.GetById(id);
            return Ok(tarefa);
        }
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Adicionar([FromBody] TarefaModel toDo)
        {
            TarefaModel tarefa = await _tarefaRepositorio.AddTarefa(toDo);
            return Ok(tarefa);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Editar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepositorio.EditTarefa(tarefaModel, id);
            return Ok(tarefa);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Deletar(int id)
        {
            bool apagado = await _tarefaRepositorio.DeleteTarefa(id);
            return Ok(apagado);
        }
    }
}
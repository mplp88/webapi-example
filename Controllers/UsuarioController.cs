using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_test.Models;
using webapi_test.Services;

namespace webapi_test.Controllers
{
  [ApiController]
  [Route("Usuarios")]
  public class UsuarioController : ControllerBase
  {
    private readonly UsuarioService service;
    public UsuarioController(UsuarioService _service)
    {
      service = _service;
    }

    [HttpGet]
    [Route("/")]
    public async Task<List<Usuario>> GetAll()
    {
      return await service.GetAll();
    }

    [HttpGet]
    [Route("/{id}")]
    public async Task<Usuario> GetById([FromRoute] int id)
    {
      return await service.GetById(id);
    }

    [HttpPost]
    [Route("/")]
    public async Task<Usuario> Register([FromBody] Usuario usuario)
    {
      await service.Add(usuario);
      return usuario;
    }

    [HttpPut]
    [Route("/{id}")]
    public async Task<Usuario> Update([FromRoute] int id, [FromBody] Usuario usuarioModificado)
    {
      var usuario = await service.Update(id, usuarioModificado);
      return usuario;
    }

    [HttpDelete]
    [Route("/{id}")]
    public async Task<bool> Delete([FromRoute] int id)
    {
      try
      {
        return await service.Delete(id);
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
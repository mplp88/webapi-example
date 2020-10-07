using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi_test.DAL;
using webapi_test.Models;

namespace webapi_test.Services
{
  public class UsuarioService
  {
    private readonly DatabaseContext context;

    public UsuarioService(DatabaseContext _context)
    {
      context = _context;
    }

    public async Task<List<Usuario>> GetAll()
    {
      return await context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetById(int id)
    {
      return await context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Usuario> Add(Usuario usuario)
    {
      await context.Usuarios.AddAsync(usuario);
      await context.SaveChangesAsync();
      return usuario;
    }

    public async Task<Usuario> Update(int id, Usuario usuarioModificado)
    {
      var usuario = new Usuario();

      if (await context.Usuarios.AnyAsync(u => u.Id == id))
      {
        usuario = await context.Usuarios.FirstAsync(u => u.Id == id);
        usuario.Username = usuarioModificado.Username;
        usuario.Password = usuarioModificado.Password;
        context.Usuarios.Update(usuario);
        await context.SaveChangesAsync();
      }

      return usuario;
    }

    public async Task<bool> Delete(int id)
    {
      try
      {
        var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        if (usuario != null)
        {
          context.Usuarios.Remove(usuario);
          await context.SaveChangesAsync();
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
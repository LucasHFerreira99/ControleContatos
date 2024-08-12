﻿using ControleContatos.Models;

namespace ControleContatos.Repositories
{
    public interface IUsuarioRepository
    {

        Usuario BuscarPorLogin(string login);
        List<Usuario> BuscarTodos();
        Usuario BuscarPorId(int id);
        Usuario Adicionar(Usuario usuario);
        Usuario Editar(Usuario usuario);
        bool Apagar(int id);
    }
}

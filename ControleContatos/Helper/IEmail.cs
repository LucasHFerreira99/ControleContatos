﻿using ControleContatos.Models;

namespace ControleContatos.Helper
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}

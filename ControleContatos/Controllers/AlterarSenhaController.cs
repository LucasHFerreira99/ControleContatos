﻿using ControleContatos.Filters;
using ControleContatos.Helper;
using ControleContatos.Models;
using ControleContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    [PaginaUsuarioLogado]
    public class AlterarSenhaController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try 
            { 
                if(ModelState.IsValid)
                {
                    Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    alterarSenhaModel.Id = usuarioLogado.UsuarioId;
                    _usuarioRepository.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }
                return View("Index", alterarSenhaModel);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel alterar a sua senha, tente novamente! Detalhe do erro: {ex.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}

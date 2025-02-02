﻿using ControleContatos.Data;
using ControleContatos.Filters;
using ControleContatos.Helper;
using ControleContatos.Models;
using ControleContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    [PaginaRestritaAdmin]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepository _repository;
        private readonly ISessao _sessao;
        private readonly IContatoRepository _contatoRepository;
        public UsuarioController(IUsuarioRepository repository, ISessao sessao = null, IContatoRepository contatoRepository = null)
        {
            _repository = repository;
            _sessao = sessao;
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _repository.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var usuario = _repository.BuscarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var usuario = _repository.BuscarPorId(id);
            return View(usuario);
        }

        public IActionResult ListarContatosPorUsuarioId(int id)
        {
            List<Contato> contatos = _contatoRepository.buscarTodos(id);
            return PartialView("_ContatosUsuario", contatos);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel cadastrar usuário, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Editar(UsuarioSemSenha usuarioSemSenha)
        {
            try
            {
                Usuario usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new Usuario()
                    {
                        UsuarioId = usuarioSemSenha.UsuarioId,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil,
                    };
                    usuario = _repository.Editar(usuario);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel editar usuário, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                if (_sessao.BuscarSessaoDoUsuario() == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                var confirma = _repository.Apagar(id);
                if (confirma == true)
                {
                    TempData["MensagemSucesso"] = "Contato excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não foi possivel deletar contato, tente novamente!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel excluir contato, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}

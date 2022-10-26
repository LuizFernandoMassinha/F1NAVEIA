using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROJ_MASSINHA.Models;
using MySqlConnector;
using Microsoft.AspNetCore.Http;


namespace PROJ_MASSINHA.Controllers
{
   public class UsuarioController : Controller
   {
      private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

       public IActionResult CadastroConcluido()
       {
        if(HttpContext.Session.GetInt32("IdUsuario")==null)
        return RedirectToAction("Login", "Usuario");
        else
        return View();
       }
       public IActionResult cadastro()
       {
        if(HttpContext.Session.GetInt32("IdUsuario")==null)
        return RedirectToAction("Login", "Usuario");
        else
        return View();
       }

    [HttpPost]
        public IActionResult cadastro(Usuario u)
        {
            UsuarioRepository ur = new UsuarioRepository();
             ur.inserir(u);
             ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
            return RedirectToAction("CadastroConcluido");
        }

        public IActionResult Listagem()
        {
         UsuarioRepository ur = new UsuarioRepository();
         List<Usuario> usuarios = ur.Query();
         return View(usuarios);
         }

        public IActionResult editarUsuario(int IdUsuario)
         {
         UsuarioRepository ur = new UsuarioRepository();
         return View(ur.buscarporID(IdUsuario));
         }
 
[HttpPost]
public IActionResult editarUsuario(Usuario u)
{
    UsuarioRepository ur = new UsuarioRepository();
    ur.editar(u);
    return RedirectToAction("Listagem");
}

public IActionResult deletar(int IdUsuario)
{
 UsuarioRepository ur = new UsuarioRepository();
 ur.deletar(IdUsuario);
 return RedirectToAction("Listagem");
}
public IActionResult Login()
{
    return View();
}

[HttpPost]
public IActionResult Login(Usuario u)
{
    UsuarioRepository ur = new UsuarioRepository();
    Usuario usuarioLogado = ur.QueryLogin(u);
    if(usuarioLogado != null)
    {
        ViewBag.Mensagem = "Você está logado";
        HttpContext.Session.SetInt32("IdUsuario", usuarioLogado.IdUsuario);
        HttpContext.Session.SetString("nomeUsuario", usuarioLogado.nomeUsuario);
        return RedirectToAction("Index", "Home");
        
    }
    else
    {
        ViewBag.Mensagem = "Falha no Login";
        return View();
    }
}
public IActionResult Logout()
{
    HttpContext.Session.Clear();//limpa toda a sessão
    return RedirectToAction("Login");
}
   }


}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROJ_MASSINHA.Models;
using Microsoft.AspNetCore.Http;
using MySqlConnector;

namespace PROJ_MASSINHA.Controllers
{
    public class OpiniaoController : Controller
    {
        private readonly ILogger<OpiniaoController> _logger;

        public OpiniaoController(ILogger<OpiniaoController> logger)
        {
            _logger = logger;
        }
        
         public IActionResult Forum()
        {
            opiniaoRepository or = new opiniaoRepository();
            List<opiniao> opiniao = or.Query();
            return View(opiniao);
        }

        public IActionResult opiniao()
        {
            if(HttpContext.Session.GetInt32("IdUsuario")==null)
            return RedirectToAction("Login", "Usuario");
            else
            return View();
        }
        
        [HttpPost]
        public IActionResult opiniao(opiniao o)
        {
            opiniaoRepository or = new opiniaoRepository();
             or.inserir(o);
             ViewBag.Mensagem = "Seu comentario foi enviado com sucesso";
            return RedirectToAction("Forum");
        }

       
    }

}
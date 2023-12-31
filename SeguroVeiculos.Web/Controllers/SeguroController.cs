﻿using Microsoft.AspNetCore.Mvc;
using SeguroVeiculos.Web.Integration;
using SeguroVeiculos.Web.Integration.Interface;
using SeguroVeiculos.Web.Models;

namespace SeguroVeiculos.Web.Controllers
{
    public class SeguroController : Controller
    {
        private readonly ISeguroIntegracao _seguroIntegracao;

        public SeguroController()
        {
            _seguroIntegracao = new SeguroIntegracao();
        }


        // GET: SeguroController
        public ActionResult Index()
        {
            return View(new List<SeguroViewModel>());
        }

        // GET: SeguroController
        public ActionResult Listar(string nomeOudocumento)
        {
            var lista = _seguroIntegracao.ListarSegurados(nomeOudocumento);
            return View("Index", lista);
        }       

        // GET: SeguroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeguroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeguroViewModel model)
        {
            try
            {
                _seguroIntegracao.Gravar(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }      
    }
}

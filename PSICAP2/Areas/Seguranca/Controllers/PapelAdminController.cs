﻿using PSICAP2.Areas.Seguranca.Models;
using PSICAP2.Infraestrutura;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PSICAP2.Areas.Seguranca.Controllers
{
    public class PapelAdminController : Controller
    {
        private GerenciadorPapel RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager
                <GerenciadorPapel>();

            }
        }

        // GET: Seguranca/PapelAdmin
        [Authorize(Roles = "Administradores")]
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        // GET: Create
        [Authorize(Roles = "Administradores")]
        public ActionResult Create()
        {
            return View();
        }

        private void AddErrorsFromResult(IdentityResult result)

        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().
                GetUserManager<GerenciadorUsuario>();
            }
        }

        //POST: Create
        [Authorize(Roles = "Administradores")]
        [HttpPost]
        public ActionResult Create([Required] string nome)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = RoleManager.Create(new Papel(nome));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(nome);
        }

        //GET: Edit
        public ActionResult Edit(string id)
        {
            Papel papel = RoleManager.FindById(id);
            string[] memberIDs = papel.Users.Select(x => x.UserId).ToArray();
            // Carrega usuários associados e usuários não associados
            IEnumerable<Usuario> membros = UserManager.Users.Where
            (x => memberIDs.Any(y => y == x.Id));
            IEnumerable<Usuario> naoMembros = UserManager.Users.Except(membros);
            // Chama a visão
            return View(new PapelEditModel
            {
                Papel = papel,
                Membros = membros,
                NaoMembros = naoMembros
            });
        }

       
        //POST: Edit
        [HttpPost]
        public ActionResult Edit(PapelModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsParaAdicionar ?? new
                string[] { })
                {
                    result = UserManager.AddToRole(userId, model.NomePapel);
                    if (!result.Succeeded)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                foreach (string userId in model.IdsParaRemover ?? new string[] { })
                {
                    result = UserManager.RemoveFromRole(userId, model.NomePapel);
                    if (!result.Succeeded)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Delete
        
        [Authorize(Roles = "Administradores")]
        public ActionResult Delete(string id)
        {
            Papel papel = RoleManager.FindById(id);
            string[] memberIDs = papel.Users.Select(x => x.UserId).ToArray();
            // Carrega usuários associados e usuários não associados
            IEnumerable<Usuario> membros = UserManager.Users.Where
            (x => memberIDs.Any(y => y == x.Id));
            IEnumerable<Usuario> naoMembros = UserManager.Users.Except(membros);
   
            // Chama a visão
            return View(new PapelDetailsModel
            {
                Nome = papel.Name,
                Membros = membros,
                NaoMembros = naoMembros
            });
        }

        // POST: Delete
        [HttpPost]
        public ActionResult Delete(Papel papel)
        {
            Papel papels = RoleManager.FindById(papel.Id);
            if (papels != null)
            {
                IdentityResult result = RoleManager.Delete(papels);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
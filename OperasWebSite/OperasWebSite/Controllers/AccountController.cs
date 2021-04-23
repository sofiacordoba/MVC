using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperasWebSite.Models;
using System.Web.Security;
using System.Web.ModelBinding;

namespace OperasWebSite.Controllers
{
    public class AccountController : Controller
    {
        // GET /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnURL = returnUrl;                //el ViewBag guarda la url
            return View();
        }

        //POST  / Account/Login
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)  // model representa el usuario y contraseña
        {
            if (ModelState.IsValid)
            {
                //CHEQUEAMOS SI EL USUARIO EXISTE EN LA BASE
                if(Membership.ValidateUser(model.UserName, model.Password)) // esto va a la tabla de datos a ver si existe
                {
                    //CREAMOS LA COOKIE VOLATIL
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    //HELPER
                    if (Url.IsLocalUrl(returnUrl))  //devuelve un booleao
                    {
                        return Redirect(returnUrl);    //Aca me redirecciona para autenticarme
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home"); // Aca me redirecciona si estoy autenticado
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El nombre o password no son correctos"); // Aca me redirecciona si NO estoy autenticado
                }
            }
            return View(model);  // SI NO PASA POR LA VALIDACION ME MANDA ACA 
        }



        //
        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    MembershipUser NewUser = Membership.CreateUser(model.UserName, model.Password);
                    //Log the user on with the new account
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Registration Error", "Registration error: " + e.StatusCode.ToString());
                }
            }

            return View(model);
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
        }


        
    }
}
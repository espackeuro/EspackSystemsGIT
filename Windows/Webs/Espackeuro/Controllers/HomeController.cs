using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;

namespace WebEspackeuro.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Session["web"] = "Index";
            if (Session["lengua"] == null)
            {
                Session["lengua"] = "en-US";
            }
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = "Espack Eurológistica";
            return View();
        }
        public ActionResult EspackPDF()
        {
            Session["web"] = "EspackPDF";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = "Espack Eurológistica";
            return View();
        }
        public ActionResult QueEsEspack()
        {
            Session["web"] = "QueEsEspack";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Que_es_Espack;
            return View();
        }
        public ActionResult ServLogis()
        {
            Session["web"] = "ServLogis";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.ServiciosLog;
            return View();
        }
        public ActionResult Ecommerce()
        {
            Session["web"] = "Ecommerce";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Ecommerce;
            return View();
        }
        public ActionResult Almacen()
        {
            Session["web"] = "Almacen";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Almacenaje;
            return View();
        }

        public ActionResult LogEmpaquetado()
        {
            Session["web"] = "LogEmpaquetado";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.LogEmpaquetado;
            return View();
        }
        public ActionResult LogIdentificacion()
        {
            Session["web"] = "LogIdentificacion";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.LogIdentificación;
            return View();
        }
        public ActionResult Medios()
        {
            Session["web"] = "Medios";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Medios;
            return View();
        }
        public ActionResult Empresas()
        {
            Session["web"] = "Empresas";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Empresas;
            return View();
        }
        public ActionResult Ventajas()
        {
            Session["web"] = "Ventajas";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Ventajas;
            return View();
        }
        public ActionResult LogSeleccion()
        {
            Session["web"] = "LogSeleccion";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.LogSeleccion;
            return View();
        }
        public ActionResult RevInsRecu()
        {
            Session["web"] = "RevInsRecu";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.RevInspRecu;
            return View();
        }
        public ActionResult MonPreCon()
        {
            Session["web"] = "MonPreCon";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Montajespreparaconjuntos;
            return View();
        }
        public ActionResult Trasvase()
        {
            Session["web"] = "Trasvase";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Trasvaseacontenedoresespec;
            return View();
        }
        public ActionResult CenCon()
        {
            Session["web"] = "CenCon";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Centroconsolidadorcontenedores;
            return View();
        }
        public ActionResult ProLogEsp()
        {
            Session["web"] = "ProLogEsp";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Proclogespeciales;
            return View();
        }
        public ActionResult Distribucion()
        {
            Session["web"] = "Distribucion";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Distribucnacionalinter;
            return View();
        }
        public ActionResult Software()
        {
            Session["web"] = "Software";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Software;
            return View();
        }
        public ActionResult CerPre()
        {
            Session["web"] = "CerPre";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.CertificadosPremios;
            return View();
        }
        public ActionResult Clientes()
        {
            Session["web"] = "Clientes";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Clientes;
            return View();
        }
        public ActionResult Plantas()
        {
            Session["web"] = "Plantas";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Plantas;
            return View();
        }
        public ActionResult Valencia()
        {
            Session["web"] = "Valencia";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Valencia;
            return View();
        }
        public ActionResult Zaragoza()
        {
            Session["web"] = "Zaragoza";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Zaragoza;
            return View();
        }
        public ActionResult Madrid()
        {
            Session["web"] = "Madrid";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Madrid;
            return View();
        }
        public ActionResult Bridgend()
        {
            Session["web"] = "Bridgend";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Bridgend;
            return View();
        }
        public ActionResult Wolverhampton()
        {
            Session["web"] = "Wolverhampton";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Wolverhampton;
            return View();
        }
        public ActionResult Halewood()
        {
            Session["web"] = "Halewood";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Halewood;
            return View();
        }
        public ActionResult Dagenham()
        {
            Session["web"] = "Dagenham";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Dagenham;
            return View();
        }
        public ActionResult Eslovaquia()
        {
            Session["web"] = "Eslovaquia";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Eslovaquia;
            return View();
        }
        public ActionResult Craiova()
        {
            Session["web"] = "Craiova";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Craiova;
            return View();
        }
        public ActionResult Colonia()
        {
            Session["web"] = "Colonia";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Colonia;
            return View();
        }
        public ActionResult CastleBromwich()
        {
            Session["web"] = "CastleBromwich";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.CastleBromwich;
            return View();
        }
        public ActionResult Graz()
        {
            Session["web"] = "Graz";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Graz;
            return View();
        }
        public ActionResult Contacto()
        {
            Session["web"] = "Contacto";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Contacto;
            return View();
        }
        [HttpPost]
        public ActionResult Contacto(string Nombre, string Asunto, string Email, string Mensaje, string robot)
        {
            Session["web"] = "Contacto";
            if (Session["lengua"] != null)
            {
                Clases.IdiomaCheck(Session["lengua"].ToString());
            }
            ViewBag.Title = Idiomas.Contacto;
            if (robot !="1") { ViewBag.Mensaje = "ERROR: No has pulsado la casilla de No Soy Robot"; return View(); }
            string _UserEmail = "datacapture";
            string _PasswordEmail = "ecexaqa9";
            string _Subject = Asunto;
            string _Body = "IP: " + Request.UserHostAddress + ", País-Idioma: " + Request.UserLanguages[0] + "<br/><br/>" + Nombre + " con Email: " + Email + " Remitió el siguiente Mensaje: <br/><br/>" + Mensaje;
            string _SendTo = "espack@espackeuro.com";
            ExchangeService exchange = new ExchangeService
            {
                Credentials = new WebCredentials(_UserEmail, _PasswordEmail)
            };
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            exchange.Url = new System.Uri("https://exchange.espackeuro.com/ews/exchange.asmx");
            if (exchange != null)
            {
                try
                {

                    EmailMessage message = new EmailMessage(exchange);
                    {
                        message.Subject = _Subject;
                        message.Body = _Body;
                        message.ToRecipients.Add(_SendTo);
                        message.Save();
                        message.SendAndSaveCopy();
                    }
                    ViewBag.Mensaje = "Mensaje Enviado Correctamente. Gracias por contactar con Espack Eurologística";

                }
                catch (Exception e)
                {
                    ViewBag.Mensaje = "ERROR " + e.Message;
                }
            }
            else { ViewBag.Mensaje = "ERROR al Enviar el Mensaje"; }
            return View();
        }

        [HttpGet]
        public ActionResult PonIdioma(string Lengua)
        {
                if (!string.IsNullOrEmpty(Lengua))
                {
                     Clases.IdiomaCheck(Lengua);
                     Session["lengua"] = Lengua;
            }
            return Redirect(Session["web"].ToString());
        }
    }
}
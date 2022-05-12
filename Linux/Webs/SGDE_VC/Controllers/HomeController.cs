using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SGDE_VC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SGDE_VC.Controllers
{
  
    public class HomeController : Controller
 {      
        public IActionResult Index()
        {
            if (int.Parse(Metodos.ObtenRol(User.Identity.Name)) > 0)
            { 
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        public IActionResult Tools()
        {
            return View();
        }

        public IActionResult ToolsTypeDoc()
        {
            return View();
        }

        public IActionResult ToolsCodeDoc()
        {
            return View();
        }

        public IActionResult NewCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCode(CreatePostTools model)
        {
            ViewBag.Mensaje = Metodos.SQL_Ejecuta_pNewCodeAdd(model.Cod, Metodos.ObtenUsuarioActivo(User.Identity.Name).Usuario);

            return View();
        }

        public IActionResult NewType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewType(CreatePostTools model)
        {      
                ViewBag.Mensaje = Metodos.SQL_Ejecuta_pNewTypeAdd(model.NombreT, model.Cod, Metodos.ObtenUsuarioActivo(User.Identity.Name).Usuario);

            return View();
        }    

        public IActionResult Rol()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rol(string UsuId, string RolId)
        {
            ViewBag.MensajeOK = "";
            ViewBag.Mensaje = "";
            if (string.IsNullOrEmpty(UsuId) | string.IsNullOrEmpty(RolId))
            {
                ViewBag.Mensaje = "Todos los campos son requeridos.";
            }
            ViewBag.Mensaje2="";
            foreach (var Roles in (List<Tipo_RolyUsuario>)Metodos.SQL_ConsultaRolyUsuario("Select * from AspNetUserRoles where UserId='" + UsuId + "' and RoleId='" + RolId+"'"))
            {
                ViewBag.Mensaje2 = "Rol "+ Roles.RoleId + " no insertado, ya está incluido.";
            }
            ViewBag.Mensaje = "";
            if (string.IsNullOrEmpty(ViewBag.Mensaje) & string.IsNullOrEmpty(ViewBag.Mensaje2))
            {
                Metodos.SQL_Ejecuta("INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('" + UsuId + "','" + RolId + "')");
                ViewBag.MensajeOK = "Rol  Id: " + RolId + " Añadido al Usuario Id: " + UsuId;
            }
            return View();
        }

        [HttpPost]
        public IActionResult UserUpdate2(string IdUser)
        {
            ViewBag.UserId= IdUser;
            foreach (var UserLogon in (List<Tipo_AspNetUsers>)Metodos.SQL_ConsultaUserProfile("Select * from AspNetUsers where Id='" + IdUser + "'"))
            {
                ViewBag.Nombre = UserLogon.Usuario;
                ViewBag.NombreCompl = UserLogon.NombreU;
                ViewBag.Cod3 = UserLogon.Cod3;
                ViewBag.Email = UserLogon.Email;
            }
            return View();
        }

        [HttpPost]
        public IActionResult UserUpdate3(Tipo_AspNetUsers model)
        {
            ViewBag.Mensaje = "";
            if (string.IsNullOrEmpty(model.NombreU) | string.IsNullOrEmpty(model.Cod3) | string.IsNullOrEmpty(model.UserId))
            {
                ViewBag.Mensaje = "ERROR Todos los campos son requeridos.";
            }

            if (string.IsNullOrEmpty(ViewBag.Mensaje))
            {

                Metodos.SQL_Ejecuta("UPDATE AspNetUsers SET NormalizedUserName='" + model.Usuario.ToUpper() + "', UserName = '" + model.Usuario + "', Nombre = '" + model.NombreU + "', COD3 = '" + model.Cod3 + "',email='"+model.Email+ "', NormalizedEmail='"+model.Email.ToUpper()+"' WHERE Id='" + model.UserId + "'");
                ViewBag.Mensaje = "User: " + model.NombreU + " Update Successfully.";           
            }
            return RedirectToAction("Index", "Home");
        }

            public IActionResult DOCUpdate()
            {
            if (int.Parse(Metodos.ObtenRol(User.Identity.Name)) > 8)
            {
                return View();
            }
            else
            {
                return Redirect("/Home/");
            }
        }

        [HttpPost]
        public IActionResult DOCUpdate2(CreatePost model)
        {
            ViewBag.Descripcion= model.Descripcion;
            ViewBag.Documento = model.Documento;           
            ViewBag.TipoDocumento = model.TipoDocumento;
            ViewBag.CTipo = model.CTipo;
            ViewBag.NumDoc = model.NumDoc;
            ViewBag.COD3 = model.COD3;
            ViewBag.NumEdicion = model.NumEdicion;
            ViewBag.EstadoEdicion = model.EstadoEdicion;
            ViewBag.NumDoc = model.NumDoc;
            ViewBag.IdReg = model.IdReg;
            ViewBag.NombreArchivo = model.NombreArchivo;
            ViewBag.Obs = model.Obs;
            ViewBag.Web = model.Web;

            return View();
        }

        [HttpPost]
        public IActionResult DOCUpdate3(CreatePost model)
        {
        string txtFileUp = "";
        bool CambioArchivo = false;
        string FileExtension = Path.GetExtension(model.NombreArchivo);
        string EstadoEdicionTabla = "";
        string NuevoNombreArchi = model.NombreArchivo;
        foreach(var Docs in (List<Tipo_Documentos>)Metodos.SQL_ConsulaDocumentos("Select * from Documentos where IdReg='"+model.IdReg+"'"))
        {
                EstadoEdicionTabla = Docs.EstadoEdicion;
        }
            if (EstadoEdicionTabla != model.EstadoEdicion)
            {
                string sourceFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + EstadoEdicionTabla + @"\DOC\"+model.NombreArchivo; 
                string destinationFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\OBSOLETO\" + EstadoEdicionTabla + @"\DOC\" + model.NombreArchivo;

                if (System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Delete(destinationFile);
                }
                    // To move a file or folder to a new location:
                    System.IO.File.Move(sourceFile, destinationFile);
                if (FileExtension == ".doc" || FileExtension == ".docx" || FileExtension == ".xls" || FileExtension == ".xlsx")
                {
                    sourceFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + EstadoEdicionTabla + @"\PDF\" + model.Documento + ".pdf";
                    destinationFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\OBSOLETO\" + EstadoEdicionTabla + @"\PDF\" + model.Documento + ".pdf";

                    if (System.IO.File.Exists(destinationFile))
                    {
                        System.IO.File.Delete(destinationFile);
                    }

                    // To move a file or folder to a new location:
                    System.IO.File.Move(sourceFile, destinationFile);
                }
            }
            if (model.Archivo == null)
            {
                if (EstadoEdicionTabla != model.EstadoEdicion)
                {
                    string destinationFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + model.EstadoEdicion + @"\DOC\" + model.NombreArchivo;
                    string sourceFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\OBSOLETO\" + EstadoEdicionTabla + @"\DOC\" + model.NombreArchivo;

                    if (System.IO.File.Exists(destinationFile))
                    {
                        System.IO.File.Delete(destinationFile);
                    }
                    // To move a file or folder to a new location:
                    System.IO.File.Copy(sourceFile, destinationFile);
                    if (FileExtension == ".doc" || FileExtension == ".docx" || FileExtension == ".xls" || FileExtension == ".xlsx")
                    {
                        destinationFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + model.EstadoEdicion + @"\PDF\" + model.Documento + ".pdf";
                        sourceFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\OBSOLETO\" + EstadoEdicionTabla + @"\PDF\" + model.Documento + ".pdf";
                        if (System.IO.File.Exists(destinationFile))
                        {
                            System.IO.File.Delete(destinationFile);
                        }
                        // To move a file or folder to a new location:
                        System.IO.File.Copy(sourceFile, destinationFile);
                    }
                }
            }
            else
            {
                CambioArchivo = true;
                txtFileUp = "Upload File ";
                string FicheroAnterior = "";
                string DocumentoAnterior = "";
                NuevoNombreArchi=model.Documento + Path.GetExtension(model.Archivo.FileName);
                foreach (var Docs in (List<Tipo_Documentos>)Metodos.SQL_ConsulaDocumentos("Select * from Documentos where IdReg='" + model.IdReg + "'")) 
                {
                    FicheroAnterior = Docs.NombreArchivo;
                    DocumentoAnterior = Docs.Documento;
                }                    
                    FileExtension = Path.GetExtension(model.Archivo.FileName);
                if (EstadoEdicionTabla == model.EstadoEdicion)
                {
                    string sourceFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + EstadoEdicionTabla + @"\DOC\" + FicheroAnterior;
                    string destinationFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\OBSOLETO\" + EstadoEdicionTabla + @"\DOC\" + FicheroAnterior;

                    if (System.IO.File.Exists(destinationFile))
                    {
                        System.IO.File.Delete(destinationFile);
                    }
                    if (System.IO.File.Exists(sourceFile))
                    {
                        // To move a file or folder to a new location:
                        System.IO.File.Move(sourceFile, destinationFile);
                    }
                    if (FileExtension == ".doc" || FileExtension == ".docx" || FileExtension == ".xls" || FileExtension == ".xlsx")
                    {
                        sourceFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + EstadoEdicionTabla + @"\PDF\" +  DocumentoAnterior + ".pdf";
                        destinationFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\OBSOLETO\" + EstadoEdicionTabla+ @"\PDF\" + DocumentoAnterior + ".pdf";

                        if (System.IO.File.Exists(destinationFile))
                        {
                            System.IO.File.Delete(destinationFile);
                        }
                        if (System.IO.File.Exists(sourceFile))
                        {
                            // To move a file or folder to a new location:
                            System.IO.File.Move(sourceFile, destinationFile);
                        }
                    }
                }
                FileExtension = Path.GetExtension(model.Archivo.FileName);
                string PathDestino = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + model.EstadoEdicion + @"\DOC\";
                string PathDestinoPDF = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + model.EstadoEdicion + @"\PDF\";
                Metodos.SubirFichero(model, PathDestino);
                if (FileExtension == ".doc" || FileExtension == ".docx")
                {
                    Metodos.WordAPDF(PathDestino, PathDestinoPDF, model.Documento+FileExtension);
                }
                PathDestino = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + model.EstadoEdicion + @"\DOC\" + model.Documento+FileExtension;
                PathDestinoPDF = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + model.EstadoEdicion + @"\PDF\"+model.Documento+".pdf";
                if (FileExtension == ".xls" || FileExtension == ".xlsx")
                {
                  string txt = Metodos.Excel_PDF(PathDestino, PathDestinoPDF);
                }
            }
            Global.Mensaje = Metodos.SQL_Ejecuta_pDocumentosUp(model.Documento, model.COD3, Metodos.ObtenUsuarioActivo(User.Identity.Name).Usuario, model.CTipo, model.TipoDocumento, model.Descripcion, model.IdReg, model.NumDoc, model.EstadoEdicion,model.NumEdicion, NuevoNombreArchi, model.Obs, CambioArchivo);
            if (txtFileUp == "Upload File ") 
            {
                Global.Mensaje = txtFileUp;
            }
            return RedirectToAction(model.Web, "Home", model.IdReg);
        }

        [HttpPost]
        public IActionResult DOCDel(CreatePost model)
        {
            string sourceFile;
            string EstadoEdicionTabla = "";
            string NombreArchivo = "";
            string destinationFile;

            if (model.Confirma == "1")
            {

                foreach (var Docs in (List<Tipo_Documentos>)Metodos.SQL_ConsulaDocumentos("Select * from Documentos where IdReg='" + model.IdReg + "'"))
                {
                    EstadoEdicionTabla = Docs.EstadoEdicion;
                    NombreArchivo = Docs.NombreArchivo;
                }
                string FileExtension = Path.GetExtension(NombreArchivo);
                if (FileExtension == ".doc" || FileExtension == ".docx" || FileExtension == ".xls" || FileExtension == ".xlsx")
                {
                    sourceFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + EstadoEdicionTabla + @"\PDF\" + NombreArchivo.Substring(0, NombreArchivo.Length - FileExtension.Length) + ".pdf";
                    destinationFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\OBSOLETO\" + EstadoEdicionTabla + @"\PDF\" + NombreArchivo.Substring(0, NombreArchivo.Length - FileExtension.Length) + ".pdf";

                    // To move a file or folder to a new location:
                    if (System.IO.File.Exists(destinationFile))
                    {
                        System.IO.File.Delete(destinationFile);
                    }
                    System.IO.File.Move(sourceFile, destinationFile);
                }
                sourceFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\" + EstadoEdicionTabla + @"\DOC\" + NombreArchivo;
                destinationFile = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\OBSOLETO\" + EstadoEdicionTabla + @"\DOC\" + NombreArchivo;

                // To move a file or folder to a new location:
                if (System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Delete(destinationFile);
                }
                System.IO.File.Move(sourceFile, destinationFile);
            }
            Global.Mensaje = Metodos.SQL_Ejecuta_pDocumentosDel(model.IdReg, model.Confirma,Metodos.ObtenUsuarioActivo(User.Identity.Name).Usuario);
            return RedirectToAction("DOCUpdate", "Home");
        }

        [HttpPost]
        public IActionResult ToolsUpdate2(CreatePostTools model)
        {
            if (model.ToC == "T")
            {
                ViewBag.Nombre = model.NombreT;
            }
            ViewBag.Code = model.Cod;
            ViewBag.T_C = model.ToC;
            ViewBag.Id = model.Id;
            return View();
        }

        [HttpPost]
        public IActionResult ToolsUpdate3(CreatePostTools model)
        {
            string retorno = "ToolsTypeDoc";
                Global.Mensaje = Metodos.SQL_Ejecuta_pToolsUp(model.NombreT, model.Cod, Metodos.ObtenUsuarioActivo(User.Identity.Name).Usuario, model.ToC, model.Id);            
            if (model.ToC == "C")
            {
                retorno = "ToolsCodeDoc";
            }
            return RedirectToAction(retorno, "Home");
        }


        [HttpPost]
        public IActionResult DOCActions(Tipo_Acciones model) 
        {
            ViewBag.NumDoc = model.NumDoc;
            ViewBag.IdReg = model.IdReg;
            return View();
        }

        [HttpPost]
        public IActionResult DOCLog(Tipo_Acciones model)
        {
            ViewBag.NumDoc = model.NumDoc;
            ViewBag.IdReg = model.IdReg;
            return View();
        }

        [HttpPost]
        public IActionResult ToolsDel(CreatePostTools model)
        {
            string retorno = "ToolsTypeDoc";
            if (model.Confirma == "1")
            {
                Global.Mensaje = Metodos.SQL_Ejecuta_pToolsDel(model.Cod, model.Confirma, model.ToC, Metodos.ObtenUsuarioActivo(User.Identity.Name).Usuario, model.Id);
            }
            if (model.ToC == "C")
            {
                retorno = "ToolsCodeDoc";
            }
            return RedirectToAction(retorno, "Home");
        }

        public IActionResult DOCNew()
        {
            if (int.Parse(Metodos.ObtenRol(User.Identity.Name)) > 7)
            {
                return View();
            }
            else
            {
                return Redirect("/Home/");
            }
        }

        [HttpPost]
        public IActionResult DOCNew(CreatePost model)
        {
            // do other validations on your model as needed
            string FileExtension = Path.GetExtension(model.Archivo.FileName);
            string uniqueFileName = model.Documento + FileExtension;
            string PathDestino = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\RIP\DOC\";
            string PathDestinoPDF = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\RIP\PDF\";
            if (model.Archivo != null)
            {
               
                //to do : Save uniqueFileName  to your db table          
                ViewBag.Mensaje = Metodos.SQL_Ejecuta_pDocumentosAdd(model.Documento,Metodos.ObtenUsuarioActivo(User.Identity.Name).Cod3, Metodos.ObtenUsuarioActivo(User.Identity.Name).Usuario, model.CTipo,model.TipoDocumento,model.Descripcion,uniqueFileName,model.Obs);
                if (ViewBag.Mensaje.ToString().Substring(0, 5).ToUpper() != "ERROR")
                {
                    Metodos.SubirFichero(model, PathDestino);
                    if (FileExtension == ".doc" || FileExtension == ".docx")
                    {
                        Metodos.WordAPDF(PathDestino, PathDestinoPDF, uniqueFileName);
                    }
                    PathDestino = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\RIP\DOC\" + uniqueFileName;
                    PathDestinoPDF = @"C:\Users\jbelenguer\Documents\My Web Sites\SGDE_VC\wwwroot\Files\RIP\PDF\" + model.Documento + ".pdf";
                    if (FileExtension == ".xls" || FileExtension == ".xlsx")
                    {
                        Metodos.Excel_PDF(PathDestino, PathDestinoPDF);
                    }
                    if (ViewBag.Mensaje.ToString().Substring(0, 2).ToUpper() == "OK")
                    {
                        Metodos.EnviaEmail("Creado Nuevo Documento: " + model.Documento, Metodos.ObtenUsuarioActivo(User.Identity.Name).Usuario + " ha creado un nuevo documento", "jbelenguer@espackeuro.com");
                    }
                }          
            }
            // to do  : Return something
            return View();
        }

        public IActionResult Movimientos()
        {
            return View();
        }

        public IActionResult DOCUMENTSRIP()
        {
            if (int.Parse(Metodos.ObtenRol(User.Identity.Name)) > 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        public IActionResult DOCUMENTSPAP()
        {
            if (int.Parse(Metodos.ObtenRol(User.Identity.Name)) > 0)
            {
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        public IActionResult DOCUMENTSAP()
        {
            return View();
        }

        public IActionResult DOCUMENTS()
        {

            return View();
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {           
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
 }
}
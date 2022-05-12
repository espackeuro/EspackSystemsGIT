using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Exchange.WebServices.Data;
using WordToPDF;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Identity;

public class CreatePost
{
    public string IdReg { set; get; }
    public string NumDoc { set; get; }
    public string Documento { set; get; }
    public string COD3 { set; get; }
    public string Descripcion { set; get; }
    public int NumEdicion { set; get; }
    public string EstadoEdicion { set; get; }
    public string CTipo { set; get; }
    public string TipoDocumento { set; get; }
    public string Tag { set; get; }
    public IFormFile Archivo { set; get; }
    public string NombreArchivo { set; get; }
    public string Obs { set; get; }
    public string Web { set; get; }
    public string Confirma { set; get; }
}

public class CreatePostTools
{
    public int Id { set; get; }
    public string Xusr { set; get; }
    public string Cod { set; get; }
    public string NombreT { set; get; }
    public string Confirma { set; get; }
    public DateTime Xfec { set; get; }
    public string ToC { set; get; }
}

public class Tipo_TrazaDocumentos
{
    public int Id { set; get; }
    public string IdReg { set; get; }
    public string NumDoc { set; get; }
    public string Documento { set; get; }
    public string COD3 { set; get; }
    public string Descripcion { set; get; }
    public int NumEdicion { set; get; }
    public string EstadoEdicion { set; get; }
    public string CTipo { set; get; }
    public string TipoDocumento { set; get; }
    public string Tag { set; get; }
    public string Accion { set; get; }
    public string NombreArchivo { set; get; }
    public string Confirma { set; get; }
    public string Xusr { set; get; }
    public string Obs { set; get; }
    public DateTime Xfec { set; get; }
}

public class Tipo_Acciones
{
    public int Id { set; get; }
    public string IdReg { set; get; }
    public string NumDoc { set; get; }
    public DateTime Xfec { set; get; }
    public string Xusr { set; get; }
    public int NumEdicion { set; get; }
    public string Obs { set; get; }
}

public class Tipo_Documentos
{
    public string IdReg { set; get; }
    public string NumDoc { set; get; }
    public string Documento { set; get; }
    public string COD3 { set; get; }
    public DateTime Xfec { set; get; }
    public string Xusr { set; get; }
    public int NumEdicion { set; get; }
    public string Descripcion { set; get; }
    public string EstadoEdicion { set; get; }
    public string CodTipo { set; get; }
    public string TipoDoc { set; get; }
    public string Tag { set; get; }
    public string NombreArchivo { set; get; }
}

public class Global
{
    public static string Mensaje { get; set; }
}

public class Usuarios
{
    public int UserId { get; set; }
    public string Nombre { get; set; }
    public string Usuario { get; set; }
    public string Cod3 { get; set; }
    public int Rol { get; set; }
}

public class Tipo_UserProfile
{
   public string Nombre { get; set; }
   public string Cod3 { get; set; }
   public string Usuario { get; set; }
   public string Password { get; set; }
   public int UserId { get; set; }
}
public class Tipo_AspNetUsers
{
    public string NombreU { get; set; }
    public string Cod3 { get; set; }
    public string Usuario { get; set; }
    public string Password { get; set; }
    public string UserId { get; set; }
    public string Email { get; set; }
}

public class Tipo_Rol
 {
   public string Nombre { get; set; }
   public string RoleId { get; set; }
 }

public class Tipo_RolyUsuario
{
   public string UserId { get; set; }
   public string RoleId { get; set; }
}

public class Metodos
{
    public static string DB_SGDE = "Data Source=10.200.90.10;Initial Catalog=SGDE;password=*espack*;User ID=IT";

    public static object SQL_ConsultaUserProfile(string SQLComando)
    {
        var model = new List<Tipo_AspNetUsers>();
        using (var connection = new SqlConnection(DB_SGDE))
        {
            var command = new SqlCommand(SQLComando, connection);
            command.Connection.Open();
            var consulta = command.ExecuteReader();
            if (consulta.HasRows)
            {
                while (consulta.Read())
                {
                    var Usuarios_Registrados = new Tipo_AspNetUsers {
                        NombreU = consulta["Nombre"].ToString(),
                        Cod3 = consulta["COD3"].ToString(),
                        Usuario = consulta["UserName"].ToString(),
                        Password = consulta["PasswordHash"].ToString(),
                        UserId = consulta["Id"].ToString(),
                        Email = consulta["Email"].ToString()
                    };
                    model.Add(Usuarios_Registrados);
                }
            }
            command.Connection.Close();
            connection.Close();
        }
        return model;
    }

    public static object SQL_ConsultaRol(string SQLComando)
    {
        var model = new List<Tipo_Rol>();
        using (var connection = new SqlConnection(DB_SGDE))
        {
            var command = new SqlCommand(SQLComando, connection);
            command.Connection.Open();
            var consulta = command.ExecuteReader();
            if (consulta.HasRows)
            {
                while (consulta.Read())
                {
                    var Roles_Registrados = new Tipo_Rol {
                        Nombre = consulta["Name"].ToString(),
                        RoleId = consulta["Id"].ToString()
                    };
                    model.Add(Roles_Registrados);
                }
            }
            command.Connection.Close();
            connection.Close();
        }
        return model;
    }

    public static object SQL_ConsultaTools(string SQLComando)
    {
        var model = new List<CreatePostTools>();
        using (var connection = new SqlConnection(DB_SGDE))
        {
            var command = new SqlCommand(SQLComando, connection);
            command.Connection.Open();
            var consulta = command.ExecuteReader();
            if (consulta.HasRows)
            {
                while (consulta.Read())
                {
                    var Tools_Registrados = new CreatePostTools();
                    if (SQLComando.Contains("ToolsTypeDoc"))
                    {
                        Tools_Registrados.NombreT = consulta["Nombre"].ToString();
                    }
                    Tools_Registrados.Cod = consulta["Cod"].ToString();
                    Tools_Registrados.Xusr = consulta["xusr"].ToString();
                    Tools_Registrados.Id = Convert.ToInt32(consulta["Id"]);
                    Tools_Registrados.Xfec = DateTime.Parse(consulta["xfec"].ToString());
                    model.Add(Tools_Registrados);
                }
            }
            command.Connection.Close();
            connection.Close();
        }
        return model;
    }

    public static object SQL_ConsultaRolyUsuario(string SQLComando)
    {
        var model = new List<Tipo_RolyUsuario>();
        using (var connection = new SqlConnection(DB_SGDE))
        {
            var command = new SqlCommand(SQLComando, connection);
            command.Connection.Open();
            var consulta = command.ExecuteReader();
            if (consulta.HasRows)
            {
                while (consulta.Read())
                {
                    var RolesyUsuario_Registrados = new Tipo_RolyUsuario {
                        UserId = consulta["UserId"].ToString(),
                        RoleId = consulta["RoleId"].ToString()
                    };
                    model.Add(RolesyUsuario_Registrados);
                }
            }
            command.Connection.Close();
            connection.Close();
        }
        return model;
    }

    public static object SQL_ConsulaDocumentos(string SQLComando)
    {
        var model = new List<Tipo_Documentos>();
        using (var connection = new SqlConnection(DB_SGDE))
        {
            var command = new SqlCommand(SQLComando, connection);
            command.Connection.Open();
            var consulta = command.ExecuteReader();
            if (consulta.HasRows)
            {
                while (consulta.Read())
                {
                    var Doc = new Tipo_Documentos {
                        IdReg = consulta["IdReg"].ToString(),
                        NumDoc = consulta["NumDoc"].ToString(),
                        Documento = consulta["Documento"].ToString(),
                        COD3 = consulta["COD3"].ToString(),
                        Xfec = DateTime.Parse(consulta["xfec"].ToString()),
                        Xusr = consulta["xusr"].ToString(),
                        CodTipo = consulta["CodTipo"].ToString(),
                        EstadoEdicion = consulta["EstadoEdicion"].ToString(),
                        TipoDoc = consulta["TipoDoc"].ToString(),
                        Descripcion = consulta["Descripcion"].ToString(),
                        Tag = consulta["Tag"].ToString(),
                        NumEdicion = Convert.ToInt32(consulta["NumEdicion"]),
                        NombreArchivo = consulta["NombreArchivo"].ToString()
                    };
                    model.Add(Doc);
                }
            }
            command.Connection.Close();
            connection.Close();
        }
        return model;
    }

    public static object SQL_ConsulaAcciones(string SQLComando)
    {
        var model = new List<Tipo_Acciones>();
        using (var connection = new SqlConnection(DB_SGDE))
        {
            var command = new SqlCommand(SQLComando, connection);
            command.Connection.Open();
            var consulta = command.ExecuteReader();
            if (consulta.HasRows)
            {
                while (consulta.Read())
                {
                    var Doc = new Tipo_Acciones {
                        Id = Convert.ToInt32(consulta["Id"]),
                        IdReg = consulta["IdReg"].ToString(),
                        NumDoc = consulta["NumDoc"].ToString(),
                        Xfec = DateTime.Parse(consulta["xfec"].ToString()),
                        Xusr = consulta["xusr"].ToString(),
                        NumEdicion = Convert.ToInt32(consulta["NumEdicion"]),
                        Obs = consulta["Obs"].ToString()
                    };
                    model.Add(Doc);
                }
            }
            command.Connection.Close();
            connection.Close();
        }
        return model;
    }

    public static object SQL_ConsulaTrazaDocumentos(string SQLComando)
    {
        var model = new List<Tipo_TrazaDocumentos>();
        using (var connection = new SqlConnection(DB_SGDE))
        {
            var command = new SqlCommand(SQLComando, connection);
            command.Connection.Open();
            var consulta = command.ExecuteReader();
            if (consulta.HasRows)
            {
                while (consulta.Read())
                {
                    var Doc = new Tipo_TrazaDocumentos {
                        Id = Convert.ToInt32(consulta["Id"]),
                        IdReg = consulta["IdReg"].ToString(),
                        NumDoc = consulta["NumDoc"].ToString(),
                        Xfec = DateTime.Parse(consulta["xfec"].ToString()),
                        Documento = consulta["Documento"].ToString(),
                        NumEdicion = Convert.ToInt32(consulta["NumEdicion"]),
                        COD3 = consulta["COD3"].ToString(),
                        Xusr = consulta["xusr"].ToString(),
                        CTipo = consulta["CodTipo"].ToString(),
                        EstadoEdicion = consulta["EstadoEdicion"].ToString(),
                        TipoDocumento = consulta["TipoDoc"].ToString(),
                        Descripcion = consulta["Descripcion"].ToString(),
                        Tag = consulta["Tag"].ToString(),
                        NombreArchivo = consulta["NombreArchivo"].ToString(),
                        Accion = consulta["Accion"].ToString(),
                        Obs = consulta["Obs"].ToString()
                    };
                    model.Add(Doc);
                }
            }
            command.Connection.Close();
            connection.Close();
        }
        return model;
    }

    public static void SQL_Ejecuta(string SQLComando)
    {
        using var connection = new SqlConnection(DB_SGDE);
        var command = new SqlCommand(SQLComando, connection);
        command.Connection.Open();
        var consulta = command.ExecuteReader();
        command.Connection.Close();
        connection.Close();
    }

    public static string SQL_Ejecuta_pDocumentosAdd(string Documento, string Cod3, string Usuario, string CTipo, string TipoDocumento, string Descripcion, string NombreArchivo, string Obs)
    {
        string txt = "Sin Retorno";
        using var connection = new SqlConnection(DB_SGDE);
        using var com = new SqlCommand();
        try
        {
            var output = new SqlParameter("@msg", SqlDbType.VarChar, 200) {
                Direction = ParameterDirection.Output
            };
            com.Parameters.Add(output);

            // Al comando se le asigna una conexión
            com.Connection = connection;

            // Se le indica el tipo de comando y el nombre
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[pDocumentosAdd]";
            com.Parameters.AddWithValue("@COD3", Cod3);
            com.Parameters.AddWithValue("@Documento", Documento);
            com.Parameters.AddWithValue("@xusr", Usuario);
            com.Parameters.AddWithValue("@CodTipo", CTipo);
            com.Parameters.AddWithValue("@TipoDoc", TipoDocumento);
            com.Parameters.AddWithValue("@Descripcion", Descripcion);
            com.Parameters.AddWithValue("@NombreArchivo", NombreArchivo);
            com.Parameters.AddWithValue("@Obs", Obs);
            // Se abre la conexión
            connection.Open();

            // Se recupera el lector de datos al utilizar ExecuteReader
            com.ExecuteScalar();

            // Se recuperan los parámetros de salida
            txt = output.Value.ToString();
            connection.Close();
            if (txt == null | txt == "")
            {
                txt = "ERROR : No tenemos parametro de retorno";
            }
            com.Connection.Close();

            return txt;
        }
        catch (Exception ex)
        {
            txt = "ERROR : " + ex.Message;
            connection.Close();
            com.Connection.Close();
            return txt;
        }
    }

    public static string SQL_Ejecuta_pNewTypeAdd(string nombre, string cod, string por) {
        string txt = "Sin Retorno";
        using var connection = new SqlConnection(DB_SGDE);
        using var com = new SqlCommand();
        try
        {
            var output = new SqlParameter("@msg", SqlDbType.VarChar, 200) {
                Direction = ParameterDirection.Output
            };
            com.Parameters.Add(output);

            // Al comando se le asigna una conexión
            com.Connection = connection;

            // Se le indica el tipo de comando y el nombre
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[pNewTypeAdd]";
            com.Parameters.AddWithValue("@Cod", cod);
            com.Parameters.AddWithValue("@Nombre", nombre);
            com.Parameters.AddWithValue("@xusr", por);
            // Se abre la conexión
            connection.Open();

            // Se recupera el lector de datos al utilizar ExecuteReader
            com.ExecuteScalar();

            // Se recuperan los parámetros de salida
            txt = output.Value.ToString();
            connection.Close();
            if (txt == null | txt == "")
            {
                txt = "ERROR : No tenemos parametro de retorno";
            }
            com.Connection.Close();

            return txt;
        }
        catch (Exception ex)
        {
            txt = "ERROR : " + ex.Message;
            connection.Close();
            com.Connection.Close();
            return txt;
        }
    }

    public static string SQL_Ejecuta_pNewCodeAdd(string cod, string por)
    {
        string txt = "Sin Retorno";
        using var connection = new SqlConnection(DB_SGDE);
        using var com = new SqlCommand();
        try
        {
            var output = new SqlParameter("@msg", SqlDbType.VarChar, 200) {
                Direction = ParameterDirection.Output
            };
            com.Parameters.Add(output);

            // Al comando se le asigna una conexión
            com.Connection = connection;

            // Se le indica el tipo de comando y el nombre
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[pNewCodeAdd]";
            com.Parameters.AddWithValue("@Cod", cod);
            com.Parameters.AddWithValue("@xusr", por);
            // Se abre la conexión
            connection.Open();

            // Se recupera el lector de datos al utilizar ExecuteReader
            com.ExecuteScalar();

            // Se recuperan los parámetros de salida
            txt = output.Value.ToString();
            connection.Close();
            if (txt == null | txt == "")
            {
                txt = "ERROR : No tenemos parametro de retorno";
            }
            com.Connection.Close();

            return txt;
        }
        catch (Exception ex)
        {
            txt = "ERROR : " + ex.Message;
            connection.Close();
            com.Connection.Close();
            return txt;
        }
    }

    public static string SQL_Ejecuta_pToolsUp(string Nombre, string Code, string Usuario, string TC, int Id)
    {
        string txt = "Sin Retorno";
        using var connection = new SqlConnection(DB_SGDE);
        using var com = new SqlCommand();
        try
        {
            var output = new SqlParameter("@msg", SqlDbType.VarChar, 200) {
                Direction = ParameterDirection.Output
            };
            com.Parameters.Add(output);

            // Al comando se le asigna una conexión
            com.Connection = connection;

            // Se le indica el tipo de comando y el nombre
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[pToolsUp]";
            com.Parameters.AddWithValue("@Nombre", Nombre);
            com.Parameters.AddWithValue("@Code", Code);
            com.Parameters.AddWithValue("@xusr", Usuario);
            com.Parameters.AddWithValue("@TC", TC);
            com.Parameters.AddWithValue("@Id", Id);
            // Se abre la conexión
            connection.Open();

            // Se recupera el lector de datos al utilizar ExecuteReader
            com.ExecuteScalar();

            // Se recuperan los parámetros de salida
            txt = output.Value.ToString();
            connection.Close();
            if (txt == null | txt == "")
            {
                txt = "ERROR : No tenemos parametro de retorno";
            }
            com.Connection.Close();

            return txt;
        }
        catch (Exception ex)
        {
            txt = "ERROR : " + ex.Message;
            connection.Close();
            com.Connection.Close();
            return txt;
        }
    }

    public static string SQL_Ejecuta_pToolsDel(string Code, string Confirmado,string T_C, string usuario,int Id)
    {
        string txt = "Sin Retorno";
        if (Confirmado == "0")
        {
            return "Canceled Delete";
        }
        if (Confirmado == "1")
        {
            using var connection = new SqlConnection(DB_SGDE);
            using var com = new SqlCommand();
            try
            {
                var output = new SqlParameter("@msg", SqlDbType.VarChar, 200) {
                    Direction = ParameterDirection.Output
                };
                com.Parameters.Add(output);

                // Al comando se le asigna una conexión
                com.Connection = connection;

                // Se le indica el tipo de comando y el nombre
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[dbo].[pToolsDel]";
                com.Parameters.AddWithValue("@Code", Code);
                com.Parameters.AddWithValue("@xusr", usuario);
                com.Parameters.AddWithValue("@TC", T_C);
                com.Parameters.AddWithValue("@Id", Id);

                // Se abre la conexión
                connection.Open();

                // Se recupera el lector de datos al utilizar ExecuteReader
                com.ExecuteScalar();

                // Se recuperan los parámetros de salida
                txt = output.Value.ToString();
                connection.Close();
                if (txt == null | txt == "")
                {
                    txt = "ERROR : No tenemos parametro de retorno";
                }
                com.Connection.Close();

                return txt;
            }
            catch (Exception ex)
            {
                txt = "ERROR : " + ex.Message;
                connection.Close();
                com.Connection.Close();
                return txt;
            }
        }
        return txt;
    }

    public static string SQL_Ejecuta_pDocumentosUp(string Documento, string Cod3, string Usuario, string CTipo, string TipoDocumento, string Descripcion, string IdReg, string NumDoc, string EstadoEdicion, int NumEdicion, string NombreArchivo, string Obs,bool CambioFichero)
    {
        string txt = "Sin Retorno";
        using var connection = new SqlConnection(DB_SGDE);
        using var com = new SqlCommand();
        try
        {
            var output = new SqlParameter("@msg", SqlDbType.VarChar, 200) {
                Direction = ParameterDirection.Output
            };
            com.Parameters.Add(output);

            // Al comando se le asigna una conexión
            com.Connection = connection;

            // Se le indica el tipo de comando y el nombre
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[pDocumentosUp]";
            com.Parameters.AddWithValue("@COD3", Cod3);
            com.Parameters.AddWithValue("@Documento", Documento);
            com.Parameters.AddWithValue("@xusr", Usuario);
            com.Parameters.AddWithValue("@CodTipo", CTipo);
            com.Parameters.AddWithValue("@TipoDoc", TipoDocumento);
            com.Parameters.AddWithValue("@Descripcion", Descripcion);
            com.Parameters.AddWithValue("@IdReg", IdReg);
            com.Parameters.AddWithValue("@NumDoc", NumDoc);
            com.Parameters.AddWithValue("@EstadoEdicion", EstadoEdicion);
            com.Parameters.AddWithValue("@NumEdicion", NumEdicion);
            com.Parameters.AddWithValue("@NombreArchivo", NombreArchivo);
            com.Parameters.AddWithValue("@CambioFichero", CambioFichero);
            if (Obs == null) { Obs = ""; }
            com.Parameters.AddWithValue("@Obs", Obs);

            // Se abre la conexión
            connection.Open();

            // Se recupera el lector de datos al utilizar ExecuteReader
            com.ExecuteScalar();

            // Se recuperan los parámetros de salida
            txt = output.Value.ToString();
            connection.Close();
            if (txt == null | txt == "")
            {
                txt = "ERROR : No tenemos parametro de retorno";
            }
            com.Connection.Close();

            return txt;
        }
        catch (Exception ex)
        {
            txt = "ERROR : " + ex.Message;
            connection.Close();
            com.Connection.Close();
            return txt;
        }
    }

    public static string SQL_Ejecuta_pDocumentosDel(string Idreg, string Confirmado, string usuario)
    {
        string txt = "Sin Retorno";
        if (Confirmado == "0")
        {
            return "Canceled Delete File";
        }
        if (Confirmado == "1")
        {
            using var connection = new SqlConnection(DB_SGDE);
            using var com = new SqlCommand();
            try
            {
                var output = new SqlParameter("@msg", SqlDbType.VarChar, 200) {
                    Direction = ParameterDirection.Output
                };
                com.Parameters.Add(output);

                // Al comando se le asigna una conexión
                com.Connection = connection;

                // Se le indica el tipo de comando y el nombre
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[dbo].[pDocumentosDel]";
                com.Parameters.AddWithValue("@IdReg", Idreg);
                com.Parameters.AddWithValue("@xusr", usuario);

                // Se abre la conexión
                connection.Open();

                // Se recupera el lector de datos al utilizar ExecuteReader
                com.ExecuteScalar();

                // Se recuperan los parámetros de salida
                txt = output.Value.ToString();
                connection.Close();
                if (txt == null | txt == "")
                {
                    txt = "ERROR : No tenemos parametro de retorno";
                }
                com.Connection.Close();

                return txt;
            }
            catch (Exception ex)
            {
                txt = "ERROR : " + ex.Message;
                connection.Close();
                com.Connection.Close();
                return txt;
            }
        }
        return txt;
    }

    public static string ObtenObs(string idreg, string tipo) 
    {
        string tabla = " ";
        if (tipo == "RIP") { tabla = "Creacion"; }
        if (tipo == "PAP") { tabla = "Revision"; }
        if (tipo == "AP") { tabla = "Aprobacion"; }
        foreach (var Docs in (List<Tipo_Acciones>)Metodos.SQL_ConsulaAcciones("Select top 1 * from " + tabla + " where IdReg='" + idreg + "' order by xfec desc"))
        {
            return Docs.Obs;
        }
        return tabla;
    }

    public static string ExtensionArchivo(string FileName)
    {
        return Path.GetExtension(FileName);
    }

    public static string Encriptar(string texto)
    {
        var encoder = new UTF8Encoding();
        var sha256hasher = new SHA256Managed();
        byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(texto));
        return Convert.ToBase64String(hashedDataBytes);
    }

    public static void WordAPDF(string PathOrigen, string PathDestino, string strFileName)
    {
        var objWorPdf = new Word2Pdf();
        object FromLocation = PathOrigen + strFileName;
        string FileExtension = Path.GetExtension(strFileName);
        string ChangeExtension = strFileName.Replace(FileExtension, ".pdf");
        if (FileExtension == ".doc" || FileExtension == ".docx")
        {
            object ToLocation = PathDestino + ChangeExtension;
            objWorPdf.InputLocation = FromLocation;
            objWorPdf.OutputLocation = ToLocation;
            objWorPdf.Word2PdfCOnversion();
        }
    }

    public static string Excel_PDF(string excelFile, string pdfFile)
    {
        try
        {
            var app = new Microsoft.Office.Interop.Excel.Application {
                Visible = false,
                DisplayAlerts = false
            };
            var wkb = app.Workbooks.Open(excelFile, ReadOnly: true);
            wkb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdfFile);
            wkb.Close();
            app.Quit();
            return "OK";
        }
        catch (Exception ex)
        {
            return ("ERROR: "+ex.StackTrace);
            throw ex;
        }

    }

    public static void SubirFichero(CreatePost posteado, string PathDestino)
    {
        string uniqueFileName = posteado.Documento + Metodos.ExtensionArchivo(posteado.Archivo.FileName);
        string filePath = Path.Combine(PathDestino, uniqueFileName);

        using var stream = System.IO.File.Create(filePath);
        posteado.Archivo.CopyTo(stream);
    }

    public static void EnviaEmail(string _Subject, string _Body, string _SendTo)
    {
        string _UserEmail = "datacapture";
        string _PasswordEmail = "ecexaqa9";
        var exchange = new ExchangeService {
            Credentials = new WebCredentials(_UserEmail, _PasswordEmail)
        };
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        exchange.Url = new System.Uri("https://exchange.espackeuro.com/ews/exchange.asmx");
        if (exchange != null)
        {
            var message = new EmailMessage(exchange);
            {
                message.Subject = _Subject;
                message.Body = _Body;
                message.ToRecipients.Add(_SendTo);
                message.Save();
                message.SendAndSaveCopy();
            }
        }
    }
    public static string ObtenRol(string Nombre)
    {
      string idusuario="";
        foreach(var Usuarios in (List<Tipo_AspNetUsers>)Metodos.SQL_ConsultaUserProfile("Select * from AspNetUsers WHERE UserName='"+Nombre + "'"))
        {
            idusuario = Usuarios.UserId;
        }
        foreach (var Rol in (List<Tipo_RolyUsuario>)Metodos.SQL_ConsultaRolyUsuario("Select * from AspNetUserRoles WHERE UserId='"+idusuario+"'"))
        {
            return Rol.RoleId;
        }
        return "0";
    }
    public static Tipo_AspNetUsers ObtenUsuarioActivo(string useractivo)
    {
        var Nombre = new Tipo_AspNetUsers();
        foreach (var Usuarios in (List<Tipo_AspNetUsers>)Metodos.SQL_ConsultaUserProfile("Select * from AspNetUsers WHERE UserName='" + useractivo + "'"))
        {
            Nombre.NombreU = Usuarios.NombreU;
            Nombre.Usuario = Usuarios.Usuario;
            Nombre.UserId = Usuarios.UserId;
            Nombre.Cod3 = Usuarios.Cod3;
        }
        return Nombre;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class MasterFruta
    {
        [Key]
        public int Fruta_Id { get; set; }
        public string Descripcion { get; set; }
        public int Tienda_Id { get; set; }
        public string xusr { get; }
        public string xord { get; }
        public DateTime xfec { get; }
        public string xsrv { get; }
    }
}

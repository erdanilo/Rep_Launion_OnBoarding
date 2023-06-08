//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnBoarding.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OBDTPuesto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OBDTPuesto()
        {
            this.OBDTEmpleadoPuesto = new HashSet<OBDTEmpleadoPuesto>();
            this.OBDTPlan = new HashSet<OBDTPlan>();
        }
    
        public int IdPuesto { get; set; }
        public int CodigoPuesto { get; set; }
        public string NombrePuesto { get; set; }
        public bool Activo { get; set; }
        public string UsuarioInserto { get; set; }
        public System.DateTime FechaInserto { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OBDTEmpleadoPuesto> OBDTEmpleadoPuesto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OBDTPlan> OBDTPlan { get; set; }
    }
}
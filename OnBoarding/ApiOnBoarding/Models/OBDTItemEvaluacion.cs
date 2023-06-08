//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiOnBoarding.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OBDTItemEvaluacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OBDTItemEvaluacion()
        {
            this.OBDTAspectoConductualItemEvaluacion = new HashSet<OBDTAspectoConductualItemEvaluacion>();
            this.OBDTAspectoTecnicoItemEvaluacion = new HashSet<OBDTAspectoTecnicoItemEvaluacion>();
        }
    
        public int IdItemEvaluacion { get; set; }
        public int CodigoItemEvaluacion { get; set; }
        public string NombreItemEvaluacion { get; set; }
        public bool Activo { get; set; }
        public string UsuarioInserto { get; set; }
        public System.DateTime FechaInserto { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OBDTAspectoConductualItemEvaluacion> OBDTAspectoConductualItemEvaluacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OBDTAspectoTecnicoItemEvaluacion> OBDTAspectoTecnicoItemEvaluacion { get; set; }
    }
}

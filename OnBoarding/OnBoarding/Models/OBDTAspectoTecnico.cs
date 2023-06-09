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
    
    public partial class OBDTAspectoTecnico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OBDTAspectoTecnico()
        {
            this.OBDTAspectoTecnicoItemEvaluacion = new HashSet<OBDTAspectoTecnicoItemEvaluacion>();
        }
    
        public int IdAspectoTecnico { get; set; }
        public int CodigoAspectoTecnico { get; set; }
        public string NombreAspectoTecnico { get; set; }
        public int IdObjetivoAprendizaje { get; set; }
        public bool Activo { get; set; }
        public string UsuarioInserto { get; set; }
        public System.DateTime FechaInserto { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
    
        public virtual OBDTObjetivoAprendizaje OBDTObjetivoAprendizaje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OBDTAspectoTecnicoItemEvaluacion> OBDTAspectoTecnicoItemEvaluacion { get; set; }
    }
}

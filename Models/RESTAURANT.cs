//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionRestaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESTAURANT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESTAURANT()
        {
            this.COMMENTAIREs = new HashSet<COMMENTAIRE>();
            this.TABLE_RESTAURANT = new HashSet<TABLE_RESTAURANT>();
        }
    
        public int Id_restaurant { get; set; }
        public string Nom_restaurant { get; set; }
        public string Adresse_restaurant { get; set; }
        public int Nombre_etoile { get; set; }
        public int Nombre_table { get; set; }
        public int Id_utilisateur { get; set; }
        public string Telephone { get; set; }
        public string Image_restaurant { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENTAIRE> COMMENTAIREs { get; set; }
        public virtual UTILISATEUR UTILISATEUR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABLE_RESTAURANT> TABLE_RESTAURANT { get; set; }
    }
}
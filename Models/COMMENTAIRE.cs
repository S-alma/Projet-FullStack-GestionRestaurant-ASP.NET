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
    
    public partial class COMMENTAIRE
    {
        public int Id_commentaire { get; set; }
        public string Type_commentaire { get; set; }
        public System.DateTime Date_commentaire { get; set; }
        public string Commentaire1 { get; set; }
        public int Id_utilisateur { get; set; }
        public int Id_restaurant { get; set; }
    
        public virtual RESTAURANT RESTAURANT { get; set; }
        public virtual UTILISATEUR UTILISATEUR { get; set; }
    }
}
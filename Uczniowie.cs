//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Uczniowie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uczniowie()
        {
            this.Wypozyczenia = new ObservableCollection<Wypozyczenia>();
        }
    
        public int IdUcznia { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Klasa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Wypozyczenia> Wypozyczenia { get; set; }
    }
}

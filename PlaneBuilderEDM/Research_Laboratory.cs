//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlaneBuilderEDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Research_Laboratory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Research_Laboratory()
        {
            this.Employees = new HashSet<Employee>();
            this.Products = new HashSet<Product>();
            this.Researches = new HashSet<Research>();
        }
    
        public int ID_Laboratory { get; set; }
        public string Name_Laboratory { get; set; }
        public int ID_Appointment { get; set; }
    
        public virtual Appointment_Research_Laboratory Appointment_Research_Laboratory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Research> Researches { get; set; }
    }
}

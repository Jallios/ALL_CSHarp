//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlaneBuilder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment_Research_Laboratory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment_Research_Laboratory()
        {
            this.Research_Laboratory = new HashSet<Research_Laboratory>();
        }
    
        public int ID_Appointment { get; set; }
        public string Name_Appointment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Research_Laboratory> Research_Laboratory { get; set; }
    }
}
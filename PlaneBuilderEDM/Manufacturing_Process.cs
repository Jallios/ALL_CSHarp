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
    
    public partial class Manufacturing_Process
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manufacturing_Process()
        {
            this.Brigades = new HashSet<Brigade>();
        }
    
        public int ID_Process { get; set; }
        public string Name_Process { get; set; }
        public string Status_Process { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Brigade> Brigades { get; set; }
    }
}

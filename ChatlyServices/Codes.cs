//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatlyServices
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class Codes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Codes()
        {
            this.Messages = new HashSet<Messages>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PinCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Messages> Messages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    [DataContract]
    public class FiltersView
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }
        [DataMember(Name = "Checked")]
        public bool Checked { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocApp.Models
{
    internal class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

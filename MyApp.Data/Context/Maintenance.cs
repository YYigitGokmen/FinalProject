using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Data.Context
{
    public class Maintenance
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public string Reason { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saichkina_backend.Models
{
    public class Doloto
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public ICollection<Сharacteristic> Totaldolotoes { get; set; }

        public int GetCountOfDolotoes()
        {
            return Totaldolotoes.Count;
        }

    }
}

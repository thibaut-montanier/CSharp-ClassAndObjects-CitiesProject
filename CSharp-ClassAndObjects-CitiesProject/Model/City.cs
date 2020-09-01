using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_POO.Model {
    public class City {

        /// <summary>
        /// Nom de la commune
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Nombre d'habitants
        /// </summary>
        public int NbCitizens { get; set; }
        /// <summary>
        /// Code postal de la commune
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// Departement de la commune
        /// </summary>
        public Department Department { get; set; }
    }
}

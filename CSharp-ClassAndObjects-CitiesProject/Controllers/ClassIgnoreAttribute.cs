using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Controllers {
    [System.AttributeUsage(System.AttributeTargets.Class |
                         System.AttributeTargets.Struct)
  ]
    public class ClassIgnoreAttribute : System.Attribute {
        private string _Reason;
        public double version;

        public ClassIgnoreAttribute(string reason) {
            this._Reason= reason;
            version = 1.0;
        }
    }
}

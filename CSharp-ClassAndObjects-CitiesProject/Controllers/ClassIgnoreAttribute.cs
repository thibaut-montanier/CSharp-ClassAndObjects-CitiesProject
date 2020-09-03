using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Controllers {
[System.AttributeUsage(System.AttributeTargets.Class)]
public class ClassIgnoreAttribute : System.Attribute {
    public string Reason { get; }

    public ClassIgnoreAttribute(string reason) {
        this.Reason= reason;
    }
}
}

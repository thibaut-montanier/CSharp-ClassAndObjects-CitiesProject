using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_POO.Model {
public class Department {

    public string Name { get; set; }

    public int Code { get; set; }

    public List<City> Cities { get; set; } = new List<City>();
}
}

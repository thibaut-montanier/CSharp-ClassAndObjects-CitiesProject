using CSharp_POO.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Services {
public interface IDepartmentService {
    void ShowDepartmentsInformation();
    Department AskForDepartment(string msg);
    void CreateDepartment();
}
}

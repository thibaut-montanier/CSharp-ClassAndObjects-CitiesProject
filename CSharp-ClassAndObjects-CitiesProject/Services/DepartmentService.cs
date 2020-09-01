using CSharp_POO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Services {
    public class DepartmentService : IDepartmentService {
        private AskTheUser _AskTheUser;
        private List<Department> _allDepartments { get; set; } = new List<Department>();

        public DepartmentService(AskTheUser askTheUser) {
            this._AskTheUser = askTheUser;
        }
        public void ShowDepartmentsInformation() {
            foreach (var d in _allDepartments)
                ShowDepartmentInformation(d);
        }
        public Department AskForDepartment(string msg) {
            Console.WriteLine(msg);
            do {
                string value = Console.ReadLine();
                int intValue;
                if (!string.IsNullOrEmpty(value) && int.TryParse(value, out intValue)
                    && _allDepartments.Any(d => d.Code == intValue)) {
                    // we got the result => return the department
                    return _allDepartments.First(d => d.Code == intValue);
                } else {
                    Console.WriteLine("incorrect, please try again");
                }
            } while (true);
        }

        private void ShowDepartmentInformation(Department d) {
            Console.WriteLine($"Department : {d.Name} " +
                    $"({d.Code})");
            // count number of people living here
            int nbPeople = 0;
            foreach (var c in d.Cities)
                nbPeople += c.NbCitizens;
            // writing number
            Console.WriteLine($"People : {nbPeople}");
        }

        public void CreateDepartment() {
            Department dpt = new Department();
            dpt.Name = _AskTheUser.ForStringValue("Department name ?");
            dpt.Code = _AskTheUser.ForIntValue("Department code ?");
            _allDepartments.Add(dpt);
        }

    }

}

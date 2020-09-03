using CSharp_ClassAndObjects_CitiesProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Controllers {
    [ClassIgnore("No dept for the moment")]
    class DepartmentController : IMenuController {

        private IDepartmentService _DepartmentService;

        public DepartmentController(IDepartmentService departmentService) {
            this._DepartmentService = departmentService;
        }
        public string showMenu() {
            return "3. Create a department\n" +
                    "4. Show all departments";
        }

        public void DoAction(string saisie) {
            switch (saisie.ToUpper()) {
                case "3":
                    _DepartmentService.CreateDepartment();
                    break;
                case "4":
                    _DepartmentService.ShowDepartmentsInformation();
                    break;
            }
        }

        public bool isAvailableItem(string saisie) {
            return saisie == "3" || saisie == "4";
        }

        public bool exit() {
            return false;
        }
    }
}

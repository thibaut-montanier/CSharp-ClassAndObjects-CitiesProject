using CSharp_ClassAndObjects_CitiesProject.Controllers;
using CSharp_ClassAndObjects_CitiesProject.Services;
using CSharp_POO.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace CSharp_POO {
    public class Program {

        static void Main(string[] args) {
            // services init
            AskTheUser _AskTheUser = new AskTheUser();
            IDepartmentService _DepartmentService = new DepartmentService(_AskTheUser);
            CityService _CityService = new CityService(_AskTheUser, _DepartmentService);
            // controllers init
            List<IMenuController> ctrls = new List<IMenuController>();
            ctrls.Add(new CitiesController(_CityService));
            ctrls.Add(new DepartmentController(_DepartmentService));
            ctrls.Add(new CitiesAndMemoryController(_CityService));
            ctrls.Add(new GeneralController());

            // generate menu message
            string MenuMessage = "What do you want to do ?\n" +
                string.Join('\n', ctrls.Select(c => c.showMenu()));

            // prog
            bool exit = false;
            List<City> allCities = new List<City>();
            do {
                // get user input   
                string saisie = _AskTheUser.ForStringValue(MenuMessage);
                // do actions
                bool actionDone = false;
                foreach (var ctrl in ctrls) { 
                    if (ctrl.isAvailableItem(saisie)) {
                        actionDone = true;
                        ctrl.DoAction(saisie);
                        exit = ctrl.exit();
                    }
                }
                if (!actionDone)
                    Console.WriteLine("I didn't understand");
            } while (!exit);

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }




    }
}

using CSharp_ClassAndObjects_CitiesProject.Controllers;
using CSharp_ClassAndObjects_CitiesProject.Services;
using CSharp_POO.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
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
            List<IMenuController> ctrls = getControllers(new object[] {_DepartmentService, _CityService});

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


        /// <summary>
        /// Another way to initialize controllers
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
private static List<IMenuController> getControllers(object[] inputServices) {

    var result = new List<IMenuController>();

    // loading from current assembly
    Assembly myAssembly = Assembly.GetExecutingAssembly();

    // get all class implementing IMenuController
    Type typeofIMenuController = typeof(IMenuController); // very slow operation, avoid to do this in loop
            var allCtrlTypes = myAssembly.GetTypes().Where(t => t.IsClass && typeofIMenuController.IsAssignableFrom(t)
                                            && !t.GetCustomAttributes<ClassIgnoreAttribute>().Any());

    // now, we create all Controllers
    foreach (var ctrlType in allCtrlTypes) {
        result.Add(createControler(ctrlType, inputServices));
    }
    // return results sorted by the menu 
    return result.OrderBy(c => c.showMenu()).ToList();
}


private static IMenuController createControler(Type CtrlType, object[] inputServices) {
    // Prepare the list of parameters for the constructor
    var specificparameters = new List<object>();
    // we do a sort of Dependency injection, taking a look at constructor parameters
    // we take the first constructor
    ConstructorInfo constr = CtrlType.GetConstructors().First();
    // analyzing constructor parameters
    foreach (var p in constr.GetParameters()) {
        // loop on all input services to provide to Controllers
        foreach (var inputParams in inputServices) {
            // if the parameter is compatible, we had it to the params
            if (p.ParameterType.IsAssignableFrom(inputParams.GetType())) {
                specificparameters.Add(inputParams);
            }
        }

    }
    // Create the instance with the parameters
    return (IMenuController)Activator.CreateInstance(CtrlType, specificparameters.ToArray());
}




    }
}

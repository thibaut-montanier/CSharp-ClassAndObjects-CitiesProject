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
            // prog
            bool exit = false;
            List<City> allCities = new List<City>();
            do {
                // show menu
                string Menu = "What do you want to do ?\n" +
                                "1. Create a city\n" +
                                "2. Show all cities\n" +
                                "3. Create a department\n" +
                                "4. Show all departments\n" +
                                "5. Load many cities\n" +
                                "6. Reload many cities\n" +
                                "7. Clear cities\n" +
                                "8. Save cities to file\n" +
                                "GC. Garbage collector\n" +
                                "E. Exit";
                string saisie = _AskTheUser.ForStringValue(Menu);
                // do actions
                switch (saisie.ToUpper()) {
                    case "1":
                        _CityService.CreateCity();
                        break;
                    case "2":
                        _CityService.ShowCitiesInformation();
                        break;
                    case "3":
                        _DepartmentService.CreateDepartment();
                        break;
                    case "4":
                        _DepartmentService.ShowDepartmentsInformation();
                        break;
                    case "5":
                        _CityService.AddManyCities(1000000);
                        break;
                    case "6":
                        _CityService.ClearCities();
                        _CityService.AddManyCities(1000000);
                        break;
                    case "7":
                        _CityService.ClearCities();
                        break;
                    case "8":
                        _CityService.SaveToFile(@"./cities.csv");
                        break;
                    case "GC":
                        GC.Collect();
                        break;
                    case "E":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("I didn't understand");
                        break;
                }
            } while (!exit);

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }




    }
}

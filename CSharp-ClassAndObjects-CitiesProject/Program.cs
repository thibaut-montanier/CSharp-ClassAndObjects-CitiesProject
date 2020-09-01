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

        private static AskTheUser _AskTheUser = new AskTheUser();
        private static DepartmentService _DepartmentService = new DepartmentService(_AskTheUser);
        static void Main(string[] args) {
            bool exit = false;
            List<City> allCities = new List<City>();
            do {
                // show menu
                string Menu = "What do you want to do ?\n" +
                                "1. Create a city\n" +
                                "2. Show all cities\n" +
                                "3. Create a department\n" +
                                "4. Show all departments\n" +
                                "E. Exit";
                string saisie = _AskTheUser.ForStringValue(Menu);
                // do actions
                switch (saisie.ToUpper()) {
                    case "1":
                        allCities.Add(createCity());
                        break;
                    case "2":
                        showCitiesInformation(allCities);
                        break;
                    case "3":
                        _DepartmentService.CreateDepartment();
                        break;
                    case "4":
                        _DepartmentService.ShowDepartmentsInformation();
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

        private static void showCitiesInformation(List<City> allCities) {
            foreach (var c in allCities)
                showCityInformation(c);
        }

        private static void showCityInformation(City cityToShow) {
            Console.WriteLine($"City : {cityToShow.Name} " +
                $"({cityToShow.PostCode} - {cityToShow.Department.Name})");
            Console.WriteLine($"Cityzen : {cityToShow.NbCitizens}");
        }

        public static City createCity() {
            City myCity = new City();

            myCity.Name = _AskTheUser.ForStringValue("City name ?");
            myCity.NbCitizens = _AskTheUser.ForIntValue("Number of cityzens ?");
            myCity.PostCode = _AskTheUser.ForStringValue("Postcode ?");
            myCity.Department = _DepartmentService.AskForDepartment("Department code ?");
            myCity.Department.Cities.Add(myCity); 
            return myCity;
        }


    }
}

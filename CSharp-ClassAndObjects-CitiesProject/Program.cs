using CSharp_POO.Helper;
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
            bool exit = false;
            List<City> allCities = new List<City>();
            List<Department> allDepartments = new List<Department>();
            do {
                // show menu
                string Menu = "What do you want to do ?\n" +
                                "1. Create a city\n" +
                                "2. Show all cities\n" +
                                "3. Create a department\n" +
                                "4. Show all departments\n" +
                                "E. Exit";
                string saisie = AskTheUser_ForStringValue(Menu);
                // do actions
                switch (saisie.ToUpper()) {
                    case "1":
                        allCities.Add(createCity(allDepartments));
                        break;
                    case "2":
                        showCitiesInformation(allCities);
                        break;
                    case "3":
                        allDepartments.Add(createDepartment());
                        break;
                    case "4":
                        showDepartmentsInformation(allDepartments);
                        break;
                    case "Q":
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

        private static void showDepartmentsInformation(List<Department> allDepartments) {
            foreach (var d in allDepartments)
                showDepartmentInformation(d);
        }

        private static void showDepartmentInformation(Department d) {
            Console.WriteLine($"Department : {d.Name} " +
                    $"({d.Code})");
            // count number of people living here
            int nbPeople = 0;
            foreach (var c in d.Cities)
                nbPeople += c.NbCitizens;
            // writing number
            Console.WriteLine($"People : {nbPeople}");
        }

        private static Department createDepartment() {
            Department dpt = new Department();
            dpt.Name = AskTheUser_ForStringValue("Department name ?");
            dpt.Code = AskTheUser_ForIntValue("Department code ?");
            return dpt;
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

        public static City createCity(List<Department> departments) {
            City myCity = new City();

            myCity.Name = AskTheUser_ForStringValue("City name ?");
            myCity.NbCitizens = AskTheUser_ForIntValue("Number of cityzens ?");
            myCity.PostCode = AskTheUser_ForStringValue("Postcode ?");
            myCity.Department = AskTheUser_ForDepartment("Department code ?", departments);
            myCity.Department.Cities.Add(myCity);

            return myCity;
        }

        private static Department AskTheUser_ForDepartment(string msg, List<Department> departments) {
            Console.WriteLine(msg);
            do {
                string value = Console.ReadLine();
                int intValue;
                if (!string.IsNullOrEmpty(value) && int.TryParse(value, out intValue)
                    && departments.Any(d => d.Code == intValue)) {
                    // we got the result => return the department
                    return departments.First(d => d.Code == intValue);
                } else {
                    Console.WriteLine("incorrect, please try again");
                }
            } while (true);
        }

public static string AskTheUser_ForStringValue(string msg) {
    Console.WriteLine(msg);

    do {
        string value = Console.ReadLine();

        if (!string.IsNullOrEmpty(value))
            return value;
        else
            Console.WriteLine("incorrect, please try again");
    } while (true);

}


public static int AskTheUser_ForIntValue(string msg) {
    Console.WriteLine(msg);

    do {
        string value = Console.ReadLine();
        int result;
        if (!string.IsNullOrEmpty(value) && int.TryParse(value, out result))
            return result;
        else
            Console.WriteLine("incorrect, please try again");
    } while (true);
}
    }
}

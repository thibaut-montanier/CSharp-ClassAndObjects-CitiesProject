using CSharp_POO.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Services {
    public class CityService {

        private AskTheUser _AskTheUser;
        private DepartmentService _DepartmentService;
        private List<City> _allCities { get; set; } = new List<City>();

        public CityService(AskTheUser askTheUser, DepartmentService departmentService) {
            this._AskTheUser = askTheUser;
            this._DepartmentService = departmentService;
        }
        public void showCitiesInformation() {
            foreach (var c in _allCities)
                showCityInformation(c);
        }

        private void showCityInformation(City cityToShow) {
            Console.WriteLine($"City : {cityToShow.Name} " +
                $"({cityToShow.PostCode} - {cityToShow.Department.Name})");
            Console.WriteLine($"Cityzen : {cityToShow.NbCitizens}");
        }

        public void createCity() {
            City myCity = new City();

            myCity.Name = _AskTheUser.ForStringValue("City name ?");
            myCity.NbCitizens = _AskTheUser.ForIntValue("Number of cityzens ?");
            myCity.PostCode = _AskTheUser.ForStringValue("Postcode ?");
            myCity.Department = _DepartmentService.AskForDepartment("Department code ?");
            myCity.Department.Cities.Add(myCity);
            _allCities.Add(myCity);
        }
    }


}

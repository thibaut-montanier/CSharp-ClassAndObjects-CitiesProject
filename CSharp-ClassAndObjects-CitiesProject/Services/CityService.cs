using CSharp_POO.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Services {
    public class CityService : ICityService {

        private AskTheUser _AskTheUser;
        private IDepartmentService _DepartmentService;
        private List<City> _allCities { get; set; } = new List<City>();

        public CityService(AskTheUser askTheUser, IDepartmentService departmentService) {
            this._AskTheUser = askTheUser;
            this._DepartmentService = departmentService;
        }
        public void ShowCitiesInformation() {
            foreach (var c in _allCities)
                ShowCityInformation(c);
        }

        private void ShowCityInformation(City cityToShow) {
            Console.WriteLine($"City : {cityToShow.Name} " +
                $"({cityToShow.PostCode} - {cityToShow.Department.Name})");
            Console.WriteLine($"Cityzen : {cityToShow.NbCitizens}");
        }

        public void CreateCity() {
            City myCity = new City();

            myCity.Name = _AskTheUser.ForStringValue("City name ?");
            myCity.NbCitizens = _AskTheUser.ForIntValue("Number of cityzens ?");
            myCity.PostCode = _AskTheUser.ForStringValue("Postcode ?");
            myCity.Department = _DepartmentService.AskForDepartment("Department code ?");
            myCity.Department.Cities.Add(myCity);
            _allCities.Add(myCity);
        }

        public void AddManyCities(int number) {
            for (int i = 0; i < number; i++) {
                _allCities.Add(new City() {
                    Name = "MyCitiy is a good place to live", NbCitizens = 5000, PostCode = "XXXX",
                    Department = new Department() { Code = 38, Name = "Here is a good place to live" }
                });
            }
        }

        public void ClearCities() {
            _allCities.Clear();
        }
    }
}

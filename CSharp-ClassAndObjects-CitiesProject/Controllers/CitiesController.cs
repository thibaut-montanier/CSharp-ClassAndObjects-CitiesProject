using CSharp_ClassAndObjects_CitiesProject.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Controllers {
    public class CitiesController : IMenuController {


        private CityService _CityService;

        public CitiesController(CityService cityService) {
            this._CityService = cityService;
        }
        public string showMenu() {
            return "11 Create a city\n" +
                    "12 Show all cities\n" +
                    "13 Load csv\n" + 
                    "14 Write csv";
                   
        }

        public void DoAction(string saisie) {
            switch (saisie.ToUpper()) {
                case "11":
                    _CityService.CreateCity();
                    break;
                case "12":
                    _CityService.ShowCitiesInformation();
                    break;
                case "13":
                    _CityService.LoadFromCsv(@"./Resources/FrenchCities.csv");
                    break;
                case "14":
                    _CityService.WriteToCsc(@"d:\tmp\FrenchCities.csv");
                    break;
            }
        }

        public bool isAvailableItem(string saisie) {
            return saisie == "11" || saisie == "12" || saisie == "13" || saisie=="14";
        }

        public bool exit() {
            return false;
        }
    }
}

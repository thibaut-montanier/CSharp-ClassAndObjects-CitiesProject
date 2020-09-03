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
            return "1. Create a city\n" +
                    "2. Show all cities";
                   
        }

        public void DoAction(string saisie) {
            switch (saisie.ToUpper()) {
                case "1":
                    _CityService.CreateCity();
                    break;
                case "2":
                    _CityService.ShowCitiesInformation();
                    break;
            }
        }

        public bool isAvailableItem(string saisie) {
            return saisie == "1" || saisie == "2" ;
        }

        public bool exit() {
            return false;
        }
    }
}

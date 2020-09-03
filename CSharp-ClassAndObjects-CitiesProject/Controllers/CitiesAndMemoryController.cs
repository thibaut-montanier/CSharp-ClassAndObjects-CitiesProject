using CSharp_ClassAndObjects_CitiesProject.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Controllers {
    public class CitiesAndMemoryController : IMenuController {


        private CityService _CityService;

        public CitiesAndMemoryController(CityService cityService) {
            this._CityService = cityService;
        }
        public string showMenu() {
            return "5. Load many cities\n" +
                    "6. Reload many cities\n" +
                    "7. Clear cities\n" +
                    "8. Save cities to file";
        }

        public void DoAction(string saisie) {
            switch (saisie.ToUpper()) {
                
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
            }
        }

        public bool isAvailableItem(string saisie) {
            return saisie == "5" || saisie == "6" || saisie == "7"
                || saisie == "8" ;
        }

        public bool exit() {
            return false;
        }
    }
}

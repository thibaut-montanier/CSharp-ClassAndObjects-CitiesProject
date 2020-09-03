using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Controllers {
    class GeneralController : IMenuController {

        private bool _exit = false;
        public void DoAction(string saisie) {
            switch (saisie.ToUpper()) {
                case "GC":
                    GC.Collect();
                    break;
                case "E":
                    _exit = true;
                    break;
            }
        }

        public bool isAvailableItem(string saisie) {
            return saisie == "GC" || saisie == "E";
        }

        public string showMenu() {
            return "GC. Garbage collector\n" +
                                "E. Exit";
        }

        public bool exit() {
            return _exit;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Controllers {
    public interface IMenuController {

        string showMenu();

        bool isAvailableItem(string saisie);

        void DoAction(string saisie);


        bool exit();
    }
}

using CSharp_POO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_ClassAndObjects_CitiesProject.Services {
    public class AskTheUser {

        public string ForStringValue(string msg) {
            Console.WriteLine(msg);

            do {
                string value = Console.ReadLine();

                if (!string.IsNullOrEmpty(value))
                    return value;
                else
                    Console.WriteLine("incorrect, please try again");
            } while (true);

        }

        public int ForIntValue(string msg) {
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

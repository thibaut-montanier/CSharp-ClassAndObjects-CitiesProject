using CSharp_POO.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void LoadFromCsv(string filePath) {
            try { 
            _allCities.AddRange(ReadFromCsv(filePath));
            }catch(Exception e) {
                Console.WriteLine("Error during operation...");
            }
        }

        private IEnumerable<City> ReadFromCsv(string pathFile) {

            // open the stream reader
            using (var sr = new StreamReader(pathFile)) {
                var firstLine = sr.ReadLine(); // headers
                string currentLine = sr.ReadLine();// read nextLine
                while (!sr.EndOfStream) {
                    // get line content
                    List<string> lineContent = currentLine.Split(';')
                                                            .ToList();
                    // read datas and create city
                    City city = new City() {
                        Name= lineContent[2],
                        PostCode = lineContent[3],
                        NbCitizens = int.Parse(lineContent[4])
                    };
                    // department management
                    int departmentCode;
                    if (!int.TryParse(lineContent[1], out departmentCode))
                        throw new Exception("Department error in the file");
                    var d = _DepartmentService.TryGetDepartment(departmentCode);
                    if (d == null) {
                        d = new Department() {
                            Name = lineContent[5],
                            Code = departmentCode
                        };
                        _DepartmentService.AddDepartment(d);
                    }

                    city.Department = d;
                    d.Cities.Add(city);
                    // city is now ready
                    yield return city;

                    // go to next line
                    currentLine = sr.ReadLine();
                }
            }// close and release resources

        }

        public void WriteToCsc( string csvFilePath) {
            try {
                using (var sw = new StreamWriter(csvFilePath)) {
                    //if you want to write first line
                    sw.WriteLine("ID;DepartmentCode;City;PostCode;Citizens;DepartmentName");
                    // write a line for each person
                    foreach (City c in _allCities) {
                        string lineContent = $";{c.Department.Code.ToString("00")};{c.Name};{c.PostCode};{c.NbCitizens};{c.Department.Name}";
                        sw.WriteLine(lineContent);
                    }
                }
            } catch (Exception e) {
                //do some exception management
                throw;
            }
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

        public void SaveToFile(string filePath) {
            StreamWriter sw = new StreamWriter(filePath);
            try {
                foreach (City c in _allCities) {
                    sw.WriteLine($"{c.Name},{c.PostCode},{c.NbCitizens}");
                }
            } catch (Exception e) {
                // do exception management
            } finally {
                sw.Dispose();
            }
        }
    }
}

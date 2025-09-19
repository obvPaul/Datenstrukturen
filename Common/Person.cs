﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Common
{
    public class Person
    {
        public int Id { get; set; }

        private string _geschlecht = string.Empty;
        public string Name { get; set; }
        public string Geschlecht
        {
            get => _geschlecht;
            set
            {
                if (value != "männlich" && value != "weiblich" && value != "Männlich" && value != "Weiblich")
                {
                    throw new ArgumentException("Ungültiges Geschlecht eingegeben!");
                }
                _geschlecht = value;
            }
        }
        public DateTime Geburtstag { get; set; }
        public int Alter => DateTime.Today.Year - Geburtstag.Year;
        public override string ToString()
        {
            return $"Name: {Name}, Alter: {Alter}, Geschlecht: {Geschlecht}";
        }
        public Person(DateTime geburtstag, string geschlecht, string name)
        {
            Name = name;
            Geburtstag = geburtstag;
            Geschlecht = geschlecht;
        }
    }
}
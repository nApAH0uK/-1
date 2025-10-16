using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labaratorka_Yarmingin_BPI_23_02
{
    public class Factory
    {
        public string Name { get; set; }
        public double PriceInRuble { get; set; }
        public string Manufacturer { get; set; }
        private const double PriceInEuro = 100.0;
        public Factory(string Name, double PriceInRuble, string Manufacturer)
        {
            ValidateAll(name, priceInRuble, manufacturer);
            Name = name;
            PriceInRuble = priceInRuble;
            Manufacturer = manufacturer;
        }
        private static void ValidateAll(string name, double priceInRuble, string manufacturer)
        {
            // Проверяем все условия в одном методе
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не может быть пустым", nameof(name));

            if (priceInRuble < 0)
                throw new ArgumentException("Цена не может быть отрицательной", nameof(priceInRuble));
        }
        public double Conversion()
        {
            return PriceInRuble / PriceInEuro;
        }
        private bool NameSamsung()
        {
            return Name == "Samsung" || Name == "samsung";
        }
        public double IncreasePriceForSamsung()
        {
            double priceInEuro = Conversion();
            if (NameSamsung())
            {
                priceInEuro *= 1.2;
            }
            return priceInEuro;
        }
    }
}

using System;

namespace Labaratorka_Yarmingin_BPI_23_02
{
    public class Factory
    {
        public string Name { get; }
        public double PriceInRuble { get; }
        public string Manufacturer { get; }
        private const double PriceInEuro = 100.0;

        public Factory(string name, double priceInRuble, string manufacturer)
        {
            ValidateAll(name, priceInRuble);

            Name = name;
            PriceInRuble = priceInRuble;
            Manufacturer = manufacturer ?? string.Empty;
        }

        private static void ValidateAll(string name, double priceInRuble)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не может быть пустым", nameof(name));

            if (priceInRuble < 0)
                throw new ArgumentException("Цена не может быть отрицательной", nameof(priceInRuble));
        }

        public double Conversion()
        {
            return PriceInRuble / PriceInEuro;
        }

        public bool NameSamsung()
        {
            return Name == "Samsung" || Name == "samsung";
        }

        public double PriceSamsung()
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
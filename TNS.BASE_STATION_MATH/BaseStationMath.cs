using System;

namespace TNS.BASE_STATION_MATH
{
    /// <summary>
    /// <para>DenseUrban  - плотная городская застройка</para>
    /// <para>MediumUrban - средняя городская застройка (малые города, новые жилые комплексы)</para>
    /// <para>Rural       - сельская застройка</para>
    /// </summary>
    public enum BuildingCoefficient
    {
        DenseUrban,
        MediumUrban,
        Rural
    }

    public class BaseStationMath
    {
        List<double> allS = [8.91, 6.17, 4.19, 2.18, 6.12];

        /// <summary>
        /// Расчет радиуса зоны обслуживания R0, км.
        /// </summary>
        /// <param name="s">Площадь района обслуживания</param>
        /// <returns>R0 - радиус зоны обслуживания</returns>
        public double CalcServiceArea(double s) 
            => Math.Sqrt(s / Math.PI);

        /// <summary>
        /// Сота - площадь, покрываемая одним приемопередатчиком (базовой станцией) сети сотовой связи.
        /// Метод определяет число сот.
        /// </summary>
        /// <param name="K">Коэфициент застройки</param>
        /// <param name="S">Площадь покрытия базовой станции</param>
        /// <returns>L - Число сот</returns>
        public double CalcCells(BuildingCoefficient K, double S)
        {
            // радиус покрытия базовой станции
            double R = Math.Sqrt(S/Math.PI);

            // площадь района обслуживания
            double R0 = CalcServiceArea(S);     

            // определение коэфициента застройки
            double coefficient = 0;
            switch (K)
            {
                case BuildingCoefficient.DenseUrban:
                    coefficient = 1.21;
                    break;
                case BuildingCoefficient.MediumUrban:
                    coefficient = 0.9;
                    break;
                case BuildingCoefficient.Rural:
                    coefficient = 0.47;
                    break;
                default:
                    break;
            }

            // расчет сот
            double L = Math.Round(
                coefficient * Math.Pow(R0 / R, 2), 
                MidpointRounding.ToPositiveInfinity);

            return L;
        }

        /// <summary>
        /// Расчет количества базовых станций с показателями хендоверов.
        /// </summary>
        /// <param name="S1">Площадь района обслуживания 1-ой станции</param>
        /// <param name="S2">Площадь района обслуживания 2-ой станции</param>
        /// <param name="S3">Площадь района обслуживания 3-ей станции</param>
        /// <returns>Количество базовых станций</returns>
        public int CalcCountBaseStations(double S1, double S2, double S3)
        {
            // радиус покрытия базовой станции
            double R1 = CalculateRadius(S1);
            double R2 = CalculateRadius(S2);
            double R3 = CalculateRadius(S3);

            // диаметры
            double D1 = CalculateD(R1);
            double D2 = CalculateD(R2);
            double D3 = CalculateD(R3);

            int checkHandover = 13;

            // C-базовые станции, аддитивная составляющая
            double C = Calculate_C_BaseStations(D1, D2, D3);

            // среднее арифметическое по всем базовым станциям
            double L = CalculateAvgL();

            // количество базовых станций
            double n = 0;
            if (checkHandover < 15)
                n = Math.Round(L / C, 
                    MidpointRounding.ToPositiveInfinity);
            else
                n = Math.Round(L / C * 1.4, 
                    MidpointRounding.ToPositiveInfinity);
            return Convert.ToInt32(n);
        }

        private double Calculate_C_BaseStations(double D1, double D2, double D3) 
            => Math.Sqrt(Math.Pow(D1, 5)) + Math.Sqrt(Math.Pow(D2, 3)) + Math.Sqrt(D3);

        private double CalculateAvgL() 
        {
            List<double> L = [];
            foreach (var S in allS) L.Add(CalcCells(BuildingCoefficient.MediumUrban, S));
            return L.Average();
        }

        private double CalculateRadius(double S) 
            => Math.Sqrt(S / Math.PI);

        private double CalculateD(double R) 
            => 2 * R;
    }
}
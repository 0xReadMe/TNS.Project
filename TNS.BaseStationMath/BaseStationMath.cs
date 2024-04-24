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
        /// <summary>
        /// Расчет радиуса зоны обслуживания R0, км.
        /// </summary>
        /// <param name="s">Площадь района обслуживания</param>
        /// <returns>R0 - радиус зоны обслуживания</returns>
        public double CalcServiceArea(double s) 
            => Math.Sqrt(s/Math.PI);

        /// <summary>
        /// Сота - площадь, покрываемая одним приемопередатчиком (базовой станцией) сети сотовой связи.
        /// Метод определяет число сот.
        /// </summary>
        /// <param name="K">Коэфициент застройки</param>
        /// <param name="S">Площадь покрытия базовой станции</param>
        /// <returns>Число сот</returns>
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
            double result = Math.Round(
                coefficient * Math.Pow(R0 / R, 2), 
                MidpointRounding.ToPositiveInfinity);

            return result;
        }


        public int CalcCountBaseStations(double D1, double D2, double D3)
        {
            double n = 0;       // количество базовых станций
            double C = 0;       // аддитивная составляющая
            double L = 8;       // среднее арифметическое по всем базовым станциям

            C = Math.Sqrt(Math.Pow(D1, 5)) 
                + Math.Sqrt(Math.Pow(D2, 3)) 
                + Math.Sqrt(D3);
            
            // TODO: проверка на хендовер, расчет L среднее арифм.
            
            n = Math.Round(L/C, MidpointRounding.ToPositiveInfinity);
            return Convert.ToInt32(n);
        }
    }
}
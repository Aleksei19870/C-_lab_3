using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum MeasureType { C, F, R, K };
    public class Temperature
    {
        private double value;
        private MeasureType type;

        public Temperature(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }


        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.C:
                    typeVerbose = "C";
                    break;
                case MeasureType.F:
                    typeVerbose = "F";
                    break;
                case MeasureType.R:
                    typeVerbose = "R";
                    break;
                case MeasureType.K:
                    typeVerbose = "K";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }

        public static Temperature operator +(Temperature instance, double number)
        {
            // расчитываем новую значение
            var newValue = instance.value + number;
            // создаем новый экземпляр класса, с новый значением и типом как у меры, к которой число добавляем
            var Temperature = new Temperature(newValue, instance.type);
            // возвращаем результат
            return Temperature;
        }

        // чтобы можно было добавлять число также слева
        public static Temperature operator +(double number, Temperature instance)
        {
            // вызываем с правильным порядком аргументов, то есть сначала длина потом число
            // для такого порядка мы определили оператор выше
            return instance + number;
        }

        // чтобы можно было складывать две температуры
        public static Temperature operator +(Temperature t1, Temperature t2)
        {
            // произведём их сложения
            return t1 + t2.To(t1.type).value;

        }

        public static Temperature operator *(Temperature instance, double number)
        {
            // мне лень по три строчки писать, поэтому я сокращаю код до одной строки
            return new Temperature(instance.value * number, instance.type); ;
        }

        public static Temperature operator *(double number, Temperature instance)
        {
            return instance * number;
        }

        public static Temperature operator *(Temperature t1, Temperature t2)
        {
            return t1 * t2.To(t1.type).value;
        }

        // вычитание
        public static Temperature operator -(Temperature instance, double number)
        {
            return new Temperature(instance.value - number, instance.type); ;
        }

        public static Temperature operator -(double number, Temperature instance)
        {
            return instance - number;
        }

        public static Temperature operator -(Temperature t1, Temperature t2)
        {
            return t1 - t2.To(t1.type).value;
        }


        // деление
        public static Temperature operator /(Temperature instance, double number)
        {
            return new Temperature(instance.value / number, instance.type); ;
        }

        public static Temperature operator /(double number, Temperature instance)
        {
            return instance / number;
        }

        public static Temperature operator /(Temperature t1, Temperature t2)
        {
            if (t2.value == 0)
            {
                throw new DivideByZeroException("Error: Division by zero!");
            }
            return t1 / t2.To(t1.type).value;
        }

        public Temperature To(MeasureType newType)
        {
            // по умолчанию новое значение совпадает со старым
            var newValue = this.value;
            // если текущий тип -- это цельсии
            if (this.type == MeasureType.C)
            {
                // а теперь рассматриваем все другие ситуации
                switch (newType)
                {
                    // если конвертим в цельсии, то значение не меняем
                    case MeasureType.C:
                        newValue = this.value;
                        break;
                    // если в фаренгейты
                    case MeasureType.F:
                        newValue = (this.value * 9 / 5) + 32;
                        break;
                    // если в  ранкины
                    case MeasureType.R:
                        newValue = (this.value * 9 / 5) + 491.67;
                        break;
                    // если в кельвины
                    case MeasureType.K:
                        newValue = this.value + 273.15;
                        break;
                }
            }
            else if (newType == MeasureType.C) // если новый тип: цельсии
            {
                switch (this.type) // а тут уже старый тип проверяем
                {
                    case MeasureType.C:
                        newValue = this.value;
                        break;
                    case MeasureType.F:
                        newValue = (this.value - 32) * 5 / 9;
                        break;
                    case MeasureType.R:
                        newValue = (this.value - 491.67) * 5 / 9;
                        break;
                    case MeasureType.K:
                        newValue = this.value - 273.15;
                        break;
                }
            }
            else // то есть не в метр и не из метра
            {
                newValue = this.To(MeasureType.C).To(newType).value;
                // в принципе можно сразу написать 
                // return this.To(MeasureType.m).To(newType);
                // но хорошем тоном считается наличие всего одного return в функции
            }
            return new Temperature(newValue, newType);
        }
    }

}

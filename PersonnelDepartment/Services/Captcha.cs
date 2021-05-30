using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelDepartment.Services
{
    /// <summary>
    /// Класс для генерации строки для капчи
    /// </summary>
    public static class Captcha
    {
        /// <summary>
        /// Генерация строки
        /// </summary>
        /// <param name="lenght">Длина строки</param>
        /// <returns>Строка</returns>
        public static string GenerateString(int lenght)
        {
            string cif = "qwertyuiopasdfghjklzxcvbnm1234567890" +
                "QWERTYUIOPASDFGHJKLZXCVBNM";
            string result = "";
            Random rnd = new Random();
            for (int i = 1; i <= lenght; i++)
            {
                result += cif[rnd.Next(0, cif.Length)];
            }
            return result;
        }
    }
}

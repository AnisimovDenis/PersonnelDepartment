using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonnelDepartment.Services
{
    /// <summary>
    /// Класс вызова диалоговых окон
    /// </summary>
    public static class MB
    {
        /// <summary>
        /// Вызов диалогового окна с уведомлением
        /// </summary>
        /// <param name="info">Уведомление</param>
        public static void MessageBoxInfo(string info)
        {
            MessageBox.Show(info, "Уведомление", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Вызов диалогового окна с ошибкой
        /// </summary>
        /// <param name="error">Ошибка</param>
        public static void MessageBoxError(string error)
        {
            MessageBox.Show(error, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Вызов диалогового окна с вопросом
        /// </summary>
        /// <param name="question">Вопрос</param>
        /// <returns></returns>
        public static bool MessageBoxQuestion(string question)
        {
            return MessageBoxResult.Yes == MessageBox.Show(question, "Уведомление",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}

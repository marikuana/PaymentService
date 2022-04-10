using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum NotifyType
{
    Error, // new object[] { "404", "Помилка", 16 })
    RegisterSuccess, // $"Ви успішно зареєструвались", "Реєстрація", MessageBoxButton.OK, MessageBoxImage.Information
    LoginBrooked, // new object[] { "Такий логін вже зареєстрований", "Помилка", 16 }
    Test, // new object[] { command, "Помилка", 16 }
    TransactionError, // "Помилка транзакції"
}

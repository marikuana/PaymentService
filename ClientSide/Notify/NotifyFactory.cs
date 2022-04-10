using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

internal class NotifyFactory
{
    public static Notify Create(NotifyType notifyType)
    {
        return notifyType switch
        {
            NotifyType.Error => new Notify("Помилка", "Помилка", MessageBoxImage.Error),
            NotifyType.RegisterSuccess => new Notify("Ви успішно зареєструвались", "Реєстрація", MessageBoxImage.Information),
            NotifyType.LoginBrooked => new Notify("Такий логін вже зареєстрований", "Помилка", MessageBoxImage.Error),
            NotifyType.Test => throw new NotImplementedException(),
            NotifyType.TransactionError => new Notify("Помилка транзакції", "Помилка", MessageBoxImage.Error),
            _ => throw new NotImplementedException(),
        };
    }

    public static Notify Create(MessageViewModel messageViewModel)
    {
        return Create(messageViewModel.MessagesType);
    }
}

class Notify
{
    public string Message { get; private set; }
    public string Caption { get; private set; }
    public MessageBoxImage Image { get; private set; }

    public Notify(string message, string caption, MessageBoxImage image)
    {
        Message = message;
        Caption = caption;
        Image = image;
    }

    public void Send()
    {
        MessageBox.Show(Message, Caption, MessageBoxButton.OK, Image);
    }
}


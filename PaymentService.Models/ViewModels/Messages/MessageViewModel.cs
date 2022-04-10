using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MessageViewModel : ViewModel
{
    public NotifyType MessagesType { get; set; }

    public MessageViewModel(NotifyType messagesType)
    {
        MessagesType = messagesType;
    }

}


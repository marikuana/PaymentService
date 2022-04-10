using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PaymentServiceServer.Controllers
{
    internal class Controller
    {
        public Dictionary<string, ControllerDelegate> Controllers;

        public delegate ViewModel ControllerDelegate(PaymentServiceSessoin sessoin, string viewModel);
        public Controller()
        {
            Controllers = new Dictionary<string, ControllerDelegate>();
            InitControllers();
        }

        private void InitControllers()
        {
            foreach (var type in Assembly.GetCallingAssembly().GetTypes())
                foreach (var method in type.GetMethods())
                {
                    ControllerAttribute? controller = method.GetCustomAttribute<ControllerAttribute>();
                    if (controller != null)
                        Controllers.Add(controller.Name, (ControllerDelegate)Delegate.CreateDelegate(typeof(ControllerDelegate), method));
                }
        }

        public ViewModel Invoke(PaymentServiceSessoin sessoin, Callback request)
        {
            if (!Controllers.ContainsKey(request.Command))
                throw new ArgumentException();

            ControllerDelegate method = Controllers[request.Command];

            ViewModel vievModel = method.Invoke(sessoin, request.ViewModel);
            
            return vievModel;
        }
    }
}

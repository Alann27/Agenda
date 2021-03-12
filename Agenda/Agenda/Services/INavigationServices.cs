using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agenda.Services
{
    public interface INavigationServices
    {
        Task NonModalPush(Page page);
        Task ModalPush(Page page);
        Task NonModalPop();
        Task ModalPop();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Services
{
    public interface IAlertServices
    {
        Task AlertAsync(string title, string description);
        Task ActionSheet(string title, string[] options);
    }
}

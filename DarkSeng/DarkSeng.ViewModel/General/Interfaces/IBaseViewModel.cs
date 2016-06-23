using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.ViewModel.General.Interfaces
{
    /// <summary>
    /// Basic View Model, all ViewModels should implement this interface
    /// </summary>
    public interface IBaseViewModel : INotifyDataErrorInfo, INotifyPropertyChanged, IDisposable
    {
    }
}

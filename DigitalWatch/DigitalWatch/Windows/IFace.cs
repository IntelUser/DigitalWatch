using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DigitalWatch.Windows
{
    /// <summary>
    /// The interface which is used by all Watch Windows.
    /// </summary>
    public interface IFace
    {
        void UpdateTime(DateTime time);

        void ShowNotification(String subject);

        void Show();

        void Hide();
    }
}

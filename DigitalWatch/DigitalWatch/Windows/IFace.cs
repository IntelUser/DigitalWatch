using System;

namespace DigitalWatch.Windows
{
    /// <summary>
    /// The interface which is used by all Watch Windows.
    /// </summary>
    public interface IFace
    {
        void UpdateTime(DateTime time);

        void ShowNotification(String message, String from);

        void Show();

        void Hide();
    }
}

using System.Windows.Input;

namespace WMECalculation
{
    public class SendKeys
    {
        public static void Send(Key key)
        { //Found online
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
            {
                RoutedEvent = Keyboard.KeyDownEvent
            };
            InputManager.Current.ProcessInput(e);
        }
    }
}

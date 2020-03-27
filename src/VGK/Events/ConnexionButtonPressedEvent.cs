using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGK.Events
{
    class ConnexionButtonPressedEvent
    {
        private static ConnexionButtonPressedEvent _evenement;
        private ConnexionButtonPressedEvent()
        {

        }

        public static ConnexionButtonPressedEvent GetInstance()
        {
            if (_evenement == null)
            {
                _evenement = new ConnexionButtonPressedEvent();
            }
            return _evenement;
        }
        public event EventHandler Handler;

        public void OnButtonPressedHandler(EventArgs e)
        {
            if (Handler != null)
            {
                Handler(this, e);
            }
        }
    }
}

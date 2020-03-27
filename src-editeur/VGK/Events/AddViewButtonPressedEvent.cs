using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGK.Events;

namespace ModelView.Events
{
    class AddViewButtonPressedEvent
    {
        #region Singleton
        private static AddViewButtonPressedEvent _evenement;
        private AddViewButtonPressedEvent()
        {

        }

        public static AddViewButtonPressedEvent GetInstance()
        {
            if (_evenement == null)
            {
                _evenement = new AddViewButtonPressedEvent();
            }
            return _evenement;
        }
        #endregion

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

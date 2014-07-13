using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool
{
    public class ClickedEvent
    {
        /// <summary>
        /// Moguće vrijednosti koje označavaju pritisnutu tipku.
        /// </summary>
        public enum ClickedButton { Save, Cancel, Print };

        public class ClickedButtonEventArgs : EventArgs
        {
            public ClickedButton ClickedButton { get; private set; }
            public string Name { get; private set; }
            public ClickedButtonEventArgs(ClickedButton cb, string name)
            {
                this.ClickedButton = cb;
                this.Name = name;
            }
        }

        /// <summary>
        /// Pokreće događaj s informacijama koja je tipka pritisnuta i nazivom kontrole na kojoj je tipka.
        /// </summary>
        /// <param name="button">ClickedEvent.ClickedButton vrijednost.</param>
        /// <param name="name">Naziv kontrole na kojoj se tipka nalazi.</param>
        public void RaiseEvent(ClickedButton button, string name)
        {
            if (!ButtonClicked.Equals(null))
            {
                ButtonClicked(this, new ClickedButtonEventArgs(button, name));
            }
        }

        public delegate void ClickedButtonEventHandler(object sender, ClickedButtonEventArgs e);
        public event ClickedButtonEventHandler ButtonClicked;
        
    }
}

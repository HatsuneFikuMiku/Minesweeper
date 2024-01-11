using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SaperV2
{
    public class CounterButton : Button
    {
        public int bomb_counter;
        private Control ParentControl;
        public CounterButton(Control parentControl, int bomb_counter)
        {
            this.bomb_counter = bomb_counter;

            this.Location = new Point(700, 2);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Size = new Size(73, 20);
            this.BackColor = SystemColors.Control;

            this.Text = "-";

            ParentControl = parentControl;

            ParentControl.Controls.Add(this);
            this.BringToFront();
        }
        public void UpdateCounter()
        {
            this.Text = bomb_counter.ToString();
        }

    }
}

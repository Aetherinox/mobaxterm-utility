using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*

    Aetherx > Control > Button

    Button customization

*/

namespace MobaXtermKG
{

    public class AetherxButton : Button
    {

        /*
            Show keyboard cues no matter what.
            By default, user must press ALT to see them.
        */

        protected override bool ShowKeyboardCues
        {
            get
            {
                return true;
            }
        }
    }
}

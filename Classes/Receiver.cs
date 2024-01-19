/*
    @app        : MobaXterm Keygen
    @repo       : https://github.com/Aetherinox/MobaXtermKeygen
    @author     : Aetherinox
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Res = MobaXtermKG.Properties.Resources;
using Cfg = MobaXtermKG.Properties.Settings;

namespace MobaXtermKG
{

    /*
        OReceiver > Status Bar
    */

    public interface IReceiver
    {
        void Status( string message );
    }

    /*
        Receiver > Status Bar
    */

    public static class StatusBar
    {
        private static IReceiver recv = null;

        /*
            Receiver > Initialize
        */

        public static void InitializeReceiver( IReceiver f )
        {
            recv = f;
        }

        /*
            Receiver > Send Message
        */

        public static void Update( string message )
        {
            if ( recv != null ) recv.Status( message );
        }
    }
}

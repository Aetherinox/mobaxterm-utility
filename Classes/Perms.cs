/*
    @app        : MobaXterm Keygen
    @repo       : https://github.com/Aetherinox/MobaXtermKeygen
    @author     : Aetherinox
*/

#region "Using"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.AccessControl;
using System.IO;

#endregion

namespace MobaXtermKG
{
    public class Perms
    {


        private static string err = "";
        
        /*
            Set Everyone Full Control permissions for selected directory
        */

       public bool SetAccess_Everyone( string path_dir )
        {

            try
            {
                // dir exists
                if ( Directory.Exists( path_dir ) == false )
                    throw new Exception(string.Format( "Directory {0} does not exist, so permissions cannot be set.", path_dir ) );

                // dir access info
                DirectoryInfo dInfo             = new DirectoryInfo( path_dir );
                DirectorySecurity dSec          = dInfo.GetAccessControl( );

                // Add the FileSystemAccessRule to the security settings. 
                dSec.AddAccessRule              ( new FileSystemAccessRule( new SecurityIdentifier(
                                                    WellKnownSidType.WorldSid,
                                                    null
                                                ), 
                                                    FileSystemRights.FullControl,
                                                    InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                                    PropagationFlags.NoPropagateInherit,
                                                    AccessControlType.Allow
                                                 ) );
                dInfo.SetAccessControl          ( dSec );

                err = String.Format( "Everyone FullControl Permissions were set for directory {0}", path_dir );

                return true;

            }
            catch ( Exception ex )
            {
                err = ex.Message;
                return false;
            }
        }
    }
}
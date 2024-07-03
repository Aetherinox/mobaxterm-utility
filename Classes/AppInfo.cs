/*
    @app        : MobaXterm Keygen
    @repo       : https://github.com/Aetherinox/MobaXtermKeygen
    @author     : Aetherinox
*/

#region "Using"

using System;
using System.Reflection;
using Res = MobaXtermKG.Properties.Resources;
using Cfg = MobaXtermKG.Properties.Settings;

#endregion

namespace MobaXtermKG
{

    /*
         AppInfo
            returns title, copyright, version, etc of Application.
    */

    class AppInfo
    {

        #region "Define: Fileinfo"

            /*
                Define > File Name
                    utilized with logging
            */

            readonly static string log_file = "AppInfo.cs";

        #endregion

        /*
             AppInfo > Get Debug

             @ret       : bool
        */

        public bool bIsDebug( )
        {
            if ( System.Diagnostics.Debugger.IsAttached )
                return true;

            if ( Settings.app_bDevmode )
                return true;

            #if DEBUG
                return true;
            #else
                return false;
            #endif
        }

        /*
             AppInfo > Get Resources

             @ret       : string
        */

        public string GetResources( )
        {
            foreach(string resourceName in Assembly.GetExecutingAssembly( ).GetManifestResourceNames( ) )
            {
                return resourceName;
            }

            return string.Empty;
        }

        /*
            AppInfo -> Title

            @usage      : string title = AppInfo.Title;
            @ret        : str
        */

        public static string Title
        {
            get
            {
                AssemblyTitleAttribute title = (AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyTitleAttribute));

                if (title != null && !string.IsNullOrEmpty(title.Title))
                    return title.Title;

                return string.Empty;
            }
        }

        /*
            AppInfo -> Description

            @usage      : string description = AppInfo.Description;
            @ret        : str
        */

        public static string Description
        {
            get
            {
                AssemblyDescriptionAttribute desc = (AssemblyDescriptionAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyDescriptionAttribute));

                if (desc != null && !string.IsNullOrEmpty(desc.Description))
                    return desc.Description;

                return string.Empty;
            }
        }

        /*
            AppInfo -> Trademark

            @usage      : string trademark = AppInfo.Trademark;
            @ret        : str
        */

        public static string Trademark
        {
            get
            {
                AssemblyTrademarkAttribute tm = (AssemblyTrademarkAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyTrademarkAttribute));

                if (tm != null && !string.IsNullOrEmpty(tm.Trademark))
                    return tm.Trademark;

                return string.Empty;
            }
        }

        /*
            AppInfo -> Company

            @usage      : string company = AppInfo.Company;
            @ret        : str
        */

        public static string Company
        {
            get
            {
                AssemblyCompanyAttribute comp = (AssemblyCompanyAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyCompanyAttribute));

                if (comp != null && !string.IsNullOrEmpty(comp.Company))
                    return comp.Company;

                return string.Empty;
            }
        }

        /*
            AppInfo -> Copyright

            @usage      : string copyright = AppInfo.Copyright;
            @ret        : str
        */

        public static string Copyright
        {
            get
            {
                AssemblyCopyrightAttribute cr = (AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyCopyrightAttribute));

                if ( cr != null && !string.IsNullOrEmpty( cr.Copyright ) )
                    return cr.Copyright;

                return string.Empty;
            }
        }

        /*
            AppInfo -> Version

            @usage      : string version = AppInfo.PublishVersion;
            @ret        : str
        */

        public static string Version
        {
            get
            {
                Version _ver = Assembly.GetExecutingAssembly().GetName().Version;
                string ver = _ver.Major + "." + _ver.Minor + "." + _ver.Build + "." + _ver.Revision;

                if (ver != null && !string.IsNullOrEmpty(ver))
                    return ver.ToString();

                return string.Empty;
            }
        }

        /*
            AppInfo -> Product Version

            @usage      : string product_ver = AppInfo.ProductVersion;
            @ret        : str
        */

        public static string ProductVersionCore
        {
            get
            {
                return System.Windows.Forms.Application.ProductVersion;
            }
        }

        /*
            AppInfo -> Publish Version

            @usage      : string publish_ver = AppInfo.PublishVersion;
            @ret        : str
        */

        public static string PublishVersion
        {
            get
            {
                if ( System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed )
                {
                    Version ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                    return string.Format( "{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision );
                }
                else
                {
                    var ver = Assembly.GetExecutingAssembly().GetName().Version;
                    return string.Format( "{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision );
                }
            }
        }

        /*
            AppInfo -> Update Available
                returns if an update is available by comparing the provided version
                with the product version.

        @ret            : true      Update Available
                          false     Current version

        */

        public bool UpdateAvailable( string v2 )
        { 

            string v1       = PublishVersion;
            int vnum_1      = 0;
            int vnum_2      = 0;
 
            for ( int i = 0, j = 0; ( i < v1.Length || j < v2.Length ); )
            {
       
                while ( i < v1.Length && v1[ i ] != '.' )
                {
                    vnum_1 = vnum_1 * 10 + ( v1[ i ] - '0' );
                    i++;
                }
 
                while ( j < v2.Length && v2[ j ] != '.' )
                {
                    vnum_2 = vnum_2 * 10 + ( v2[ j ] - '0' );
                    j++;
                }
 
                if ( vnum_1 > vnum_2 )
                    return false;
                if ( vnum_2 > vnum_1 )
                    return true;
 
                vnum_1 = vnum_2 = 0;

                i++;
                j++;
            }

            return false;
        }

        /*
            AppInfo -> Version Check
                compare two versions.

            @arg        : str v1
            @arg        : str v2
            @ret        : 0 = equal
                          1 = v2 smaller
                         -1 = v1 smaller

        */

        static int VersionCheck( string v1, string v2 )
        {

            int vnum_1      = 0;
            int vnum_2      = 0;
 
            for ( int i = 0, j = 0; ( i < v1.Length || j < v2.Length ); )
            {
 
                while ( i < v1.Length && v1[ i ] != '.' )
                {
                    vnum_1 = vnum_1 * 10 + ( v1[ i ] - '0' );
                    i++;
                }
 
                while ( j < v2.Length && v2[ j ] != '.' )
                {
                    vnum_2 = vnum_2 * 10 + ( v2[ j ] - '0' );
                    j++;
                }
 
                if ( vnum_1 > vnum_2 )
                    return 1;
                if ( vnum_2 > vnum_1 )
                    return -1;
 
                vnum_1 = vnum_2 = 0;

                i++;
                j++;
            } 

            return 0; 
        } 

    }
}
/*
    @app        : MobaXterm Keygen
    @repo       : https://github.com/Aetherinox/MobaXtermKeygen
    @author     : Aetherinox
*/

#region "Using"

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace MobaXtermKG
{
    public sealed class Hash
    {

        #region "Define: Fileinfo"

            /*
                Define > File Name
                    utilized with logging
            */

            readonly static string log_file = "Hash.cs";

        #endregion

        /*
            Define > Classes
        */

        static AppInfo AppInfo             = new AppInfo( );

        /*
            method : hash
        */

        private Hash( ) {}

        /*
           cryptographic service provider
        */

        private static MD5 Md5              = MD5.Create( );
        private static SHA256 Sha256        = SHA256.Create( );

        /*
            method : string to byte array

            @ret    : byteArr
        */

        private static byte[] ConvertStringToByteArray( string data )
        {
            return ( new System.Text.UnicodeEncoding( ) ).GetBytes( data );
        }

        /*
            method : bytes to string

            @ret    : str
        */

        public static string BytesToString( byte[] bytes )
        {
            string result = "";
            foreach ( byte b in bytes ) result += b.ToString( "x2" );
            return result;
        }

        /*
            method : file stream

            @arg    : str path
        */

        private static System.IO.FileStream GetFileStream( string path )
        {
            return ( new System.IO.FileStream( path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite ) );
        }

        /*
            method : Get SHA1 Hash
                requires a path to file to obtain the SHA1 hash

            @arg    : str path
            @ret    : str
        */

        public static string GetSHA1Hash( string path )
        {
            string result       = "";
            string res_hash     = "";

            byte[] arrByteHash;
            System.IO.FileStream fs = null;

            System.Security.Cryptography.SHA1CryptoServiceProvider sha1_hash = new System.Security.Cryptography.SHA1CryptoServiceProvider( );

            try
            {
                fs              = GetFileStream( path );
                arrByteHash     = sha1_hash.ComputeHash( fs );

                fs.Close( );

                res_hash        = System.BitConverter.ToString( arrByteHash );
                res_hash        = res_hash.Replace( "-", "" );
                result          = res_hash;
            }
            catch ( System.Exception ex )
            {
                MessageBox.Show
                (
                    new Form( ) { TopMost = true, TopLevel = true, StartPosition = FormStartPosition.CenterScreen },
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
            }

            if ( AppInfo.bIsDebug( ) )
            {
                MessageBox.Show
                (
                    new Form( ) { TopMost = true, TopLevel = true, StartPosition = FormStartPosition.CenterScreen },
                    string.Format( "{0}", result ),
                    "Hash.cs ( SHA1 )",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                );
            }


            return ( result );
        }

        /*
            method : Get MD5 Hash
                requires a path to file to obtain the md5 hash

            @arg    : str path
            @ret    : str
        */

        public static string GetMD5Hash( string path )
        {
            string result       = "";
            string res_hash     = "";

            byte[] arrByteHash;
            System.IO.FileStream fs = null;

            System.Security.Cryptography.MD5CryptoServiceProvider sha1_hash = new System.Security.Cryptography.MD5CryptoServiceProvider( );

            try
            {
                fs              = GetFileStream( path );
                arrByteHash     = sha1_hash.ComputeHash( fs );

                fs.Close( );

                res_hash        = System.BitConverter.ToString( arrByteHash );
                res_hash        = res_hash.Replace( "-", "" );
                result          = res_hash;
            }
            catch ( System.Exception ex )
            {
                MessageBox.Show
                (
                    new Form( ) { TopMost = true, TopLevel = true, StartPosition = FormStartPosition.CenterScreen },
                    ex.Message, 
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
            }

            if ( AppInfo.bIsDebug( ) )
            {
                MessageBox.Show
                (
                    new Form( ) { TopMost = true, TopLevel = true, StartPosition = FormStartPosition.CenterScreen },
                    string.Format( "{0}", result ),
                    "Hash.cs ( MD5 )",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                );
            }

            return ( result );
        }

        /*
            method : Get MD5 Hash
                requires a path to file to obtain the md5 hash

                string MD5Hash = Hash.BytesToString( Hash.GetHashMD5( saveDlg.FileName ) );

            @arg    : str path
            @ret    : str
        */

        public static byte[] GetHashMD5( string path )
        {
            using ( FileStream stream = File.OpenRead( path ) )
            {
                return Md5.ComputeHash( stream );
            }
        }



        /*
            method : Get SHA256 Hash (string)
                requires a path to file to obtain the sha256 hash

            @arg    : str path
            @ret    : str
        */

        static string GetSHA256HashString( string str )
        {
            // create SHA256
            using ( SHA256 sha256Hash = SHA256.Create( ) )
            {
                // return byte array
                byte[] bytes = sha256Hash.ComputeHash( Encoding.UTF8.GetBytes( str ) );

                // convert byte array to str
                StringBuilder builder = new StringBuilder( );
                for ( int i = 0; i < bytes.Length; i++ )
                {
                    builder.Append( bytes[ i ].ToString( "x2" ) );
                }

                return builder.ToString( );
            }
        }

        /*
            method : Get SHA256 Hash
                requires a path to file to obtain the sha256 hash

                string SHA256 = Hash.BytesToString( Hash.GetSHA256Hash( saveDlg.FileName ) );

            @arg    : str path
            @ret    : str
        */

        public static string GetSHA256Hash( string path )
        {
            using ( FileStream stream = File.OpenRead( path ) )
            {
                byte[] bytes = Sha256.ComputeHash( stream );
                return BytesToString( bytes );
            }
        }


    }
}

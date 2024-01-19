/*
    @app        : MobaXterm Keygen
    @repo       : https://github.com/Aetherinox/MobaXtermKeygen
    @author     : Aetherinox
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MobaXtermKG
{
    public sealed class Log
    {

        #region "Fileinfo"

            /*
                Define > File Name
                    utilized with logging
            */

            readonly static string log_file = "Log.cs";

		#endregion

        #region "Class: Console: Initialize"

            /*
                Console > Initialize
                    override the default functionality for Console.Write() and Console.WriteLine().
                    re-routes text to display in console and save to log file.
            */

            public class Initialize : TextWriter
            {
                private Encoding encoding = Encoding.UTF8;
                private StreamWriter writer;
                private TextWriter console;

                public sealed class SetNull: TextWriter
                {
                    public override Encoding Encoding
                    {
                        get { return Encoding.UTF8; }
                    }
                }

                public override Encoding Encoding
                {
                    get { return encoding; }
                }

                public Initialize( string file, TextWriter console, Encoding encoding = null)
                {

                    if ( encoding != null )
                        this.encoding = encoding;

                    this.console    = console;
                    this.writer     = new StreamWriter( file, true, this.encoding );

                    this.writer.AutoFlush = true;
                }

                public override void Write( string msg )
                {
                    Console.SetOut  ( console );
                    Console.Write   ( msg );
                    Console.SetOut  ( this );

                    this.writer.Write( msg );
                }

                public override void WriteLine( string msg )
                {
                    Console.SetOut          ( console );
                    Console.WriteLine       ( msg );
                    Console.SetOut          ( this );

                    this.writer.WriteLine( msg );
                }

                public override void Flush( )
                {
                    this.writer.Flush( );
                }

                public override void Close( )
                {
                    this.writer.Close( );
                }

                new public void Dispose( )
                {
                    this.writer.Flush( );
                    this.writer.Close( );
                    this.writer.Dispose( );
                    base.Dispose( );
                }

            }

        #endregion

        #region "Methods: Console: Helpers"

		    /*
			    Log > Get Storage File
				    specifies where logs will be stored.

                @arg        : void
                @ret        : str
		    */

		    public static string GetStorageFile( )
		    {
                DateTime dt             = DateTime.Now;
                string now              = dt.ToString( "MM_dd_yy" );
            
			    return String.Format( "{0}_devlog.log", now );
		    }

            /*
			    re-structures console output and file logs to display logs in a certain manner.

                    [ MM.dd.yy HH:mm ] FileName[ Line # ] Message Value

                @arg        : str cat
                @arg        : int line
                @arg        : str msg
                @arg        : str val
                @ret        : void
		    */

            public static void Send( string cat = "", int line = 0, string msg = "", string val = "" )
		    {
			    DateTime dt			= DateTime.Now;
			    string now			= dt.ToString( "MM.dd.yy HH:mm" );
			    string line_file	= String.Format( "{0}[{1}]", cat, line );

			    Console.WriteLine( "{0,-18}{1,-24}{2,-30}{3,-15}", now, line_file, msg, val );
		    }

        #endregion

        #region "Methods: Print Columns"

            /*
			    convert list of string arrays to a string with proper column formatting / padding.
			    each array must contain the same number of arguments

			    string a	= "Some Data";
			    string b	= "More Data"
			    var lines	= new List<string[]>();

			    lines.Add( new[] { "Column Name", a, b } );

			    var output	= Log.PrintLines( lines, 3 );
		    */

            public static void PrintColumn( List<string[]> lines, int padding = 1 )
		    {
			    var numElements		= lines[ 0 ].Length;
			    var maxValues		= new int[numElements ];

			    for ( int i = 0; i < numElements; i++ )
				    maxValues[ i ] = lines.Max( x => x[ i ].Length ) + padding;

			    var sb			= new StringBuilder( );
			    bool bFirst		= true;

			    foreach ( var line in lines )
			    {
				    if ( !bFirst )
					    sb.AppendLine( );

				    bFirst = false;

				    for ( int i = 0; i < line.Length; i++ )
				    {
					    var value = line[i];
					    sb.Append( value.PadRight( maxValues[ i ] ) );
				    }
			    }

			    Console.WriteLine( sb.ToString( ) );

			    //return sb.ToString();
		    }

        #endregion

	}

}

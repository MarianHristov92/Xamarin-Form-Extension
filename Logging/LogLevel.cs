// // ///-----------------------------------------------------------------
// // ///   Class:		EmptyEnumeration.cs
// // ///   Description:	<Description>
// // ///   Author:		Bastian Noffer		Date: 29.06.2018
// // ///   Notes:		<Notes>
// // ///   Revision History:
// // ///   Name:			Date:	Description:
// // ///   Bastian Noffer	29.06.2018	- file created
// // ///-----------------------------------------------------------------
using System;
namespace Xamarin.Forms.Extensions.Logging
{
    /// <summary>
    /// Specifies the Log level.
    /// Error: shows only error messages and exceptions
    /// Debug: shows all Error messages + all Debug messages
    /// Info: Show everything
    /// </summary>
    public enum LogLevel
    {
        Info,
        Debug,
        Error
    }
}

using System;
using System.IO;

namespace Reminders.Droid.Services
{
    /// <summary>
    ///     Platform specific file access.
    /// </summary>
    public class FileAccessHelper
    {
        /// <summary>
        ///     Get a full file path.
        /// </summary>
        /// <param name="filename">Name of the file.</param>
        /// <returns>File with the path prepended.</returns>
        public static string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
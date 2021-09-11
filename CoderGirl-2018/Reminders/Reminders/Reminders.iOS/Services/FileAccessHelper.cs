using System;
using System.IO;

namespace Reminders.iOS.Services
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
            path = Path.Combine(path, "..", "Library");

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            return Path.Combine(path, filename);
        }
    }
}
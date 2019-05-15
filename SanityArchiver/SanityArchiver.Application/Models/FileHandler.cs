using System.IO;

namespace SanityArchiver.Application.Models
{
    /// <summary>
    /// This class handles 5 operations on FileInfo objects. Move, Copy, Rename, Change extension, Change sisibility.
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        /// Moves FileInfo object to the destination directory (entered as a string). Uses the File.Copy method then deletes the original file.
        /// </summary>
        /// <param name="file">FileInfo</param>
        /// <param name="destination">string</param>
        public void Move(FileInfo file, string destination)
        {
            string sourceFile = CreateSourcePath(file, destination);
            string destFile = CreateDestPath(file, destination);

            File.Copy(sourceFile, destFile, true);
            file.Delete();
        }

        /// <summary>
        /// Copies a FileInfo object to the destination folder.Uses the File.Copy method.
        /// </summary>
        /// <param name="file">FileInfo</param>
        /// <param name="destination">string</param>
        public void Copy(FileInfo file, string destination)
        {
            string sourceFile = CreateSourcePath(file, destination);
            string destFile = CreateDestPath(file, destination);

            File.Copy(sourceFile, destFile, true);
        }

        /// <summary>
        /// Renames the subject file passed as a FileInfo object. The new name does NOT need the extension added. The method keeps the original extension.
        /// </summary>
        /// <param name="file">FileInfo</param>
        /// <param name="newName">string</param>
        public void ChangeName(FileInfo file, string newName)
        {
            file.MoveTo(file.Directory.FullName + "\\" + newName + Path.GetExtension(file.FullName));
        }

        /// <summary>
        /// Changes the extension of a file passed as a FileInfo object. New extension is passed as a string. The extension needs the "." in front of it, for example ".txt", ".ppt" etc.
        /// </summary>
        /// <param name="file">FileInfo</param>
        /// <param name="extension">string</param>
        public void ChangeExtension(FileInfo file, string extension)
        {
            File.Move(file.FullName, Path.ChangeExtension(file.FullName, extension));
        }

        /// <summary>
        /// Changes the visibility of a file passed as a FileInfo object. Use boolean false to hide, true to reveal the file.
        /// </summary>
        /// <param name="file">FileInfo</param>
        /// <param name="visible">boolean</param>
        public void ModifyVisibility(FileInfo file, bool visible)
        {
            if (visible == true)
            {
                file.Attributes = FileAttributes.Normal;
            }
            else
            {
                file.Attributes = FileAttributes.Hidden;
            }
        }

        private string CreateSourcePath(FileInfo file, string destination)
        {
            return Path.Combine(file.DirectoryName, file.Name);
        }

        private string CreateDestPath(FileInfo file, string destination)
        {
            return Path.Combine(destination, file.Name);
        }
    }
}

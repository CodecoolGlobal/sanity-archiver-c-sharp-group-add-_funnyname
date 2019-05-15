using System.IO;


namespace SanityArchiver.Application.Handler
{
    public class FileHandler
    {
        public void Move(FileInfo file, string destination)
        {
            string sourceFile = CreateSourcePath(file, destination);
            string destFile = CreateDestPath(file, destination);
            File.Copy(sourceFile, destFile, true);
            file.Delete();
        }

        public void Copy(FileInfo file, string destination)
        {
            string sourceFile = CreateSourcePath(file, destination);
            string destFile = CreateDestPath(file, destination);
            File.Copy(sourceFile, destFile, true);
        }

        private string CreateSourcePath(FileInfo file, string destination)
        {
            return Path.Combine(file.DirectoryName, file.Name);
        }

        private string CreateDestPath(FileInfo file, string destination)
        {
            return Path.Combine(destination, file.Name);
        }

        public void ChangeName(FileInfo file, string newName)
        {
            file.MoveTo(file.Directory.FullName + "\\" + newName + Path.GetExtension(file.FullName));
        }

        public void ChangeExtension(FileInfo file, string extension)
        {
            File.Move(file.FullName, Path.ChangeExtension(file.FullName, extension));
        }

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
    }    
}

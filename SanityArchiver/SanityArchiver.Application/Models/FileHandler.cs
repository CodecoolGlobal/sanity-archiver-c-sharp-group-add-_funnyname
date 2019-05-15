using System;
using System.IO;


namespace SanityArchiver.Application.Handler
{
    public class FileHandler
    {

        public void Move(FileInfo file, string destination)
        {
            file.MoveTo(destination);
        }

        public void Copy(FileInfo file, string destination)
        {
            ///this will create a copy 
        }

        public void ChangeName(FileInfo file, string newName)
        {
            ///this will update the file's name
        }

        public void ChangeExtension(FileInfo file, string extension)
        {
            ///this will update the extension of the file
        }

        public void ModifyVisibility(FileInfo file, bool visible)
        {
            ///this will update the visibility of the file
        }

    }
}

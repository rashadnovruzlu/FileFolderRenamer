using System.IO.Compression;
using System.Reflection;

namespace FileFolderRenamer
{
    public sealed class FileCommand
    {
        public FileCommand(string currentProjectName, string newProjectName, string newProjectPath)
        {
            CurrentProjectName = currentProjectName;
            NewProjectName = newProjectName;
            NewProjectPath = newProjectPath;
        }

        public string NewProjectPath { get; set; }
        public string CurrentProjectName { get; set; }
        public string NewProjectName { get; set; }
         
        public void ReplaceFolderName(string dir)
        {
            try
            {

                foreach (string folder in Directory.GetDirectories(dir))
                {
                    string folderName = folder;

                    if (folder.IndexOf(CurrentProjectName) != -1)
                    {
                        folderName = folder.Replace(CurrentProjectName, NewProjectName);

                        Directory.Move(folder, folderName);
                    }

                    ReplaceFolderName(folderName);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReplaceFileName(string dir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    if (file.IndexOf(CurrentProjectName) != -1)
                    {
                        File.Move(file, file.Replace(CurrentProjectName, NewProjectName));
                    }
                }

                foreach (string folder in Directory.GetDirectories(dir))
                {
                    ReplaceFileName(folder);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReplaceFileContent(string dir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(dir))
                {

                    string text = File.ReadAllText(file);
                    text = text.Replace(CurrentProjectName, NewProjectName);
                    File.WriteAllText(file, text);

                }

                foreach (string folder in Directory.GetDirectories(dir))
                {
                    ReplaceFileContent(folder);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}


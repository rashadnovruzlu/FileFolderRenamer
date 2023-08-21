using FileFolderRenamer;

string currenstolutionName = "e-commerce";

string newSolutionName = "e-shopping";

string solutionPath = @"D:\api-backend";

Console.WriteLine("The process is started.");

FileCommand fileCommand = new FileCommand(currenstolutionName, newSolutionName, solutionPath);

Console.WriteLine("The folder renamer operation is started.");
fileCommand.ReplaceFolderName(solutionPath);
Console.WriteLine("The Folders are renamed successfully.");

Console.WriteLine("The file renamer operation is started.");
fileCommand.ReplaceFileName(solutionPath);
Console.WriteLine("The Files are renamed successfully.");

Console.WriteLine("The content renamer operation is started.");
fileCommand.ReplaceFileContent(solutionPath);
Console.WriteLine("The File contents are renamed successfully.");

Console.WriteLine("Process has completed successfully."); 
Console.ReadLine();
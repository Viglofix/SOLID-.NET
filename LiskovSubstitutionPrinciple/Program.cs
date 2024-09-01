﻿//Calling class not following Liskov Substitution Principle

IFileReader accessDataFile = new AdminDataFileUser();
accessDataFile.ReadFile(@"c:\temp\a.txt");
accessDataFile.WriteFile(@"c:\temp\a.txt");

IFileReader accessDataFileR = new RegularDataFileUser();
accessDataFileR.ReadFile(@"c:\temp\a.txt");
//accessDataFileR.WriteFile();  // Throws exception

// Not following the Liskov Substitution Principle

public interface IFileReader {
  public void ReadFile(string filePath);
}
public interface IFileWriter{
  public void WriteFile(string filePath);
}
public class AdminDataFileUser : IFileReader,IFileWriter 
{
    public void ReadFile(string filePath)
    {
        // Read File logic
        Console.WriteLine($"File {filePath} has been read");
    }

    public void WriteFile(string filePath)
    {
        //Write File Logic
        Console.WriteLine($"File {filePath} has been written");
    }
}
public class RegularDataFileUser : IFileReader
{
    public void ReadFile(string filePath)
    {
        // Read File logic
        Console.WriteLine($"File {filePath} has been read");
    }
}


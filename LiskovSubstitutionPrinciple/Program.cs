﻿//Calling class not following Liskov Substitution Principle

IMultiFunctionalDevice accessDataFile = new AdminDataFileUser();
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
public interface IMultiFunctionalDevice : IFileReader,IFileWriter;
public class AdminDataFileUser : IMultiFunctionalDevice
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


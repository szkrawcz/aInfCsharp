using System;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
        /*    //  Loop through all the immediate subdirectories of C.
            foreach (string entry in Directory.GetDirectories(@"C:\"))
            {
                DisplayFileSystemInfoAttributes(new DirectoryInfo(entry));
            }
            //  Loop through all the files in C.
            foreach (string entry in Directory.GetFiles(@"C:\"))
            {
                DisplayFileSystemInfoAttributes(new FileInfo(entry));
            }
        */
var sw = new Stopwatch();

sw.Start();

    DirSearch(@"C:\");
sw.Stop();

Console.WriteLine("Elapsed={0}",sw.Elapsed);
        
			//ListFiles(@"C:\");
            Console.ReadKey(true);
        }
  



        static void DisplayFileSystemInfoAttributes(FileSystemInfo fsi)
        {
            //  Assume that this entry is a file.
            string entryType = "File";

            // Determine if entry is really a directory
            if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory )
            {
                entryType = "Directory";
            }
            //  Show this entry's type, name, and creation date.
            Console.WriteLine("{0} entry {1} was created on {2:D} last write {3:D}", entryType, fsi.FullName, fsi.CreationTime , fsi.LastWriteTime);
            var fullName =fsi.FullName;
            var creationTime =  fsi.CreationTime;
            var lastWrite = fsi.LastWriteTime;
           // fsi.GetHashCode
        }
        
        
        
   static void ListFiles(string sDir)
   {
   	string[] files = Directory.GetFiles(sDir);
   
   	for (var i =0 ; i < files.Length; i++)
   	{
   		try 
   		{
   			DisplayFileSystemInfoAttributes(new FileInfo( files[i]));
   		//	Console.WriteLine(files[i]);
   			
   		}
   		catch (System.Exception excpt)
        {
           //Console.WriteLine(excpt.Message);
        }
   	}
   }
        
        
   static void DirSearch(string sDir)
   {
   	string[] directories = Directory.GetDirectories(sDir);
   	ListFiles(sDir);
   	for (var i =0 ; i < directories.Length; i++)
   	{
   		try 
   		{
   			//Console.WriteLine(directories[i]);
   			DirSearch(directories[i]);
   		}
   		catch (System.Exception excpt)
        {
           //Console.WriteLine(excpt.Message);
        }
   	}

   }
 }
}

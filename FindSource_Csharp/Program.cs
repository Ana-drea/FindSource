using System;
using System.Collections;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> enulist = new List<string>();
            System.Console.WriteLine("Please enter the path of the enu file list:");
            string EnuListPath = System.Console.ReadLine();

            if (File.Exists(EnuListPath))
            {
                StreamReader sr = new StreamReader(EnuListPath);
                String s;
                while ((s = sr.ReadLine()) != null)
                {
                    enulist.Add(s);
                }
                String language = null;


                System.Console.WriteLine("Type in a number to choose a target language:");
                System.Console.WriteLine("1: deu");
                System.Console.WriteLine("2. esp");
                System.Console.WriteLine("3. fra");
                System.Console.WriteLine("4. ita");
                System.Console.WriteLine("5. jpn");
                String languagecode = System.Console.ReadLine();
                switch (languagecode)
                {
                    case "1":
                        language = "\\de\\";
                        break;
                    case "2":
                        language = "\\es\\";
                        break;
                    case "3":
                        language = "\\fr\\";
                        break;
                    case "4":
                        language = "\\it\\";
                        break;
                    case "5":
                        language = "\\ja\\";
                        break;
                    default:
                        System.Console.WriteLine("Wrong input, end the process");
                        System.Environment.Exit(1);
                        break;
                }

                System.Console.WriteLine("Type in '1' to print out and check your target folder path");
                System.Console.WriteLine("Type in '2' to start copying to target folder");
                String nextstep = System.Console.ReadLine();
                switch (nextstep)
                {
                    case "1":
                        ShowTargetLanFolder(enulist, language);
                        break;
                    case "2":
                        CopyToTargetLanFolder(enulist, language);
                        break;
                    default:
                        System.Console.WriteLine("Wrong input, end the process");
                        System.Environment.Exit(1);
                        break;
                }

            }
            else
            {
                System.Console.WriteLine("Invalid path. Please check your input.");
            }
        }


        public static void CopyToTargetLanFolder(List<string> enulist, String language)
        {
            for (int i = 0; i < enulist.Count; i++)
            {
                // 
                string EnuFilePath = enulist[i];
                string FileName = Path.GetFileName(EnuFilePath);
                // 
                string TargetFolder = Path.GetDirectoryName(EnuFilePath).Replace("\\en\\", language);

                // 
                string TargetFilePath = Path.Combine(TargetFolder, FileName + "_enu");
                copyFileContent(EnuFilePath, TargetFilePath);
            }
        }
        public static void ShowTargetLanFolder(List<string> enulist, String language)
        {
            for (int i = 0; i < enulist.Count; i++)
            {
                // 
                string EnuFilePath = enulist[i];

                // 
                string TargetFolder = Path.GetDirectoryName(EnuFilePath).Replace("\\en\\", language);

                // 
                System.Console.WriteLine(TargetFolder);
            }
        }

        public static void copyFileContent(string EnuFilePath, string TargetFilePath)
        {
            StreamReader sr = new StreamReader(EnuFilePath);
            StreamWriter sw = new StreamWriter(TargetFilePath);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sw.WriteLine(line);
            }
            sr.Close();
            sw.Close();
        }

    }
}
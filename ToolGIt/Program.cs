using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
namespace ToolGIt
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Utilitaire sprecifique pour git !");
            Console.WriteLine("");
            Console.WriteLine("               ------------o ");
            Console.WriteLine("-------------o----------------------o");
            Console.WriteLine("                       -----------o ");
            Console.WriteLine("Prerequisite");
            Console.WriteLine("git config --global user.name [NAME]");
            Console.WriteLine("git config --global user.email [EMAIL]");
            Console.WriteLine("");
            string gitCommand = "git";

            try
            {
                string path_origin = Directory.GetCurrentDirectory();
                Console.WriteLine("Witch diretory, if not found he created !");
                string target = Console.ReadLine();

                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }
                Environment.CurrentDirectory = (target);
                if (path_origin.Equals(Directory.GetCurrentDirectory()))
                {
                    Console.WriteLine("You are not in directory.");
                }
                else
                {
                    Console.WriteLine("You are in the directory.");
                    Console.WriteLine("");


                    string gitInitArgument = @$"init";

                    Process.Start(gitCommand, gitInitArgument);
                    Thread.Sleep(1000);

                    Console.WriteLine("");


                    string path = target + "//README.md";
                    try
                    {
                        using (FileStream fs = File.Create(path))
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes("ToolGit.");
                            fs.Write(info, 0, info.Length);
                        }

                        using (StreamReader sr = File.OpenText(path))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(s);
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }



                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        


            Console.WriteLine("Configurations");
            Console.WriteLine("");

            Console.WriteLine("Remote ?");
            Console.WriteLine("");

            string remote = Console.ReadLine();
            //Console.WriteLine("Name ?");
            Console.WriteLine("");

            //string username = Console.ReadLine();
            //Console.WriteLine("Mail ?");
            //Console.WriteLine("");

            //string mail = Console.ReadLine();

            string gitRemoteArgument = @$"remote add origin {remote}";
            //string gitUsernameArgument = @$"config --global user.name '{username}'";
            //string gitMailArgument = @$"config --global user.email {mail}";
            string gitStatusArgument = @$"status";
            string gitBranchArgument = @$"branch -M main";
            string gitAddArgument = @$"add .";
            string gitCommitArgument = @$"commit -m ""first commit with toolGit""";
            string gitPushArgument = @$"push -u origin main";


          
            Process.Start(gitCommand, gitRemoteArgument);
            Thread.Sleep(1000);
            //Process.Start(gitCommand, gitUsernameArgument);

            //Process.Start(gitCommand, gitMailArgument);

            Process.Start(gitCommand, gitBranchArgument);
            Thread.Sleep(1000);

            Process.Start(gitCommand, gitStatusArgument);
            Thread.Sleep(1000);

            Process.Start(gitCommand, gitAddArgument);
            Thread.Sleep(1000);

            Process.Start(gitCommand, gitCommitArgument);
            Thread.Sleep(1000);

            
            Process.Start(gitCommand, gitPushArgument);
            


        }

   
    }
}

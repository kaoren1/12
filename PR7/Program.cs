using PR7;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace PR7
{
    internal class Program
    {
        public static void Main()
        {
            Console.Clear();
            DriveInfo[] disks = DriveInfo.GetDrives();
            foreach (DriveInfo disk in disks)
            {
                long space = disk.TotalFreeSpace / 1024 / 1024 / 1024;
                Console.WriteLine("  " + disk + "\t\tСвободное пространство на диске (ГБ): " + space);
            }
            int selected = Menu.Cursor(disks.Length - 1);
            if (selected == -1)
            {
                return;
            }
            Console.Clear();
            string o = disks[selected].Name;
            ShowDirectories(o);
        }
        public static void ShowDirectories(string path)
        {
            string[] directory = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            int data = 0;
            try
            {
                int a = 0;
                do
                {
                    Console.Clear();
                    foreach (string dir in directory)
                    {
                        DateTime space = Directory.GetCreationTime(dir);
                        Console.WriteLine("  " + dir + "\t\t\t(Дата создания: " + space + ")");
                    }
                    foreach (string file in files)
                    {
                        DateTime space = File.GetCreationTime(file);
                        Console.WriteLine("  " + file + "\t\t\t(Дата создания: " + space + ")");
                    }
                    int long1 = directory.Length + files.Length;
                    int selected = Menu.Cursor(long1 - 1);
                    if (selected == -1)
                    {
                        return;
                    }
                    data = selected;
                    ShowDirectories(directory[selected]);
                }
                while (a != 1);
            }
            catch (IndexOutOfRangeException)
            {
                try
                {
                    OpenFile(files[data]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка открытия файла");
                    Thread.Sleep(1000);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.Clear();
                Console.WriteLine("Ошибка: доступ запрещен");
                Thread.Sleep(1000);
                Main();
            }
        }
        private static void OpenFile(string pathFile)
        {
            Process.Start(new ProcessStartInfo { FileName = pathFile, UseShellExecute = true });
            Console.Clear();
            Main();
        }
    }
}
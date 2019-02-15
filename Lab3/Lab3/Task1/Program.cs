using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    enum FSIMode
    {
        DirectoryInfo = 1,
        File = 2
    }

    class Layer
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }
        public int SelectedIndex
        {
            get;
            set;
        }
        public void Draw()// пометка элементов
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (Content[i].GetType() == typeof(FileInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine((i + 1) + ". " + Content[i].Name);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Asus\Pictures");
            Layer l = new Layer
            {
                Content = dir.GetFileSystemInfos(),
                SelectedIndex = 0
            };


            FSIMode curMode = FSIMode.DirectoryInfo;

            Stack<Layer> history = new Stack<Layer>();
            history.Push(l);

            bool esc = false;
            while (!esc)
            {
                history.Peek().Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow: //движение вверх по списку
                        if (history.Peek().SelectedIndex - 1 < 0)
                        {
                            history.Peek().SelectedIndex = history.Peek().Content.Length - 1;
                        }
                        else
                        {
                            history.Peek().SelectedIndex--;
                        }
                        break;

                    case ConsoleKey.DownArrow: //движение вниз по списку
                        if (history.Peek().SelectedIndex + 1 >= history.Peek().Content.Length)
                        {
                            history.Peek().SelectedIndex = 0;
                        }
                        else
                        {
                            history.Peek().SelectedIndex++;
                        }
                        break;

                    case ConsoleKey.Enter: //заходит в помеченную папку для показа содержимого
                        int index = history.Peek().SelectedIndex;
                        FileSystemInfo fsi = history.Peek().Content[index];
                        if (fsi.GetType() == typeof(DirectoryInfo))
                        {
                            curMode = FSIMode.DirectoryInfo;
                            DirectoryInfo d = fsi as DirectoryInfo;
                            history.Push(new Layer
                            {
                                Content = d.GetFileSystemInfos(),
                                SelectedIndex = 0
                            });
                        }
                        else
                        {
                            curMode = FSIMode.File;
                            using (FileStream fs = new FileStream(fsi.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;

                    case ConsoleKey.Backspace: //Back
                        if (curMode == FSIMode.DirectoryInfo)
                        {
                            history.Pop();
                        }
                        else
                        {
                            curMode = FSIMode.DirectoryInfo;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.Delete: //Удаление элемента
                        int iter = history.Peek().SelectedIndex;
                        FileSystemInfo fsi1 = history.Peek().Content[iter];
                        Console.Clear();
                        Console.WriteLine("Do you want to delete {0} ?\nPress [Y/N]", fsi1.Name);
                        ConsoleKeyInfo res = Console.ReadKey();
                        while (res.Key != ConsoleKey.Y && res.Key != ConsoleKey.N)
                            res = Console.ReadKey();
                        if (res.Key == ConsoleKey.Y)
                        {
                            fsi1.Delete();
                        }
                        else { break; }
                        history.Pop();
                        break;

                    case ConsoleKey.F: //Переимонование выбранного элемента
                        int iter1 = history.Peek().SelectedIndex;
                        FileSystemInfo fsi2 = history.Peek().Content[iter1];
                        Console.WriteLine("Enter new name:");
                        string name = Console.ReadLine();
                        string prev = fsi2.FullName;

                        string newName = Path.Combine(Path.GetDirectoryName(prev), name);
                        Directory.Move(prev, newName);
                        history.Pop();
                        break;

                    case ConsoleKey.Escape: //Выход
                        esc = true;
                        break;
                }
            }
        }
    }
}
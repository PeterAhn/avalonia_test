using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Avalonia.Media.Imaging;
using Avalonia;
using Avalonia.Platform;
using System.IO;
using System.Reflection;

namespace AvaloniaTest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            RunCmd = ReactiveCommand.Create(RunCmdProc);
        }

        private IBitmap imgSrc;
        public IBitmap ImageSrc
        {
            get => imgSrc;
            set => this.RaiseAndSetIfChanged(ref imgSrc, value);
        }

        private void RunCmdProc()
        {
            Console.WriteLine("Button Click");
            string path = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\Assets\\noimage.jpg";

            Console.WriteLine(path);
            try
            {
                Mat img = new Mat(path);
                var bmp = img.ToMemoryStream();
                Bitmap t = new Bitmap(bmp);
                ImageSrc = t;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string Greeting => "Welcome to Avalonia!";

        public ReactiveCommand<Unit, Unit> RunCmd { get; }

    }
}

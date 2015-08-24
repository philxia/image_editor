using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Media.Imaging.FormatProviders;

namespace ImageEditor
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         this.ImageEditorUI.ImageEditorLoaded += ImageEditorUI_ImageEditorLoaded;
      }

      void ImageEditorUI_ImageEditorLoaded(object sender, EventArgs e)
      {
         string[] args = Environment.GetCommandLineArgs();
         if (args.Length > 1)
         {
            string imagePath = args[1];
            if (File.Exists(imagePath))
            {
               FileInfo fi = new FileInfo(imagePath);
               string extension = fi.Extension.ToLower();
               FileStream stream = fi.Open(FileMode.Open);

               IImageFormatProvider formatProvider = ImageFormatProviderManager.GetFormatProviderByExtension(extension);
               if (formatProvider == null)
               {
                  StringBuilder sb = new StringBuilder();
                  sb.Append("Unable to find format provider for extension: ")
                    .Append(extension).Append(" .");
                  return;
               }
               else
               {
                  this.ImageEditorUI.Image = formatProvider.Import(stream);
                  this.ImageEditorUI.ImageEditor.ScaleFactor = 0;
               }

            }
         }
      }
   }
}

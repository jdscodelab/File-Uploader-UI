using FileUploaderUI.CustomControl;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace FileUploaderUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = true };
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                //Get Selected Files
                string[] files = openFileDialog.FileNames;

                //Iterate and add all selected files to upload
                for (int i = 0; i < files.Length; i++)
                {
                    string filename = System.IO.Path.GetFileName(files[i]);
                    FileInfo fileInfo = new FileInfo(files[i]);
                    UploadingFilesList.Items.Add(new fileDetail() 
                    { 
                        FileName = filename,

                        //To Convert bytes to Mb => bytes / 1.049e+6
                        FileSize = string.Format("{0} {1}", (fileInfo.Length/1.049e+6).ToString("0.0"), "Mb"),
                        UploadProgress=100
                    });
                }
            }
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            //Checking what kind of file is User dropping 
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                //Iterate and add all selected files to upload
                for (int i = 0; i < files.Length; i++)
                {
                    string filename = System.IO.Path.GetFileName(files[i]);
                    FileInfo fileInfo = new FileInfo(files[i]);
                    UploadingFilesList.Items.Add(new fileDetail()
                    {
                        FileName = filename,

                        //To Convert bytes to Mb => bytes / 1.049e+6
                        FileSize = string.Format("{0} {1}", (fileInfo.Length / 1.049e+6).ToString("0.0"), "Mb"),
                        UploadProgress = 100
                    });
                }
            }
        }
    }
}

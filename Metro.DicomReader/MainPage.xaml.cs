using System;
using System.Text;
using EvilDicom.Components;
using EvilDicom.Image;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Metro.DicomReader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void OpenFileButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var fileOpenPicker = new FileOpenPicker();
                fileOpenPicker.FileTypeFilter.Add(".dcm");

                var file = await fileOpenPicker.PickSingleFileAsync();
                if (file == null) return;

                var dicomFile = new DICOMFile(file);

                var stringBuilder = new StringBuilder();
                dicomFile.ToXML(stringBuilder);
                DicomXmlDump.Text = stringBuilder.ToString();

                DicomImage.Source = await new ImageMatrix(new IStorageFile[] { file }).GetImage(0);
            }
            catch (Exception exception)
            {
                DicomXmlDump.Text = exception.Message + Environment.NewLine + exception.StackTrace;
            }
        }
    }
}

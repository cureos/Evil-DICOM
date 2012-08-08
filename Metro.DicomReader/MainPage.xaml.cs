using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EvilDicom.Components;
using EvilDicom.Image;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Metro.DicomReader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
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

        private async void OpenFileButton_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var fileOpenPicker = new FileOpenPicker();
                fileOpenPicker.FileTypeFilter.Add(".dcm");
                var file = await fileOpenPicker.PickSingleFileAsync();
                if (file != null)
                {
                    var dicomFile = new DICOMFile(file);

                    var stringBuilder = new StringBuilder();
                    dicomFile.ToXML(stringBuilder);
                    DicomXmlDump.Text = stringBuilder.ToString();

                    DicomImage.Source = await new ImageMatrix(file).GetImage(0);
                }
            }
            catch (Exception exception)
            {
                DicomXmlDump.Text = exception.Message + Environment.NewLine + exception.StackTrace;
            }
        }
    }
}

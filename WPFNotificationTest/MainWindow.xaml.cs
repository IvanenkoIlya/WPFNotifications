using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace WPFNotificationTest
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
            ToastNotificationManager.CreateToastNotifier("MyTestId").Show( CreateBasicToast());
        }

        private ToastNotification CreateBasicToast()
        {
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "title"
                        },

                        new AdaptiveText()
                        {
                            Text = "content"
                        }
                    },

                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = "",
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };

            ToastContent toastContent = new ToastContent()
            {
                Visual = visual
            };

            string toastXml = toastContent.GetContent();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(toastXml);

            return new ToastNotification(doc);
        }
    }
}

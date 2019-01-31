namespace WpfGuiApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using StringProcessor;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The on process text.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnProcessText(object sender, RoutedEventArgs e)
        {
            IStringProcessor processor = availableProcessors.SelectedItem as IStringProcessor;
            if (processor != null)
            {
                string input = originalText.Text;
                string result = processor.Process(input);
                resultText.Text = result;
            }
        }

        /// <summary>
        /// The on window loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            availableProcessors.Items.Add(new ReverseProcessor());
            availableProcessors.Items.Add(new UppercaseString());
            availableProcessors.Items.Add(new RandomizeString());
            availableProcessors.Items.Add(new ReverseWords());
            availableProcessors.SelectedIndex = 0;
        }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   The main window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SequenceLoader
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

    using Bio;
    using Bio.IO;

    using Microsoft.Win32;

    using SequenceLoader.ViewModels;

    /// <summary>
    /// The main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The vm.
        /// </summary>
        private readonly MainViewModel vm = new MainViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            // Wire up command handlers for 3 menu commands.
            CommandBindings.Add(
                new CommandBinding(ApplicationCommands.Open, this.OnOpenFile));
            CommandBindings.Add(
                new CommandBinding(ApplicationCommands.Save, this.OnExportData, (s, e) => e.CanExecute = this.vm.SelectedSequence != null));
            CommandBindings.Add(
                new CommandBinding(ApplicationCommands.Close, (s, e) => Close()));
            this.DataContext = this.vm;
            this.InitializeComponent();
        }

        /// <summary>
        /// The on open file.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this) == true)
            {
                // Identify the file format if we can
                ISequenceParser parser = SequenceParsers.FindParserByFileName(ofd.FileName);
                if (parser != null)
                {
                    // Load the sequence(s) in.
                    IEnumerable<ISequence> sequenceList = parser.Parse();
                    if (sequenceList != null)
                    {
                        // Add them to the UI
                        foreach (ISequence sequence in sequenceList)
                        {
                            this.vm.LoadedSequences.Add(new SequenceViewModel(sequence));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The on export data.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnExportData(object sender, RoutedEventArgs e)
        {
            // TODO: add formatter selection here
        }
    }
}

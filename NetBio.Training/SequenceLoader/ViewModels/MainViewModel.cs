namespace SequenceLoader.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The _selected sequence.
        /// </summary>
        private SequenceViewModel selectedSequence;

        /// <summary>
        /// Gets Collection of loaded sequences
        /// </summary>
        public IList<SequenceViewModel> LoadedSequences { get; internal set; }

        /// <summary>
        /// Gets or sets the selected sequence
        /// </summary>
        public SequenceViewModel SelectedSequence
        {
            get
            {
                return this.selectedSequence;
            }

            set
            {
                this.selectedSequence = value;
                this.RaisePropertyChanged("SelectedSequence");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.LoadedSequences = new ObservableCollection<SequenceViewModel>();
        }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            // Verify property exists in debug builds.
            Debug.Assert(string.IsNullOrEmpty(propertyName) || GetType().GetProperty(propertyName) != null);

            // Raise PropertyChanged
            PropertyChangedEventHandler inpc = this.PropertyChanged;
            if (inpc != null)
                inpc.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
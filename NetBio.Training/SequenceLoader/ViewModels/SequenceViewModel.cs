namespace SequenceLoader.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;

    using Bio;

    /// <summary>
    /// ViewModel for a single sequence.
    /// </summary>
    public class SequenceViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        /// <summary>
        /// The display count.
        /// </summary>
        private const int DisplayCount = 50;

        /// <summary>
        /// The sequence.
        /// </summary>
        private readonly Bio.ISequence sequence;

        /// <summary>
        /// Gets the position.
        /// </summary>
        public int Position { get; internal set; }

        /// <summary>
        /// Gets the first 20 characters of sequence name
        /// </summary>
        public string ShortName
        {
            get { return this.sequence.ID.Substring(0, Math.Min(20, sequence.ID.Length)); }
        }

        /// <summary>
        /// Gets the molecule type from alphabet
        /// </summary>
        public string MoleculeType
        {
            get { return this.sequence.Alphabet.Name; }
        }

        /// <summary>
        /// Gets the full name of the sequence
        /// </summary>
        public string FullName
        {
            get { return this.sequence.ID; }
        }

        /// <summary>
        /// Current position within the sequence for the UI display.
        /// </summary>
        public int SegmentPosition
        {
            get
            {
                return this.Position;
            }
            set
            {
                this.Position = value;
                this.RaisePropertyChanged("SegmentPosition");
                this.RaisePropertyChanged("SegmentEnd");
                this.RaisePropertyChanged("Segment");
                this.RaisePropertyChanged("ReverseSegment");
                this.RaisePropertyChanged("ComplementSegment");
                this.RaisePropertyChanged("ReverseComplementSegment");
            }
        }

        /// <summary>
        /// Gets the ending index for the sequence in the UI display.
        /// </summary>
        public int SegmentEnd
        {
            get { return this.Position + DisplayCount; }
        }

        /// <summary>
        /// Gets the maximum range for the slider in the UI
        /// I.e. what it's value is at the far right end.
        /// </summary>
        public int SegmentMaxRange
        {
            get { return (int)this.sequence.Count - DisplayCount; }
        }
        
        /// <summary>
        /// Gets the slice of the sequence (Pos+Size)
        /// </summary>
        public string Segment
        {
            get { return GetString(this.sequence.GetSubSequence(this.Position, DisplayCount)); }
        }

        /// <summary>
        /// Gets the Reverse of the Segment.
        /// </summary>
        public string ReverseSegment
        {
            get { return GetString(this.sequence.GetReversedSequence().GetSubSequence(this.Position, DisplayCount)); }
        }

        /// <summary>
        /// Gets the Complement of the Segment.
        /// </summary>
        public string ComplementSegment
        {
            get
            {
                if (this.sequence.Alphabet == ProteinAlphabet.Instance)
                    return "N/A";
                return GetString(this.sequence.GetSubSequence(this.Position, DisplayCount).GetComplementedSequence());
            }
        }

        /// <summary>
        /// Gets the ReverseComplement of the Segment.
        /// </summary>
        public string ReverseComplementSegment
        {
            get
            {
                if (this.sequence.Alphabet == ProteinAlphabet.Instance)
                    return "N/A";
                return GetString(this.sequence.GetReverseComplementedSequence().GetSubSequence(this.Position, DisplayCount));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceViewModel"/> class.
        /// </summary>
        /// <param name="sequence">
        /// The sequence.
        /// </param>
        public SequenceViewModel(ISequence sequence)
        {
            this.sequence = sequence;
        }

        /// <summary>
        /// Generate a string from a sequence - limited to 255 characters.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private static string GetString(ISequence sequence)
        {
            return new string(
                sequence.Select(b => (char)b).Take(255).ToArray());
        }

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
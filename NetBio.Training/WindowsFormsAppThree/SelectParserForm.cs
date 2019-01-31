namespace WindowsFormsAppThree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The select parser form.
    /// </summary>
    public partial class SelectParserForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectParserForm"/> class.
        /// </summary>
        public SelectParserForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the file name.
        /// </summary>
        public string FileName { get; internal set; }

        /// <summary>
        /// Gets or sets the selected parser.
        /// </summary>
        public Bio.IO.ISequenceParser SelectedParser { get; set; }
    }
}

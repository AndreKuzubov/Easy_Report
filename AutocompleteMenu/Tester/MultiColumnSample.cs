using System.Windows.Forms;
using AutocompleteMenuNS;

namespace Tester
{
    public partial class MultiColumnSample : Form
    {
        public MultiColumnSample()
        {
            InitializeComponent();

            autocompleteMenu1.MaximumSize = new System.Drawing.Size(250, 200);
            var columnWidth = new int[] { 50, 200 };

            autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "fsdf", "Mr. fdsgdf()" }, "Adam.Smith(4)") );
            autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "sdf", "Ms. Eva Smith" }, "Eva.Smith") );
            autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "sdf", "Mr. Bond, James Bond" }, "James Bond") );
            autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "sdf", "Mr. Sam, Serios Sam" }, "Serios Sam") );

            autocompleteMenu1.Items = null;
            autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "fsdf", "Mr. fdsgdf()" }, "Adam.Smith(4)"));
            autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "sdf", "Ms. Eva Smith" }, "Eva.Smith"));
            autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "sdf", "Mr. Bond, James Bond" }, "James Bond"));
            autocompleteMenu1.AddItem(new MulticolumnAutocompleteItem(new[] { "sdf", "Mr. Sam, Serios Sam" }, "Serios Sam"));
        }
    }
}

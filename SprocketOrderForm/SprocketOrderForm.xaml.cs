using System.Windows;

namespace SprocketOrderApp
{
    public partial class SprocketOrderForm : Window
    {
        private SprocketOrder _currentOrder = new SprocketOrder();

        public SprocketOrderForm()
        {
            InitializeComponent(); // Initialize UI components
        }

        // Event handler for the Local Pickup checkbox
        private void chkLocalPickup_Checked(object sender, RoutedEventArgs e)
        {
            txtAddress.IsEnabled = !chkLocalPickup.IsChecked ?? true;
        }

        // Event handler for the Add button
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addForm = new SprocketForm(); // Open Add Sprocket form
            if (addForm.ShowDialog() == true)
            {
                _currentOrder.AddItem(addForm.NewSprocket); // Add sprocket to the order
                UpdateSummary(); // Update the order summary display
            }
        }

        // Event handler for the Remove button
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Logic to confirm and remove a sprocket from the order
            MessageBox.Show("Remove functionality not implemented yet.");
        }

        // Event handler for the Save button
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Open a SaveFileDialog and save the order to a file
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = ".txt",
                Title = "Save Order"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using var writer = new System.IO.StreamWriter(saveFileDialog.FileName);
                writer.WriteLine(_currentOrder.ToString());
                foreach (var sprocket in _currentOrder.Items)
                {
                    writer.WriteLine(sprocket.ToString());
                }
                MessageBox.Show("Order saved successfully!");
            }
        }

        // Update the summary TextBox
        private void UpdateSummary()
        {
            txtOrderSummary.Text = _currentOrder.ToString();
        }
    }
}

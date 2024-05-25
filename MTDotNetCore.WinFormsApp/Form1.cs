namespace MTDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        public FrmBlog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}

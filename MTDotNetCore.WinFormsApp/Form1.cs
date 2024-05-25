using MTDotNetCore.Shared;
using MTDotNetCore.WinFormsApp.Models;

namespace MTDotNetCore.WinFormsApp
{
    public partial class Form1 : Form
    {
        DapperService _dapperService;
        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.builder.ConnectionString);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearContorls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel newblog = new BlogModel()
                {
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim(),
                };

                int result = _dapperService.Execute(Queries.BlogQuery.InsertQuery, newblog);
                string message = result > 0 ? "Saving Successful" : "Saving Failed";
                MessageBoxIcon messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;

                MessageBox.Show(message, "Saving Blog", MessageBoxButtons.OK, messageBoxIcon);

                if (result > 0) ClearContorls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ClearContorls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }
    }
}

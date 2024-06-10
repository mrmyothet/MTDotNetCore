using MTDotNetCore.Shared;
using MTDotNetCore.WinFormsApp.Models;

namespace MTDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        DapperService _dapperService;

        private readonly int _blogId;

        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.builder.ConnectionString);
        }

        public FrmBlog(int blogId)
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.builder.ConnectionString);

            _blogId = blogId;

            string query = "select * from tbl_blog where blogid = @BlogId";
            var model = _dapperService.QueryFirstOrDefault<BlogModel>(query, new { BlogId = blogId });

            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogAuthor;
            txtContent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogModel() { 
                    BlogId = _blogId, 
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim(),
                };

                string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE [BlogId] = @BlogId";

                int result = _dapperService.Execute(query, item);
                string message = result > 0 ? "Update Successful!" : "Update Failed!";
                MessageBox.Show(message);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

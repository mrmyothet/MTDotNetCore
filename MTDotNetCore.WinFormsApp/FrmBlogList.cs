using MTDotNetCore.Shared;
using MTDotNetCore.WinFormsApp.Models;
using MTDotNetCore.WinFormsApp.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        DapperService _dapperService;

        public FrmBlogList()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.builder.ConnectionString);
            dgvBlog.AutoGenerateColumns = false;
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            //List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.SelectQuery);
            //dgvBlog.DataSource = lst;

            LoadBlogList();
        }

        private void LoadBlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.SelectQuery);
            dgvBlog.DataSource = lst;
        }

        private void dgvBlog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int blogId = Convert.ToInt32(dgvBlog.Rows[e.RowIndex].Cells["colId"].Value);

            if (e.ColumnIndex == (int)EnumFormControlType.Edit) 
            {
                FrmBlog blogForm = new FrmBlog(blogId);
                blogForm.ShowDialog();

                // Load data again to see updated record
                LoadBlogList();
            }
            if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure to delete it?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                
                int result = DeleteBlog(blogId);
                string message = result > 0 ? "Delete Successful!" : "Delete Failed";
                MessageBox.Show(message);

                // Load data again to disapper deleted record
                LoadBlogList();
            }
        }

        private int DeleteBlog(int id)
        {
            string query = BlogQuery.DeleteQuery;

            int result = _dapperService.Execute(query, new BlogModel { BlogId = id });
            return result;
        }
    }
}

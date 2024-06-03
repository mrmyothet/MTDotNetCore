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
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.SelectQuery);
            dgvBlog.DataSource = lst;
        }
    }
}

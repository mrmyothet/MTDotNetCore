using MTDotNetCore.Shared;

namespace MTDotNetCore.WinFormsAppSqlnjection
{
    public partial class frmLogin : Form
    {
        private readonly DapperService _dapperService;
        public frmLogin()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.builder.ConnectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            // 123' or 1=1 + '

            string query = $"select * from tbl_user where email = @Email and password=@Password";
            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new { 
                Email = email,
                Password = password
            });

            if (model is null)
            {
                MessageBox.Show("The user doesn't exist.");
                return;
            }

            MessageBox.Show("Is Admin : " + model.Email);
        }
    }

    public class UserModel
    {
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}

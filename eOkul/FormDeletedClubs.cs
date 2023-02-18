using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eOkul
{
    public partial class FormDeletedClubs : Form
    {
        public FormDeletedClubs()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=DBOKUL;Integrated Security=True");

        public void list()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT ID,AD FROM TBL_KULUP WHERE DURUM=0", conn);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void FormDeletedClubs_Load(object sender, EventArgs e)
        {
            list();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommandDelete = new SqlCommand("UPDATE TBL_KULUP SET DURUM=1 WHERE ID=@D1", conn);
            sqlCommandDelete.Parameters.AddWithValue("@D1", textBoxID.Text);
            sqlCommandDelete.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kulüp aktifleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }
    }
}

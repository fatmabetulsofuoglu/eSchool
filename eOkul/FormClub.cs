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
    public partial class FormClub : Form
    {
        public FormClub()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=DBOKUL;Integrated Security=True");

        public void list()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT ID,AD FROM TBL_KULUP WHERE DURUM=1", conn);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void FormClub_Load(object sender, EventArgs e)
        {
            list();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommandAdd = new SqlCommand("INSERT INTO TBL_KULUP (AD) VALUES (@P1)", conn);
            sqlCommandAdd.Parameters.AddWithValue("@P1", textBoxClubName.Text);
            sqlCommandAdd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kulüp eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridViewCellEventArgs e parametresi datagridin hücre görünümü olayları için çalışır.
            textBoxID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxClubName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommandDelete = new SqlCommand("UPDATE TBL_KULUP SET DURUM=0 WHERE ID=@D1", conn);
            sqlCommandDelete.Parameters.AddWithValue("@D1", textBoxID.Text);
            sqlCommandDelete.ExecuteNonQuery();
            conn.Close(); 
            textBoxID.Clear();
            textBoxClubName.Clear();
            MessageBox.Show("Kulüp kaldırıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void buttonPassiveClubs_Click(object sender, EventArgs e)
        {
            FormDeletedClubs formDeletedClubs = new FormDeletedClubs();
            formDeletedClubs.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommandUpdate = new SqlCommand("UPDATE TBL_KULUP SET AD=@P1 WHERE ID=@P2", conn);
            sqlCommandUpdate.Parameters.AddWithValue("@P1", textBoxClubName.Text);
            sqlCommandUpdate.Parameters.AddWithValue("@P2", textBoxID.Text);
            sqlCommandUpdate.ExecuteNonQuery();
            conn.Close();
            textBoxID.Clear();
            textBoxClubName.Clear();
            MessageBox.Show("Kulüp güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }
    }
}

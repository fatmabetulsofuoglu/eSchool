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
    public partial class FormStudentNotes : Form
    {
        public FormStudentNotes()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=DBOKUL;Integrated Security=True");
        public string studentName;

        private void FormStudentNotes_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT TBL_DERS.AD, SINAV1, SINAV2, SINAV3, ORTALAMA,PROJE, DURUM FROM TBL_NOT INNER JOIN TBL_DERS ON TBL_NOT.DERS = TBL_DERS.ID ", conn);
            SqlCommand sqlCommand2 = new SqlCommand("SELECT TBL_OGRENCİ.AD, TBL_OGRENCİ.SOYAD FROM TBL_NOT INNER JOIN TBL_OGRENCİ ON TBL_NOT.DERS = TBL_OGRENCİ.ID WHERE ID=@s1", conn);
            sqlCommand.Parameters.AddWithValue("@s1", studentName);
            this.Text = studentName.ToString();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

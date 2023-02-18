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

        private void FormStudentNotes_Load(object sender, EventArgs e)
        {

        }
    }
}

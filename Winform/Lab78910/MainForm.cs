using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab78910
{
    public partial class MainForm : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM OrderDetail", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            if (dataGridView.Rows.Count > 0)
            {
                //dataGridView.Rows[0].Selected = true;
                comboBoxAgent.DataSource = dt;
                comboBoxAgent.DisplayMember = "";
                comboBoxAgent.ValueMember = "";
                LoadData();
            }         
        }


        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void comboBoxAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM OrderDetail WHERE ID =" + comboBoxAgent.SelectedValue, conn);

                SqlDataAdapter adpater = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpater.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Data");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

    }
}

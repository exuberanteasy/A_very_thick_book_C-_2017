//如何使用 DataView物件來過濾資料
//18-6
//


using System.Data;
using System.Data.SqlClient;

namespace DataViewDemo_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataView dvScore;

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data source=(LocalDB)\MSSQLLocalDB;" +
                                      "AttachDbFilename=|DataDirectory|ch18DB.mdf;" +
                                      "Integrated Security=Trun";
                SqlDataAdapter daScore = new SqlDataAdapter("SELECT * FROM 成績單 ORDER BY 國文 DESC", cn);
                DataSet ds = new DataSet();
                daScore.Fill(ds, "成績單");
                dvScore = ds.Tables["成績單"].DefaultView;
            }
            dataGridView1.DataSource = dvScore;
            rdbChi.Checked = true;
            rdbDesc.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sortStr = "";
            if (rdbChi.Checked) sortStr += rdbChi.Text;
            if (rdbEng.Checked) sortStr += rdbEng.Text;
            if (rdbMath.Checked) sortStr += rdbMath.Text;
            if (rdbDesc.Checked) sortStr += "DESC";
            if (rdbAsc.Checked) sortStr += "ASC";
            dvScore.RowFilter = txtFilter.Text;
            dvScore.Sort = sortStr;
            dataGridView1.DataSource = dvScore;
        }
    }
}

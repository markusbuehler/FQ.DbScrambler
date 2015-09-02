using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FQ.DBScrambler.Logic;

namespace FQ.DbScrambler
{
    public partial class DbScrambler : Form
    {
        public string ConnectionString { get; set; }

        public DbScrambler()
        {
            InitializeComponent();
        }

        private void DbScrambler_Load(object sender, EventArgs e)
        {
            //var connectionString = "data source=.;initial catalog=GRCM_ERM;User Id=GRCM_Application;Password=pzNad07mz8Bw;";

            btnLoad.Enabled = false;
            btnGenerateScramblingSql.Enabled = false;
        }

        private void btnGenerateScramblingSql_Click(object sender, EventArgs e)
        {
            rtbScramlingSql.Clear();

            var selectedNodesInfo = GetCheckedNodes(tvDBStructure.Nodes);

            if (selectedNodesInfo.Count == 0)
            {
                MessageBox.Show(@"There are no selected columns to scramble", @"Warning", MessageBoxButtons.OK);
                return;
            }
            
            var sb = new StringBuilder();
            sb.AppendLine(Constants.SqlTemplates.PrepareSensitiveData);

            foreach (var node in selectedNodesInfo)
            {
                var nodeInfo = node.Split(new [] {" - "}, StringSplitOptions.None);
                if (nodeInfo.Length == 3)
                {
                    sb.AppendFormat(Constants.SqlTemplates.Insert, nodeInfo[0], nodeInfo[2], nodeInfo[1]);
                    sb.AppendLine();
                }
            }

            sb.AppendFormat(Constants.SqlTemplates.RemoveUnnecessaryData1, "GRCM_ERM");
            sb.AppendLine();

            foreach (TreeNode node in tvDBStructure.Nodes)
            {
                if (selectedNodesInfo.FirstOrDefault(x => GetTableName(x) == node.Text) != null && node.Nodes.Count > 0)
                {
                    sb.AppendFormat(Constants.SqlTemplates.Delete, node.Text);
                    sb.AppendLine();
                }
            }

            sb.AppendFormat(Constants.SqlTemplates.RemoveUnnecessaryData2, "GRCM_ERM");
            sb.AppendLine();

            sb.AppendFormat(Constants.SqlTemplates.ScrambleData);
            sb.AppendLine();
            
            rtbScramlingSql.Text = sb.ToString();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            ConnectionString = chbIntegratedAuthentication.Checked ? 
                string.Format("data source={0};initial catalog={1};Integrated Security=true;", string.IsNullOrEmpty(tbServer.Text) ? "." : tbServer.Text, tbDatabase.Text) : 
                string.Format("data source={0};initial catalog={1};User Id={2};Password={3};", string.IsNullOrEmpty(tbServer.Text) ? "." : tbServer.Text, tbDatabase.Text, tbUser.Text, tbPassword.Text);
            
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();

                MessageBox.Show(@"Database connection is successfull", @"Warning", MessageBoxButtons.OK);
                btnLoad.Enabled = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(@"Database connection failed", @"Warning", MessageBoxButtons.OK);
            }
            finally
            {
                if (conn != null) 
                    conn.Dispose();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                var tableTable = conn.GetSchema("Tables");
                var columnsTable = conn.GetSchema("Columns");

                tvDBStructure.Nodes.Clear();

                foreach (DataRow row in tableTable.Rows)
                {
                    if (!row["TABLE_NAME"].ToString().StartsWith("MSys"))
                    {
                        var tableName = string.Format("{0}.{1}", row["TABLE_SCHEMA"], row["TABLE_NAME"]);

                        var node = new TreeNode(tableName);
                        tvDBStructure.Nodes.Add(node);

                        foreach (DataRow columnRow in columnsTable.Rows)
                        {
                            var key = string.Format("{0}.{1}", columnRow["TABLE_SCHEMA"], columnRow["TABLE_NAME"]);
                            if (key.Equals(tableName))
                                node.Nodes.Add(string.Format("{0} - {1}", columnRow["COLUMN_NAME"], columnRow["DATA_TYPE"]));
                        }
                    }
                }

                tvDBStructure.CollapseAll();
                btnGenerateScramblingSql.Enabled = true;
                conn.Close();
            }
        }

        private void chbIntegratedAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            tbUser.Enabled = !chbIntegratedAuthentication.Checked;
            tbPassword.Enabled = !chbIntegratedAuthentication.Checked;
        }

        #region Helpers

        private List<string> GetCheckedNodes(TreeNodeCollection nodes)
        {
            var result = new List<string>();

            if (nodes != null)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Checked)
                        result.Add(string.Format("{0} - {1}", node.Text, node.Parent.Text));

                    result.AddRange(GetCheckedNodes(node.Nodes));
                }
            }

            return result;
        }

        private string GetTableName(string nodeText)
        {
            var nodeInfo = nodeText.Split(new[] { " - " }, StringSplitOptions.None);
            return nodeInfo.Length == 3 ? nodeInfo[2] : string.Empty;
        }

        #endregion
    }
}

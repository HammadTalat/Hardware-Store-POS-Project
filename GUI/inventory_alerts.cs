﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chaudhary_Brothers
{
    public partial class inventory_alerts : Form
    {
        public inventory_alerts()
        {
            InitializeComponent();
            LoadProductsIntoGrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inventory_pic_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_label_Click(object sender, EventArgs e)
        {

        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logout_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            inventory inventory = new inventory();
            this.Hide();
            inventory.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            inventory inventory = new inventory();
            this.Hide();
            inventory.Show();
        }

        private void inventory_pic_Click_1(object sender, EventArgs e)
        {
            owner owner = new owner();
            this.Hide();
            owner.Show();
        }

        private void dashboard_label_Click_1(object sender, EventArgs e)
        {
            owner_dashboard dashboard = new owner_dashboard();
            this.Hide();
            dashboard.Show();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            owner_dashboard dashboard = new owner_dashboard();
            this.Hide();
            dashboard.Show();
        }

        private void username_Click_1(object sender, EventArgs e)
        {
            owner owner = new owner();
            this.Hide();
            owner.Show();
        }

        private void logout_panel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void logout_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You sure you want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                @enum obj2 = new @enum();
                obj2.end();
                this.Close();
                Form1 obj = new Form1();
                obj.Show();
            }
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You sure you want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                @enum obj2 = new @enum();
                obj2.end();
                this.Close();
                Form1 obj = new Form1();
                obj.Show();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async Task<DataTable> FetchProductsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string url = "http://localhost:8080/getInventoryAlerts"; // Adjust as necessary
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonResponse);
                    return ConvertToDataTable(products);
                }
                else
                {
                    throw new Exception("Failed to retrieve products");
                }
            }
        }
        private DataTable ConvertToDataTable(List<Dictionary<string, object>> items)
        {
            var dt = new DataTable();
            if (items.Count == 0) return dt;

            // Add columns dynamically based on the first element
            foreach (var key in items[0].Keys)
            {
                dt.Columns.Add(key);
            }

            // Add rows
            foreach (var item in items)
            {
                var row = dt.NewRow();
                foreach (var key in item.Keys)
                {
                    row[key] = item[key] ?? DBNull.Value;
                }

                dt.Rows.Add(row);
            }

            return dt;
        }
        private async void LoadProductsIntoGrid()
        {
            DataTable productsTable = await FetchProductsAsync();
            dataGridView1.Rows.Clear();

            foreach (DataRow row in productsTable.Rows)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["Name1"].Value = row["product_id"];
                dataGridView1.Rows[rowIndex].Cells["Company_Name"].Value = row["name"];
                dataGridView1.Rows[rowIndex].Cells["Quantity"].Value = row["unit_quantity"];

            }
        }

    }
}

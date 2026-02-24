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

namespace ExemploWinClient
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient s_httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:7189/") // ensure matches server
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            ExibirDadosAsync();
        }
     
        private async Task ExibirDadosAsync()
        {
            try
            {
                var response = await s_httpClient.GetAsync("api/ContaService");
                response.EnsureSuccessStatusCode();
                var contas = await response.Content.ReadAsAsync<List<ContaListItem>>();
                dataGridView1.DataSource = contas;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Unable to reach API: {ex.Message}");
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

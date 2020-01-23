using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormQuinox.Model;

namespace WinFormQuinox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidateImput()
        {
            int i = 0;
            if (txtYear.Text.Trim().Length > 0)
            {
                return int.TryParse(txtYear.Text.Trim(), out i);
            }
            return true;

        }

        private string QueryBuilderMovie()
        {

            string query = ConfigurationSettings.AppSettings["baseAddress"] + "Movies?";
            if (txtTitle.Text.Length > 0)
                query += $"t={txtTitle.Text.Trim()}&";
            if (txtYear.Text.Length > 0)
                query += $"year={txtYear.Text.Trim()}&";
            if (cmbPlot.SelectedIndex > 0)
                query += $"plot={cmbPlot.SelectedValue}&";

            query = query.Substring(0, query.Length - 1);
            return query;

        }

        private string QueryBuilderMoviesList()
        {

            string query = ConfigurationSettings.AppSettings["baseAddress"] + "Movies?";
            if (txtTitle.Text.Length > 0)
                query += $"s={txtTitle.Text.Trim()}&";
            if (txtYear.Text.Length > 0)
                query += $"year={txtYear.Text.Trim()}&";
            if (cmbPlot.SelectedIndex > 0)
                query += $"plot={cmbPlot.SelectedValue}&";

            query = query.Substring(0, query.Length - 1);
            return query;

        }
        private void PopulateDataGridView()
        {
            HttpClient _httpClient = new HttpClient();
            try
            {
                string apiUrl = QueryBuilderMoviesList();// "https://localhost:44330/api/Movies?s=batman&plot=short&year=1998";
                var response = _httpClient.GetStringAsync(apiUrl).Result;

                var result = JsonConvert.DeserializeObject<MovieSearch>(response, new JsonSerializerSettings
                {
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                    DateParseHandling = DateParseHandling.None,
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        var currentError = args.ErrorContext.Error.Message;
                        args.ErrorContext.Handled = true;
                    }
                });

                dgvMoviesList.DataSource = result.Search;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An error has ocurred");
            }
            finally
            {
                _httpClient.Dispose();
            }
      
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                MessageBox.Show("Year is not valid");
                return;
            }
            PopulateDataGridView();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace AppLTI
{
    public partial class loginForm : Form
    {
        private List<Router> credentials;

        string baseURI = @"http://localhost:11755";
        RestClient restClient = null;
        public loginForm()
        {
            InitializeComponent();
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

            var request = new RestRequest("/api/credentials", Method.Get);
            request.RequestFormat = DataFormat.Json;

            restClient = new RestClient(baseURI);

            //popular a dropdown com os 10 ip's mais recentes
            listCredentials();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login(textBoxRouterIP.Text, textBoxUsername.Text, textBoxPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private async void Login(string routerIp, string username, string password)
        {
            if (routerIp == "" || username == "" || password == "")
            {
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);
                HttpResponseMessage response = await client.GetAsync($"http://{routerIp}/rest/system/resource");

                if (response.IsSuccessStatusCode)
                {

                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(responseBody);
                    string boardName = (string)jsonObject["board-name"];
                    string platform = (string)jsonObject["platform"];

                    bool flag = checkBoxGuardarPassword.Checked;

                    Router credential = new Router
                    {
                        Ip = routerIp,
                        Username = username,
                        Password = flag ? Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password)) : null,
                        Model = platform + " - " + boardName
                    };

                    var request = new RestRequest("api/credentials", Method.Post);
                    request.RequestFormat = DataFormat.Json;
                    request.AddObject(credential);

                    var responseRequest = restClient.Execute(request);

                    if (responseRequest.StatusCode != HttpStatusCode.OK)
                    {
                        MessageBox.Show("Erro Interno - Login Falhou.");
                        return;
                    }

                    // store credenciais na db

                    mainPage mainPageForm = new mainPage();
                    checkBoxGuardarPassword.Checked = false;
                    clearTextBoxes();
                    mainPageForm.SetCredentials(routerIp, username, password, credential.Model);
                    mainPageForm.Show();
                    MessageBox.Show("Login efetuado com sucesso!");
                    listCredentials();
                }
                else
                {
                    MessageBox.Show("Login falhou, verifica as Credenciais e tenta de novo.");

                }
            }

        }

        private void buttonSeePassword_Click(object sender, EventArgs e)
        {

            if (textBoxPassword.PasswordChar == '•')
            {
                buttonHidePassword.BringToFront();
                textBoxPassword.PasswordChar = '\0';
            }
        }

        private void buttonHidePassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.PasswordChar == '\0')
            {
                buttonSeePassword.BringToFront();
                textBoxPassword.PasswordChar = '•';
            }
        }

        private void listCredentials()
        {
            var requestCredentials = new RestRequest("api/credentials", Method.Get);
            requestCredentials.RequestFormat = DataFormat.Json;
            requestCredentials.AddHeader("Accept", "application/json");

            var responseCredentials = restClient.Execute(requestCredentials);

            if (responseCredentials.IsSuccessful)
            {
                comboBoxRoutersIP.Items.Clear();

                credentials = JsonConvert.DeserializeObject<List<Router>>(responseCredentials.Content);

                foreach (var router in credentials)
                {
                    comboBoxRoutersIP.Items.Add(router.Username + " - " + router.Ip + " (" + router.Id + ")");
                }
            }
        }

        private void comboBoxRoutersIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBoxRoutersIP.SelectedItem.ToString();

            if (selectedItem == "")
            {
                clearTextBoxes();
                return;
            }

            Router selectedRouter = credentials.FirstOrDefault(r => r.Username + " - " + r.Ip + " (" + r.Id + ")" == selectedItem);

            if (selectedRouter != null)
            {
                //textBoxRouterIP.Text = selectedRouter.Ip;
                textBoxRouterIP.Text = selectedRouter.Ip;
                textBoxUsername.Text = selectedRouter.Username;
                textBoxPassword.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(selectedRouter.Password));
            }
        }

        private void clearTextBoxes()
        {
            textBoxRouterIP.Clear();
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }

    }
}

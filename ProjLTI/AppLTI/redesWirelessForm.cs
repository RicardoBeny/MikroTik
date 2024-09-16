using Newtonsoft.Json.Linq;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AppLTI
{
    public partial class redesWirelessForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private Timer timer;

        public redesWirelessForm()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await GetAndDisplayRouterStatus(routerIp);
        }

        private async Task GetAndDisplayRouterStatus(string routerIp)
        {
            try
            {
                string resourceUrl = $"http://{routerIp}/rest/system/resource";
                string clockUrl = $"http://{routerIp}/rest/system/clock?.proplist=time";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage resourceResponse = await client.GetAsync(resourceUrl);
                    resourceResponse.EnsureSuccessStatusCode();

                    string resourceBody = await resourceResponse.Content.ReadAsStringAsync();
                    JObject resourceStatus = JObject.Parse(resourceBody);

                    string cpuLoad = resourceStatus["cpu-load"].ToString();
                    string freeMemoryBytes = resourceStatus["free-memory"].ToString();
                    double freeMemoryMB = Convert.ToDouble(freeMemoryBytes) / (1024 * 1024);
                    string totalMemoryBytes = resourceStatus["total-memory"].ToString();
                    double totalMemoryMB = Convert.ToDouble(totalMemoryBytes) / (1024 * 1024);
                    string totalHddSpaceBytes = resourceStatus["total-hdd-space"].ToString();
                    double totalHddSpaceMB = Convert.ToDouble(totalHddSpaceBytes) / (1024 * 1024);
                    string freeHddSpaceBytes = resourceStatus["free-hdd-space"].ToString();
                    double freeHddSpaceMB = Convert.ToDouble(freeHddSpaceBytes) / (1024 * 1024);
                    string uptime = resourceStatus["uptime"].ToString();
                    string version = resourceStatus["version"].ToString();

                    HttpResponseMessage clockResponse = await client.GetAsync(clockUrl);
                    clockResponse.EnsureSuccessStatusCode();

                    string clockBody = await clockResponse.Content.ReadAsStringAsync();
                    JObject clockData = JObject.Parse(clockBody);

                    string time = clockData["time"].ToString();

                    textBoxStatus.Text = $"CPU: {cpuLoad}%" + "   " +
                                         $"Memória Livre: {freeMemoryMB:F2} MB" + "   " +
                                         $"Memória Total: {totalMemoryMB:F2} MB" + "   " +
                                         $"Espaço Total do HDD: {totalHddSpaceMB:F2} MB" + "   " +
                                         $"Espaço Livre do HDD: {freeHddSpaceMB:F2} MB" + "   " +
                                         $"Uptime: {uptime}" + "   " +
                                         $"Versão: {version}" + "   " +
                                         $"Hora: {time}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro a verificar o status: {ex.Message}");
            }
        }

        private async Task LoadPerfis()
        {
            try
            {
                comboBoxPerfilAssociado.Items.Clear();
                listBoxPerfisSeguranca.Items.Clear();
                string url = $"http://{routerIp}/rest/interface/wireless/security-profiles";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxRedesWireless.Items.Add("Não foram encontrados perfis de segurança");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string tipo_autenticação = routeObject.Value<string>("authentication-types");
                            string mode = routeObject.Value<string>("mode");
                            string name = routeObject.Value<string>("name");

                            comboBoxPerfilAssociado.Items.Add($"ID: {id}; Nome: {name}; Mode: {mode}; Tipo de autenticação: {tipo_autenticação}");
                            listBoxPerfisSeguranca.Items.Add($"ID: {id}; Nome: {name}; Mode: {mode}; Tipo de autenticação: {tipo_autenticação}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os perfis de segurança. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os perfis: " + ex.Message);
            }
        }

        private async Task LoadRedes()
        {
            try
            {
                textBoxSSID.Clear();
                textBoxEditNome.Clear();
                comboBoxADRede.Items.Clear();
                comboBoxSelectInterface.Items.Clear();
                listBoxRedesWireless.Items.Clear();
                string url = $"http://{routerIp}/rest/interface/wireless";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxRedesWireless.Items.Add("Não foram encontradas redes wireless");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string name = routeObject.Value<string>("name");
                            string ssid = routeObject.Value<string>("ssid");
                            string perfil = routeObject.Value<string>("security-profile");
                            string desativo = routeObject.Value<string>("disabled");

                            string status = (desativo == "true") ? "Desativado" : "Ativo";

                            comboBoxADRede.Items.Add($"ID: {id}; Nome: {name}; SSID: {ssid}; Perfil Associado: {perfil}; Status: {status}");
                            comboBoxSelectInterface.Items.Add($"ID: {id}; Nome: {name}; SSID: {ssid}; Perfil Associado: {perfil}; Status: {status}");
                            listBoxRedesWireless.Items.Add($"ID: {id}; Nome: {name}; SSID: {ssid}; Perfil Associado: {perfil}; Status: {status}");

                        }
                        await LoadPerfis();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as redes Wireless. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as redes Wireless: " + ex.Message);
            }
        }

        public void SetCredentials(string routerIp, string username, string password, string model)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.model = model;
        }

        private void buttonPerfisGo_Click(object sender, EventArgs e)
        {
            perfilSegurançaForm perfilSegurançaForm = new perfilSegurançaForm();
            perfilSegurançaForm.SetCredentials(routerIp, username, password, model);
            perfilSegurançaForm.Show();
            this.Dispose();
        }

        private async void buttonAtualizarPerfis_Click(object sender, EventArgs e)
        {
            await LoadPerfis();
        }

        private async void btnListInterface_Click(object sender, EventArgs e)
        {
            await LoadRedes();
        }

        private async void buttonDesativar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxADRede.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma rede para desativar.");
                    return;
                }

                string selectedItemText = comboBoxADRede.Items[comboBoxADRede.SelectedIndex].ToString();
                string routeId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                string disabled = "true";

                var requestBody = new JObject();
                requestBody[".id"] = routeId;
                requestBody["disabled"] = disabled;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireless/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Rede desativada com sucesso.");
                        await LoadRedes();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao desativar a rede. Mensagem de erro: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao desativar a rede: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxADRede.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma rede para ativar.");
                    return;
                }

                string selectedItemText = comboBoxADRede.Items[comboBoxADRede.SelectedIndex].ToString();
                string routeId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                string disabled = "false";

                var requestBody = new JObject();
                requestBody[".id"] = routeId;
                requestBody["disabled"] = disabled;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireless/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Rede ativada com sucesso.");
                        await LoadRedes();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao ativar a rede. Mensagem de erro: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao ativar a rede: " + ex.Message);
            }
        }

        private async void btnEditInterface_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectInterface.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma rede para editar.");
                    return;
                }
                string selectedItemText = comboBoxPerfilAssociado.Items[comboBoxPerfilAssociado.SelectedIndex].ToString();
                string newprofileName = selectedItemText.Substring(selectedItemText.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                string selectedItemText1 = comboBoxSelectInterface.Items[comboBoxSelectInterface.SelectedIndex].ToString();
                string wirelessId = selectedItemText1.Substring(selectedItemText1.IndexOf("ID:") + 3).Split(';')[0].Trim();

                string newname = textBoxEditNome.Text.Trim();
                string ssid = textBoxSSID.Text.Trim();

                var requestBody = new JObject();
                requestBody[".id"] = wirelessId;
                requestBody["name"] = newname;
                requestBody["ssid"] = ssid;
                requestBody["security-profile"] = newprofileName;
                requestBody["comment"] = textBoxComentario.Text;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireless/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Rede configurada com sucesso.");
                        textBoxEditNome.Clear();
                        textBoxSSID.Clear();
                        textBoxComentario.Clear();
                        comboBoxPerfilAssociado.SelectedIndex = -1;
                        await LoadRedes();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao configurar a rede. Mensagem de erro: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao configurar a rede: " + ex.Message);
            }
        }

        private void redesWirelessForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxSSID.Clear();
                textBoxEditNome.Clear();

                string url = $"http://{routerIp}/rest/interface/wireless";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectInterface.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione uma rede wireless editar");
                    }

                    string selectedItemText = comboBoxSelectInterface.Items[comboBoxSelectInterface.SelectedIndex].ToString();
                    string endIPId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxRedesWireless.Items.Add("Não foram encontradas redes Wireless");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (endIPId == id)
                            {
                                string name = routeObject.Value<string>("name");
                                string ssid = routeObject.Value<string>("ssid");
                                string perfilseguranca = routeObject.Value<string>("security-profile");
                                textBoxSSID.Text = ssid;
                                textBoxEditNome.Text = name;

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxComentario.Text = comentario;
                                }

                                foreach (var item in comboBoxPerfilAssociado.Items)
                                {
                                    string selectedItemText1 = item.ToString();
                                    string perfilName = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                                    if (perfilName == perfilseguranca)
                                    {
                                        comboBoxPerfilAssociado.SelectedItem = item;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar perfil de segurança. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar o perfil de segurança: " + ex.Message);
            }
        }

        private async void comboBoxSelectInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadEdit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mainPage mainPage = new mainPage();
            mainPage.SetCredentials(routerIp, username, password, model);
            mainPage.Show();
            this.Dispose();
        }
    }
}

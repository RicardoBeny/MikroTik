using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AppLTI
{
    public partial class rotas_Form : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private Timer timer;

        public rotas_Form()
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

        public void SetCredentials(string routerIp, string username, string password, string model)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.model = model;
        }

        private async Task LoadRotas()
        {
            try
            {
                checkBoxEditDesativa.Checked = false;
                checkBoxEditAtiva.Checked = false;
                textBoxEditEndDestino.Clear();
                textBoxEditGateway.Clear();
                listBoxRotas.Items.Clear();
                comboBoxSelectRotas.Items.Clear();
                comboBoxElimRota.Items.Clear();

                string url = $"http://{routerIp}/rest/ip/route";

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
                            listBoxRotas.Items.Add("Não foram encontradas rotas");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string dstAddress = routeObject.Value<string>("dst-address");
                            string gateway = routeObject.Value<string>("gateway");
                            string dinamico = routeObject.Value<string>("dynamic");
                            string estatico = routeObject.Value<string>("static");
                            listBoxRotas.Items.Add($"ID: {id}; Endereço de destino: {dstAddress}; Gateway: {gateway}");
                            comboBoxElimRota.Items.Add($"ID: {id}; Endereço de destino: {dstAddress}; Gateway: {gateway}");

                            if (routeObject.ContainsKey("dynamic"))
                            {
                                if (dinamico == "false")
                                {
                                    comboBoxSelectRotas.Items.Add($"ID: {id}; Endereço de destino: {dstAddress}; Gateway: {gateway}");
                                }
                            }
                            else if (routeObject.ContainsKey("static"))
                            {
                                if (estatico == "true")
                                {
                                    comboBoxSelectRotas.Items.Add($"ID: {id}; Endereço de destino: {dstAddress}; Gateway: {gateway}");
                                }
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as rotas. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as rotas: " + ex.Message);
            }
        }

        private async void btnAddRota_Click(object sender, EventArgs e)
        {
            try
            {
                string dstAddress = textBoxDestAddress.Text.Trim();
                string gateway = textBoxGateway.Text.Trim();

                if (string.IsNullOrWhiteSpace(dstAddress))
                {
                    MessageBox.Show("O endereço de destino não pode estar vazio.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(gateway))
                {
                    MessageBox.Show("O campo gateway não pode estar vazio.");
                    return;
                }

                var requestBody = new JObject();
                requestBody["dst-address"] = dstAddress;
                requestBody["gateway"] = gateway;

                if (checkBoxNão.Checked && !checkBoxSim.Checked)
                {
                    requestBody["disabled"] = true;
                }
                else if (checkBoxSim.Checked && !checkBoxNão.Checked)
                {
                    requestBody["disabled"] = false;
                }
                else if (checkBoxNão.Checked && checkBoxSim.Checked)
                {
                    MessageBox.Show("Selecione apenas uma opção do campo Ativa.");
                    return ;
                }
                else
                {
                    MessageBox.Show("Selecione uma das opções do campo Ativa.");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/route/add";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Rota adicionada com sucesso.");
                        textBoxDestAddress.Clear();
                        textBoxGateway.Clear();
                        checkBoxSim.Checked = false;
                        checkBoxNão.Checked = false;
                        await LoadRotas();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao adicionar a rota. Erro: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar a rota: " + ex.Message);
            }
        }

        private async void btnEditRota_Click(object sender, EventArgs e)
        {
            try { 
                if (comboBoxSelectRotas.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma interface para editar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditEndDestino.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo 'Endereço Destino' para editar a rota.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditGateway.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo 'Gateway' para editar a rota.");
                    return;
                }

                if (checkBoxEditAtiva.Checked && checkBoxEditDesativa.Checked)
                {
                    MessageBox.Show("Selecione apenas uma opção do campo Estado da rota.");
                    return;
                }
                else if (!checkBoxEditAtiva.Checked && !checkBoxEditDesativa.Checked)
                {
                    MessageBox.Show("Selecione pelo menos uma opção do campo Estado da rota.");
                    return;
                }

                string selectedItemText = comboBoxSelectRotas.Items[comboBoxSelectRotas.SelectedIndex].ToString();
                string routeId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();
                string dstAddress = textBoxEditEndDestino.Text.Trim();
                string gateway = textBoxEditGateway.Text.Trim();
                bool disabled = false;

                if (checkBoxEditAtiva.Checked)
                {
                    disabled = false;
                }
                else if (checkBoxEditDesativa.Checked)
                {
                    disabled = true;
                }

                var requestBody = new JObject();
                requestBody[".id"] = routeId;
                requestBody["dst-address"] = dstAddress;
                requestBody["gateway"] = gateway;
                requestBody["disabled"] = disabled;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/route/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Rota editada com sucesso.");
                        textBoxEditEndDestino.Clear();
                        textBoxEditGateway.Clear();
                        checkBoxEditAtiva.Checked=false;
                        checkBoxEditDesativa.Checked = false;
                        await LoadRotas();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao editar a rota. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar a rota: " + ex.Message);
            }
        }

        private async void btnDeleteRotas_Click(object sender, EventArgs e)
        {
            try { 
                if (comboBoxElimRota.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma interface para eliminar.");
                    return;
                }

                string selectedItemText = comboBoxElimRota.Items[comboBoxElimRota.SelectedIndex].ToString();
                string routeId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody[".id"] = routeId;
                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/route/remove";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Rota eliminada com sucesso.");
                        await LoadRotas();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar a rota. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar a rota: " + ex.Message);
            }
        }

        private async void btnLoadRotas_Click(object sender, EventArgs e)
        {
            await LoadRotas();
        }

        private void rotas_Form_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxEditEndDestino.Clear();
                textBoxEditGateway.Clear();

                string url = $"http://{routerIp}/rest/ip/route";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectRotas.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione uma rota a editar");
                    }

                    string selectedItemText = comboBoxSelectRotas.Items[comboBoxSelectRotas.SelectedIndex].ToString();
                    string rotaId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxRotas.Items.Add("Não foram encontradas rotas");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (rotaId == id)
                            {
                                string destino = routeObject.Value<string>("dst-address");
                                string gateway = routeObject.Value<string>("gateway");
                                string desativo = routeObject.Value<string>("disabled");
                                textBoxEditEndDestino.Text = destino;
                                textBoxEditGateway.Text = gateway;

                                if (desativo == "false")
                                {
                                    checkBoxEditAtiva.Checked = true;
                                    checkBoxEditDesativa.Checked = false;
                                }
                                else
                                {
                                    checkBoxEditAtiva.Checked = false;
                                    checkBoxEditDesativa.Checked = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as rotas. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as rotas: " + ex.Message);
            }
        }

        private async void comboBoxSelectRotas_SelectedIndexChanged(object sender, EventArgs e)
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

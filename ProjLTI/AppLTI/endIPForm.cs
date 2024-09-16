using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AppLTI
{
    public partial class endIPForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private Timer timer;

        public endIPForm()
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

        private async Task LoadIPs()
        {
            try
            {
                checkBoxEditDesativa.Checked = false;
                checkBoxEditAtiva.Checked = false;
                checkBoxSim.Checked = false;
                checkBoxNão.Checked = false;
                textBoxEndIP.Clear();
                textBoxNetwork.Clear();
                listBoxEnderecosIP.Items.Clear();
                comboBoxInterfaces.Items.Clear();
                comboBoxElimIP.Items.Clear();
                comboBoxSelectIP.Items.Clear();
                textBoxComentEdit.Clear();
                textBoxEditIPAddress.Clear();
                textBoxEditNetwork.Clear();
                comboBoxEditInterface.Items.Clear();

                string url = $"http://{routerIp}/rest/ip/address";

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
                            listBoxEnderecosIP.Items.Add("Não foram encontrados endereços IP");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string iPAddress = routeObject.Value<string>("address");
                            string network = routeObject.Value<string>("network");
                            string interfaceR = routeObject.Value<string>("interface");
                            string desativada = routeObject.Value<string>("disabled");

                            listBoxEnderecosIP.Items.Add($"ID: {id}; Endereço IP: {iPAddress}; Network: {network}; Interface: {interfaceR}; Desativada: {desativada}");
                            comboBoxSelectIP.Items.Add($"ID: {id}; Endereço IP: {iPAddress}; Network: {network}; Interface: {interfaceR}; Desativada: {desativada}");
                            comboBoxElimIP.Items.Add($"ID: {id}; Endereço IP: {iPAddress}; Network: {network}; Interface: {interfaceR}; Desativada: {desativada}");
                        }
                        await UpdateBridgeInterfaces();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar endereços IP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar endereços IP: " + ex.Message);
            }
        }

        private async Task UpdateBridgeInterfaces()
        {
            try
            {
                listBoxInterfaces.Items.Clear();
                comboBoxInterfaces.Items.Clear();
                comboBoxEditInterface.Items.Clear();
                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync($"http://{routerIp}/rest/interface");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxInterfaces.Items.Add("Não foram encontradas interfaces");
                            return;
                        }

                        JArray interfacesArray = JArray.Parse(responseBody);
                        foreach (JObject interfaceObject in interfacesArray)
                        {
                            string id = interfaceObject.Value<string>(".id");
                            string name = interfaceObject.Value<string>("name");
                            string macAddress = interfaceObject.Value<string>("mac-address");
                            listBoxInterfaces.Items.Add($"ID:{id}; Nome:{name}; Mac-Address({macAddress})");
                            comboBoxInterfaces.Items.Add($"ID:{id}; Nome:{name}; Mac-Address({macAddress})");
                            comboBoxEditInterface.Items.Add($"ID:{id}; Nome:{name}; Mac-Address({macAddress})");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar interfaces. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar interfaces: " + ex.Message);
            }
        }

        private async void btnAddEndIP_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxInterfaces.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma interface para associar.");
                    return;
                }
                string selectedItem = comboBoxInterfaces.SelectedItem.ToString();
                string intId = selectedItem.Split(';')[0].Trim().Substring(3);

                string endIP = textBoxEndIP.Text.Trim();
                string network = textBoxNetwork.Text.Trim();

                if (string.IsNullOrWhiteSpace(endIP))
                {
                    MessageBox.Show("O endereço de destino não pode estar vazio.");
                    return;
                }

                var requestBody = new JObject();
                requestBody["address"] = endIP;
                requestBody["interface"] = intId;

                if (!string.IsNullOrWhiteSpace(textBoxComentarioAdd.Text))
                {
                    requestBody["comment"] = textBoxComentarioAdd.Text;
                }

                if (!string.IsNullOrWhiteSpace(network))
                {
                    requestBody["network"] = network;
                }

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
                    MessageBox.Show("Selecione apenas uma opção.");
                    return;
                }
                else
                {
                    MessageBox.Show("Selecione uma das opções.");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/address/add";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Endereço IP adicionado com sucesso.");
                        await LoadIPs();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar o endereço IP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar endereço IP: " + ex.Message);
            }
        }

        private async void btnLoadIP_Click(object sender, EventArgs e)
        {
            await LoadIPs();
        }

        private async void btnAtualizarInt_Click(object sender, EventArgs e)
        {
            await UpdateBridgeInterfaces();
        }

        private async void btnDeleteRotas_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxElimIP.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma interface para excluir.");
                    return;
                }

                string selectedItem = comboBoxElimIP.SelectedItem.ToString();
                string ipAdddpress = selectedItem.Split(';')[0].Trim().Substring(3);

                JObject interfaceData = new JObject();
                interfaceData[".id"] = ipAdddpress;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/address/remove";
                    var content = new StringContent(interfaceData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Endereço IP removido com sucesso!");
                        await LoadIPs();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao remover o endereço IP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao remover o endereço IP: " + ex.Message);
            }
        }

        private async void btnEditEndIP_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectIP.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um endereço para editar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditIPAddress.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo 'Endereço IP' para editar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditNetwork.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo 'Network' para editar.");
                    return;
                }

                string selectedItem = comboBoxSelectIP.SelectedItem.ToString();
                string endereçoIPid = selectedItem.Split(';')[0].Trim().Substring(3);

                string selectedItem1 = comboBoxEditInterface.SelectedItem.ToString();
                string interfaceId = selectedItem1.Split(';')[0].Trim().Substring(3);

                string newIPaddress = textBoxEditIPAddress.Text.Trim();
                string newNetwork = textBoxEditNetwork.Text.Trim();

                bool disabled;
                if (checkBoxEditDesativa.Checked && checkBoxEditAtiva.Checked)
                {
                    MessageBox.Show("Erro: Ambos desativado e ativado selecionados.");
                    return;
                }
                else if (checkBoxEditDesativa.Checked)
                {
                    disabled = true;
                }
                else if (checkBoxEditAtiva.Checked)
                {
                    disabled = false;
                }
                else
                {
                    MessageBox.Show("Por favor, selecione 'Desativado' ou 'Ativado'.");
                    return;
                }

                JObject interfaceData = new JObject();
                interfaceData[".id"] = endereçoIPid;
                interfaceData["address"] = newIPaddress;
                interfaceData["network"] = newNetwork;
                interfaceData["disabled"] = disabled;
                interfaceData["interface"] = interfaceId;
                interfaceData["comment"] = textBoxComentEdit.Text;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/address/set";
                    var content = new StringContent(interfaceData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Endereço IP editado com sucesso!");
                        comboBoxEditInterface.SelectedIndex = -1;
                        await LoadIPs();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao editar o endereço IP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar o endereço IP: " + ex.Message);
            }
        }

        private void endIPForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxEditIPAddress.Clear();
                textBoxEditNetwork.Clear();
                textBoxComentEdit.Clear();
                checkBoxEditAtiva.Checked = false;
                checkBoxEditDesativa.Checked = false;

                string url = $"http://{routerIp}/rest/ip/address";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectIP.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione um endereço IP para editar");
                    }

                    string selectedItemText = comboBoxSelectIP.Items[comboBoxSelectIP.SelectedIndex].ToString();
                    string endIPId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxEnderecosIP.Items.Add("Não foram encontrados endereços IP");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (endIPId == id)
                            {
                                string address = routeObject.Value<string>("address");
                                string network = routeObject.Value<string>("network");
                                string desativo = routeObject.Value<string>("disabled");
                                string interfacea = routeObject.Value<string>("interface");

                                textBoxEditIPAddress.Text = address;
                                textBoxEditNetwork.Text = network;

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxComentEdit.Text = comentario;
                                }

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

                                foreach (var item in comboBoxEditInterface.Items)
                                {
                                    string selectedItemText1 = item.ToString();
                                    string interfaceName = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                                    if (interfaceName == interfacea)
                                    {
                                        comboBoxEditInterface.SelectedItem = item;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar endereços IP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os endereços IP: " + ex.Message);
            }
        }

        private async void comboBoxSelectIP_SelectedIndexChanged(object sender, EventArgs e)
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

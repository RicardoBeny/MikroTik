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

namespace AppLTI
{
    public partial class portsForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private Timer timer;

        public portsForm()
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

        private async Task UpdateBridgeInterfaces()
        {
            try
            {
                comboBoxBridgeEdit.Items.Clear();
                comboBoxBridgeAdd.Items.Clear();

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync($"http://{routerIp}/rest/interface/bridge");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        JArray interfacesArray = JArray.Parse(responseBody);
                        foreach (JObject interfaceObject in interfacesArray)
                        {
                            string name = interfaceObject.Value<string>("name");
                            comboBoxBridgeEdit.Items.Add($"{name}");
                            comboBoxBridgeAdd.Items.Add($"{name}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as interfaces bridge. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as interfaces bridge: " + ex.Message);
            }
        }

        private async Task UpdateInterfaces()
        {
            try
            {
                comboBoxInterfaceAdd.Items.Clear();
                comboBoxInterfaceEdit.Items.Clear();

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync($"http://{routerIp}/rest/interface");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        JArray interfacesArray = JArray.Parse(responseBody);
                        foreach (JObject interfaceObject in interfacesArray)
                        {
                            string type = interfaceObject.Value<string>("type");
                            if (type == "wlan" || type == "ether")
                            {
                                string name = interfaceObject.Value<string>("name");
                                comboBoxInterfaceAdd.Items.Add($"{name}");
                                comboBoxInterfaceEdit.Items.Add($"{name}");
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as interfaces bridge. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as interfaces bridge: " + ex.Message);
            }
        }

        private async Task LoadPorts()
        {
            try
            {
                await UpdateBridgeInterfaces();
                await UpdateInterfaces();

                comboBoxSelectPortos.Items.Clear();
                comboBoxElimPorto.Items.Clear();
                listBoxPortos.Items.Clear();

                string url = $"http://{routerIp}/rest/interface/bridge/port";

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
                            listBoxPortos.Items.Add("Não foram encontrados portos");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string bridge = routeObject.Value<string>("bridge");
                            string interfaceFisica = routeObject.Value<string>("interface");
                            string desativado = routeObject.Value<string>("disabled");

                            comboBoxSelectPortos.Items.Add($"ID: {id}; Bridge: {bridge}; Interface: {interfaceFisica}; Desativado: {desativado}");
                            comboBoxElimPorto.Items.Add($"ID: {id}; Bridge: {bridge}; Interface: {interfaceFisica}; Desativado: {desativado}");
                            listBoxPortos.Items.Add($"ID: {id}; Bridge: {bridge}; Interface: {interfaceFisica}; Desativado: {desativado}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar as portos. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os portos: " + ex.Message);
            }
        }

        public void SetCredentials(string routerIp, string username, string password, string model)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.model = model;
        }

        private async void btnListBridge_Click(object sender, EventArgs e)
        {
            await LoadPorts();
        }

        private async void btnAddPort_Click(object sender, EventArgs e)
        {
            try
            {
                string comentario = textBoxCommentarioAdd.Text.Trim();

                var requestBody = new JObject();

                if (!string.IsNullOrWhiteSpace(comentario))
                {
                    requestBody["comment"] = comentario;
                }

                if (comboBoxInterfaceAdd.SelectedIndex == -1)
                {
                    MessageBox.Show("Interface tem de ser preenchida.");
                    return;
                }

                if (comboBoxBridgeAdd.SelectedIndex == -1)
                {
                    MessageBox.Show("Bridge tem de ser preenchida.");
                    return;
                }

                requestBody["interface"] = comboBoxInterfaceAdd.SelectedItem.ToString();
                requestBody["bridge"] = comboBoxBridgeAdd.SelectedItem.ToString();

                if (checkBoxAddDesativo.Checked && !checkBoxAddAtivo.Checked)
                {
                    requestBody["disabled"] = true;
                }
                else if (checkBoxAddAtivo.Checked && !checkBoxAddDesativo.Checked)
                {
                    requestBody["disabled"] = false;
                }
                else if (checkBoxAddDesativo.Checked && checkBoxAddAtivo.Checked)
                {
                    MessageBox.Show("Selecione apenas uma opção do campo Estado.");
                    return;
                }
                else
                {
                    MessageBox.Show("Selecione uma das opções do campo Estado.");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/bridge/port/add";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Porto adicionado com sucesso.");
                        textBoxCommentarioAdd.Clear();
                        checkBoxAddAtivo.Checked = false;
                        checkBoxAddDesativo.Checked= false;
                        await LoadPorts();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao adicionar o porto. Erro: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar o porto: " + ex.Message);
            }
        }

        private async void btnEditPort_Click(object sender, EventArgs e)
        {
            try
            {
                var requestBody = new JObject();
                requestBody["comment"] = textBoxCommentEdit.Text;

                if (comboBoxInterfaceEdit.SelectedIndex == -1)
                {
                    MessageBox.Show("Interface tem de ser preenchida.");
                    return;
                }

                if (comboBoxBridgeEdit.SelectedIndex == -1)
                {
                    MessageBox.Show("Bridge tem de ser preenchida.");
                    return;
                }

                if (comboBoxSelectPortos.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione um porto para poder editá-lo.");
                    return;
                }

                string selectedItemText = comboBoxSelectPortos.Items[comboBoxSelectPortos.SelectedIndex].ToString();
                string portoId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                requestBody[".id"]= portoId;
                requestBody["interface"] = comboBoxInterfaceEdit.SelectedItem.ToString();
                requestBody["bridge"] = comboBoxBridgeEdit.SelectedItem.ToString();

                if (checkBoxDesativoEdit.Checked && !checkBoxAtivoEdit.Checked)
                {
                    requestBody["disabled"] = true;
                }
                else if (checkBoxAtivoEdit.Checked && !checkBoxDesativoEdit.Checked)
                {
                    requestBody["disabled"] = false;
                }
                else if (checkBoxDesativoEdit.Checked && checkBoxAtivoEdit.Checked)
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

                    string url = $"http://{routerIp}/rest/interface/bridge/port/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Porto editado com sucesso.");
                        comboBoxInterfaceEdit.SelectedIndex = -1;
                        comboBoxBridgeEdit.SelectedIndex = -1;
                        textBoxCommentEdit.Clear();
                        checkBoxAtivoEdit.Checked = false;
                        checkBoxDesativoEdit.Checked = false;

                        await LoadPorts();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao editar o porto. Erro: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar o porto: " + ex.Message);
            }
        }

        private async void btnElimPorto_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxElimPorto.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um porto para eliminar.");
                    return;
                }

                string selectedItemText = comboBoxElimPorto.Items[comboBoxElimPorto.SelectedIndex].ToString();
                string portId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody[".id"] = portId;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/bridge/port/remove";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Porto eliminado com sucesso.");
                        await LoadPorts();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar o porto. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o porto: " + ex.Message);
            }
        }

        private void portsForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxCommentEdit.Clear();
                checkBoxDesativoEdit.Checked = false;
                checkBoxAtivoEdit.Checked = false;

                string url = $"http://{routerIp}/rest/interface/bridge/port";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectPortos.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione um porto para editar");
                    }

                    string selectedItemText = comboBoxSelectPortos.Items[comboBoxSelectPortos.SelectedIndex].ToString();
                    string endIPId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxPortos.Items.Add("Não foram encontrados portos");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (endIPId == id)
                            {
                                string desativo = routeObject.Value<string>("disabled");
                                string interfaceb = routeObject.Value<string>("interface");
                                string bridge = routeObject.Value<string>("bridge");

                                if (desativo == "false")
                                {
                                    checkBoxAtivoEdit.Checked = true;
                                    checkBoxDesativoEdit.Checked = false;
                                }
                                else
                                {
                                    checkBoxAtivoEdit.Checked = false;
                                    checkBoxDesativoEdit.Checked = true;
                                }

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxCommentEdit.Text = comentario;
                                }

                                foreach (var item in comboBoxInterfaceEdit.Items)
                                {
                                    string interfaceName = item.ToString();

                                    if (interfaceName == interfaceb)
                                    {
                                        comboBoxInterfaceEdit.SelectedItem = item;
                                        break;
                                    }
                                }

                                foreach (var item in comboBoxBridgeEdit.Items)
                                {
                                    string bridgeName = item.ToString();

                                    if (bridgeName == bridge)
                                    {
                                        comboBoxBridgeEdit.SelectedItem = item;
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

        private async void comboBoxSelectPortos_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadEdit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            interfacesBridge interfacesBridge = new interfacesBridge();
            interfacesBridge.SetCredentials(routerIp, username, password, model);
            interfacesBridge.Show();
            this.Dispose();
        }
    }
}

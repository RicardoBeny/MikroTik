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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AppLTI
{
    public partial class interfacesBridge : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private List<string> selectedPortIds = new List<string>();
        private Timer timer;

        public interfacesBridge()
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

        private async Task UpdateBridgeInterfaces()
        {
            try
            {
                checkBoxNão.Checked = false;
                checkBoxSim.Checked = false;
                checkBoxAtivado.Checked = false;
                checkBoxDesativado.Checked = false;
                textBoxNomeInterface.Clear();
                textBoxEditNome.Clear();
                textBoxComEdit.Clear();
                textBoxComentarioAdd.Clear();
                comboBoxElimInterface.Items.Clear();
                comboBoxSelectInterface.Items.Clear();
                listBoxInterfacesBridge.Items.Clear();
                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync($"http://{routerIp}/rest/interface/bridge");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxInterfacesBridge.Items.Add("Não foram encontradas interfaces bridge");
                            return;
                        }

                        JArray interfacesArray = JArray.Parse(responseBody);
                        foreach (JObject interfaceObject in interfacesArray)
                        {
                            string id = interfaceObject.Value<string>(".id");
                            string name = interfaceObject.Value<string>("name");
                            string macAddress = interfaceObject.Value<string>("mac-address");
                            string disabled = interfaceObject.Value<string>("disabled");
                            listBoxInterfacesBridge.Items.Add($"ID: {id}; Nome: {name}; Mac-Address({macAddress}); Desativada:{disabled}");
                            comboBoxSelectInterface.Items.Add($"ID: {id}; Nome: {name}; Mac-Address({macAddress})");
                            comboBoxElimInterface.Items.Add($"ID: {id}; Nome: {name}; Mac-Address({macAddress})");
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

        private async Task UpdatePortInterfaces()
        {
            try
            {
                listBoxPortos.Items.Clear();

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync($"http://{routerIp}/rest/interface/bridge/port");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxPortos.Items.Add("Não foram encontrados portos");
                            return;
                        }

                        JArray portArray = JArray.Parse(responseBody);

                        foreach (JObject portObject in portArray)
                        {
                            string bridgeName = portObject.Value<string>("bridge");
                            string interfaceName = portObject.Value<string>("interface");

                            listBoxPortos.Items.Add($"Bridge Associada: {bridgeName} Interface: {interfaceName}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as portas. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar as portas: " + ex.Message);
            }
        }

        private async Task EliminarPortos(string nomeBridgeSelecionado)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/bridge/port";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JArray responseObject = JArray.Parse(responseBody);

                        foreach (JObject portObject in responseObject)
                        {
                            string nomeBridge = portObject.Value<string>("bridge");
                            if (nomeBridge == nomeBridgeSelecionado)
                            {
                                selectedPortIds.Add(portObject.Value<string>(".id"));
                            }
                        }
                        if (selectedPortIds.Count > 0)
                        {
                            foreach (string portId in selectedPortIds)
                            {
                                try
                                {
                                    using (HttpClient clientPort = new HttpClient())
                                    {
                                        var base64CredentialsPort = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64CredentialsPort);

                                        string portUrl = $"http://{routerIp}/rest/interface/bridge/port/remove";

                                        JObject portData = new JObject();
                                        portData[".id"] = portId;

                                        var content = new StringContent(portData.ToString(), Encoding.UTF8, "application/json");

                                        HttpResponseMessage portResponse = await client.PostAsync(portUrl, content);

                                        if (portResponse.IsSuccessStatusCode)
                                        {
                                            MessageBox.Show($"Porto {portId} removido com sucesso.");
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Falha ao remover o porto {portId}. Servidor deu return com o código de erro: {portResponse.StatusCode}");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ocorreu um erro ao remover o porto associado: " + ex.Message);
                                }
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
                MessageBox.Show("Ocorreu um erro ao carregar a interface: " + ex.Message);
            }
        }

        private async void btnListBridge_Click_1(object sender, EventArgs e)
        {
            await UpdateBridgeInterfaces();
            await UpdatePortInterfaces();
        }

        private async void btnAddBridge_Click(object sender, EventArgs e)
        {
            try
            {
                string interfaceName = textBoxNomeInterface.Text.Trim();
                if (string.IsNullOrWhiteSpace(interfaceName))
                {
                    MessageBox.Show("Por favor preencha o campo nome.");
                    return;
                }

                JObject interfaceData = new JObject();
                interfaceData["name"] = interfaceName;

                if (checkBoxNão.Checked && !checkBoxSim.Checked)
                {
                    interfaceData["disabled"] = true;
                }
                else if (checkBoxSim.Checked && !checkBoxNão.Checked)
                {
                    interfaceData["disabled"] = false;
                }
                else if (checkBoxNão.Checked && checkBoxSim.Checked)
                {
                    MessageBox.Show("Selecione apenas uma opção do campo Ativa.");
                    return;
                }
                else
                {
                    MessageBox.Show("Selecione uma das opções do campo Ativa.");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(textBoxComentarioAdd.Text))
                {
                    interfaceData["comment"] = textBoxComentarioAdd.Text;
                }

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/bridge/add";
                    var content = new StringContent(interfaceData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Interface adicionada com sucesso!");
                        await UpdateBridgeInterfaces();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar a interface bridge. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar interface: " + ex.Message);
            }
        }

        private async void btnElimInterface_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxElimInterface.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma interface para excluir.");
                    return;
                }

                string selectedItem = comboBoxElimInterface.SelectedItem.ToString();
                string[] parts = selectedItem.Split(';');
                string interfaceId = parts[0].Trim().Substring(3);
                string interfaceName = selectedItem.Split(new string[] { "Nome:" }, StringSplitOptions.None)[1].Split(';')[0].Trim();

                await EliminarPortos(interfaceName);

                JObject interfaceData = new JObject();
                interfaceData[".id"] = interfaceId;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/bridge/remove";
                    var content = new StringContent(interfaceData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Interface removida com sucesso!");
                        await UpdateBridgeInterfaces();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar a interface bridge. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar interface: " + ex.Message);
            }

            await UpdatePortInterfaces();
        }

        private async void btnEditInterface_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectInterface.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma interface para editar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditNome.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo 'Nome' para editar a interface.");
                    return;
                }

                string selectedItem = comboBoxSelectInterface.SelectedItem.ToString();
                string interfaceId = selectedItem.Split(';')[0].Trim().Substring(3);

                string newName = textBoxEditNome.Text.Trim();

                bool disabled;
                if (checkBoxDesativado.Checked && checkBoxAtivado.Checked)
                {
                    MessageBox.Show("Erro: Ambos desativado e ativado selecionados.");
                    return;
                }
                else if (checkBoxDesativado.Checked)
                {
                    disabled = true;
                }
                else if (checkBoxAtivado.Checked)
                {
                    disabled = false;
                }
                else
                {
                    MessageBox.Show("Por favor, selecione 'Desativado' ou 'Ativado'.");
                    return;
                }

                JObject interfaceData = new JObject();
                interfaceData[".id"] = interfaceId;
                interfaceData["name"] = newName;
                interfaceData["disabled"] = disabled;
                interfaceData["comment"] = textBoxComEdit.Text;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/bridge/set";
                    var content = new StringContent(interfaceData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Interface editada com sucesso!");
                        await UpdateBridgeInterfaces();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao editar a interface. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar a interface: " + ex.Message);
            }
        }

        private void interfacesBridge_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private void buttonConfPortos_Click(object sender, EventArgs e)
        {
            portsForm portsForm = new portsForm();
            portsForm.SetCredentials(routerIp, username, password, model);
            portsForm.Show();
            this.Dispose();
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxEditNome.Clear();
                textBoxComEdit.Clear();
                checkBoxDesativado.Checked = false;
                checkBoxAtivado.Checked = false;

                string url = $"http://{routerIp}/rest/interface/bridge";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectInterface.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione um servidor para editar");
                    }

                    string selectedItemText = comboBoxSelectInterface.Items[comboBoxSelectInterface.SelectedIndex].ToString();
                    string interfaceId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxInterfacesBridge.Items.Add("Não foram encontradas interfaces bridge");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (interfaceId == id)
                            {
                                string interfaceservername = routeObject.Value<string>("name");
                                string desativo = routeObject.Value<string>("disabled");
                                string pool = routeObject.Value<string>("address-pool");

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxComEdit.Text = comentario;
                                }
                                textBoxEditNome.Text = interfaceservername;

                                if (desativo == "false")
                                {
                                    checkBoxAtivado.Checked = true;
                                    checkBoxDesativado.Checked = false;
                                }
                                else
                                {
                                    checkBoxAtivado.Checked = false;
                                    checkBoxDesativado.Checked = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os servidores DHCP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os Servidores DHCP: " + ex.Message);
            }
        }

        private async void comboBoxSelectInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadEdit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            interfaces interfaces = new interfaces();
            interfaces.SetCredentials(routerIp, username, password, model);
            interfaces.Show();
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

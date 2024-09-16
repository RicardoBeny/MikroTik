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
    public partial class wireGuardServerForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private List<string> selectedPeersIds = new List<string>();
        private Timer timer;

        public wireGuardServerForm()
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

        private async Task GetWireGuardServers()
        {
            try
            {
                textBoxPortEscuta.Clear();
                textBoxPublicKey.Clear();
                comboBoxPubKeyServer.Items.Clear();
                comboBoxRefazerChaves.Items.Clear();
                comboBoxListPeersServer.Items.Clear();
                comboBoxSelectServer.Items.Clear();
                comboBoxelimServer.Items.Clear();
                listBoxServer.Items.Clear();
                string url = $"http://{routerIp}/rest/interface/wireguard";

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
                            listBoxServer.Items.Add("Não foram encontrados servidores");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string serverName = routeObject.Value<string>("name");
                            string serverWireguardId = routeObject.Value<string>(".id");
                            string disabled = routeObject.Value<string>("disabled");
                            listBoxServer.Items.Add($"ID: {serverWireguardId}; Nome do Servidor: {serverName}; Desativada: {disabled}");
                            comboBoxelimServer.Items.Add($"ID: {serverWireguardId}; Nome: {serverName}; Desativada: {disabled}");
                            comboBoxPubKeyServer.Items.Add($"ID: {serverWireguardId}; Nome do Servidor: {serverName}; Desativada: {disabled}");
                            comboBoxSelectServer.Items.Add($"ID: {serverWireguardId}; Nome do Servidor: {serverName}; Desativada: {disabled}");
                            comboBoxListPeersServer.Items.Add($"Nome: {serverName}; Desativada: {disabled}");
                            comboBoxRefazerChaves.Items.Add($"ID: {serverWireguardId}; Nome do Servidor: {serverName}; Desativada: {disabled}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os Servidores WireGuard. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os servidores: " + ex.Message);
            }
        }

        private async Task EliminarPeers(string nomeServerSelecionado)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireguard/peers";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JArray responseObject = JArray.Parse(responseBody);

                        foreach (JObject peerObject in responseObject)
                        {
                            string nomeServer = peerObject.Value<string>("interface");
                            if (nomeServer == nomeServerSelecionado)
                            {
                                selectedPeersIds.Add(peerObject.Value<string>(".id"));
                            }
                        }
                        if (selectedPeersIds.Count > 0)
                        {
                            foreach (string peerId in selectedPeersIds)
                            {
                                try
                                {
                                    using (HttpClient clientPort = new HttpClient())
                                    {
                                        var base64CredentialsPort = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64CredentialsPort);

                                        string portUrl = $"http://{routerIp}/rest/interface/wireguard/peers/remove";

                                        JObject portData = new JObject();
                                        portData[".id"] = peerId;

                                        var content = new StringContent(portData.ToString(), Encoding.UTF8, "application/json");

                                        HttpResponseMessage portResponse = await client.PostAsync(portUrl, content);

                                        if (portResponse.IsSuccessStatusCode)
                                        {
                                            MessageBox.Show($"Peer {peerId} eliminado com sucesso.");
                                        }
                                        else
                                        {
                                            string errorMessage = await response.Content.ReadAsStringAsync();
                                            MessageBox.Show($"Falha ao remover o Peer associado {peerId}. Mensagem de erro: " + errorMessage);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ocorreu um erro ao eliminar o(s) peer(s) associado(s): " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os peers desse servidor. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private async void btnAtualizarServidorVPN_Click(object sender, EventArgs e)
        {
            await GetWireGuardServers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            peersForm peersForm = new peersForm();
            peersForm.SetCredentials(routerIp, username, password, model);
            peersForm.Show();
            this.Dispose();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxListPeersServer.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um servidor para apresentar os peers.");
                    return;
                }

                listBoxPeers.Items.Clear();

                string selectedItemText1 = comboBoxListPeersServer.Items[comboBoxListPeersServer.SelectedIndex].ToString();
                string serverWireguardname = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                string url = $"http://{routerIp}/rest/interface/wireguard/peers";

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
                            listBoxPeers.Items.Add("Não foram encontrados peers neste servidor");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string wireGuardServerName = routeObject.Value<string>("interface");
                            string desativada = routeObject.Value<string>("disabled");
                            string allowedAddress = routeObject.Value<string>("allowed-address");
                            string portoEscuta = routeObject.Value<string>("current-endpoint-port");

                            if(wireGuardServerName == serverWireguardname)
                            {
                                listBoxPeers.Items.Add($"ID: {id}; Nome do Servidor: {wireGuardServerName}; Desativada: {desativada}; Porto em escuta: {portoEscuta}; IP: {allowedAddress}");
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os peers do servidor selecionado WireGuard. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os peers: " + ex.Message);
            }
        }

        private async void buttonkeysObtain_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPubKeyServer.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um servidor para obter a key e porto.");
                    return;
                }

                textBoxPublicKey.Clear();

                string selectedItemText1 = comboBoxPubKeyServer.Items[comboBoxPubKeyServer.SelectedIndex].ToString();
                string serverWireguardId = selectedItemText1.Substring(selectedItemText1.IndexOf("ID:") + 3).Split(';')[0].Trim();

                string url = $"http://{routerIp}/rest/interface/wireguard";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string portoEscuta = routeObject.Value<string>("listen-port");

                            if (id == serverWireguardId)
                            {
                                string publicKey = routeObject.Value<string>("public-key");
                                textBoxPublicKey.Text = publicKey;
                                textBoxPortEscuta.Text = portoEscuta;
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar o servidor selecionado WireGuard. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar o Servidor WireGuard: " + ex.Message);
            }
        }

        private void buttonCopyPublicKey_Click(object sender, EventArgs e)
        {
            string publickey = textBoxPublicKey.Text;
            if (!string.IsNullOrEmpty(publickey))
            {
                Clipboard.SetText(publickey);
            }
            else
            {
                MessageBox.Show("Public key is empty.");
            };
        }

        private async void btnAddServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNomeAdd.Text))
                {
                    MessageBox.Show("Campo nome deve ser preenchido.");
                    return;
                }

                if (checkBoxAddAtivo.Checked && checkBoxAddDesativo.Checked)
                {
                    MessageBox.Show("Selecione apenas uma opção.");
                    return;
                }
                else if (!checkBoxAddAtivo.Checked && !checkBoxAddDesativo.Checked)
                {
                    MessageBox.Show("Selecione pelo menos uma opção.");
                    return;
                }

                string name = textBoxNomeAdd.Text.Trim();

                bool disabled = false;

                if (checkBoxAddAtivo.Checked)
                {
                    disabled = false;
                }
                else if (checkBoxAddDesativo.Checked)
                {
                    disabled = true;
                }

                var requestBody = new JObject();
                requestBody["name"] = name;
                requestBody["disabled"] = disabled;

                if (!string.IsNullOrWhiteSpace(textBoxComentario.Text))
                {
                    requestBody["comment"] = textBoxComentario.Text;
                }

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireguard/add";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servidor WireGuard adicionado com sucesso.");
                        textBoxNomeAdd.Clear();
                        textBoxComentario.Clear();
                        checkBoxAddDesativo.Checked = false;
                        checkBoxAddAtivo.Checked = false;
                        await GetWireGuardServers();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar o servidor WireGuard. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar o servidor WireGuard: " + ex.Message);
            }
        }

        private async void buttoneditServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectServer.SelectedIndex == -1)
                {
                    MessageBox.Show("Escolha um servidor a editar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditName.Text))
                {
                    MessageBox.Show("Campo nome deve ser preenchido.");
                    return;
                }

                if (checkBoxAtivoEdit.Checked && checkBoxDesativoEdit.Checked)
                {
                    MessageBox.Show("Selecione apenas uma opção.");
                    return;
                }
                else if (!checkBoxAtivoEdit.Checked && !checkBoxDesativoEdit.Checked)
                {
                    MessageBox.Show("Selecione pelo menos uma opção.");
                    return;
                }

                string selectedItemText = comboBoxSelectServer.Items[comboBoxSelectServer.SelectedIndex].ToString();
                string peerId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();
                string name = textBoxEditName.Text.Trim();
                bool disabled = false;

                if (checkBoxAtivoEdit.Checked)
                {
                    disabled = false;
                }
                else if (checkBoxDesativoEdit.Checked)
                {
                    disabled = true;
                }

                var requestBody = new JObject();
                requestBody[".id"] = peerId;
                requestBody["name"] = name;
                requestBody["disabled"] = disabled;
                requestBody["comment"] = textBoxcommentEdit.Text;
                requestBody["listen-port"] = textBoxPorto.Text;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireguard/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servidor Wireguard editado com sucesso.");
                        textBoxEditName.Clear();
                        textBoxcommentEdit.Clear();
                        textBoxPorto.Clear();
                        checkBoxAtivoEdit.Checked = false;
                        checkBoxDesativoEdit.Checked = false;
                        await GetWireGuardServers();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao editar o servidor selecionado WireGuard. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar o Servidor Wireguard: " + ex.Message);
            }
        }

        private async void buttonelimServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxelimServer.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um peer para eliminar.");
                    return;
                }

                string selectedItemText = comboBoxelimServer.Items[comboBoxelimServer.SelectedIndex].ToString();
                string serverID = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                string selectedItemText1 = comboBoxelimServer.Items[comboBoxelimServer.SelectedIndex].ToString();
                string serverName = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                await EliminarPeers(serverName);

                var requestBody = new JObject();
                requestBody[".id"] = serverID;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireguard/remove";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servidor Wireguard eliminado com sucesso.");
                        await GetWireGuardServers();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar o servidor selecionado WireGuard. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o Servidor Wireguard: " + ex.Message);
            }
        }

        private void buttonCopyPort_Click(object sender, EventArgs e)
        {
            string porto = textBoxPortEscuta.Text;
            if (!string.IsNullOrEmpty(porto))
            {
                Clipboard.SetText(porto);
            }
            else
            {
                MessageBox.Show("Port is empty.");
            };
        }

        private void wireGuardServerForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxEditName.Clear();
                textBoxPorto.Clear();
                checkBoxAtivoEdit.Checked = false;
                checkBoxDesativoEdit.Checked = false;

                string url = $"http://{routerIp}/rest/interface/wireguard";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectServer.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione um servidor Wireguard para editar");
                    }

                    string selectedItemText = comboBoxSelectServer.Items[comboBoxSelectServer.SelectedIndex].ToString();
                    string serverId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxServer.Items.Add("Não foram encontrados servidores");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (serverId == id)
                            {
                                string nameserver = routeObject.Value<string>("name");
                                string desativo = routeObject.Value<string>("disabled");
                                string porto = routeObject.Value<string>("listen-port");

                                textBoxEditName.Text = nameserver;
                                textBoxPorto.Text = porto;

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxcommentEdit.Text = comentario;
                                }

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
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar servidores. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os servidores: " + ex.Message);
            }
        }

        private async void comboBoxSelectServer_SelectedIndexChanged(object sender, EventArgs e)
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

        private async void buttonRefazerChaves_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxRefazerChaves.SelectedIndex == -1)
                {
                    MessageBox.Show("Escolha um servidor refazer as chaves.");
                    return;
                }

                string selectedItemText = comboBoxRefazerChaves.Items[comboBoxRefazerChaves.SelectedIndex].ToString();
                string serverId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody[".id"] = serverId;
                requestBody["private-key"] = "";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireguard/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Chaves do Servidor Wireguard refeitas com sucesso.");
                        await GetWireGuardServers();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao refazer as chaves do servidor selecionado WireGuard. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao refazer as chaves do Servidor Wireguard: " + ex.Message);
            }
        }
    }
}

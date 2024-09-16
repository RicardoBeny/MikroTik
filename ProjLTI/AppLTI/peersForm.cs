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
    public partial class peersForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private Timer timer;

        public peersForm()
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
                comboBoxAddServer.Items.Clear();
                comboBoxEditServer.Items.Clear();
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
                            listBoxServer.Items.Add("Não foram encontrados servidores wireless");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string serverName = routeObject.Value<string>("name");
                            string serverWireguardId = routeObject.Value<string>(".id");
                            string disabled = routeObject.Value<string>("disabled");
                            listBoxServer.Items.Add($"ID: {serverWireguardId}; Nome do Servidor: {serverName}; Desativada: {disabled}");
                            comboBoxAddServer.Items.Add($"Nome: {serverName}; Desativada: {disabled}");
                            comboBoxEditServer.Items.Add($"Nome: {serverName}; Desativada: {disabled}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os servidores WireGuard. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os servidores WireGuard: " + ex.Message);
            }
        }

        private async Task LoadPeers()
        {
            try
            {
                comboBoxElimPeer.Items.Clear();
                comboBoxSelectPeer.Items.Clear();
                listBoxPeer.Items.Clear();

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
                            listBoxPeer.Items.Add("Não foram encontrados peers");
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

                            listBoxPeer.Items.Add($"ID: {id}; Nome do Servidor: {wireGuardServerName}; Desativada: {desativada}; Porto em escuta: {portoEscuta}; IP: {allowedAddress}");
                            comboBoxElimPeer.Items.Add($"ID: {id}; Nome do Servidor: {wireGuardServerName}; Desativada: {desativada}; Porto em escuta: {portoEscuta}; IP: {allowedAddress}");
                            comboBoxSelectPeer.Items.Add($"ID: {id}; Nome do Servidor: {wireGuardServerName}; Desativada: {desativada}; Porto em escuta: {portoEscuta}; IP: {allowedAddress}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os peers. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os peers: " + ex.Message);
            }
        }

        private async void btnLoadServidores_Click(object sender, EventArgs e)
        {
            await LoadPeers();
        }

        private async void btnAddServWire_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPublicKeyAdd.Text))
                {
                    MessageBox.Show("Public key tem de ser preenchida.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxIPAdd.Text))
                {
                    MessageBox.Show("Endereço IP permitido tem de ser preenchido.");
                    return;
                }

                if (comboBoxAddServer.SelectedIndex == -1)
                {
                    MessageBox.Show("Servidor tem de ser preenchido.");
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

                string newPubKey = textBoxPublicKeyAdd.Text.Trim();
                string allowed = textBoxIPAdd.Text.Trim();

                bool disabled = false;

                if (checkBoxAddAtivo.Checked)
                {
                    disabled = false;
                }
                else if (checkBoxAddDesativo.Checked)
                {
                    disabled = true;
                }

                string selectedItemText = comboBoxAddServer.Items[comboBoxAddServer.SelectedIndex].ToString();
                string serverName = selectedItemText.Substring(selectedItemText.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody["interface"] = serverName;
                requestBody["public-key"] = newPubKey;
                requestBody["allowed-address"] = allowed;
                requestBody["disabled"]= disabled;

                if (!string.IsNullOrWhiteSpace(textBoxcomment.Text))
                {
                    requestBody["comment"] = textBoxcomment.Text;
                }


                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireguard/peers/add";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Peer WireGuard adicionado com sucesso.");
                        comboBoxAddServer.SelectedIndex = -1;
                        textBoxPublicKeyAdd.Clear();
                        textBoxIPAdd.Clear();
                        textBoxcomment.Clear();
                        checkBoxAddAtivo.Checked = false;
                        checkBoxAddDesativo.Checked = false;
                        await LoadPeers();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar o peer ao servidor WireGuard selecionado . Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar o peer ao servidor WireGuard: " + ex.Message);
            }
        }

        private async void btnDeleteWireGuard_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxElimPeer.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um peer para eliminar.");
                    return;
                }

                string selectedItemText = comboBoxElimPeer.Items[comboBoxElimPeer.SelectedIndex].ToString();
                string peerID = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody[".id"] = peerID;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireguard/peers/remove";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Peer eliminado com sucesso.");
                        await LoadPeers();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar o peer. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o peer: " + ex.Message);
            }
        }

        private async void btnEditWireGuard_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectPeer.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione um peer a editar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditPublicKey.Text))
                {
                    MessageBox.Show("Public key tem de ser preenchida.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEndIPEdit.Text))
                {
                    MessageBox.Show("Endereço IP permitido tem de ser preenchido.");
                    return;
                }

                if (checkBoxEditAtiva.Checked && checkBoxEditDesativa.Checked)
                {
                    MessageBox.Show("Selecione apenas uma opção.");
                    return;
                }
                else if (!checkBoxEditAtiva.Checked && !checkBoxEditDesativa.Checked)
                {
                    MessageBox.Show("Selecione pelo menos uma opção.");
                    return;
                }

                string selectedItemText = comboBoxSelectPeer.Items[comboBoxSelectPeer.SelectedIndex].ToString();
                string peerId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();
                string newPubKey = textBoxEditPublicKey.Text.Trim();
                string newendIPEdit = textBoxEndIPEdit.Text.Trim();
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
                requestBody[".id"] = peerId;
                requestBody["public-key"] = newPubKey;
                requestBody["allowed-address"] = newendIPEdit;
                requestBody["disabled"] = disabled;
                requestBody["comment"] = textBoxcommentEdit.Text;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireguard/peers/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Peer editado com sucesso.");
                        textBoxEditPublicKey.Clear();
                        textBoxEndIPEdit.Clear();
                        textBoxcommentEdit.Clear();
                        checkBoxEditAtiva.Checked = false;
                        checkBoxEditDesativa.Checked = false;
                        comboBoxEditServer.SelectedIndex = -1;
                        await LoadPeers();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao editar o peer. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar o peer: " + ex.Message);
            }
        }

        private async void btnAtualizarServidorVPN_Click(object sender, EventArgs e)
        {
            await GetWireGuardServers();
        }

        private void wireguardVPN_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxEditPublicKey.Clear();
                textBoxEndIPEdit.Clear();
                textBoxcommentEdit.Clear();
                checkBoxEditAtiva.Checked = false;
                checkBoxEditDesativa.Checked = false;

                string url = $"http://{routerIp}/rest/interface/wireguard/peers";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectPeer.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione um peer para editar");
                    }

                    string selectedItemText = comboBoxSelectPeer.Items[comboBoxSelectPeer.SelectedIndex].ToString();
                    string endIPId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxPeer.Items.Add("Não foram encontrados peers");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (endIPId == id)
                            {
                                string enderecopermitido = routeObject.Value<string>("allowed-address");
                                string desativo = routeObject.Value<string>("disabled");
                                string pubkey = routeObject.Value<string>("public-key");
                                string interfaceWire = routeObject.Value<string>("interface");

                                textBoxEditPublicKey.Text = pubkey;
                                textBoxEndIPEdit.Text = enderecopermitido;

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxcommentEdit.Text = comentario;
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

                                foreach (var item in comboBoxEditServer.Items)
                                {
                                    string selectedItemText1 = item.ToString();
                                    string interfaceName = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                                    if (interfaceName == interfaceWire)
                                    {
                                        comboBoxEditServer.SelectedItem = item;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar peers. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as peers: " + ex.Message);
            }
        }

        private async void comboBoxSelectPeer_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadEdit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            wireGuardServerForm wireGuardServerForm = new wireGuardServerForm();
            wireGuardServerForm.SetCredentials(routerIp, username, password, model);
            wireGuardServerForm.Show();
            this.Dispose();
        }
    }
}

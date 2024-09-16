using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

    public partial class dhcpForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private Timer timer;

        public dhcpForm()
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

        private void ClearTextBox()
        {
            textBoxAddNomeServidor.Clear();
            textBoxAddEndereçoServidor.Clear();
            textBoxAddLeaseTime.Clear();
            checkBoxSim.Checked = false;
            checkBoxNão.Checked = false;
            textBoxEditNomeServidor.Clear();
            textBoxCommentEdit.Clear();
            textBoxEndereçoServidor.Clear();
            textBoxLeaseTime.Clear();
            checkBoxEditAtiva.Checked = false;
            checkBoxEditDesativa.Checked = false;
            comboBoxEditPool.Items.Clear();
            comboBoxPoolAssociada.Items.Clear();
            comboBoxSelectDHCP.Items.Clear();
            comboBoxElimDHCP.Items.Clear();
            comboBoxEditInterface.Items.Clear();
            textBoxcomment.Clear();
        }

        private async Task LoadPool()
        {
            try
            {
                comboBoxEditPool.Items.Clear();
                comboBoxPoolAssociada.Items.Clear();
                listBoxIPPool.Items.Clear();

                string url = $"http://{routerIp}/rest/ip/pool";

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
                            listBoxIPPool.Items.Add("Não foram encontradas Pools");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string name = routeObject.Value<string>("name");
                            string range = routeObject.Value<string>("ranges");

                            listBoxIPPool.Items.Add($"ID: {id}; Nome: {name}; Range: {range}");
                            comboBoxEditPool.Items.Add($"ID: {id}; Nome: {name}; Range: {range}");
                            comboBoxPoolAssociada.Items.Add($"ID: {id}; Nome: {name}; Range: {range}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as IP Pools. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as IP Pools: " + ex.Message);
            }
        }

        private async Task LoadEdit()
        {
            try
            {
                await LoadPool();
                await UpdateBridgeInterfaces();
                textBoxEditNomeServidor.Clear();
                textBoxEndereçoServidor.Clear();
                textBoxLeaseTime.Clear();
                textBoxCommentEdit.Clear();
                checkBoxEditAtiva.Checked = false;
                checkBoxEditDesativa.Checked = false;

                string url = $"http://{routerIp}/rest/ip/dhcp-server";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if(comboBoxSelectDHCP.SelectedIndex == -1){
                        MessageBox.Show("Selecione um servidor para editar");
                    }

                    string selectedItemText = comboBoxSelectDHCP.Items[comboBoxSelectDHCP.SelectedIndex].ToString();
                    string dhcpId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxServidoresDHCP.Items.Add("Não foram encontrados servidores DHCP");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if(dhcpId == id)
                            {
                                string dhcpservername = routeObject.Value<string>("name");
                                string leasetime = routeObject.Value<string>("lease-time");
                                string desativo = routeObject.Value<string>("disabled");
                                string pool = routeObject.Value<string>("address-pool");
                                string interfaceb = routeObject.Value<string>("interface");

                                if (routeObject.ContainsKey("server-address"))
                                {
                                    string enderecoServer = routeObject.Value<string>("server-address");
                                    textBoxEndereçoServidor.Text = enderecoServer;
                                }

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxCommentEdit.Text = comentario;
                                }
                                textBoxEditNomeServidor.Text = dhcpservername;
                                textBoxLeaseTime.Text = leasetime;

                                if(desativo == "false")
                                {
                                    checkBoxEditAtiva.Checked = true;
                                    checkBoxEditDesativa.Checked = false;
                                }
                                else
                                {
                                    checkBoxEditAtiva.Checked = false;
                                    checkBoxEditDesativa.Checked = true;
                                }

                                foreach (var item in comboBoxEditPool.Items)
                                {
                                    string selectedItemText1 = item.ToString();
                                    string poolName = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                                    if (poolName == pool)
                                    {
                                        comboBoxEditPool.SelectedItem = item;
                                        break;
                                    }
                                }

                                foreach (var item in comboBoxEditInterface.Items)
                                {
                                    string selectedItemText2 = item.ToString();
                                    string interfaceName = selectedItemText2.Substring(selectedItemText2.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                                    if (interfaceName == interfaceb)
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
                        MessageBox.Show("Falha ao carregar os servidores DHCP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os Servidores DHCP: " + ex.Message);
            }
        }

        private async Task UpdateBridgeInterfaces()
        {
            try
            {
                listBoxInterfaces.Items.Clear();
                comboBoxEditInterface.Items.Clear();
                comboBoxAddInterface.Items.Clear();
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
                            comboBoxAddInterface.Items.Add($"ID:{id}; Nome:{name}; Mac-Address({macAddress})");
                            comboBoxEditInterface.Items.Add($"ID:{id}; Nome:{name}; Mac-Address({macAddress})");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as interfaces. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as interfaces: " + ex.Message);
            }
        }

        private async Task LoadDHCP()
        {
            try
            {
                comboBoxSelectDHCP.Items.Clear();
                comboBoxElimDHCP.Items.Clear();
                listBoxServidoresDHCP.Items.Clear();

                string url = $"http://{routerIp}/rest/ip/dhcp-server";

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
                            listBoxServidoresDHCP.Items.Add("Não foram encontrados servidores DHCP");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string dhcpservername = routeObject.Value<string>("name");
                            string lease = routeObject.Value<string>("lease-time");
                            string interfaceR = routeObject.Value<string>("interface");
                            string desativada = routeObject.Value<string>("disabled");

                            listBoxServidoresDHCP.Items.Add($"ID: {id}; Nome do Servidor: {dhcpservername}; Lease-time: {lease}; Interface: {interfaceR}; Desativada: {desativada}");
                            comboBoxSelectDHCP.Items.Add($"ID: {id}; Nome do Servidor: {dhcpservername}; Lease-time: {lease}; Interface: {interfaceR}; Desativada: {desativada}");
                            comboBoxElimDHCP.Items.Add($"ID: {id}; Nome do Servidor: {dhcpservername}; Lease-time: {lease}; Interface: {interfaceR}; Desativada: {desativada}");
                        }
                        await UpdateBridgeInterfaces();
                        await LoadPool();
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

        private async void btnLoadDHCP_Click(object sender, EventArgs e)
        {
            await LoadDHCP();
        }

        private async void btnAtualizarInt_Click(object sender, EventArgs e)
        {
            await UpdateBridgeInterfaces();
        }

        private async void btnAddServDHCP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxAddNomeServidor.Text))
                {
                    MessageBox.Show("Campo nome tem de ser preenchido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxAddEndereçoServidor.Text))
                {
                    MessageBox.Show("Campo endereço de servidor tem de ser preenchido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxAddLeaseTime.Text))
                {
                    MessageBox.Show("Campo lease time tem de ser preenchido.");
                    return;
                }

                if (comboBoxPoolAssociada.SelectedIndex == -1)
                {
                    MessageBox.Show("Pool tem de ser selecionada.");
                    return;
                }

                if (comboBoxAddInterface.SelectedIndex == -1)
                {
                    MessageBox.Show("Interface associada deve ser selecionada.");
                    return;
                }

                if (checkBoxSim.Checked == checkBoxNão.Checked)
                {
                    MessageBox.Show("Selecione apenas uma opção entre 'Sim' e 'Não' para ativar ou desativar o servidor DHCP.");
                    return;
                }
                string selectedItemText = comboBoxPoolAssociada.Items[comboBoxPoolAssociada.SelectedIndex].ToString();
                string poolName = selectedItemText.Substring(selectedItemText.IndexOf("Nome:") + 5).Split(';')[0].Trim();
                string selectedItemText1 = comboBoxAddInterface.Items[comboBoxAddInterface.SelectedIndex].ToString();
                string interfaceName = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();
                string newName = textBoxAddNomeServidor.Text.Trim();
                string endServidor = textBoxAddEndereçoServidor.Text.Trim();
                string leaseTime = textBoxAddLeaseTime.Text.Trim();

                var requestBody = new JObject();

                if (!string.IsNullOrWhiteSpace(textBoxcomment.Text))
                {
                    requestBody["comment"] = textBoxcomment.Text;
                }

                requestBody["interface"] = interfaceName;
                requestBody["address-pool"] = poolName;
                requestBody["name"] = newName;
                requestBody["lease-time"] = leaseTime;
                requestBody["server-address"] = endServidor;

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

                    string url = $"http://{routerIp}/rest/ip/dhcp-server/add";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servidor DHCP adicionado com sucesso.");
                        ClearTextBox();
                        await LoadDHCP();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar o servidor DHCP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar o servidor DHCP: " + ex.Message);
            }
        }

        private void btnConfIPPool_Click(object sender, EventArgs e)
        {
            ipPoolForm ipPoolForm = new ipPoolForm();
            ipPoolForm.SetCredentials(routerIp, username, password, model);
            ipPoolForm.Show();
            this.Hide();
        }

        private async void btnAtualizarIPPool_Click(object sender, EventArgs e)
        {
            await LoadPool();
        }

        private async void btnEditServDHCP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxEditNomeServidor.Text))
                {
                    MessageBox.Show("Campo nome deve ser preenchido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEndereçoServidor.Text))
                {
                    MessageBox.Show("Campo endereço de servidor deve ser preenchido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxLeaseTime.Text))
                {
                    MessageBox.Show("Campo leasetime deve ser preenchido.");
                    return;
                }

                if (comboBoxEditPool.SelectedIndex == -1)
                {
                    MessageBox.Show("Pool tem de ser selecionada.");
                    return;
                }

                if (comboBoxEditInterface.SelectedIndex == -1)
                {
                    MessageBox.Show("Interface tem de ser selecionada.");
                    return;
                }

                if (comboBoxSelectDHCP.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione um servidor DHCP para editar.");
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

                string selectedItemText = comboBoxEditPool.Items[comboBoxEditPool.SelectedIndex].ToString();
                string newpoolName = selectedItemText.Substring(selectedItemText.IndexOf("Nome:") + 5).Split(';')[0].Trim();
                string selectedItemText2 = comboBoxEditInterface.Items[comboBoxEditInterface.SelectedIndex].ToString();
                string newinterfaceName = selectedItemText2.Substring(selectedItemText2.IndexOf("Nome:") + 5).Split(';')[0].Trim();
                string selectedItemText3 = comboBoxSelectDHCP.Items[comboBoxSelectDHCP.SelectedIndex].ToString();
                string dhcpId = selectedItemText3.Substring(selectedItemText3.IndexOf("ID:") + 3).Split(';')[0].Trim();
                string newName = textBoxEditNomeServidor.Text.Trim();
                string newEndServidor = textBoxEndereçoServidor.Text.Trim();
                string leaseTime = textBoxLeaseTime.Text.Trim();
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
                requestBody[".id"] = dhcpId;
                requestBody["address-pool"] = newpoolName;
                requestBody["interface"] = newinterfaceName;
                requestBody["name"] = newName;
                requestBody["server-address"] = newEndServidor;
                requestBody["lease-time"] = leaseTime;
                requestBody["disabled"] = disabled;
                requestBody["comment"] = textBoxCommentEdit.Text;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/dhcp-server/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servidor DHCP editado com sucesso.");
                        ClearTextBox();
                        comboBoxEditPool.SelectedIndex = -1;
                        comboBoxEditInterface.SelectedIndex = -1;
                        await LoadDHCP();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao editar o servidor DHCP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar o Servidor DHCP: " + ex.Message);
            }
        }

        private async void btnDeleteDHCP_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxElimDHCP.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um Servidor DHCP para eliminar.");
                    return;
                }

                string selectedItemText = comboBoxElimDHCP.Items[comboBoxElimDHCP.SelectedIndex].ToString();
                string dhcpID = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody[".id"] = dhcpID;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/dhcp-server/remove";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servidor DHCP eliminado com sucesso.");
                        await LoadDHCP();
                        ClearTextBox();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar o servidor DHCP. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o Servidor DHCP: " + ex.Message);
            }
        }

        private void dhcpForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async void comboBoxSelectDHCP_SelectedIndexChanged(object sender, EventArgs e)
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

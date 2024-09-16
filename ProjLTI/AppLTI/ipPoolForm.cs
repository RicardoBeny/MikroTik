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
    public partial class ipPoolForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private int erroVerificar = 0;
        private Timer timer;

        public ipPoolForm()
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

        private async Task LoadPool()
        {
            try
            {
                comboBoxSelectIPPool.Items.Clear();
                comboBoxElimPool.Items.Clear();
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
                            listBoxIPPool.Items.Add("Não foram encontrados portos");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string name = routeObject.Value<string>("name");
                            string range = routeObject.Value<string>("ranges");

                            comboBoxElimPool.Items.Add($"ID: {id}; Nome: {name}; Range: {range}");
                            comboBoxSelectIPPool.Items.Add($"ID: {id}; Nome da Pool: {name}; Range: {range}");
                            listBoxIPPool.Items.Add($"ID: {id}; Nome da Pool: {name}; Range: {range}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar as Pools. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as Pools: " + ex.Message);
            }
        }

        private async Task VerificarExistencia()
        {
            try
            {
                if (comboBoxElimPool.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma Pool para excluir.");
                    return;
                }

                string selectedItemText = comboBoxElimPool.Items[comboBoxElimPool.SelectedIndex].ToString();
                string poolName = selectedItemText.Substring(selectedItemText.IndexOf("Nome:") + 5).Split(';')[0].Trim();

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
                            MessageBox.Show("Não foram encontrados servidores DHCP");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string poolenderecos = routeObject.Value<string>("address-pool");

                            if (poolenderecos == poolName)
                            {
                                MessageBox.Show("Não é possível eliminar uma pool asociada a um servidor DHCP");
                                erroVerificar = 1;
                                return;
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

        private async void btnLoadIPPool_Click(object sender, EventArgs e)
        {
            await LoadPool();
        }

        private async void btnAddIPPool_Click(object sender, EventArgs e)
        {
            try
            {
                string poolName = textBoxAddName.Text.Trim();
                if (string.IsNullOrWhiteSpace(poolName))
                {
                    MessageBox.Show("Por favor preencha o campo nome.");
                    return;
                }

                string gama = textBoxAddGama.Text.Trim();
                if (string.IsNullOrWhiteSpace(gama))
                {
                    MessageBox.Show("Por favor preencha a gama de endereços.");
                    return;
                }

                JObject poolData = new JObject();
                poolData["ranges"] = gama;
                poolData["name"] = poolName;

                if (!string.IsNullOrWhiteSpace(textBoxcomment.Text))
                {
                    poolData["comment"] = textBoxcomment.Text;
                }
                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/pool/add";
                    var content = new StringContent(poolData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pool adicionada com sucesso!");
                        textBoxAddName.Clear();
                        textBoxAddGama.Clear();
                        textBoxcomment.Clear();
                        await LoadPool();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar as Pools. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar a Pool: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSelectIPPool.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma Pool para editar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditPoolName.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo 'Nome' para editar a Pool.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEditGama.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo 'Gama de Endereços' para editar a Pool.");
                    return;
                }

                string selectedItem = comboBoxSelectIPPool.SelectedItem.ToString();
                string poolId = selectedItem.Split(';')[0].Trim().Substring(3);

                string newName = textBoxEditPoolName.Text.Trim();
                string gama = textBoxEditGama.Text.Trim();

                
                JObject poolData = new JObject();
                poolData[".id"] = poolId;
                poolData["name"] = newName;
                poolData["ranges"] = gama;
                poolData["comment"] = textBoxcommentEdit.Text;


                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/pool/set";
                    var content = new StringContent(poolData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pool editada com sucesso!");
                        textBoxEditPoolName.Clear();
                        textBoxEditGama.Clear();
                        textBoxcommentEdit.Clear();
                        await LoadPool();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao editar a Pool. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro a editar a Pool: " + ex.Message);
            }
        }

        private async void btnDeleteDHCP_Click(object sender, EventArgs e)
        {
            erroVerificar = 0;
            try
            {
                await VerificarExistencia();

                if (erroVerificar == 1)
                {
                    return;
                }

                string selectedItem = comboBoxElimPool.SelectedItem.ToString();
                string[] parts = selectedItem.Split(';');
                string poolid = parts[0].Trim().Substring(3);

                JObject poolData = new JObject();
                poolData[".id"] = poolid;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/pool/remove";
                    var content = new StringContent(poolData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pool removida com sucesso!");
                        await LoadPool();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao remover a Pool. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao remover a Pool: " + ex.Message);
            }
        }

        private void ipPoolForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxEditPoolName.Clear();
                textBoxEditGama.Clear();
                textBoxcommentEdit.Clear();

                string url = $"http://{routerIp}/rest/ip/pool";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectIPPool.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione uma pool para editar");
                    }

                    string selectedItemText = comboBoxSelectIPPool.Items[comboBoxSelectIPPool.SelectedIndex].ToString();
                    string poolId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxIPPool.Items.Add("Não foram encontradas pools");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (poolId == id)
                            {
                                string interfaceservername = routeObject.Value<string>("name");
                                string ranges = routeObject.Value<string>("ranges");

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxcommentEdit.Text = comentario;
                                }
                                textBoxEditPoolName.Text = interfaceservername;
                                textBoxEditGama.Text = ranges;
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as pools. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as pools: " + ex.Message);
            }
        }

        private async void comboBoxSelectIPPool_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadEdit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dhcpForm dhcpForm = new dhcpForm();
            dhcpForm.SetCredentials(routerIp, username, password, model);
            dhcpForm.Show();
            this.Hide();
        }
    }
}

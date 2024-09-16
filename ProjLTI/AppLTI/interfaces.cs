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
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


namespace AppLTI
{
    public partial class interfaces : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private Timer timer;

        public interfaces()
        {
            InitializeComponent();
            InitializeTimer();
        }
        public void SetCredentials(string routerIp, string username, string password, string model)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.model = model;
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

        private async void btnInterfacesN_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxInterfaces.Items.Clear();
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
                            string name = interfaceObject.Value<string>("name");
                            string macAddress = interfaceObject.Value<string>("mac-address");
                            listBoxInterfaces.Items.Add($"Interface: {name} com o Mac-Address({macAddress})");
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

        private async void btnWireless_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxWireless.Items.Clear();
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
                            listBoxWireless.Items.Add("Não foram encontradas interfaces wireless");
                            return;
                        }

                        JArray interfacesArray = JArray.Parse(responseBody);
                        foreach (JObject interfaceObject in interfacesArray)
                        {
                            string name = interfaceObject.Value<string>("name");
                            string macAddress = interfaceObject.Value<string>("mac-address");
                            string type = interfaceObject.Value<string>("type");

                            if (type == "wlan")
                            {
                                listBoxWireless.Items.Add($"Interface: {name} com o Mac-Address: ({macAddress})");
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as interfaces Wireless. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as interfaces Wireless: " + ex.Message);
            }
        }

        private void btnBridge_Click(object sender, EventArgs e)
        {
            interfacesBridge interfacesBridge = new interfacesBridge();
            interfacesBridge.SetCredentials(routerIp, username, password, model);
            interfacesBridge.Show();
            this.Dispose();
        }

        private void interfaces_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
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

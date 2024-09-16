using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AppLTI
{
    public partial class mainPage : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private IWebDriver driver;
        private Timer timer;

        public mainPage()
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

        private void btnInterfaces_Click(object sender, EventArgs e)
        {
            interfaces interfacesForm = new interfaces();
            interfacesForm.SetCredentials(routerIp, username, password, model);
            interfacesForm.Show();
            this.Dispose();
        }

        private void btnRotas_Click(object sender, EventArgs e)
        {
            rotas_Form rotas_Form = new rotas_Form();
            rotas_Form.SetCredentials(routerIp, username, password, model);
            rotas_Form.Show();
            this.Dispose();
        }

        private void btnEndIP_Click(object sender, EventArgs e)
        {
            endIPForm endIPForm = new endIPForm();
            endIPForm.SetCredentials(routerIp, username, password, model);
            endIPForm.Show();
            this.Dispose();
        }

        private void btnServDHCP_Click(object sender, EventArgs e)
        {
            dhcpForm dhcpForm = new dhcpForm();
            dhcpForm.SetCredentials(routerIp, username, password, model);
            dhcpForm.Show();
            this.Dispose();
        }

        private void btnServDNS_Click(object sender, EventArgs e)
        {
            dns_Form DNS_Form = new dns_Form();
            DNS_Form.SetCredentials(routerIp, username, password, model);
            DNS_Form.Show();
            this.Dispose();
        }

        private void btnRedes_Click(object sender, EventArgs e)
        {
            redesWirelessForm redesWirelessForm = new redesWirelessForm();
            redesWirelessForm.SetCredentials(routerIp, username, password, model);
            redesWirelessForm.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wireGuardServerForm wireGuardServerForm = new wireGuardServerForm();
            wireGuardServerForm.SetCredentials(routerIp, username, password, model);
            wireGuardServerForm.Show();
            this.Dispose();
        }

        private void mainPage_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sshMikrotik sshMikrotik = new sshMikrotik();
            sshMikrotik.SetCredentials(routerIp, username, password, model);
            sshMikrotik.Show();
            this.Dispose();
        }

        private void buttonPagWeb_Click(object sender, EventArgs e)
        {
            OpenRouterPage(routerIp,username,password);
        }

        private void OpenRouterPage(string routerIp, string username, string password)
        {

            try
            {
                // Configure Chrome options
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("start-maximized");
                options.AddArgument("disable-infobars");
                options.AddArgument("disable-extensions");
                options.AddArgument("disable-notifications");

                // Create ChromeDriver service with options
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                driver = new ChromeDriver(service, options);

                driver.Navigate().GoToUrl($"http://{routerIp}");

                var usernameField = driver.FindElement(By.Id("name"));
                var passwordField = driver.FindElement(By.Id("password"));
                var submitButton = driver.FindElement(By.CssSelector("input[type='submit']"));

                if (usernameField.GetAttribute("value") == "admin")
                {
                    usernameField.Clear();
                }

                // Enter username and password
                usernameField.SendKeys(username);
                passwordField.SendKeys(password);
                submitButton.Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

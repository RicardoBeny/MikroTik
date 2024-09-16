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
    public partial class dnsEstaticoForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private Timer timer;

        public dnsEstaticoForm()
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

        private async Task LoadDNSEntradas()
        {
            try
            {
                listBoxEntradasEstáticas.Items.Clear();
                comboBoxSelectDNSEdit.Items.Clear();
                comboBoxElimEntrada.Items.Clear();
                textBoxnomeEdit.Clear();
                textBoxvalueEdit.Clear();
                textBoxcommEdit.Clear();
                textBoxttlEdit.Clear();
                checkBoxDesativoEdit.Checked = false;
                checkBoxAtivoEdit.Checked = false;

                string url = $"http://{routerIp}/rest/ip/dns/static";

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
                            listBoxEntradasEstáticas.Items.Add("Não foram encontradas entradas DNS");
                            return;
                        }

                        JArray responseArray = JArray.Parse(responseBody);

                        foreach (JObject responseObject in responseArray)
                        {
                            string idEndrada = responseObject[".id"].ToString();
                            string timeToLive = responseObject["ttl"].ToString();
                            string desativado = responseObject["disabled"].ToString();
                            string nome = responseObject["name"].ToString();

                            string type = responseObject["type"]?.ToString() ?? "A";

                            string value = null;
                            switch (type)
                            {
                                case "A":
                                case "AAAA":
                                    value = responseObject["address"]?.ToString();
                                    comboBoxSelectDNSEdit.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    listBoxEntradasEstáticas.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    comboBoxElimEntrada.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    break;
                                case "CNAME":
                                    value = responseObject["cname"]?.ToString();
                                    comboBoxSelectDNSEdit.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    listBoxEntradasEstáticas.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    comboBoxElimEntrada.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    break;
                                case "FWD":
                                    value = responseObject["forward-to"]?.ToString();
                                    comboBoxSelectDNSEdit.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    listBoxEntradasEstáticas.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    comboBoxElimEntrada.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    break;
                                case "MX":
                                    value = responseObject["mx-exchange"]?.ToString();
                                    comboBoxSelectDNSEdit.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    listBoxEntradasEstáticas.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    comboBoxElimEntrada.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    break;
                                default:
                                    listBoxEntradasEstáticas.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    comboBoxElimEntrada.Items.Add($"ID: {idEndrada}; Nome: {nome}; TTL: {timeToLive}; Tipo: {type}; Valor: {value} ;Desativada: {desativado}");
                                    break;
                            }

                            
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar servidor dns. Mensagem de erro: " + errorMessage);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar o Servidor DNS: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await LoadDNSEntradas();
        }

        private async void buttonElim_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxElimEntrada.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione uma entrada para eliminar.");
                    return;
                }

                string selectedItemText = comboBoxElimEntrada.Items[comboBoxElimEntrada.SelectedIndex].ToString();
                string entradaID = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody[".id"] = entradaID;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/dns/static/remove";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Entrada DNS eliminada com sucesso.");
                        await LoadDNSEntradas();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar entrada DNS. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar a entrada DNS: " + ex.Message);
            }
        }

        private async void buttonAddEntradaEstatica_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    MessageBox.Show("Campo nome deve ser preenchido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxAddressStatic.Text))
                {
                    MessageBox.Show("Campo value deve ser preenchido.");
                    return;
                }

                if (comboBoxTipos.SelectedIndex == -1)
                {
                    MessageBox.Show("Tipo deve ser preenchido.");
                    return;
                }


                string name = textBoxName.Text.Trim();

                string selectedItemText = comboBoxTipos.Items[comboBoxTipos.SelectedIndex].ToString();

                var requestBody = new JObject();
                requestBody["name"] = name;
                requestBody["type"] = selectedItemText;

                if (!string.IsNullOrWhiteSpace(textBoxcomment.Text))
                {
                    requestBody["comment"] = textBoxcomment.Text;
                }

                if (!string.IsNullOrWhiteSpace(textBoxttl.Text))
                {
                    requestBody["ttl"] = textBoxttl.Text;
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

                switch (selectedItemText)
                {
                    case "A":
                    case "AAAA":
                        requestBody["address"] = textBoxAddressStatic.Text;
                        break;
                    case "CNAME":
                        requestBody["cname"] = textBoxAddressStatic.Text;
                        break;
                    case "MX":
                        requestBody["mx-exchange"] = textBoxAddressStatic.Text;
                        break;
                    case "FWD":
                        requestBody["forward-to"] = textBoxAddressStatic.Text;
                        break;
                }

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/dns/static/add";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Entrada adicionada com sucesso.");
                        await LoadDNSEntradas();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar a entrada dns. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar a entrada: " + ex.Message);
            }
        }

        private async void buttonEditEntradas_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxnomeEdit.Text))
                {
                    MessageBox.Show("Campo nome deve ser preenchido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxvalueEdit.Text))
                {
                    MessageBox.Show("Campo value deve ser preenchido.");
                    return;
                }

                if (comboBoxtipoEdit.SelectedIndex == -1)
                {
                    MessageBox.Show("Tipo deve ser preenchido.");
                    return;
                }

                string name = textBoxnomeEdit.Text.Trim();

                string selectedItemText = comboBoxtipoEdit.Items[comboBoxtipoEdit.SelectedIndex].ToString();

                string selectedItemText3 = comboBoxSelectDNSEdit.Items[comboBoxSelectDNSEdit.SelectedIndex].ToString();
                string entradaID = selectedItemText3.Substring(selectedItemText3.IndexOf("ID:") + 3).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody["name"] = name;
                requestBody["type"] = selectedItemText;
                requestBody[".id"] = entradaID;
                requestBody["comment"] = textBoxcommEdit.Text;

                if (!string.IsNullOrWhiteSpace(textBoxttl.Text))
                {
                    requestBody["ttl"] = textBoxttlEdit.Text;
                }

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

                switch (selectedItemText)
                {
                    case "A":
                    case "AAAA":
                        requestBody["address"] = textBoxvalueEdit.Text;
                        break;
                    case "CNAME":
                        requestBody["cname"] = textBoxvalueEdit.Text;
                        break;
                    case "MX":
                        requestBody["mx-exchange"] = textBoxvalueEdit.Text;
                        break;
                    case "FWD":
                        requestBody["forward-to"] = textBoxvalueEdit.Text;
                        break;
                }

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/ip/dns/static/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Entrada DNS editada com sucesso.");
                        comboBoxtipoEdit.SelectedIndex = -1;
                        await LoadDNSEntradas();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao editar a entrada dns. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar a entrada DNS: " + ex.Message);
            }
        }

        private void dnsEstaticoForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxnomeEdit.Clear();
                textBoxvalueEdit.Clear();
                textBoxcommEdit.Clear();
                textBoxttlEdit.Clear();
                checkBoxAtivoEdit.Checked = false;
                checkBoxDesativoEdit.Checked = false;

                string url = $"http://{routerIp}/rest/ip/dns/static";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectDNSEdit.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione uma entrada DNS para editar");
                    }

                    string selectedItemText = comboBoxSelectDNSEdit.Items[comboBoxSelectDNSEdit.SelectedIndex].ToString();
                    string dnsId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxEntradasEstáticas.Items.Add("Não foram encontradas entradas DNS");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (dnsId == id)
                            {
                                string dnsservername = routeObject.Value<string>("name");
                                string ttl = routeObject.Value<string>("ttl");
                                string desativo = routeObject.Value<string>("disabled");
                                string tipo;

                                textBoxnomeEdit.Text = dnsservername;
                                textBoxttlEdit.Text = ttl;

                                if (routeObject.ContainsKey("type"))
                                {
                                    tipo = routeObject.Value<string>("type");
                                }
                                else
                                {
                                    tipo = "A";
                                }

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxcommEdit.Text = comentario;
                                }

                                if (routeObject.ContainsKey("mx-exchange"))
                                {
                                    string value = routeObject.Value<string>("mx-exchange");
                                    textBoxvalueEdit.Text = value;
                                }
                                else if(routeObject.ContainsKey("forward-to"))
                                {
                                    string forward = routeObject.Value<string>("forward-to");
                                    textBoxvalueEdit.Text = forward;
                                }
                                else if (routeObject.ContainsKey("cname"))
                                {
                                    string cname = routeObject.Value<string>("cname");
                                    textBoxvalueEdit.Text = cname;
                                }
                                else if (routeObject.ContainsKey("address"))
                                {
                                    string address = routeObject.Value<string>("address");
                                    textBoxvalueEdit.Text = address;
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

                                foreach (var item in comboBoxtipoEdit.Items)
                                {
                                    string tipoedit = item.ToString();

                                    if (tipoedit == tipo)
                                    {
                                        comboBoxtipoEdit.SelectedItem = item;
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

        private async void comboBoxSelectRotaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadEdit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dns_Form dns_Form = new dns_Form();
            dns_Form.SetCredentials(routerIp, username, password, model);
            dns_Form.Show();
            this.Dispose();
        }
    }
}

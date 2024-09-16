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
    public partial class perfilSegurançaForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string model;
        private int erroVerificar = 0;
        private Timer timer;
        public perfilSegurançaForm()
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

        private async Task LoadPerfis()
        {
            try
            {
                comboBoxElimPerfil.Items.Clear();
                comboBoxSelectPerfil.Items.Clear();
                listBoxPerfis.Items.Clear();
                string url = $"http://{routerIp}/rest/interface/wireless/security-profiles";

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
                            listBoxPerfis.Items.Add("Não foram encontrados perfis de segurança");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");
                            string tipo_autenticação = routeObject.Value<string>("authentication-types");
                            string mode = routeObject.Value<string>("mode");
                            string name = routeObject.Value<string>("name");

                            comboBoxElimPerfil.Items.Add($"ID: {id}; Nome: {name}; Mode: {mode}; Tipo de autenticação: {tipo_autenticação}") ;
                            listBoxPerfis.Items.Add($"ID: {id}; Nome do Perfil: {name}; Mode: {mode}; Tipo de autenticação: {tipo_autenticação}");

                            if(tipo_autenticação == "wpa2-psk")
                            comboBoxSelectPerfil.Items.Add($"ID: {id}; Nome do Perfil: {name}; Mode: {mode}; Tipo de autenticação: {tipo_autenticação}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os perfis de segurança. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os perfis: " + ex.Message);
            }
        }

        private async Task VerificarExistencia()
        {
            try
            {
                if (comboBoxElimPerfil.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um perfil para excluir.");
                    return;
                }

                string selectedItemText = comboBoxElimPerfil.Items[comboBoxElimPerfil.SelectedIndex].ToString();
                string profileName = selectedItemText.Substring(selectedItemText.IndexOf("Nome:") + 5).Split(';')[0].Trim();

                string url = $"http://{routerIp}/rest/interface/wireless";

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
                            MessageBox.Show("Não foram encontradas interfaces wireless");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string profiles = routeObject.Value<string>("security-profile");
                            if (profiles == profileName)
                            {
                                MessageBox.Show("Não é possível eliminar um perfil asociado a uma interface wireless");
                                erroVerificar = 1;
                                return;
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar interfaces wireless. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as interfaces wireless: " + ex.Message);
            }
        }

        private async void btnLoadPerfis_Click(object sender, EventArgs e)
        {
            await LoadPerfis();
        }

        private async void btnAddPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                string mode;
                string wpa2psk = "";
                string keywpa2sk = "";


                if (string.IsNullOrWhiteSpace(textBoxNomePerfil.Text))
                {
                    MessageBox.Show("Campo nome tem de ser preenchido.");
                    return;
                }

                if (checkBoxNone.Checked == checkBoxDynamic.Checked)
                {
                    MessageBox.Show("Escolha apenas um Modo.");
                    return;
                }

                if (checkBoxNone.Checked)
                {
                    mode = "none";
                }
                else
                {
                    mode = "dynamic-keys";
                    if (checkBoxWPA2PSK.Checked)
                    {
                        wpa2psk = "wpa2-psk";
                        if (string.IsNullOrWhiteSpace(textBoxWPA2KEY.Text))
                        {
                            MessageBox.Show("Preencha a key do WPA2");
                            return;
                        }
                        else
                        {
                            if(textBoxWPA2KEY.TextLength >64 || textBoxWPA2KEY.TextLength < 8)
                            {
                                MessageBox.Show("O tamanho da chave tem de ter no mínimo 8 caracteres e no máximo 64 ");
                                return;
                            }
                            keywpa2sk = textBoxWPA2KEY.Text.Trim();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha o tipo de autenticação");
                        return;
                    }
                }

                var requestBody = new JObject();
                requestBody["mode"] = mode;
                requestBody["name"] = textBoxNomePerfil.Text.Trim();
                requestBody["authentication-types"] = wpa2psk;
                requestBody["wpa2-pre-shared-key"] = keywpa2sk;

                if (!string.IsNullOrWhiteSpace(textBoxComentarioAdd.Text))
                {
                    requestBody["comment"] = textBoxComentarioAdd.Text;
                }

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireless/security-profiles/add";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Perfil adicionado com sucesso.");
                        textBoxNomePerfil.Clear();
                        textBoxComentarioAdd.Clear();
                        textBoxWPA2KEY.Clear();
                        checkBoxWPA2PSK.Checked = false;
                        checkBoxDynamic.Checked = false;
                        checkBoxNone.Checked = false;
                        await LoadPerfis();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao adicionar Perfil. Erro: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar o Perfil: " + ex.Message);
            }
        }

        private async void btnDeletePerfil_Click(object sender, EventArgs e)
        {
            erroVerificar = 0;
            await VerificarExistencia();

            if(erroVerificar == 1)
            {
                return;
            }

            try
            {
                if (comboBoxElimPerfil.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecione um Perfil para eliminar.");
                    return;
                }

                string selectedItemText = comboBoxElimPerfil.Items[comboBoxElimPerfil.SelectedIndex].ToString();
                string perfilID = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                var requestBody = new JObject();
                requestBody[".id"] = perfilID;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireless/security-profiles/remove";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Perfil eliminado com sucesso.");
                        await LoadPerfis();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao aliminar o perfil de segurança. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o Perfil: " + ex.Message);
            }
        }

        private async void btnEditPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                string mode;
                string wpa2psk = "";
                string keywpa2sk = "";

                if (string.IsNullOrWhiteSpace(textBoxnewName.Text))
                {
                    MessageBox.Show("Campo nome tem de ser preenchido.");
                    return;
                }

                if (checkBoxNENHUMEDIT.Checked == checkBoxDINAMICOEDIT.Checked)
                {
                    MessageBox.Show("Escolha apenas um Modo.");
                    return;
                }

                if (checkBoxNENHUMEDIT.Checked)
                {
                    mode = "none";
                }
                else
                {
                    mode = "dynamic-keys";
                    if (checkBoxWPA2PSKEDIT.Checked)
                    {
                        wpa2psk = "wpa2-psk";
                        if (string.IsNullOrWhiteSpace(textBoxWPA2KEYEDIT.Text))
                        {
                            MessageBox.Show("Preencha a key do WPA2");
                            return;
                        }
                        else
                        {
                            if (textBoxWPA2KEYEDIT.TextLength > 64 || textBoxWPA2KEYEDIT.TextLength < 8)
                            {
                                MessageBox.Show("O tamanho da chave tem de ter no mínimo 8 caracteres e no máximo 64 ");
                                return;
                            }
                            keywpa2sk = textBoxWPA2KEYEDIT.Text.Trim();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha o tipo de autenticação");
                        return;
                    }
                }

                string selectedItemText = comboBoxSelectPerfil.Items[comboBoxSelectPerfil.SelectedIndex].ToString();
                string perfilID = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                string nome = textBoxnewName.Text.Trim();

                var requestBody = new JObject();
                requestBody[".id"] = perfilID;
                requestBody["mode"] = mode;
                requestBody["name"] = nome;
                requestBody["authentication-types"] = wpa2psk;
                requestBody["wpa2-pre-shared-key"] = keywpa2sk;
                requestBody["comment"] = textBoxComentarioEdit.Text;

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    string url = $"http://{routerIp}/rest/interface/wireless/security-profiles/set";

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Perfil editado com sucesso.");
                        textBoxnewName.Clear();
                        checkBoxNENHUMEDIT.Checked = false;
                        checkBoxDINAMICOEDIT.Checked = false;
                        checkBoxWPA2PSKEDIT.Checked = false;
                        textBoxWPA2KEYEDIT.Clear();
                        textBoxComentarioEdit.Clear();
                        await LoadPerfis();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Falha ao editar Perfil. Erro: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar o Perfil: " + ex.Message);
            }
        }

        private void perfilSegurançaForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + Environment.NewLine + model;
        }

        private async Task LoadEdit()
        {
            try
            {
                textBoxnewName.Clear();
                textBoxWPA2KEYEDIT.Clear();
                textBoxComentarioEdit.Clear();
                checkBoxNENHUMEDIT.Checked = false;
                checkBoxDINAMICOEDIT.Checked = false;
                checkBoxWPA2PSKEDIT.Checked = false;

                string url = $"http://{routerIp}/rest/interface/wireless/security-profiles";

                using (HttpClient client = new HttpClient())
                {
                    var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (comboBoxSelectPerfil.SelectedIndex == -1)
                    {
                        MessageBox.Show("Selecione um perfil de segurança para editar");
                    }

                    string selectedItemText = comboBoxSelectPerfil.Items[comboBoxSelectPerfil.SelectedIndex].ToString();
                    string endIPId = selectedItemText.Substring(selectedItemText.IndexOf("ID:") + 3).Split(';')[0].Trim();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrEmpty(responseBody))
                        {
                            listBoxPerfis.Items.Add("Não foram encontrados perfis");
                            return;
                        }

                        JArray routesArray = JArray.Parse(responseBody);

                        foreach (JObject routeObject in routesArray)
                        {
                            string id = routeObject.Value<string>(".id");

                            if (endIPId == id)
                            {
                                string tipoautenticacao = routeObject.Value<string>("authentication-types");
                                string modo = routeObject.Value<string>("mode");
                                string nomeperfil = routeObject.Value<string>("name");
                                string key = routeObject.Value<string>("wpa2-pre-shared-key");

                                textBoxnewName.Text = nomeperfil;

                                if (tipoautenticacao == "wpa2-psk")
                                {
                                    checkBoxWPA2PSKEDIT.Checked = true;
                                }

                                if(modo == "")
                                {
                                    checkBoxNENHUMEDIT.Checked = true;
                                }else if(modo == "dynamic-keys")
                                {
                                    checkBoxDINAMICOEDIT.Checked = true;
                                }


                                if (routeObject.ContainsKey("wpa2-pre-shared-key"))
                                {
                                    string comentario = routeObject.Value<string>("wpa2-pre-shared-key");
                                    textBoxWPA2KEYEDIT.Text = key;
                                }

                                if (routeObject.ContainsKey("comment"))
                                {
                                    string comentario = routeObject.Value<string>("comment");
                                    textBoxComentarioEdit.Text = comentario;
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

        private async void comboBoxSelectPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadEdit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            redesWirelessForm redesWirelessForm = new redesWirelessForm();
            redesWirelessForm.SetCredentials(routerIp, username, password, model);
            redesWirelessForm.Show();
            this.Dispose();
        }
    }
}

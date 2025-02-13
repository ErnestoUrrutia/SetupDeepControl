using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

using Microsoft.Win32.TaskScheduler;
using System.Security.Cryptography;
namespace SetupDeepControl
{
    public partial class SetupForm : Form
    {
        bool instalacion = true;
        private static readonly string ClaveAES = "NA0407MaP1812182";
        public SetupForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ToolTip toolTip1 = new ToolTip();

            toolTip1.SetToolTip(infoOrganizacion, "En este campo se coloca el nombre de la organización que controla las salas de computo o estaciones\r\nEjemplo: \"Departamento de Sistemas\"");
            toolTip1.SetToolTip(infoServer, "En este campo se coloca la direccion IP donde se encuentra corriendo el servidor DeepControl\r\nEjemplo: \"192.168.1.200\"");
            toolTip1.SetToolTip(infoPuerto, "En este campo se coloca el puerto de trabajo entre servidor y semilla\r\nSe recomienda usar el default: \"47474\" Para caracteristicas adicionales se utilizará también el puerto+1, en caso de dejar el valor default  47474 tambien se ocupará 47475");
            toolTip1.SetToolTip(infoPC, "En este campo se coloca el nombre de la maquina o estación en la cual se esta instalando, de esta forma será visualizada en el servidor\r\nEjemplo: \"PC10\"");
            toolTip1.SetToolTip(infoGrupo, "En este campo se coloca el nombre de la sala o grupo de trabajo, de esta forma será agrupado con las estaciones de su misma area \r\nEjemplo: \"SALA01\"");
            toolTip1.SetToolTip(infoInventario, "En este campo se coloca el número de inventario(de ser necesario), con la finalidad de llevar un control más especifico del equipo o estación \r\nEjemplo: \"INV0102\" \r\nEn caso de no ser requerido colocar \"N/A\"");
            toolTip1.SetToolTip(btnDesinstalar, "Desinstalar");

            //System.Threading.Tasks.Task.Run(() => moverBarra(50));

            string keyName = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
            string valueName = "UpdateDeepControl";

            try
            {
                // Eliminar en HKEY_CURRENT_USER
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
                {
                    if (key != null && key.GetValue(valueName) != null)
                    {
                        key.DeleteValue(valueName);
                        Console.WriteLine("Clave eliminada en HKEY_CURRENT_USER.");
                    }
                }

                // Eliminar en HKEY_LOCAL_MACHINE (requiere permisos de administrador)
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
                {
                    if (key != null && key.GetValue(valueName) != null)
                    {
                        key.DeleteValue(valueName);
                        Console.WriteLine("Clave eliminada en HKEY_LOCAL_MACHINE.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


        }
        public void moverBarra(int incremento)
        {
            Thread.Sleep(2000);
            for (int i = progressBar1.Value; i <= incremento; i++)
            {
                 progressBar1.Value += i;
                 Thread.Sleep(1);
            }
        }

        public bool CrearTarea()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    var task = ts.NewTask();
                    task.RegistrationInfo.Description = "DeepObserver visor de DeepControl";
                    task.Principal.UserId = "SYSTEM";
                    task.Principal.LogonType = TaskLogonType.ServiceAccount;
                    var trigger = new BootTrigger();
                    task.Triggers.Add(trigger);
                    var exec = new ExecAction(@"C:\Windows\System32\DeepObserver.exe", null, null);
                    task.Actions.Add(exec);
                    const string taskName = "DeepObserver";
                    ts.RootFolder.RegisterTaskDefinition(taskName, task);
                    var registeredTask = ts.GetTask(taskName);
                    return registeredTask != null;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void LogMessage(string message)
        {
            richTextBox1.AppendText(message + Environment.NewLine);

        }
        private void LogMessage(string text, Color color)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionColor = color;
            richTextBox1.AppendText(text + Environment.NewLine);
            richTextBox1.SelectionColor = Color.Black;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("taskkill", $"/f /im DeepObserver.exe");
            Process.Start("taskkill", $"/f /im DeepControl.exe");
            Thread.Sleep(2000);
            int progreso = 12;
            progressBar1.Value = 0;


            string appPathDeep = @"C:\Windows\System32\DeepControl.exe";
            string appNameDeep = "DeepControl";


            /*************************************************************************************************************************************/
            CrearTarea();
            moverBarra(progreso);

            /*************************************************************************************************************************************/
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue(appNameDeep, "\"" + appPathDeep + "\"");
                string value = (string)key.GetValue(appNameDeep);
                if (value != null && value.Equals("\"" + appPathDeep + "\""))
                {
                    LogMessage("Programa agregado correctamente al arranque.", Color.Green);
                    moverBarra(progreso);
                }
                else
                {
                    LogMessage("No se pudo agregar el programa al arranque.", Color.Red);
                    instalacion = false;
                }
                
            }
            catch (Exception ex)
            {
                LogMessage("Ocurrió un error: " + ex, Color.Red);
                instalacion = false;
            }



            /*************************************************************************************************************************************/
            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SetupDeepControl.DeepControl.exe"))
                {
                    using (FileStream fileStream = new FileStream(appPathDeep, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                }

                if (File.Exists(appPathDeep))
                {
                    LogMessage("El archivo Deep fue copiado exitosamente", Color.Green);
                    moverBarra(progreso);
                }
                else
                {
                    LogMessage("La copia del archivo Deep falló", Color.Red);
                    instalacion = false;
                }


            }
            catch (Exception ex)
            {
                LogMessage("Ocurrió un error: " + ex, Color.Red);
                instalacion = false;
            }


            /*************************************************************************************************************************************/
            string ObserverPath = @"C:\Windows\System32\DeepObserver.exe";
            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SetupDeepControl.DeepObserver.exe"))
                {
                    using (FileStream fileStream = new FileStream(ObserverPath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                }

                if (File.Exists(ObserverPath))
                {
                    LogMessage("El archivo Observer fue copiado exitosamente", Color.Green);
                    moverBarra(progreso);
                }
                else
                {
                    LogMessage("La copia del archivo Observer falló", Color.Red);
                    instalacion = false;
                }


            }
            catch (Exception ex)
            {
                LogMessage("Ocurrió un error: " + ex, Color.Red);
                instalacion = false;
            }

            /*************************************************************************************************************************************/
            if (txtIPserver.Text != "" && txtPuerto.Text != "" && txtOrganizacion.Text != "" && txtNombrePC.Text != "" && txtGrupo.Text != "" && txtInventario.Text != "")
            {
                try
                {
                    CrearArchivoConfiguracion("C:\\Windows\\System32\\DeepControlConfig.xml", txtIPserver.Text, txtPuerto.Text, txtOrganizacion.Text, txtNombrePC.Text, txtGrupo.Text, txtInventario.Text);
                    LogMessage("Archivo DeepControlConfig.xml escrito correctamente", Color.Green);
                    moverBarra(progreso);
                }
                catch (Exception ex)
                {
                    LogMessage("El archivo  DeepControlConfig.xml no se generó correctamente ", Color.Red);
                    instalacion = false;
                }
            }
            else
            {
                MessageBox.Show("No pueden quedar vacios los campos");
            }
            if (instalacion)
            {
                DialogResult result = MessageBox.Show("¿Deseas Reiniciar en este momento?", "La instalación fue exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo("shutdown", "/r /f /t 0")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error durante el proceso de la instalación\nSe recomienda ejecutar el instalador con privilegios de administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        
        public void CrearArchivoConfiguracion(string rutaArchivo, string servidorIP, string puerto, string organizacion, string nombrePC, string grupoPC, string inventarioPC)
        {
            // Crear el documento XML con la estructura deseada
            XDocument configuracionXml = new XDocument(
                new XElement("configuration",
                    new XElement("appSettings",
                        new XElement("add", new XAttribute("key", "ServidorIP"), new XAttribute("value", servidorIP)),
                        new XElement("add", new XAttribute("key", "Puerto"), new XAttribute("value", puerto.ToString())),
                        new XElement("add", new XAttribute("key", "Organizacion"), new XAttribute("value", organizacion)),
                        new XElement("add", new XAttribute("key", "NombrePC"), new XAttribute("value", nombrePC)),
                        new XElement("add", new XAttribute("key", "GrupoPC"), new XAttribute("value", grupoPC)),
                        new XElement("add", new XAttribute("key", "InventarioPC"), new XAttribute("value", inventarioPC))
                    )
                )
            );

            // Guardar el documento en la ruta especificada
            configuracionXml.Save(rutaArchivo);
            string xmlString = configuracionXml.ToString();

            // Encriptar el XML y guardarlo en el archivo
            string encryptedXml = EncriptarAES(xmlString, ClaveAES);
            File.WriteAllText(rutaArchivo, encryptedXml);
        }

        private string EncriptarAES(string textoPlano, string clave)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(clave.PadRight(32).Substring(0, 32)); // Clave de 256 bits
                aes.IV = new byte[16]; // Vector de inicialización (IV) en ceros (para simplificar)

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] bytesTexto = Encoding.UTF8.GetBytes(textoPlano);
                    cs.Write(bytesTexto, 0, bytesTexto.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public bool EliminarTarea()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    const string taskName = "DeepObserver";

                    // Buscar y eliminar la tarea si existe
                    var task = ts.GetTask(taskName);
                    if (task != null)
                    {
                        ts.RootFolder.DeleteTask(taskName);
                        LogMessage("Tarea DeepObserver eliminada correctamente.", Color.Green);
                        return true;
                    }
                    else
                    {
                        LogMessage("La tarea DeepObserver no se encontró.", Color.Red);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error al eliminar la tarea: {ex.Message}", Color.Red);
                return false;
            }
        }

        private void btnDesinstalar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas desinstalar DeepControl?", "Desinstalación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool desinstalacionExitosa = true;
                string[] archivosAEliminar = {

                    @"C:\Windows\System32\DeepControlConfig.xml",
                    @"C:\Windows\System32\DeepObserver.exe",
                    @"C:\Windows\System32\DeepControl.exe"
                };

                try
                {
                    // Terminar los procesos relacionados
                    Process.Start("taskkill", "/f /im DeepObserver.exe");
                    Process.Start("taskkill", "/f /im DeepControl.exe");
                    Thread.Sleep(2000);

                    // Eliminar archivos
                    foreach (string archivo in archivosAEliminar)
                    {
                        if (File.Exists(archivo))
                        {
                            File.Delete(archivo);
                            LogMessage($"Archivo {archivo} eliminado.", Color.Green);
                        }
                    }

                    // Eliminar directorio
                    string carpetaInstalacion = @"C:\Deep";
                    if (Directory.Exists(carpetaInstalacion))
                    {
                        Directory.Delete(carpetaInstalacion, true);
                        LogMessage("Carpeta de instalación eliminada.", Color.Green);
                    }

                    // Eliminar entrada del registro para inicio automático
                    string appName = "DeepControl";
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                    {
                        if (key.GetValue(appName) != null)
                        {
                            key.DeleteValue(appName);
                            LogMessage("Entrada de registro de inicio automático eliminada.", Color.Green);
                        }
                    }
                    if (EliminarTarea())
                    {
                        LogMessage("Entrada de registro de tarea eliminada.", Color.Green);
                    }
                    else
                    {
                        LogMessage("Error al eliminar registro de tarea ", Color.Red);
                    }

                    LogMessage("Desinstalación completada correctamente.", Color.Green);
                }
                catch (Exception ex)
                {
                    desinstalacionExitosa = false;
                    LogMessage($"Error durante la desinstalación: {ex.Message}", Color.Red);
                }

                // Mostrar mensaje final
                if (desinstalacionExitosa)
                {
                    progressBar1.Value = 100;
                    MessageBox.Show("Desinstalación completada con éxito.", "Desinstalación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La desinstalación no se completó correctamente. Revisa los permisos o ejecuta como administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                this.Close();
            }


        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnInstalar.Enabled = chkActivar.Checked;
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            btnInstalar.Enabled = false;
            txtOrganizacion.Focus();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}







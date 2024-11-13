using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

using Microsoft.Win32.TaskScheduler;
namespace SetupDeepControl
{
    public partial class SetupForm : Form
    {
        bool instalacion = true;
        public SetupForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ToolTip toolTip1 = new ToolTip();

            toolTip1.SetToolTip(infoOrganizacion, "En este campo se coloca el nombre de la organizaci�n que controla las salas de computo o estaciones\r\nEjemplo: \"Departamento de Sistemas\"");
            toolTip1.SetToolTip(infoServer, "En este campo se coloca la direccion IP donde se encuentra corriendo el servidor DeepControl\r\nEjemplo: 192.168.1.200\"");
            toolTip1.SetToolTip(infoPuerto, "En este campo se coloca el puerto de trabajo entre servidor y semilla\r\nSe recomienda usar el default: 47373");
            toolTip1.SetToolTip(infoPC, "En este campo se coloca el nombre de la maquina o estaci�n en la cual se esta instalando, de esta forma ser� visualizada en el servidor\r\nEjemplo: \"PC10\"");
            toolTip1.SetToolTip(infoGrupo, "En este campo se coloca el nombre de la sala o grupo de trabajo, de esta forma ser� agrupado con las estaciones de su misma area \r\nEjemplo: \"SALA01\"");
            toolTip1.SetToolTip(infoInventario, "En este campo se coloca el n�mero de inventario(de ser necesario), con la finalidad de llevar un control m�s especifico del equipo o estaci�n \r\nEjemplo: \"INV0102\" \r\nEn caso de no ser requerido colocar \"N/A\"");
            toolTip1.SetToolTip(btnDesinstalar, "Desinstalar");
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
            int progreso = 14;
            progressBar1.Value += progreso;


            string UpdatePath = @"C:\Windows\System32\UpdateDeepControl.exe";
            string appName = "UpdateDeepControl";
     
            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SetupDeepControl.UpdateDeepControl.exe"))
                {
                    using (FileStream fileStream = new FileStream(UpdatePath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
                if (File.Exists(UpdatePath))
                {
                    LogMessage("El archivo Update fue copiado exitosamente a System32.", Color.Green);
                    progressBar1.Value += progreso;
                }
                else
                {
                    LogMessage("La copia del archivo Update a System32 fall�.", Color.Red);
                    instalacion = false;
                }
            }
            catch (UnauthorizedAccessException)
            {
                LogMessage("Error: No se tienen permisos suficientes para copiar el archivo a System32.", Color.Red);
                instalacion = false;
            }
            catch (Exception ex)
            {
                LogMessage($"Error al copiar el archivo: {ex.Message}", Color.Red);
                instalacion = false;

            }
            CrearTarea();
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue(appName, "\"" + UpdatePath + "\"");
                string value = (string)key.GetValue(appName);
                if (value != null && value.Equals("\"" + UpdatePath + "\""))
                {
                    LogMessage("Programa agregado correctamente al arranque.", Color.Green);
                    progressBar1.Value += progreso;
                }
                else
                {
                    LogMessage("No se pudo agregar el programa al arranque.", Color.Red);
                    instalacion = false;
                }
            }
            catch (Exception ex)
            {

                LogMessage("Ocurri� un error: " + ex, Color.Red);
                instalacion = false;
            }


            try
            {
                if (!Directory.Exists(@"C:\Deep"))
                {
                    Directory.CreateDirectory(@"C:\Deep");
                    LogMessage("Carpeta de instalaci�n creada exitosamente", Color.Green);
                }
                else
                {
                    LogMessage("La carpeta ya existe.", Color.Green);
                }

                progressBar1.Value += progreso;
            }
            catch (Exception ex)
            {
                LogMessage("Ocurri� un error: " + ex, Color.Red);
                instalacion = false;
            }




            string DeepPath = @"C:\Deep\DeepControl.exe";
            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SetupDeepControl.DeepControl.exe"))
                {
                    using (FileStream fileStream = new FileStream(DeepPath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                }

                if (File.Exists(DeepPath))
                {
                    LogMessage("El archivo Deep fue copiado exitosamente", Color.Green);
                    progressBar1.Value += progreso;
                }
                else
                {
                    LogMessage("La copia del archivo Deep fall�", Color.Red);
                    instalacion = false;
                }


            }
            catch (Exception ex)
            {
                LogMessage("Ocurri� un error: "+ex, Color.Red);
                instalacion = false;
            }

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
                    progressBar1.Value += progreso;
                }
                else
                {
                    LogMessage("La copia del archivo Observer fall�", Color.Red);
                    instalacion = false;
                }


            }
            catch (Exception ex)
            {
                LogMessage("Ocurri� un error: " + ex, Color.Red);
                instalacion = false;
            }

            /************/
            if (txtIPserver.Text != "" && txtPuerto.Text != "" && txtOrganizacion.Text != "" && txtNombrePC.Text != "" && txtGrupo.Text != "" && txtInventario.Text != "")
            {
                try
                {
                    CrearArchivoConfiguracion("C:\\Windows\\System32\\DeepControlConfig.xml", txtIPserver.Text, txtPuerto.Text, txtOrganizacion.Text, txtNombrePC.Text, txtGrupo.Text, txtInventario.Text);
                    LogMessage("Archivo DeepControlConfig.xml escrito correctamente", Color.Green);
                    progressBar1.Value += progreso;
                }
                catch (Exception ex)
                {
                    LogMessage("El archivo  DeepControlConfig.xml no se gener� correctamente ", Color.Red);
                    instalacion = false;
                }
            }
            else
            {
                MessageBox.Show("No pueden quedar vacios los campos");
            }
            if (instalacion)
            {
                DialogResult result = MessageBox.Show("�Deseas Reiniciar en este momento?", "La instalaci�n fue exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                MessageBox.Show("Ocurri� un error durante el proceso de la instalaci�n\nSe recomienda ejecutar el instalador con privilegios de administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        LogMessage("La tarea DeepObserver no se encontr�.", Color.Red);
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
            DialogResult result = MessageBox.Show("�Deseas desinstalar DeepControl?", "Desinstalaci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool desinstalacionExitosa = true;
                string[] archivosAEliminar = {
                    @"C:\Windows\System32\UpdateDeepControl.exe",
                    @"C:\Windows\System32\DeepControlConfig.xml",
                    @"C:\Windows\System32\DeepObserver.exe",
                    @"C:\Deep\DeepControl.exe"
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
                        LogMessage("Carpeta de instalaci�n eliminada.", Color.Green);
                    }

                    // Eliminar entrada del registro para inicio autom�tico
                    string appName = "UpdateDeepControl";
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                    {
                        if (key.GetValue(appName) != null)
                        {
                            key.DeleteValue(appName);
                            LogMessage("Entrada de registro de inicio autom�tico eliminada.", Color.Green);
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

                    LogMessage("Desinstalaci�n completada correctamente.", Color.Green);
                }
                catch (Exception ex)
                {
                    desinstalacionExitosa = false;
                    LogMessage($"Error durante la desinstalaci�n: {ex.Message}", Color.Red);
                }

                // Mostrar mensaje final
                if (desinstalacionExitosa)
                {
                    progressBar1.Value=100;
                    MessageBox.Show("Desinstalaci�n completada con �xito.", "Desinstalaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La desinstalaci�n no se complet� correctamente. Revisa los permisos o ejecuta como administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                this.Close();
            }
           

        }
    }
}







using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
namespace SetupDeepControl
{
    public partial class Form1 : Form
    {
        bool instalacion = true;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;


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
            int progreso = 15;
            progressBar1.Value += progreso;

            string system32Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "UpdateDeepControl.exe");
            string sourceFilePath = "UpdateDeepControl.exe";
            string appPath = @"C:\Windows\System32\UpdateDeepControl.exe";
            string appName = "UpdateDeepControl";
            try
            {
                File.Copy(sourceFilePath, system32Path, true);
                if (File.Exists(system32Path))
                {
                    LogMessage("El archivo fue copiado exitosamente a System32.", Color.Green);
                    progressBar1.Value += progreso;
                }
                else
                {
                    LogMessage("La copia del archivo a System32 fall�.", Color.Red);
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

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue(appName, "\"" + appPath + "\"");
                string value = (string)key.GetValue(appName);
                if (value != null && value.Equals("\"" + appPath + "\""))
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

                LogMessage($"Error al agregar al registro: {ex.Message}", Color.Red);
                instalacion = false;
            }


            try
            {
                // Crea la carpeta
                Directory.CreateDirectory(@"C:\Deep");
                LogMessage("Carpeta de instalaci�n creada exitosamente", Color.Green);
                progressBar1.Value += progreso;
            }
            catch (Exception ex)
            {
                LogMessage("Error al crear carpeta de instalaci�n", Color.Red);
                instalacion = false;
            }
            string sourceExePath = "DeepControl.exe"; // Ruta del archivo .exe
            string sourceIcoPath = "logotipo.ico"; // Ruta del archivo .ico
            string destinationPath = @"C:\Deep"; // Ruta de destino

            try
            {
                // Aseg�rate de que la carpeta de destino exista
                Directory.CreateDirectory(destinationPath);

                // Copiar el archivo .exe
                string exeFileName = Path.GetFileName(sourceExePath);
                string exeDestinationPath = Path.Combine(destinationPath, exeFileName);
                File.Copy(sourceExePath, exeDestinationPath, true); // true para sobrescribir si existe
                Console.WriteLine("Archivo .exe copiado a: " + exeDestinationPath);

                // Verificar si se copi� correctamente
                if (File.Exists(exeDestinationPath))
                {
                    LogMessage("Verificaci�n: Archivo DeepControl.exe copiado exitosamente.", Color.Green);
                    progressBar1.Value += progreso;
                }
                else
                {
                    LogMessage("Error: El archivo DeepControl.exe no se copi�.", Color.Red);
                    instalacion = false;
                }

                // Copiar el archivo .ico
                string icoFileName = Path.GetFileName(sourceIcoPath);
                string icoDestinationPath = Path.Combine(destinationPath, icoFileName);
                File.Copy(sourceIcoPath, icoDestinationPath, true); // true para sobrescribir si existe


                // Verificar si se copi� correctamente
                if (File.Exists(icoDestinationPath))
                {
                    LogMessage("Verificaci�n: Archivo logotipo.ico copiado exitosamente.", Color.Green);
                    progressBar1.Value += progreso;
                }
                else
                {
                    LogMessage("Error: El archivo logotipo.ico no se copi�.", Color.Red);
                    instalacion = false;
                }
            }
            catch (Exception ex)
            {
                LogMessage("Ocurri� un error: ", Color.Red);
                instalacion = false;
            }


            /************/
            if (txtIPserver.Text != "" && txtPuerto.Text != "" && txtOrganizacion.Text != "" && txtNombrePC.Text != "" && txtGrupo.Text != "" && txtInventario.Text != "")
            {
                try
                {
                    CrearArchivoConfiguracion("C:\\Windows\\System32\\DeepControlConfig.xml", txtIPserver.Text, txtPuerto.Text, txtOrganizacion.Text, txtNombrePC.Text, txtGrupo.Text, txtInventario.Text);
                    LogMessage("Verificaci�n: Archivo DeepControlConfig.xml escrito correctamente", Color.Green);
                    progressBar1.Value += progreso;
                }
                catch (Exception ex)
                {
                    LogMessage("Error: El archivo  DeepControlConfig.xml no se gener� correctamente.", Color.Red);
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


    }
}







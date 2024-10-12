using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
namespace SetupDeepControl
{
    public partial class Form1 : Form
    {
        bool instalacion = true;
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Desactiva el botón de maximizar
            string ip = "192.168.1.1";
            string port = "8080";

            // Codificar en Base64
            string encodedIp = Convert.ToBase64String(Encoding.UTF8.GetBytes(ip));
            string encodedPort = Convert.ToBase64String(Encoding.UTF8.GetBytes(port));

            // Guardar en archivo .ini
            File.WriteAllText("config.ini", $"ip={encodedIp}\nport={encodedPort}");



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
         
            string system32Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "UpdateDeepControl.exe");
            string sourceFilePath = "UpdateDeepControl.exe";
            string appPath = @"C:\Windows\System32\UpdateDeepControl.exe";
            string appName = "UpdateDeepControl";
            try
            {
                File.Copy(sourceFilePath, system32Path, true);
                if (File.Exists(system32Path))
                {
                    LogMessage("El archivo fue copiado exitosamente a System32.",Color.Green);
                }
                else
                {
                    LogMessage("La copia del archivo a System32 falló.",Color.Red);
                    instalacion = false;
                    
                }
            }
            catch (UnauthorizedAccessException)
            {
                LogMessage("Error: No se tienen permisos suficientes para copiar el archivo a System32.",Color.Red);
                instalacion = false;
            }
            catch (Exception ex)
            {
                LogMessage($"Error al copiar el archivo: {ex.Message}",Color.Red);
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
                LogMessage("Carpeta de instalación creada exitosamente",Color.Green);
            }
            catch (Exception ex)
            {
                LogMessage("Error al crear carpeta de instalación", Color.Red);
            }
            string sourceExePath = "DeepControl.exe"; // Ruta del archivo .exe
            string sourceIcoPath = "logotipo.ico"; // Ruta del archivo .ico
            string destinationPath = @"C:\Deep"; // Ruta de destino

            try
            {
                // Asegúrate de que la carpeta de destino exista
                Directory.CreateDirectory(destinationPath);

                // Copiar el archivo .exe
                string exeFileName = Path.GetFileName(sourceExePath);
                string exeDestinationPath = Path.Combine(destinationPath, exeFileName);
                File.Copy(sourceExePath, exeDestinationPath, true); // true para sobrescribir si existe
                Console.WriteLine("Archivo .exe copiado a: " + exeDestinationPath);

                // Verificar si se copió correctamente
                if (File.Exists(exeDestinationPath))
                {
                    LogMessage("Verificación: Archivo DeepControl.exe copiado exitosamente.", Color.Green);
                }
                else
                {
                    LogMessage("Error: El archivo DeepControl.exe no se copió.", Color.Red);
                    instalacion = false;
                }

                // Copiar el archivo .ico
                string icoFileName = Path.GetFileName(sourceIcoPath);
                string icoDestinationPath = Path.Combine(destinationPath, icoFileName);
                File.Copy(sourceIcoPath, icoDestinationPath, true); // true para sobrescribir si existe
             

                // Verificar si se copió correctamente
                if (File.Exists(icoDestinationPath))
                {
                    LogMessage("Verificación: Archivo logotipo.ico copiado exitosamente.", Color.Green);
                }
                else
                {
                    LogMessage("Error: El archivo logotipo.ico no se copió.", Color.Red);
                    instalacion = false;
                }
            }
            catch (Exception ex)
            {
                LogMessage("Ocurrió un error: ", Color.Red);
                instalacion = false;
            }
            if(instalacion)
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
                MessageBox.Show("Ocurrió un error durante el proceso de la instalación\nSe recomienda ejecutar el instalador con privilegios de administrador" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}







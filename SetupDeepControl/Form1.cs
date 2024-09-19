using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;
namespace SetupDeepControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void LogMessage(string message)
        {
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new Action(() => textBoxLog.AppendText(message + Environment.NewLine)));
            }
            else
            {
                textBoxLog.AppendText(message + Environment.NewLine);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string system32Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "update_chek.exe");
            LogMessage(system32Path);
            // Ruta de origen del archivo que se quiere copiar
            string sourceFilePath = @"update_chek.exe";
            try
            {
                // Copiar el archivo a System32
                File.Copy(sourceFilePath, system32Path, true); // true para sobrescribir si ya existe

                // Verificar si la copia fue exitosa
                if (File.Exists(system32Path))
                {
                    LogMessage("El archivo fue copiado exitosamente a System32.");
                }
                else
                {
                    LogMessage("La copia del archivo a System32 falló.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                LogMessage("Error: No se tienen permisos suficientes para copiar el archivo a System32.");
            }
            catch (Exception ex)
            {
                LogMessage($"Error al copiar el archivo: {ex.Message}");
            }
        }
    }
}







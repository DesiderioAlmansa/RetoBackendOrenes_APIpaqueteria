using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetoBackendOrenes.WinformsPrueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnAñadirPedido_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxIdVehiculo1.Text) || String.IsNullOrEmpty(textBoxNumVehiculo1.Text))
            {
                labelAvisos.ForeColor = Color.Red;
                labelAvisos.Text = "Debe introducir los datos.";
            }
            else
            {
                var url = $"https://localhost:44379/api/pedido/asignarVehiculo/" + textBoxNumVehiculo1.Text + "/" + textBoxIdVehiculo1.Text ;
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "PUT";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                // Do something with responseBody
                                labelAvisos.ForeColor = Color.Green;
                                labelAvisos.Text = responseBody;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    labelAvisos.ForeColor = Color.Red;
                    labelAvisos.Text = "No se ha podido asignar el vehiculo al pedido, asegurese de que todos los datos sean correctos.";
                }
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxIdVehiculo2.Text) || String.IsNullOrEmpty(textBoxUbicacion2.Text)) {
                labelAvisos.ForeColor = Color.Red;
                labelAvisos.Text = "Debe introducir los datos.";
            }
            else
            {
                var url = $"https://localhost:44379/api/vehiculo/cambiaubicacion/" + textBoxIdVehiculo2.Text + "/"+ textBoxUbicacion2.Text;
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "PUT";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                // Do something with responseBody
                                labelAvisos.ForeColor = Color.Green;
                                labelAvisos.Text = responseBody;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    labelAvisos.ForeColor = Color.Red;
                    labelAvisos.Text = "No se ha podido actualizar la ubicación, asegurese de que todos los datos sean correctos.";
                }
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {///
            if (String.IsNullOrEmpty(textBoxNumPedido3.Text))
            {
                labelAvisos.ForeColor = Color.Red;
                labelAvisos.Text = "Debe introducir los datos.";
            }
            else
            {
                var url = $"https://localhost:44379/api/pedido/obtenerVehiculo/" + textBoxNumPedido3.Text;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                labelAvisos.ForeColor = Color.Green;

                                dynamic jsonObj = JsonConvert.DeserializeObject(responseBody);
                                textBoxIdVehiculo3.Text = jsonObj["vehiculoId"].ToString();
                                textBoxUbicacion3.Text = jsonObj["ubicacionActual"].ToString();

                                labelAvisos.Text = "Se ha encontrado el pedido.";
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    labelAvisos.ForeColor = Color.Red;
                    labelAvisos.Text = "No se ha encontrado el pedido, asegurese de que todos los datos sean correctos.";
                }
            }
        }
    }
}

using PROYECTO.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PROYECTO
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            llenardatos();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            //  var emple = new empleado
            // {
            //   codigo = int.Parse(txtcodigo.Text),
            // nombre = txtnombre.Text,
            //pais = txtpais.Text,
            //departamento= txtdepartamento.Text,
            //municipio= txtmunicipio.Text,
            //residencia=txtresidencia.Text,
            //};

            if (validardatos())
            {
                empleado emple = new empleado
                {
                    
                    nombre = txtnombre.Text,
                    pais = txtpais.Text,
                    departamento = txtdepartamento.Text,
                    municipio = txtmunicipio.Text,
                    residencia = txtresidencia.Text,
                };
                await App.Database.saveempleAsync(emple);
               
                await DisplayAlert("Registrado", "Ingresado con Exito", "OK"); 
                limpiarcontroles();
                llenardatos();

            }
            else
            {
                await DisplayAlert("Advertencia", "Debe de lenar todo los campos", "OK");
            }

            // if (await App.Database.saveemple(emple) > 0)
            // {
            //    await DisplayAlert("Ingresado", "Ingresado con Exito", "OK");
            // }

            //var secondpage = new Pageresultado();
            //secondpage.BindingContext = emple;
            //Navigation.PushAsync(secondpage);

        }

        public async void llenardatos()
        {
            var emplelist = await App.Database.GetEmpleadosAsync();
            if (emplelist != null)
            {
                listempleado.ItemsSource = emplelist;
            }

        }
        public bool validardatos()
        {
            bool respuesta;
            
            if (string.IsNullOrEmpty(txtnombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtpais.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtdepartamento.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtmunicipio.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtresidencia.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcodigo.Text))
            {
                empleado empleado = new empleado()
                {
                    codigo = Convert.ToInt32(txtcodigo.Text),
                    nombre = txtnombre.Text,
                    pais = txtpais.Text,
                    departamento = txtdepartamento.Text,
                    municipio = txtmunicipio.Text,
                    residencia = txtresidencia.Text,
            };
                await App.Database.saveempleAsync(empleado);
                await DisplayAlert("Actualizacion", "Actualizado con Exito", "OK");
                limpiarcontroles();
                txtcodigo.IsVisible= true;
                btnactualizar.IsVisible= false;
                btnguardar.IsVisible= true;
                llenardatos();
                
            }
        }

        private async void listempleado_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (empleado)e.SelectedItem;
            btnguardar.IsVisible = false;
            txtcodigo.IsVisible = true;
            btnactualizar.IsVisible = true;
            btneliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.codigo.ToString()))
            {
                var empleado = await App.Database.GetEmpleadoByIdAsync(obj.codigo);
                if (empleado != null)
                {
                    txtcodigo.Text = empleado.codigo.ToString();
                    txtnombre.Text = empleado.nombre;
                    txtpais.Text = empleado.pais;
                    txtdepartamento.Text = empleado.departamento;
                    txtmunicipio.Text = empleado.municipio;
                    txtresidencia.Text = empleado.residencia;
                }
            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var empleado = await App.Database.GetEmpleadoByIdAsync(Convert.ToInt32(txtcodigo.Text));
            if (empleado != null)
            {
                await App.Database.DeleteEmple(empleado);
                await DisplayAlert("Eliminar", "Se Elimino de manera Exitosa", "OK");
                limpiarcontroles();
                llenardatos();
                txtcodigo.IsVisible = true;
                btnactualizar.IsVisible = false;
                btneliminar.IsVisible = false;
                btnguardar.IsVisible = true;
            }
        }

        public void limpiarcontroles()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtpais.Text = "";
            txtdepartamento.Text = "";
            txtmunicipio.Text = "";
            txtresidencia.Text = "";
        }
    }
}

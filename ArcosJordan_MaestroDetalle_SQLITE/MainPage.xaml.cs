using System;
using Microsoft.Maui.Controls;

namespace ArcosJordan_MaestroDetalle_SQLITE
{
    public partial class MainPage : ContentPage
    {
        private MarcaModelo _repositorio = new MarcaModelo();

        public MainPage()
        {
            InitializeComponent();
        }
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombreMarca.Text) ||
                    string.IsNullOrEmpty(txtNombreModelo.Text) ||
                    string.IsNullOrEmpty(txtAño.Text))
                {
                    await DisplayAlertAsync("Atención", "Por favor llene la Marca, Modelo y Año.", "OK");
                    return;
                }

                var nuevoVehiculo = new Modelo
                {
                    nombre_marca = txtNombreMarca.Text,
                    nombre_modelo = txtNombreModelo.Text,
                    año = int.Parse(txtAño.Text)
                };

                var resultado = _repositorio.Create(nuevoVehiculo);

                await DisplayAlertAsync("Éxito", $"Vehículo guardado.\nID Modelo: {resultado.id}\nID Marca: {resultado.id_marca}", "OK");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", "No se pudo guardar: " + ex.Message, "OK");
            }
        }
        private async void btnLeer_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdModelo.Text))
                {
                    await DisplayAlertAsync("Atención", "Por favor, ingresa un ID de Modelo para buscar.", "OK");
                    return;
                }

                int idBuscar = int.Parse(txtIdModelo.Text);
                var modeloEncontrado = _repositorio.GetById(idBuscar);

                if (modeloEncontrado != null)
                {
                    txtIdMarca.Text = modeloEncontrado.id_marca.ToString();
                    txtNombreMarca.Text = modeloEncontrado.nombre_marca;
                    txtNombreModelo.Text = modeloEncontrado.nombre_modelo;
                    txtAño.Text = modeloEncontrado.año.ToString();
                }
                else
                {
                    await DisplayAlertAsync("No encontrado", "No existe ningún modelo con ese ID.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", "Ocurrió un error al buscar: " + ex.Message, "OK");
            }
        }
        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdModelo.Text) || string.IsNullOrEmpty(txtIdMarca.Text))
                {
                    await DisplayAlertAsync("Atención", "Primero debes 'Buscar' el registro usando el ID del Modelo para poder actualizarlo.", "OK");
                    return;
                }

                var vehiculoActualizar = new Modelo
                {
                    id = int.Parse(txtIdModelo.Text),
                    id_marca = int.Parse(txtIdMarca.Text),
                    nombre_marca = txtNombreMarca.Text,
                    nombre_modelo = txtNombreModelo.Text,
                    año = int.Parse(txtAño.Text)
                };

                _repositorio.Update(vehiculoActualizar);
                await DisplayAlertAsync("Éxito", "El registro se actualizó correctamente en ambas tablas.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", "No se pudo actualizar: " + ex.Message, "OK");
            }
        }
        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdModelo.Text))
                {
                    await DisplayAlertAsync("Atención", "Ingresa el ID del Modelo que deseas eliminar.", "OK");
                    return;
                }

                int idEliminar = int.Parse(txtIdModelo.Text);
                bool confirmar = await DisplayAlertAsync("Confirmar", "¿Estás seguro de que deseas eliminar este modelo?", "Sí", "No");

                if (confirmar)
                {
                    _repositorio.Delete(idEliminar);
                    await DisplayAlertAsync("Éxito", "Modelo eliminado correctamente.", "OK");
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", "No se pudo eliminar: " + ex.Message, "OK");
            }
        }
        private void LimpiarCampos()
        {
            txtIdMarca.Text = string.Empty;
            txtNombreMarca.Text = string.Empty;
            txtIdModelo.Text = string.Empty;
            txtNombreModelo.Text = string.Empty;
            txtAño.Text = string.Empty;
        }
    }
}
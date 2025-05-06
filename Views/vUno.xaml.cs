using System.Text.RegularExpressions;

namespace jcorreaT3A.Views;

public partial class vUno : ContentPage
{
	public vUno()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        var tipoId = pickerIdentificacion.SelectedItem?.ToString();
        var numeroId = txtIdentificacion.Text?.Trim();
        var nombres = txtNombre.Text?.Trim();
        var apellidos = txtApellido.Text?.Trim();
        var correo = txtCorreo.Text?.Trim();
        var salario = txtSalario.Text?.Trim();
        var fecha = dateFecha.Date.ToString("yyyy-MM-dd");

        if (string.IsNullOrWhiteSpace(tipoId) || string.IsNullOrWhiteSpace(numeroId) ||
            string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos))
        {
            DisplayAlert("Error", "Complete todos los campos requeridos.", "OK");
            return;
        }

        // Validaciones
        if (tipoId == "CI" && numeroId.Length != 10)
        {
            DisplayAlert("Error", "La CI debe tener 10 dígitos.", "OK");
            return;
        }

        if (tipoId == "RUC" && numeroId.Length != 13)
        {
            DisplayAlert("Error", "El RUC debe tener 13 dígitos.", "OK");
            return;
        }

        if (!string.IsNullOrWhiteSpace(correo) && !Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            DisplayAlert("Error", "Correo no válido.", "OK");
            return;
        }

        DisplayAlert("Contacto Guardado", $"Nombre: {nombres} {apellidos}\nIdentificación: {tipoId} {numeroId}\nCorreo: {correo}\nFecha: {fecha}\nSalario: {salario}", "OK");
        Navigation.PushAsync(new vDos(tipoId, numeroId, nombres, apellidos, fecha, correo, salario));
    }
}
using System.Globalization;

namespace jcorreaT3A.Views;

public partial class vDos : ContentPage
{
	private string contenidoTexto;
    public vDos()
    {
        InitializeComponent();

    }
        public vDos(string tipoId, string numeroId, string nombres, string apellidos, string fecha, string correo, string salarioStr)
    {
        InitializeComponent();

        decimal salario = decimal.TryParse(salarioStr, out var s) ? s : 0;
        decimal aporte = salario * 0.0945m;

        contenidoTexto = $"Nombre: {nombres} {apellidos}\n" +
                         $"Identificación: {tipoId} {numeroId}\n" +
                         $"Fecha Nacimiento: {fecha}\n" +
                         $"Correo: {correo}\n" +
                         $"Salario: {salario.ToString("C", new CultureInfo("en-US"))}\n" +
                         $"Aporte IESS (9.45%): {aporte.ToString("C", new CultureInfo("en-US"))}";

        // Asignar a Labels
        NombreLabel.Text = $"Nombre: {nombres} {apellidos}";
        IdentificacionLabel.Text = $"Identificación: {tipoId} {numeroId}";
        FechaLabel.Text = $"Fecha: {fecha}";
        CorreoLabel.Text = $"Correo: {correo}";
        SalarioLabel.Text = $"Salario: {salario.ToString("C", new CultureInfo("en-US"))}";
        AporteIessLabel.Text = $"Aporte IESS (9.45%): {aporte.ToString("C", new CultureInfo("en-US"))}";
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "contacto.txt");
        File.WriteAllText(filePath, contenidoTexto);

        DisplayAlert("Éxito", $"Archivo guardado en:\n{filePath}", "OK");
    }
}
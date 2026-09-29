// Nombres: Raúl de Jesús Berlanga Martínez
// Números de Control TecNM: I24050400
// Fecha: 29/09/2026

using SoundCore.UI;

namespace SoundCore;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}

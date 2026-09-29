// Nombres: Raúl de Jesús Berlanga Martínez
// Números de Control TecNM: I24050400
// Fecha: 29/09/2026

namespace SoundCore.Modelos;

/// <summary>
/// Registro inmutable que representa una pista musical dentro del setlist del DJ.
/// </summary>
/// <param name="Id">Identificador único y secuencial de la pista.</param>
/// <param name="Titulo">Título de la canción.</param>
/// <param name="Artista">Artista o productor.</param>
/// <param name="Bpm">Beats por minuto (curva de energía armónica).</param>
/// <param name="DuracionSegundos">Duración total de la pista en segundos.</param>
public record Pista(
    int Id,
    string Titulo,
    string Artista,
    int Bpm,
    int DuracionSegundos)
{
    public override string ToString() =>
        $"[{Id:D3}] {Titulo} - {Artista} | {Bpm} BPM";
}

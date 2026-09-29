// Nombres: Raúl de Jesús Berlanga Martínez
// Números de Control TecNM: I24050400
// Fecha: 29/09/2026

namespace SoundCore.EstructurasPropias;

/// <summary>
/// Bloque constructivo básico de la lista enlazada simple.
/// No depende de ninguna colección externa: solo se referencia a sí mismo.
/// </summary>
/// <typeparam name="T">Tipo de dato almacenado en el nodo.</typeparam>
public class Nodo<T>
{
    public T Valor { get; set; }
    public Nodo<T>? Siguiente { get; set; }

    public Nodo(T valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

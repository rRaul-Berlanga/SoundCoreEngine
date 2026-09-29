// Nombres: Raúl de Jesús Berlanga Martínez
// Números de Control TecNM: I240500400
// Fecha: 29/09/2026

using System.Collections;

namespace SoundCore.EstructurasPropias;

/// <summary>
/// Lista simple enlazada genérica construida 100% desde cero, sin apoyarse en
/// System.Collections.Generic. Es totalmente desacoplada de Windows Forms:
/// puede reutilizarse en cualquier proyecto .NET.
/// </summary>
/// <typeparam name="T">Tipo de dato que almacenará cada nodo.</typeparam>
public class ListaSimpleEnlazada<T> : IEnumerable<T>
{
    public Nodo<T>? Cabeza { get; private set; }
    private Nodo<T>? _cola;

    public int Contador { get; private set; }

    public bool EstaVacia => Cabeza is null;

    public void AgregarAlFinal(T valor)
    {
        var nuevo = new Nodo<T>(valor);

        if (Cabeza is null)
        {
            Cabeza = nuevo;
            _cola = nuevo;
        }
        else
        {
            _cola!.Siguiente = nuevo;
            _cola = nuevo;
        }

        Contador++;
    }


    public void ReproducirSiguiente(T valor)
    {
        var nuevo = new Nodo<T>(valor);

        if (Cabeza is null)
        {
            Cabeza = nuevo;
            _cola = nuevo;
        }
        else
        {
            nuevo.Siguiente = Cabeza.Siguiente;
            Cabeza.Siguiente = nuevo;
            if (_cola == Cabeza) _cola = nuevo; 
        }

        Contador++;
    }

    public T AvanzarPista()
    {
        if (Cabeza is null)
            throw new InvalidOperationException("No hay pistas en la cola para avanzar.");

        var valor = Cabeza.Valor;
        Cabeza = Cabeza.Siguiente;
        if (Cabeza is null) _cola = null;

        Contador--;
        return valor;
    }


    public void Invertir()
    {
        Nodo<T>? previo = null;
        Nodo<T>? actual = Cabeza;
        Nodo<T>? siguiente;

        _cola = Cabeza; 

        while (actual != null)
        {
            siguiente = actual.Siguiente; 
            actual.Siguiente = previo;    
            previo = actual;              
            actual = siguiente;           
        }

        Cabeza = previo;                 
    }


    public void InsertarOrdenado(T valor, Comparison<T> comparador)
    {
        var nuevo = new Nodo<T>(valor);

        if (Cabeza is null || comparador(valor, Cabeza.Valor) < 0)
        {
            nuevo.Siguiente = Cabeza;
            Cabeza = nuevo;
            if (_cola is null) _cola = nuevo;
            Contador++;
            return;
        }

        var actual = Cabeza;
        while (actual.Siguiente != null && comparador(valor, actual.Siguiente.Valor) >= 0)
        {
            actual = actual.Siguiente;
        }

        nuevo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevo;
        if (actual == _cola) _cola = nuevo;

        Contador++;
    }

    public void DepurarDuplicados(Func<T, T, bool> comparadorIgualdad)
    {
        var actual = Cabeza;

        while (actual != null)
        {
            var runner = actual;
            while (runner.Siguiente != null)
            {
                if (comparadorIgualdad(actual.Valor, runner.Siguiente.Valor))
                {
                    runner.Siguiente = runner.Siguiente.Siguiente;
                    if (runner.Siguiente is null) _cola = runner;
                    Contador--;
                }
                else
                {
                    runner = runner.Siguiente;
                }
            }
            actual = actual.Siguiente;
        }
    }


    public IEnumerator<T> GetEnumerator()
    {
        var actual = Cabeza;
        while (actual != null)
        {
            yield return actual.Valor;
            actual = actual.Siguiente;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

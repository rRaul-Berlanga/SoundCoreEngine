// Nombres: Raúl de Jesús Berlanga Martínez
// Números de Control TecNM: I240500400
// Fecha: 29/09/2026

using System.Diagnostics;
using SoundCore.EstructurasPropias;
using SoundCore.Modelos;

namespace SoundCore.UI;

public partial class MainForm : Form
{
    private enum ModoActivo { ListaPropia, LinkedListNet, ListNet }

    // Tres colecciones independientes para poder comparar operaciones idénticas
    // bajo la misma interfaz gráfica.
    private ListaSimpleEnlazada<Pista> _listaPropia = new();
    private LinkedList<Pista> _listaLinkedNet = new();
    private List<Pista> _listaListNet = new();

    private int _siguienteId = 1;

    public MainForm()
    {
        InitializeComponent();
        RefrescarGrid();
    }

    // ---------------------------------------------------------------
    // Manejadores de eventos (conectados desde MainForm.Designer.cs)
    // ---------------------------------------------------------------
    private void BtnEncolar_Click(object? sender, EventArgs e) => Ejecutar(() =>
    {
        var p = CrearPistaDesdeFormulario();
        switch (ModoActual())
        {
            case ModoActivo.ListaPropia: _listaPropia.AgregarAlFinal(p); break;
            case ModoActivo.LinkedListNet: _listaLinkedNet.AddLast(p); break;
            case ModoActivo.ListNet: _listaListNet.Add(p); break;
        }
    });

    private void BtnReproducirSiguiente_Click(object? sender, EventArgs e) => Ejecutar(() =>
    {
        var p = CrearPistaDesdeFormulario();
        switch (ModoActual())
        {
            case ModoActivo.ListaPropia:
                _listaPropia.ReproducirSiguiente(p);
                break;
            case ModoActivo.LinkedListNet:
                if (_listaLinkedNet.First is null) _listaLinkedNet.AddFirst(p);
                else _listaLinkedNet.AddAfter(_listaLinkedNet.First, p);
                break;
            case ModoActivo.ListNet:
                if (_listaListNet.Count == 0) _listaListNet.Add(p);
                else _listaListNet.Insert(1, p);
                break;
        }
    });

    private void BtnAvanzar_Click(object? sender, EventArgs e)
    {
        try
        {
            Pista sonando;
            switch (ModoActual())
            {
                case ModoActivo.ListaPropia:
                    sonando = _listaPropia.AvanzarPista();
                    break;
                case ModoActivo.LinkedListNet:
                    if (_listaLinkedNet.First is null) throw new InvalidOperationException("Cola vacía.");
                    sonando = _listaLinkedNet.First.Value;
                    _listaLinkedNet.RemoveFirst();
                    break;
                default:
                    if (_listaListNet.Count == 0) throw new InvalidOperationException("Cola vacía.");
                    sonando = _listaListNet[0];
                    _listaListNet.RemoveAt(0);
                    break;
            }
            RefrescarGrid();
            MessageBox.Show(this, $"Ahora suena: {sonando}", "Avanzar Pista",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (InvalidOperationException)
        {
            MessageBox.Show(this,
                "No se puede avanzar: la cola de reproducción está vacía.",
                "SoundCore Engine",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnInvertir_Click(object? sender, EventArgs e) => Ejecutar(() =>
    {
        switch (ModoActual())
        {
            case ModoActivo.ListaPropia:
                _listaPropia.Invertir(); // in-place, técnica de 3 punteros
                break;
            case ModoActivo.LinkedListNet:
                _listaLinkedNet = new LinkedList<Pista>(_listaLinkedNet.Reverse());
                break;
            case ModoActivo.ListNet:
                _listaListNet.Reverse();
                break;
        }
    });

    private void BtnOrdenarBpm_Click(object? sender, EventArgs e) => Ejecutar(() =>
    {
        switch (ModoActual())
        {
            case ModoActivo.ListaPropia:
                var ordenada = new ListaSimpleEnlazada<Pista>();
                foreach (var pista in _listaPropia)
                    ordenada.InsertarOrdenado(pista, (a, b) => a.Bpm.CompareTo(b.Bpm));
                _listaPropia = ordenada;
                break;
            case ModoActivo.LinkedListNet:
                _listaLinkedNet = new LinkedList<Pista>(_listaLinkedNet.OrderBy(p => p.Bpm));
                break;
            case ModoActivo.ListNet:
                _listaListNet = _listaListNet.OrderBy(p => p.Bpm).ToList();
                break;
        }
    });

    private void BtnPurgarDuplicados_Click(object? sender, EventArgs e) => Ejecutar(() =>
    {
        bool SonIguales(Pista a, Pista b) =>
            string.Equals(a.Titulo, b.Titulo, StringComparison.OrdinalIgnoreCase);

        switch (ModoActual())
        {
            case ModoActivo.ListaPropia:
                _listaPropia.DepurarDuplicados(SonIguales); // sin HashSets ni arrays
                break;
            case ModoActivo.LinkedListNet:
                _listaLinkedNet = new LinkedList<Pista>(
                    _listaLinkedNet.GroupBy(p => p.Titulo.ToLowerInvariant()).Select(g => g.First()));
                break;
            case ModoActivo.ListNet:
                _listaListNet = _listaListNet
                    .GroupBy(p => p.Titulo.ToLowerInvariant())
                    .Select(g => g.First())
                    .ToList();
                break;
        }
    });

    private void BtnImportarCsv_Click(object? sender, EventArgs e) => ImportarDesdeCsv();

    private void BtnBenchmark_Click(object? sender, EventArgs e) => EjecutarBenchmark();

    private void RbModo_CheckedChanged(object? sender, EventArgs e) => RefrescarGrid();

    // ---------------------------------------------------------------
    // Lógica auxiliar
    // ---------------------------------------------------------------
    private void Ejecutar(Action accion)
    {
        try
        {
            accion();
            RefrescarGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "SoundCore Engine",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private ModoActivo ModoActual()
    {
        if (rbLinkedList.Checked) return ModoActivo.LinkedListNet;
        if (rbListNet.Checked) return ModoActivo.ListNet;
        return ModoActivo.ListaPropia;
    }

    private Pista CrearPistaDesdeFormulario()
    {
        var titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? $"Sin título {_siguienteId}" : txtTitulo.Text.Trim();
        var artista = string.IsNullOrWhiteSpace(txtArtista.Text) ? "Desconocido" : txtArtista.Text.Trim();
        return new Pista(_siguienteId++, titulo, artista, (int)numBpm.Value, (int)numDuracion.Value);
    }

    // ---------------------------------------------------------------
    // Importación masiva: lee un archivo CSV/TXT con tus propias
    // canciones (Titulo,Artista,BPM,DuracionSegundos) y las encola
    // una por una en la estructura activa con AgregarAlFinal.
    //
    // Formato esperado (una canción por línea, separadas por coma):
    //   Titulo,Artista,BPM,DuracionSegundos
    // La primera línea puede ser un encabezado y se ignora automáticamente.
    // ---------------------------------------------------------------
    private void ImportarDesdeCsv()
    {
        using var dialogo = new OpenFileDialog
        {
            Title = "Importar canciones desde CSV",
            Filter = "Archivos CSV o texto (*.csv;*.txt)|*.csv;*.txt|Todos los archivos (*.*)|*.*"
        };

        if (dialogo.ShowDialog(this) != DialogResult.OK) return;

        int importadas = 0;
        var errores = new List<string>();
        string[] lineas;

        try
        {
            lineas = File.ReadAllLines(dialogo.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"No se pudo leer el archivo:\n{ex.Message}",
                "Importar CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        for (int i = 0; i < lineas.Length; i++)
        {
            var linea = lineas[i].Trim();
            if (linea.Length == 0) continue;

            var campos = linea.Split(',');
            if (campos.Length < 4)
            {
                errores.Add($"Línea {i + 1}: se esperaban 4 columnas (Titulo,Artista,BPM,Duracion).");
                continue;
            }

            var titulo = campos[0].Trim();
            var artista = campos[1].Trim();

            // Detecta y salta el encabezado si BPM/Duracion no son numéricos.
            if (!int.TryParse(campos[2].Trim(), out int bpm) ||
                !int.TryParse(campos[3].Trim(), out int duracion))
            {
                if (i == 0) continue; // probablemente el encabezado
                errores.Add($"Línea {i + 1}: BPM o Duración no son números válidos.");
                continue;
            }

            if (titulo.Length == 0) titulo = $"Sin título {_siguienteId}";
            if (artista.Length == 0) artista = "Desconocido";

            var pista = new Pista(_siguienteId++, titulo, artista, bpm, duracion);

            switch (ModoActual())
            {
                case ModoActivo.ListaPropia: _listaPropia.AgregarAlFinal(pista); break;
                case ModoActivo.LinkedListNet: _listaLinkedNet.AddLast(pista); break;
                case ModoActivo.ListNet: _listaListNet.Add(pista); break;
            }

            importadas++;
        }

        RefrescarGrid();

        var resumen = $"Se importaron {importadas} canciones correctamente.";
        if (errores.Count > 0)
            resumen += $"\n\n{errores.Count} línea(s) con problemas:\n" + string.Join("\n", errores.Take(10));

        MessageBox.Show(this, resumen, "Importar CSV",
            MessageBoxButtons.OK,
            errores.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
    }

    // ---------------------------------------------------------------
    // Sincronización reactiva: refresca el DataGridView, el indicador
    // "Sonando" y los contadores según la estructura activa.
    // ---------------------------------------------------------------
    private void RefrescarGrid()
    {
        dgvPlaylist.Rows.Clear();

        List<Pista> valores;
        List<string> punteros = new();

        switch (ModoActual())
        {
            case ModoActivo.ListaPropia:
                valores = new List<Pista>();
                var nodo = _listaPropia.Cabeza;
                while (nodo != null)
                {
                    valores.Add(nodo.Valor);
                    punteros.Add(FormatearPuntero(nodo));
                    nodo = nodo.Siguiente;
                }
                break;

            case ModoActivo.LinkedListNet:
                valores = _listaLinkedNet.ToList();
                var enlace = _listaLinkedNet.First;
                while (enlace != null)
                {
                    punteros.Add(FormatearPuntero(enlace));
                    enlace = enlace.Next;
                }
                break;

            default:
                valores = _listaListNet.ToList();
                foreach (var p in valores) punteros.Add(FormatearPuntero(p));
                break;
        }

        for (int i = 0; i < valores.Count; i++)
        {
            var destino = i == valores.Count - 1 ? "Null" : "Next";
            dgvPlaylist.Rows.Add(
                $"{i + 1:D3}",
                valores[i].Titulo,
                valores[i].Artista,
                valores[i].Bpm,
                punteros[i],
                destino);
        }

        lblSonando.Text = valores.Count > 0
            ? $"▶ Sonando: \"{valores[0].Titulo}\" - {valores[0].Artista} ({valores[0].Bpm} BPM)"
            : "▶ Sonando: (cola vacía)";

        lblTotalCola.Text = $"Total en cola: {valores.Count} pistas";

        var totalSegundos = valores.Sum(p => p.DuracionSegundos);
        lblTiempoTotal.Text = $"Tiempo total: {totalSegundos / 60:D2}:{totalSegundos % 60:D2}";
    }

    private static string FormatearPuntero(object referencia) =>
        $"0x{(referencia.GetHashCode() & 0xFFFF):X4}";

    // ---------------------------------------------------------------
    // Benchmark: 25,000 inserciones intermedias (posición 1) sobre
    // las tres estructuras, medidas con Stopwatch.
    // ---------------------------------------------------------------
    private void EjecutarBenchmark()
    {
        const int total = 25_000;
        var sw = new Stopwatch();

        var listaPropiaBench = new ListaSimpleEnlazada<Pista>();
        listaPropiaBench.AgregarAlFinal(new Pista(0, "Seed", "-", 120, 180));
        sw.Restart();
        for (int i = 1; i <= total; i++)
            listaPropiaBench.ReproducirSiguiente(new Pista(i, $"Track{i}", "DJ", 120, 180));
        sw.Stop();
        var msPropia = sw.Elapsed.TotalMilliseconds;

        var linkedBench = new LinkedList<Pista>();
        linkedBench.AddFirst(new Pista(0, "Seed", "-", 120, 180));
        sw.Restart();
        for (int i = 1; i <= total; i++)
            linkedBench.AddAfter(linkedBench.First!, new Pista(i, $"Track{i}", "DJ", 120, 180));
        sw.Stop();
        var msLinked = sw.Elapsed.TotalMilliseconds;

        var listBench = new List<Pista>();
        listBench.Add(new Pista(0, "Seed", "-", 120, 180));
        sw.Restart();
        for (int i = 1; i <= total; i++)
            listBench.Insert(1, new Pista(i, $"Track{i}", "DJ", 120, 180));
        sw.Stop();
        var msListT = sw.Elapsed.TotalMilliseconds;

        txtBenchmarkResultado.Text =
            "=== Duelo en Vivo: 25,000 inserciones intermedias (posición 1) ===" + Environment.NewLine +
            Environment.NewLine +
            $"Lista Propia (Nodos) ........ {msPropia,8:0.00} ms   -> O(1) por inserción: solo reconecta 2 referencias." + Environment.NewLine +
            $".NET LinkedList<T> .......... {msLinked,8:0.00} ms   -> O(1) nativa (nodos doblemente enlazados)." + Environment.NewLine +
            $".NET List<T> ................ {msListT,8:0.00} ms   -> O(n): Array.Copy desplaza todos los elementos." + Environment.NewLine +
            Environment.NewLine +
            "Conclusión: la curva de List<T> crece linealmente con el tamaño de la cola," + Environment.NewLine +
            "mientras que la lista propia y LinkedList<T> permanecen prácticamente constantes." + Environment.NewLine +
            "Esto confirma en la práctica la teoría de complejidad Big-O.";
    }
}

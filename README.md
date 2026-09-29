# SoundCore Engine GUI — DJ Queue & Transition Manager

**TecNM Monclova — Ingeniería en Informática — 3er Semestre**
**Asignatura:** Estructura de Datos — Reto Unidad 2

> Nombres: Raúl de Jesús Berlanga Martínez  
> Números de control: I240500400  
> Fecha: 29/09/2026

## 1. Descripción

Laboratorio de software que compara una **lista simple enlazada genérica construida
desde cero** (`ListaSimpleEnlazada<T>`) contra las colecciones nativas de **.NET 10**
(`LinkedList<T>` y `List<T>`), evaluadas mediante una interfaz gráfica en **Windows
Forms** y un benchmark de estrés con `Stopwatch`.

## 2. Arquitectura

```
SoundCoreEngine/
│
├── SoundCoreEngine.sln
└── SoundCoreEngine/
    ├── SoundCoreEngine.csproj
    ├── Program.cs
    ├── Modelos/
    │   └── Pista.cs                 // record con metadatos de DJ
    ├── EstructurasPropias/
    │   ├── Nodo.cs                  // clase genérica autoreferenciada
    │   └── ListaSimpleEnlazada.cs   // los 6 algoritmos desde cero
    └── UI/
        ├── MainForm.cs              // lógica de interfaz y sincronización
        └── MainForm.Designer.cs     // layout WinForms
```

**Reglas de ingeniería aplicadas:**
- `ListaSimpleEnlazada<T>` es 100% desacoplada de Windows Forms y reutilizable.
- Es genérica: soporta cualquier tipo de dato, no solo `Pista`.
- Implementa `IEnumerable<T>` con `yield return` para enlazarse al `DataGridView`
  sin exponer los nodos internos.

## 3. Los 6 algoritmos obligatorios

| Método | Complejidad | Acción |
|---|---|---|
| `AgregarAlFinal(T)` | O(1) (puntero de cola) | Encola una pista al final de la sesión. |
| `ReproducirSiguiente(T)` | O(1) | Inserta justo después de la cabeza (Up Next VIP). |
| `AvanzarPista()` | O(1) | Desencola la pista sonando y actualiza la cabeza. |
| `Invertir()` | O(n) tiempo / O(1) espacio | Invierte el setlist **estrictamente in-place** (técnica de 3 punteros: `previo`, `actual`, `siguiente`). |
| `InsertarOrdenado(T, cmp)` | O(n) | Ordena por curva de energía armónica (BPM). |
| `DepurarDuplicados(eq)` | O(n²) | Elimina canciones repetidas sin `HashSet` ni arreglos auxiliares. |

`Invertir()` reorienta punteros de memoria en tiempo real, sin listas temporales
ni intercambio de valores, con 0 bytes de memoria auxiliar adicional.

## 4. Interfaz gráfica

- Panel **Registro**: alta de pista (título, artista, BPM, duración) y selector de
  **Modo** (Lista Simple Propia / `LinkedList<T>` / `List<T>`) para operar cualquiera
  de las tres estructuras bajo los mismos controles.
- Panel **Acciones de Cola**: Encolar al Final, Reproducir Siguiente, Avanzar Pista,
  Invertir Lista (In-Place), Ordenar por Curva BPM, Purgar Duplicados.
- Panel **Playlist en Vivo**: `DataGridView` sincronizado en tiempo real, indicador de
  pista sonando, total en cola y tiempo total.
- Panel **Benchmark Telemetría**: botón para ejecutar 25,000 inserciones intermedias
  sobre las tres estructuras y comparar resultados con `Stopwatch`.
- Botón **"📂 Importar desde CSV"**: carga tus propias canciones desde un archivo
  `.csv`/`.txt` con el formato `Titulo,Artista,BPM,DuracionSegundos` (una por línea).
  Se incluye `canciones_ejemplo.csv` como referencia. Las inserta con
  `AgregarAlFinal` en la estructura activa (según el Modo seleccionado) e ignora la
  primera línea si es un encabezado.
- Manejo de errores: al avanzar con la cola vacía se muestra un `MessageBox`
  informativo en lugar de colapsar la aplicación.

## 5. Benchmark

El botón **"Probar 25,000 Inserciones"** somete a `ListaSimpleEnlazada<T>`,
`LinkedList<T>` y `List<T>` a 25,000 inserciones en la posición 2 (justo después de
la cabeza) y mide el tiempo con `Stopwatch`. Se espera confirmar en la práctica que:

- **Lista propia** y **`LinkedList<T>`**: tiempo prácticamente constante — O(1) por
  inserción (solo reconectan referencias).
- **`List<T>`**: degradación notable — O(n) por inserción, ya que `Insert` desplaza
  todos los elementos posteriores con `Array.Copy`.

## 6. Casos de prueba

| ID | Escenario | Entrada | Resultado esperado |
|---|---|---|---|
| CP-01 | Inserción final | "Track 1" (120 BPM) | Se agrega a la última fila del grid. |
| CP-02 | Up Next VIP | "Track VIP" | Se ubica en posición 2 (detrás de la cabeza). |
| CP-03 | Avanzar pista | Clic en [Avanzar] | Se reproduce la cabeza y sale del grid. |
| CP-04 | Inversión in-place | BPMs [100, 110, 120] | Grid muestra [120, 110, 100] sin memoria extra. |
| CP-05 | Curva BPM | 128, 115, 140, 120 | Reordena ascendente: 115 → 120 → 128 → 140. |
| CP-06 | Purgar duplicados | Títulos repetidos | Mantiene el primero y borra duplicados. |
| CP-07 | Manejo de errores | Avanzar cola vacía | Muestra `MessageBox` informativo sin colapso. |

## 7. Cómo ejecutar

Requiere **.NET SDK** con soporte para Windows Forms.

```bash
cd SoundCoreEngine
dotnet build
dotnet run --project SoundCoreEngine
```

## 8. Entregables

1. **Repositorio Git** con esta solución compilable + este `README.md`.
2. **Video demostrativo (máx. 3:00 min)**:
   - `0:00–1:15` — Prueba en vivo de las 6 operaciones en la GUI.
   - `1:15–2:00` — Ejecución del test de estrés con 25,000 pistas.
   - `2:00–3:00` — Explicación del código de `Invertir()` señalando `previo`,
     `actual` y `siguiente`.

## 9. Rúbrica

| Criterio | % |
|---|---|
| Estructuras desde cero (6 métodos, inversión in-place) | 40% |
| Interfaz gráfica WinForms | 25% |
| Integración .NET 10 (`LinkedList<T>` / `List<T>`) | 20% |
| Benchmark y análisis | 15% |

---
*"Un buen programador conoce las librerías. Un ingeniero comprende la memoria
detrás de ellas."*

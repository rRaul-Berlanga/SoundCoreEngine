// Nombres: Raúl de Jesús Berlanga Martínez
// Números de Control TecNM: I240500400
// Fecha: 29/09/2026

namespace SoundCore.UI;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private GroupBox grpRegistro;
    private Label lblTitulo;
    private TextBox txtTitulo;
    private Label lblArtista;
    private TextBox txtArtista;
    private Label lblBpm;
    private NumericUpDown numBpm;
    private Label lblDuracion;
    private NumericUpDown numDuracion;
    private Label lblModo;
    private RadioButton rbListaPropia;
    private RadioButton rbLinkedList;
    private RadioButton rbListNet;

    private GroupBox grpAcciones;
    private Button btnEncolar;
    private Button btnReproducirSiguiente;
    private Button btnAvanzar;
    private Button btnInvertir;
    private Button btnOrdenarBpm;
    private Button btnPurgarDuplicados;
    private Button btnImportarCsv;

    private GroupBox grpPlaylist;
    private Label lblSonando;
    private DataGridView dgvPlaylist;
    private DataGridViewTextBoxColumn colPos;
    private DataGridViewTextBoxColumn colTitulo;
    private DataGridViewTextBoxColumn colArtista;
    private DataGridViewTextBoxColumn colBpm;
    private DataGridViewTextBoxColumn colPuntero;
    private DataGridViewTextBoxColumn colDestino;
    private Label lblTotalCola;
    private Label lblTiempoTotal;

    private GroupBox grpBenchmark;
    private Button btnBenchmark;
    private TextBox txtBenchmarkResultado;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        grpRegistro = new GroupBox();
        lblTitulo = new Label();
        txtTitulo = new TextBox();
        lblArtista = new Label();
        txtArtista = new TextBox();
        lblBpm = new Label();
        numBpm = new NumericUpDown();
        lblDuracion = new Label();
        numDuracion = new NumericUpDown();
        lblModo = new Label();
        rbListaPropia = new RadioButton();
        rbLinkedList = new RadioButton();
        rbListNet = new RadioButton();
        grpAcciones = new GroupBox();
        btnEncolar = new Button();
        btnReproducirSiguiente = new Button();
        btnAvanzar = new Button();
        btnInvertir = new Button();
        btnOrdenarBpm = new Button();
        btnPurgarDuplicados = new Button();
        btnImportarCsv = new Button();
        grpPlaylist = new GroupBox();
        lblSonando = new Label();
        dgvPlaylist = new DataGridView();
        colPos = new DataGridViewTextBoxColumn();
        colTitulo = new DataGridViewTextBoxColumn();
        colArtista = new DataGridViewTextBoxColumn();
        colBpm = new DataGridViewTextBoxColumn();
        colPuntero = new DataGridViewTextBoxColumn();
        colDestino = new DataGridViewTextBoxColumn();
        lblTotalCola = new Label();
        lblTiempoTotal = new Label();
        grpBenchmark = new GroupBox();
        btnBenchmark = new Button();
        txtBenchmarkResultado = new TextBox();
        grpRegistro.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numBpm).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
        grpAcciones.SuspendLayout();
        grpPlaylist.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPlaylist).BeginInit();
        grpBenchmark.SuspendLayout();
        SuspendLayout();
        // 
        // grpRegistro
        // 
        grpRegistro.Controls.Add(lblTitulo);
        grpRegistro.Controls.Add(txtTitulo);
        grpRegistro.Controls.Add(lblArtista);
        grpRegistro.Controls.Add(txtArtista);
        grpRegistro.Controls.Add(lblBpm);
        grpRegistro.Controls.Add(numBpm);
        grpRegistro.Controls.Add(lblDuracion);
        grpRegistro.Controls.Add(numDuracion);
        grpRegistro.Controls.Add(lblModo);
        grpRegistro.Controls.Add(rbListaPropia);
        grpRegistro.Controls.Add(rbLinkedList);
        grpRegistro.Controls.Add(rbListNet);
        grpRegistro.Location = new Point(12, 12);
        grpRegistro.Name = "grpRegistro";
        grpRegistro.Size = new Size(1140, 110);
        grpRegistro.TabIndex = 0;
        grpRegistro.TabStop = false;
        grpRegistro.Text = "REGISTRO";
        // 
        // lblTitulo
        // 
        lblTitulo.Location = new Point(12, 25);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(53, 24);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Título:";
        // 
        // txtTitulo
        // 
        txtTitulo.Location = new Point(60, 22);
        txtTitulo.Name = "txtTitulo";
        txtTitulo.Size = new Size(200, 27);
        txtTitulo.TabIndex = 1;
        // 
        // lblArtista
        // 
        lblArtista.Location = new Point(275, 25);
        lblArtista.Name = "lblArtista";
        lblArtista.Size = new Size(50, 32);
        lblArtista.TabIndex = 2;
        lblArtista.Text = "Artista:";
        // 
        // txtArtista
        // 
        txtArtista.Location = new Point(330, 22);
        txtArtista.Name = "txtArtista";
        txtArtista.Size = new Size(180, 27);
        txtArtista.TabIndex = 3;
        // 
        // lblBpm
        // 
        lblBpm.Location = new Point(525, 25);
        lblBpm.Name = "lblBpm";
        lblBpm.Size = new Size(40, 24);
        lblBpm.TabIndex = 4;
        lblBpm.Text = "BPM:";
        // 
        // numBpm
        // 
        numBpm.Location = new Point(570, 22);
        numBpm.Maximum = new decimal(new int[] { 220, 0, 0, 0 });
        numBpm.Minimum = new decimal(new int[] { 40, 0, 0, 0 });
        numBpm.Name = "numBpm";
        numBpm.Size = new Size(70, 27);
        numBpm.TabIndex = 5;
        numBpm.Value = new decimal(new int[] { 124, 0, 0, 0 });
        // 
        // lblDuracion
        // 
        lblDuracion.Location = new Point(655, 25);
        lblDuracion.Name = "lblDuracion";
        lblDuracion.Size = new Size(85, 24);
        lblDuracion.TabIndex = 6;
        lblDuracion.Text = "Duración (s):";
        // 
        // numDuracion
        // 
        numDuracion.Location = new Point(745, 22);
        numDuracion.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
        numDuracion.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
        numDuracion.Name = "numDuracion";
        numDuracion.Size = new Size(80, 27);
        numDuracion.TabIndex = 7;
        numDuracion.Value = new decimal(new int[] { 210, 0, 0, 0 });
        // 
        // lblModo
        // 
        lblModo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblModo.Location = new Point(12, 62);
        lblModo.Name = "lblModo";
        lblModo.Size = new Size(50, 27);
        lblModo.TabIndex = 8;
        lblModo.Text = "Modo:";
        // 
        // rbListaPropia
        // 
        rbListaPropia.Checked = true;
        rbListaPropia.Location = new Point(65, 60);
        rbListaPropia.Name = "rbListaPropia";
        rbListaPropia.Size = new Size(210, 29);
        rbListaPropia.TabIndex = 9;
        rbListaPropia.TabStop = true;
        rbListaPropia.Text = "Lista Simple Propia (Nodos)";
        rbListaPropia.CheckedChanged += RbModo_CheckedChanged;
        // 
        // rbLinkedList
        // 
        rbLinkedList.Location = new Point(285, 60);
        rbLinkedList.Name = "rbLinkedList";
        rbLinkedList.Size = new Size(160, 29);
        rbLinkedList.TabIndex = 10;
        rbLinkedList.Text = ".NET LinkedList<T>";
        rbLinkedList.CheckedChanged += RbModo_CheckedChanged;
        // 
        // rbListNet
        // 
        rbListNet.Location = new Point(455, 60);
        rbListNet.Name = "rbListNet";
        rbListNet.Size = new Size(120, 29);
        rbListNet.TabIndex = 11;
        rbListNet.Text = ".NET List<T>";
        rbListNet.CheckedChanged += RbModo_CheckedChanged;
        // 
        // grpAcciones
        // 
        grpAcciones.Controls.Add(btnEncolar);
        grpAcciones.Controls.Add(btnReproducirSiguiente);
        grpAcciones.Controls.Add(btnAvanzar);
        grpAcciones.Controls.Add(btnInvertir);
        grpAcciones.Controls.Add(btnOrdenarBpm);
        grpAcciones.Controls.Add(btnPurgarDuplicados);
        grpAcciones.Controls.Add(btnImportarCsv);
        grpAcciones.Location = new Point(12, 130);
        grpAcciones.Name = "grpAcciones";
        grpAcciones.Size = new Size(260, 344);
        grpAcciones.TabIndex = 1;
        grpAcciones.TabStop = false;
        grpAcciones.Text = "ACCIONES DE COLA";
        // 
        // btnEncolar
        // 
        btnEncolar.Location = new Point(15, 28);
        btnEncolar.Name = "btnEncolar";
        btnEncolar.Size = new Size(220, 36);
        btnEncolar.TabIndex = 0;
        btnEncolar.Text = "+ Encolar al Final";
        btnEncolar.UseVisualStyleBackColor = true;
        btnEncolar.Click += BtnEncolar_Click;
        // 
        // btnReproducirSiguiente
        // 
        btnReproducirSiguiente.Location = new Point(15, 72);
        btnReproducirSiguiente.Name = "btnReproducirSiguiente";
        btnReproducirSiguiente.Size = new Size(220, 36);
        btnReproducirSiguiente.TabIndex = 1;
        btnReproducirSiguiente.Text = "⏭ Reproducir Siguiente";
        btnReproducirSiguiente.UseVisualStyleBackColor = true;
        btnReproducirSiguiente.Click += BtnReproducirSiguiente_Click;
        // 
        // btnAvanzar
        // 
        btnAvanzar.Location = new Point(15, 116);
        btnAvanzar.Name = "btnAvanzar";
        btnAvanzar.Size = new Size(220, 36);
        btnAvanzar.TabIndex = 2;
        btnAvanzar.Text = "⏩ Avanzar Pista";
        btnAvanzar.UseVisualStyleBackColor = true;
        btnAvanzar.Click += BtnAvanzar_Click;
        // 
        // btnInvertir
        // 
        btnInvertir.Location = new Point(15, 160);
        btnInvertir.Name = "btnInvertir";
        btnInvertir.Size = new Size(220, 36);
        btnInvertir.TabIndex = 3;
        btnInvertir.Text = "⇅ Invertir Lista (In-Place)";
        btnInvertir.UseVisualStyleBackColor = true;
        btnInvertir.Click += BtnInvertir_Click;
        // 
        // btnOrdenarBpm
        // 
        btnOrdenarBpm.Location = new Point(15, 204);
        btnOrdenarBpm.Name = "btnOrdenarBpm";
        btnOrdenarBpm.Size = new Size(220, 36);
        btnOrdenarBpm.TabIndex = 4;
        btnOrdenarBpm.Text = "⚡ Ordenar por Curva BPM";
        btnOrdenarBpm.UseVisualStyleBackColor = true;
        btnOrdenarBpm.Click += BtnOrdenarBpm_Click;
        // 
        // btnPurgarDuplicados
        // 
        btnPurgarDuplicados.Location = new Point(15, 248);
        btnPurgarDuplicados.Name = "btnPurgarDuplicados";
        btnPurgarDuplicados.Size = new Size(220, 36);
        btnPurgarDuplicados.TabIndex = 5;
        btnPurgarDuplicados.Text = "\U0001f9f9 Purgar Duplicados";
        btnPurgarDuplicados.UseVisualStyleBackColor = true;
        btnPurgarDuplicados.Click += BtnPurgarDuplicados_Click;
        // 
        // btnImportarCsv
        // 
        btnImportarCsv.Location = new Point(15, 292);
        btnImportarCsv.Name = "btnImportarCsv";
        btnImportarCsv.Size = new Size(220, 36);
        btnImportarCsv.TabIndex = 6;
        btnImportarCsv.Text = "📂 Importar desde CSV";
        btnImportarCsv.UseVisualStyleBackColor = true;
        btnImportarCsv.Click += BtnImportarCsv_Click;
        // 
        // grpPlaylist
        // 
        grpPlaylist.Controls.Add(lblSonando);
        grpPlaylist.Controls.Add(dgvPlaylist);
        grpPlaylist.Controls.Add(lblTotalCola);
        grpPlaylist.Controls.Add(lblTiempoTotal);
        grpPlaylist.Location = new Point(284, 130);
        grpPlaylist.Name = "grpPlaylist";
        grpPlaylist.Size = new Size(868, 344);
        grpPlaylist.TabIndex = 2;
        grpPlaylist.TabStop = false;
        grpPlaylist.Text = "PLAYLIST EN VIVO";
        // 
        // lblSonando
        // 
        lblSonando.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblSonando.Location = new Point(12, 24);
        lblSonando.Name = "lblSonando";
        lblSonando.Size = new Size(830, 20);
        lblSonando.TabIndex = 0;
        lblSonando.Text = "▶ Sonando: (cola vacía)";
        // 
        // dgvPlaylist
        // 
        dgvPlaylist.AllowUserToAddRows = false;
        dgvPlaylist.AllowUserToDeleteRows = false;
        dgvPlaylist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPlaylist.ColumnHeadersHeight = 29;
        dgvPlaylist.Columns.AddRange(new DataGridViewColumn[] { colPos, colTitulo, colArtista, colBpm, colPuntero, colDestino });
        dgvPlaylist.Location = new Point(12, 50);
        dgvPlaylist.Name = "dgvPlaylist";
        dgvPlaylist.ReadOnly = true;
        dgvPlaylist.RowHeadersVisible = false;
        dgvPlaylist.RowHeadersWidth = 51;
        dgvPlaylist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPlaylist.Size = new Size(840, 244);
        dgvPlaylist.TabIndex = 1;
        // 
        // colPos
        // 
        colPos.HeaderText = "Pos";
        colPos.MinimumWidth = 6;
        colPos.Name = "colPos";
        colPos.ReadOnly = true;
        // 
        // colTitulo
        // 
        colTitulo.HeaderText = "Título";
        colTitulo.MinimumWidth = 6;
        colTitulo.Name = "colTitulo";
        colTitulo.ReadOnly = true;
        // 
        // colArtista
        // 
        colArtista.HeaderText = "Artista";
        colArtista.MinimumWidth = 6;
        colArtista.Name = "colArtista";
        colArtista.ReadOnly = true;
        // 
        // colBpm
        // 
        colBpm.HeaderText = "BPM";
        colBpm.MinimumWidth = 6;
        colBpm.Name = "colBpm";
        colBpm.ReadOnly = true;
        // 
        // colPuntero
        // 
        colPuntero.HeaderText = "Puntero (Nodo)";
        colPuntero.MinimumWidth = 6;
        colPuntero.Name = "colPuntero";
        colPuntero.ReadOnly = true;
        // 
        // colDestino
        // 
        colDestino.HeaderText = "-> Destino";
        colDestino.MinimumWidth = 6;
        colDestino.Name = "colDestino";
        colDestino.ReadOnly = true;
        // 
        // lblTotalCola
        // 
        lblTotalCola.Location = new Point(12, 306);
        lblTotalCola.Name = "lblTotalCola";
        lblTotalCola.Size = new Size(220, 22);
        lblTotalCola.TabIndex = 2;
        lblTotalCola.Text = "Total en cola: 0 pistas";
        // 
        // lblTiempoTotal
        // 
        lblTiempoTotal.Location = new Point(250, 306);
        lblTiempoTotal.Name = "lblTiempoTotal";
        lblTiempoTotal.Size = new Size(220, 22);
        lblTiempoTotal.TabIndex = 3;
        lblTiempoTotal.Text = "Tiempo total: 00:00";
        // 
        // grpBenchmark
        // 
        grpBenchmark.Controls.Add(btnBenchmark);
        grpBenchmark.Controls.Add(txtBenchmarkResultado);
        grpBenchmark.Location = new Point(12, 484);
        grpBenchmark.Name = "grpBenchmark";
        grpBenchmark.Size = new Size(1140, 260);
        grpBenchmark.TabIndex = 3;
        grpBenchmark.TabStop = false;
        grpBenchmark.Text = "BENCHMARK TELEMETRÍA";
        // 
        // btnBenchmark
        // 
        btnBenchmark.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnBenchmark.Location = new Point(15, 28);
        btnBenchmark.Name = "btnBenchmark";
        btnBenchmark.Size = new Size(260, 40);
        btnBenchmark.TabIndex = 0;
        btnBenchmark.Text = "🚀 Probar 25,000 Inserciones";
        btnBenchmark.UseVisualStyleBackColor = true;
        btnBenchmark.Click += BtnBenchmark_Click;
        // 
        // txtBenchmarkResultado
        // 
        txtBenchmarkResultado.Font = new Font("Consolas", 9.5F);
        txtBenchmarkResultado.Location = new Point(15, 78);
        txtBenchmarkResultado.Multiline = true;
        txtBenchmarkResultado.Name = "txtBenchmarkResultado";
        txtBenchmarkResultado.ReadOnly = true;
        txtBenchmarkResultado.ScrollBars = ScrollBars.Vertical;
        txtBenchmarkResultado.Size = new Size(1110, 160);
        txtBenchmarkResultado.TabIndex = 1;
        // 
        // MainForm
        // 
        ClientSize = new Size(1180, 780);
        Controls.Add(grpRegistro);
        Controls.Add(grpAcciones);
        Controls.Add(grpPlaylist);
        Controls.Add(grpBenchmark);
        Font = new Font("Segoe UI", 9F);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";
        grpRegistro.ResumeLayout(false);
        grpRegistro.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numBpm).EndInit();
        ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
        grpAcciones.ResumeLayout(false);
        grpPlaylist.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPlaylist).EndInit();
        grpBenchmark.ResumeLayout(false);
        grpBenchmark.PerformLayout();
        ResumeLayout(false);
    }
}

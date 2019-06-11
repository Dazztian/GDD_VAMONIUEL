using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class ModificarRecorrido : Form
    {
        int idRecorrido;
        private Dictionary<string, string> filtros = new Dictionary<string, string>();
        DataTable datos=new DataTable();
        List<Tramo> tramosModificados = new List<Tramo>();
        Boolean cambioOrigenRecorrido = false;
        Boolean cambioDestinoRecorrido = false;
        public ModificarRecorrido(int id)
        {
            InitializeComponent();
            idRecorrido = id;
        }

        private void ModificarRecorrido_Load(object sender, EventArgs e)
        {
            filtros.Add("idRecorrido", Conexion.Filtro.Exacto(idRecorrido.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Tramos_asociados_a_recorridos, ref dataGridViewTramos, filtros);
           
        }

        private void btnOrigen_Click(object sender, EventArgs e)
        {
            Tramo tramo = new Tramo();
            Tramo tramoAnterior = new Tramo();
            int filaActual = dataGridViewTramos.SelectedCells[1].OwningRow.Cells["idTramo"].RowIndex;
            CambiarOrigen cambiar = new CambiarOrigen(dataGridViewTramos.Rows[filaActual].Cells["parada1"].Value.ToString());
            DialogResult res;
            
            if (dataGridViewTramos.Rows.Count.Equals(0))
            {
                MessageBox.Show("Debe seleccionar un tramo");
            }
            else
                if (filaActual.Equals(0))
                {
                    tramo.id = Convert.ToInt32(dataGridViewTramos.SelectedCells[1].OwningRow.Cells["idTramo"].Value);
                    tramo.destino = dataGridViewTramos.SelectedCells[3].OwningRow.Cells["parada2"].Value.ToString();
                    tramo.precio = Convert.ToDecimal(dataGridViewTramos.SelectedCells[4].OwningRow.Cells["Precio"].Value);
                    cambiar = new CambiarOrigen(dataGridViewTramos.Rows[filaActual].Cells["parada1"].Value.ToString());
                    res = cambiar.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        tramo.origen = cambiar.origenNuevo.ToString();
                        dataGridViewTramos.SelectedCells[2].OwningRow.Cells["parada1"].Value = cambiar.origenNuevo;
                        tramosModificados.Add(tramo);
                        cambioOrigenRecorrido = true;
                    }
                }
                else
                {
                    tramo.id = Convert.ToInt32(dataGridViewTramos.SelectedCells[1].OwningRow.Cells["idTramo"].Value);
                    tramo.destino = dataGridViewTramos.SelectedCells[3].OwningRow.Cells["parada2"].Value.ToString();
                    tramo.precio = Convert.ToDecimal(dataGridViewTramos.SelectedCells[4].OwningRow.Cells["Precio"].Value);
                    tramoAnterior.id = Convert.ToInt32(dataGridViewTramos.Rows[filaActual - 1].Cells["idTramo"].Value);
                    tramoAnterior.origen = dataGridViewTramos.Rows[filaActual - 1].Cells["parada1"].Value.ToString();
                    tramoAnterior.precio = Convert.ToDecimal(dataGridViewTramos.Rows[filaActual - 1].Cells["idTramo"].Value);
                    cambiar = new CambiarOrigen(dataGridViewTramos.Rows[filaActual].Cells["parada1"].Value.ToString());
                    res = cambiar.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        tramo.origen = cambiar.origenNuevo.ToString();
                        tramoAnterior.destino = cambiar.origenNuevo.ToString();
                        dataGridViewTramos.SelectedCells[2].OwningRow.Cells["parada1"].Value = cambiar.origenNuevo;
                        dataGridViewTramos.Rows[filaActual - 1].Cells["parada2"].Value = cambiar.origenNuevo;
                        tramosModificados.Add(tramo);
                        tramosModificados.Add(tramoAnterior);
                    }

                }
            
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            Tramo tramo = new Tramo();
            Tramo tramoPosterior = new Tramo();
            int filaActual = dataGridViewTramos.SelectedCells[1].OwningRow.Cells["idTramo"].RowIndex;
            CambiarDestino cambiar = new CambiarDestino(dataGridViewTramos.Rows[filaActual].Cells["parada2"].Value.ToString());
            DialogResult res;

            if (dataGridViewTramos.Rows.Count.Equals(0))
            {
                MessageBox.Show("Debe seleccionar un tramo");
            }
            else
                //revisar count
                if (filaActual.Equals(dataGridViewTramos.Rows.Count - 2))
                {
                    tramo.id = Convert.ToInt32(dataGridViewTramos.SelectedCells[1].OwningRow.Cells["idTramo"].Value);
                    tramo.origen = dataGridViewTramos.SelectedCells[2].OwningRow.Cells["parada1"].Value.ToString();
                    tramo.precio = Convert.ToDecimal(dataGridViewTramos.SelectedCells[4].OwningRow.Cells["Precio"].Value);
                    cambiar = new CambiarDestino(dataGridViewTramos.Rows[filaActual].Cells["parada2"].Value.ToString());
                    res = cambiar.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        tramo.origen = cambiar.destinoNuevo.ToString();
                        dataGridViewTramos.SelectedCells[3].OwningRow.Cells["parada2"].Value = cambiar.destinoNuevo;
                        tramosModificados.Add(tramo);
                        cambioDestinoRecorrido = true;
                    }
                }
                else
                {
                    tramo.id = Convert.ToInt32(dataGridViewTramos.SelectedCells[1].OwningRow.Cells["idTramo"].Value);
                    tramo.origen = dataGridViewTramos.SelectedCells[2].OwningRow.Cells["parada1"].Value.ToString();
                    tramo.precio = Convert.ToDecimal(dataGridViewTramos.SelectedCells[4].OwningRow.Cells["Precio"].Value);
                    tramoPosterior.id = Convert.ToInt32(dataGridViewTramos.Rows[filaActual + 1].Cells["idTramo"].Value);
                    tramoPosterior.destino = dataGridViewTramos.Rows[filaActual + 1].Cells["parada2"].Value.ToString();
                    tramoPosterior.precio = Convert.ToDecimal(dataGridViewTramos.Rows[filaActual + 1].Cells["idTramo"].Value);
                    cambiar = new CambiarDestino(dataGridViewTramos.Rows[filaActual].Cells["parada2"].Value.ToString());
                    res = cambiar.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        tramo.destino = cambiar.destinoNuevo.ToString();
                        tramoPosterior.origen = cambiar.destinoNuevo.ToString();
                        dataGridViewTramos.SelectedCells[3].OwningRow.Cells["parada2"].Value = cambiar.destinoNuevo;
                        dataGridViewTramos.Rows[filaActual + 1].Cells["parada1"].Value = cambiar.destinoNuevo;
                        tramosModificados.Add(tramo);
                        tramosModificados.Add(tramoPosterior);
                    }

                }

        }
    }
}

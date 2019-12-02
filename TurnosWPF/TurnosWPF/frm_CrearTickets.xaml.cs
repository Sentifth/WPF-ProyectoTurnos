using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using capaAccesoaDatos;
using capaLogicadeNegocio;

namespace TurnosWPF
{

    /// <summary>
    /// Lógica de interacción para frm_CrearTickets.xaml
    /// </summary>
    public partial class frm_CrearTickets : Window
    {
        private cls_clasificacion Clas = new cls_clasificacion();
        private cls_ticket Tick = new cls_ticket();
        private cls_cola Cola = new cls_cola();
        SqlConnection conexion = new SqlConnection("server=DESKTOP-PQK0OO9\\SQLEXPRESS ; database=gestion_turnos2 ; integrated security = true");
        public frm_CrearTickets()
        {
            InitializeComponent();
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");

            try
            {
                SqlCommand comando = new SqlCommand("Select * from dbo.clasificacion", conexion);
                SqlDataAdapter adaptador = new SqlDataAdapter();
                DataTable dataTable = this.Clas.sp_listar_clasificacion();
                dataGridView1.ItemsSource = dataTable.DefaultView;
            }
            catch
            {
                MessageBox.Show("Error: Llenar_Datagrid()");
            }


        }
        


        private void Btn_CrearTicket(object sender, RoutedEventArgs e)
        {
            try
            {
                this.btn_CrearTicket.Enabled = false;
                    if (this.dataGridView1.Rows.Count != 0)
                    {
                        int index = this.dataGridView1.CurrentRow.Index;
                        this.Tick.codigo = this.dataGridView1.Rows[index].Cells[1].Value.ToString();
                        DataTable dataTable = this.Tick.sp_registrar_ticket();
                        long num = Convert.ToInt64(dataTable.Rows[0][1].ToString());
                        dataTable = this.Tick.sp_listar_tickets_xcodigo();
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            if (num == Convert.ToInt64(dataTable.Rows[i][0].ToString()))
                            {
                                this.Tick.id = Convert.ToInt64(dataTable.Rows[i][0].ToString());
                                this.Tick.codigo = dataTable.Rows[i][1].ToString();
                                this.Tick.codigo_numeracion = this.Tick.codigo + "-" + (i + 1);
                                this.Tick.modulo = (int)Convert.ToInt16(dataTable.Rows[i][3].ToString());
                                this.Tick.estado = (int)Convert.ToInt16(dataTable.Rows[i][4].ToString());
                                this.Tick.sp_actualizar_ticket();
                                new frm_Imprimir_Ticket
                                {
                                    Id = this.Tick.id,
                                    Clasificacion = this.dataGridView1.Rows[index].Cells[2].Value.ToString(),
                                    NumeroTicket = this.Tick.codigo_numeracion
                                }.ShowDialog();
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: btn_CrearTicket_Click \n\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                this.btn_CrearTicket.Enabled = true;
            }
        }

    }
}

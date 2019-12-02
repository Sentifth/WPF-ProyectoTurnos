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
          
        }

    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TurnosWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_CrearTickets_Click(object sender, RoutedEventArgs e)
        {
            this.open_forms(1);
        }

        private void Btn_AtenderClientes_Click(object sender, RoutedEventArgs e)
        {
            this.open_forms(2);
        }

        private void Btn_Pantalla_Click(object sender, RoutedEventArgs e)
        {
            this.open_forms(3);
        }

        private void Btn_Configurar_Click(object sender, RoutedEventArgs e)
        {
            this.open_forms(4);
        }

        private void open_forms(int imenu)
        {
            this.groupBox1.IsEnabled = false;
            base.Hide();
            switch (imenu)
            {
                case 1:

                    {
                        frm_CrearTickets frm_CrearTickets = new frm_CrearTickets();
                        frm_CrearTickets.ShowDialog();
                        break;
                    }
                case 2:

                    {
                        frm_AtencionCliente frm_AtencionCliente = new frm_AtencionCliente();
                        frm_AtencionCliente.ShowDialog();
                        break;
                    }
                case 3:

                    {
                        frm_Pantalla frm_Pantalla = new frm_Pantalla();
                        frm_Pantalla.ShowDialog();
                        break;
                    }
                case 4:

                    {
                        frmLogin frmLogin = new frmLogin();
                        frmLogin.ShowDialog();
                        break;
                    }
            }
            this.groupBox1.IsEnabled = true;
            base.Show();
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
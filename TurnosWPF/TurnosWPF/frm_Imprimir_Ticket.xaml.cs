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
using System.Runtime.InteropServices;

namespace TurnosWPF
{
    /// <summary>
    /// Lógica de interacción para frm_Imprimir_Ticket.xaml
    /// </summary>
    public partial class frm_Imprimir_Ticket : Window
    {
        public long Id
        {
            get;
            set;
        }
        public string Clasificacion
        {
            get;
            set;
        }
        public string NumeroTicket
        {
            get;
            set;
        }
        public frm_Imprimir_Ticket()
        {
            InitializeComponent();
        }
        private void frm_Imprimir_Ticket_Load(object sender, EventArgs e)
        {
            PrintDialog imprimirDlg = new PrintDialog();
            imprimirDlg.PrintVisual(this, "Imprimiendo_WPF");
            
        }
        private void OnDataGridPrinting(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

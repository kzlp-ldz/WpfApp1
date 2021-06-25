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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            double loanAm = double.Parse(tb_LoanAmount1.Text);
            int loanTe = Convert.ToInt32(tb_LoanTerm.Text);
            string[] rate = tb_rate.Text.Split(';');
            double[] cumulatively = new double[loanTe];
            double[] payments = new double[loanTe];
            double cumu = 0;

            for (int i = 0; i <= loanTe; i++)
            {
                cumu += (Convert.ToDouble(rate[i]) / 100) * loanAm;
                cumulatively[i] = cumu;
                payments[i] = cumu + loanAm;
            }
        }

        private void tb_LoanAmount1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int loanAm = int.Parse(tb_LoanAmount1.Text);
        }

        private void tb_LoanTerm_TextChanged(object sender, TextChangedEventArgs e)
        {
            int loanTe = int.Parse(tb_LoanTerm.Text);
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
        }

        private void tb_LoanAmount1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_LoanTerm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            double loanAm = double.Parse(tb_LoanAmount1.Text);
            int loanTe = Convert.ToInt32(tb_LoanTerm.Text);
            if ((loanAm > 0) && (loanTe > 0)) {
                string[] rate = tb_rate.Text.Split(';');
                double[] cumulatively = new double[loanTe];
                double[] payments = new double[loanTe];
                double cumu = 0;
                List<string> result = new List<string>();
                for (int i = 0; i < loanTe; i++)
                {
                    cumu += (Convert.ToDouble(rate[i]) / 100) * loanAm;
                    cumulatively[i] = cumu;
                    payments[i] = cumu + loanAm;
                    result.Add($"День: {i + 1}, Ставка: {rate[i]}, Накопительные %: {cumulatively[i]}, Сумма выплат: {payments[i]}");
                }
                tb_TotalPayout.Text = Convert.ToString(payments[loanTe - 1]);
                tb_InterestAmount.Text = Convert.ToString(cumulatively[loanTe - 1]);
                tb_EffectiveRate.Text = Convert.ToString(((cumulatively[loanTe - 1] / loanAm) / loanTe) * 100);
                tb_interest.Text = string.Join(Environment.NewLine, result);
            }
            else
            {
                MessageBox.Show("Ошибка, введите коректные значения");
            }
        }

        private void tb_TotalPayout_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_rate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

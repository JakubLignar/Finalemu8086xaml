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

namespace Projekt
{
   
    public partial class MainWindow : Window
    {
        private Dictionary<string, TextBox> rejestryTb;

        public MainWindow()
        {
            InitializeComponent();
            rejestryTb = new Dictionary<string, TextBox>
            {
                {"AH", AH_tb },
                {"BH", BH_tb },
                {"CH", CH_tb },
                {"DH", DH_tb },
                {"AL", AL_tb },
                {"BL", BL_tb },
                {"CL", CL_tb },
                {"DL", DL_tb },
            };
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tx = sender as TextBox;
            string chars = "1234567890ABCDEF";
            if (tx.Text.Length > 4)
            {
                MessageBox.Show("Podano niepoprawną liczbę!");
                tx.Text = "";
                return;
            }
            foreach (var item in tx.Text)
            {
                if(!chars.Contains(item))
                {
                    MessageBox.Show("złe dane!");
                    tx.Text = "";
                    return;
                }
            }

        }

        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            string rejestr1 = R1_cb.SelectedItem as string;
            string rejestr2 = R2_cb.SelectedItem as string;
            if(rejestr1 == null || rejestr2 == null)
            {
                MessageBox.Show("Wybierz rejestry!");
            }
            else
            {
                rejestryTb[rejestr1].Text = rejestryTb[rejestr2].Text;
            }
        }

       

        private void MoveButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            string rejestr1 = R1_cb.SelectedItem as string;
            string rejestr2 = R2_cb.SelectedItem as string;
            if (rejestr1 == null || rejestr2 == null)
            {
                MessageBox.Show("Proszę wybrać rejestry");
            }
            else
            {
                string tmp = rejestryTb[rejestr1].Text;
                rejestryTb[rejestr1].Text = rejestryTb[rejestr2].Text;
                rejestryTb[rejestr2].Text = tmp;
            }
        }

        private void R1_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

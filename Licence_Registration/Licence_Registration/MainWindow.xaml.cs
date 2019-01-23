using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Licence_Registration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Command;
        DateTime EndDate;
        string HddSerial_No;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["M-BillingOnlineServer"].ConnectionString))
            {
                var Temp = Txt_StartDate.SelectedDate;
                EndDate = Temp.Value.AddYears(1);
                Command = string.Format("Insert into Licence_Customer (CustomerName,MobileNo,CustomerAddress,MoneyPaid,YearlyPlan,StartDate,EndDate,HddInfo) values (" + "'" + Txt_Name.Text + "'" + ',' + "'" +
                          Txt_Mobile_No.Text + "'" + ',' + "'" + Txt_Address.Text + "'" + ',' + Convert.ToInt32(Txt_MoneyPaid.Text) + ',' +
                          Convert.ToInt32(Txt_Yearly_Plan.Text) + ',' + "'" + Convert.ToDateTime(Txt_StartDate.SelectedDate).ToString("yyyy-MM-dd") + "'" + ',' + "'" +
                          Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd") + "'" + ',' + "'" + HddSerial_No + "'" + Txt_Licence_Key.Text + "'" + ")");

                using (SqlCommand cmd = new SqlCommand(Command, con))
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Sucessfull Now yor are Aurthorised to Use This Software until " + EndDate.ToShortDateString(), "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetHddInfo Obj = new GetHddInfo();
            HddSerial_No = Obj.HddSerialNo().ToString();
        }


    }
}

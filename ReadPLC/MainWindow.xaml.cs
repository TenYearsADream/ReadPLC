using Sharp7;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ReadPLC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private S7Client Client;
        private byte[] Buffer = new byte[65536];
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            Client = new S7Client();

            if (IntPtr.Size == 4)
                this.Title = this.Title + " - Running 32 bit Code";
            else
                this.Title = this.Title + " - Running 64 bit Code";

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            int Result;
            //1605 = 170LH
            //1601 = 160lLH
            //1617 = 200LH
            //size = 1400
            Result = Client.DBRead(Convert.ToInt32(TxtIP_Copy.Text), 0, 1500, Buffer);

            MesClass Mesdata = new MesClass();

            if (Result == 0)
            {
                //pos 700
                int DInt = S7.GetDIntAt(Buffer, 700);
                string inter = S7.GetStringAt(Buffer, 726);
                string serial = S7.GetStringAt(Buffer, 764);
                string sss = serial.Trim();
                string ssss = "";
                string iii = inter.Trim();

                if (sss == "")
                {
                    ssss = "0";
                }
                else
                {
                    sss = sss.Substring(0, 2);
                    iii = iii.Substring(0, 6);

                    //search the db - 1 or 2 characters
                    if(sss.Contains(";"))
                    {
                        sss = sss.Substring(0, 1);
                    }
                    ssss = Mesdata.Get_Part(sss);

                    LblText.Content = System.Convert.ToString(DInt);
                    LblText_Copy.Content = iii;

                    listBox1.Items.Add(System.Convert.ToString(DInt) + " -- " + ssss + " (" + sss + ") -- " + iii + " --- " + DateTime.Now.ToString("HH:mm:ss"));
                    listBox1.Items.MoveCurrentToLast();
                }


                listBox1.SelectedItem = listBox1.Items.CurrentItem;
                listBox1.ScrollIntoView(listBox1.Items.CurrentItem);

            }
            else
            {
                MessageBox.Show("failed to read");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Result;
            //ipaddress, rack, slot
            Result = Client.ConnectTo(TxtIP.Text, 0, 0);

            if (Result == 0)
            {
                CmdConnect.IsEnabled = false;
                CmdRead.IsEnabled = true;
                CmdDIs.IsEnabled = true;

                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("failed to conenct");
            }
        }

        private void CmdDIs_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

            dispatcherTimer.Stop();
            dispatcherTimer = null;

            Client.Disconnect();

            CmdRead.IsEnabled = false;
            CmdConnect.IsEnabled = true;
            CmdDIs.IsEnabled = false;
        }

        private void CmdRead_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            dispatcherTimer = new DispatcherTimer();

            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            dispatcherTimer.Start();
        }
    }
}

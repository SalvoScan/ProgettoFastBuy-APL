using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    public partial class FormTracciamentoOrdine : Form
    {
        FormAccedi f1 = (FormAccedi)Program.GetForm1();
        static Thread NotificaTrack = FormVisualizzazioneCarrello.GetThread();

        string myvalue2;
        int counter = 0;

        public FormTracciamentoOrdine()
        {
            InitializeComponent();
        }

        private void FormTracciamentoOrdine_Closed(object sender, EventArgs e)
        {
            f1.Close();
            NotificaTrack.Abort();
        }

        private void FormTracciamentoOrdine_Load(object sender, EventArgs e)
        {
            VisualizzaTracciamento();
        }

        // Usato quando si clicca sul tasto TornaIndietro
        private void B_TornaIndietro_Click(object sender, EventArgs e)
        {
            FormVisualizzazioneOrdini f6 = (FormVisualizzazioneOrdini)Program.GetForm6();
            f6.Show();
            this.pictureBox1.Hide();
            this.Hide();
        }
        public void VisualizzaTracciamento()
        {
            this.pictureBox1.Show();
            string user = FormAccedi.getUser();
            int index = FormVisualizzazioneOrdini.getIndex();
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                // Indirizzo IP usato per connettersi al Server Python (ThreadTracciamentoOrdine)
                // che permette la visualizzazione dell'immagine relativa ai punti riguardardanti
                // il Tracciamento, e il tempo d'attesa per la ricezione della notifica
                tcpclnt.Connect("localhost", 9005);
                Console.WriteLine("Connected");

                Stream stm = tcpclnt.GetStream();

                string myvalue1 = "Tracciamento" + counter + ".png";

                // Concatenazione dei valori inseriti nei campi
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(user + "$" + index);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[2048];

                int k = stm.Read(bb, 0, 2048);

                myvalue2 = @"Images/" + myvalue1;

                using (FileStream fp = File.Create(myvalue2))
                {
                    while (k != 0)
                    {
                        fp.Write(bb, 0, 2048);
                        k = stm.Read(bb, 0, 2048);
                    }

                    Console.WriteLine("Dati Ricevuti Correttamente");

                    // Chiusura File Immagine Ricevuta
                    fp.Close();
                }

                tcpclnt.Close();
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox1.Image = Image.FromFile(myvalue2);
                counter++;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error..... " + ex.StackTrace);
            }
        }

        // Usato quando si clicca sul tasto AggiornaTracciamentoOrdine
        private void B_AggiornaTracciamentoOrdine_Click(object sender, EventArgs e)
        {
            VisualizzaTracciamento();
        }
    }
}
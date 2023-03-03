using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    class ThreadNotificaTrack
    {
        string str_final;
        // Evento di sincronizzazione dei Thread
        ManualResetEvent flag = FormVisualizzazioneCarrello.GetFlag();

        // Funzione di esecuzione del Thread
        public void Notify()
        {
            while (true)
            {
                // Blocco del Thread fino a ricezione del segnale
                flag.WaitOne();
                try
                {
                    TcpClient tcpclnt = new TcpClient();
                    Console.WriteLine("Connecting.....");

                    // Indirizzo IP usato per connettersi al Server Python (Thread Main)
                    // utilizzato per la ricezione dei messaggi quando si raggiunge un determinato punto
                    tcpclnt.Connect("localhost", 9006);
                    Console.WriteLine("Connected");

                    Stream stm = tcpclnt.GetStream();

                    // Concatenazione dei valori inseriti nei campi
                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(FormAccedi.getUser() + "$" + FormVisualizzazioneCarrello.getCodOrdine());
                    Console.WriteLine("Transmitting.....");

                    stm.Write(ba, 0, ba.Length);

                    for (int i = 0; i < 5; i++)
                    {
                        byte[] bb = new byte[100];
                        int k = stm.Read(bb, 0, 100);
                        char[] vec = new char[k];

                        for (int j = 0; j < k; j++)
                        {
                            Console.Write(Convert.ToChar(bb[j]));
                            vec[j] = Convert.ToChar(bb[j]);
                        }

                        str_final = getString(vec);
                        // Console.WriteLine("STRINGA RICEVUTA:  " + str_final);
                        MessageBox.Show(str_final);

                        // Invio della stringa OK, come sorta di ACK
                        asen = new ASCIIEncoding();
                        ba = asen.GetBytes("OK");
                        Console.WriteLine("Transmitting.....");
                        stm.Write(ba, 0, ba.Length);
                    }

                    byte[] bb1 = new byte[100];
                    int k1 = stm.Read(bb1, 0, 100);
                    char[] vec1 = new char[k1];

                    for (int j = 0; j < k1; j++)
                    {
                        Console.Write(Convert.ToChar(bb1[j]));
                        vec1[j] = Convert.ToChar(bb1[j]);
                    }

                    str_final = getString(vec1);
                    // Console.WriteLine("STRINGA RICEVUTA:  " + str_final);
                    MessageBox.Show(str_final);

                    tcpclnt.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error..... " + ex.StackTrace);
                }
                // Viene impostato lo stato di non segnalato, in modo tale da bloccare il Thread
                flag.Reset();
            }
        }

        static string getString(char[] arr)
        {
            string s = new string(arr);
            return s;
        }
    }
}

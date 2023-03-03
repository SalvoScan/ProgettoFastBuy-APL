using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    public partial class FormRegistrazione : Form
    {
        private string user;
        private string pass;
        private string nome;
        private string cognome;
        private string email;
        FormAccedi f1 = (FormAccedi)Program.GetForm1();

        public FormRegistrazione()
        {
            InitializeComponent();
        }
        // Usato quando si clicca sul tasto Registrati
        private void B_Registrati_Click(object sender, EventArgs e)
        {
            String str = user;
            String str1 = pass;
            String str2 = nome;
            String str3 = cognome;
            String str4 = email;

            if (str == null || str1 == null || str2 == null || str3 == null || str4 == null)
            {
                MessageBox.Show("Inserire campi mancanti");
            }

            else {
                try
                {
                    TcpClient tcpclnt = new TcpClient();
                    Console.WriteLine("Connecting.....");

                    // Indirizzo IP usato per connettersi al Server C++
                    tcpclnt.Connect("localhost", 8001);
                    Console.WriteLine("Connected");

                    Stream stm = tcpclnt.GetStream();

                    // Concatenazione dei valori inseriti nei campi
                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes("1" + str + "$" + str1 + "$" + str2 + "$" + str3 + "$" + str4);
                    Console.WriteLine("Transmitting.....");

                    stm.Write(ba, 0, ba.Length);

                    byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);
                    char[] vec = new char[k];

                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(Convert.ToChar(bb[i]));
                        vec[i] = Convert.ToChar(bb[i]);
                    }

                    string str_final = getString(vec);
                    MessageBox.Show(str_final);
                    tcpclnt.Close();

                    if (str_final.CompareTo("Utente registrato!") == 0)
                    {
                        f1.Show();
                        this.Hide();
                    }
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine("Error..... " + ex.StackTrace);
                }
            }
        }

        // Usato quando si clicca sul link Accedi
        private void LinkAccedi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f1.Show();
            this.Hide();
        }
        static string getString(char[] arr)
        {
            string s = new string(arr);
            return s;
        }

        // Funzioni utilizzate per prelevare il testo dai rispettivi campi
        private void NomeText_TextChanged(object sender, EventArgs e)
        {
            string a = NomeText.Text;
            nome = a;
        }

        private void CognomeText_TextChanged(object sender, EventArgs e)
        {
            string b = CognomeText.Text;
            cognome = b;
        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {
            string c = UsernameText.Text;
            user = c;
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            string d = PasswordText.Text;
            pass = d;
        }

        private void EmailText_TextChanged(object sender, EventArgs e)
        {
            string f = EmailText.Text;
            email = f;
        }

        private void FormRegistrazione_Closed(object sender, EventArgs e)
        {
            f1.Close();
        }
    }
}
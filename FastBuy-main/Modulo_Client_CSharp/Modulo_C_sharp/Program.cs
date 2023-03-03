using System;
using System.Windows.Forms;

namespace Modulo_C_sharp
{
    static class Program
    {
        private static FormAccedi f1;
        private static FormRegistrazione f2;
        private static FormInserimentoProd f3;
        private static FormSceltaCategoria f4;
        private static FormVisualizzazioneCarrello f5;
        private static FormVisualizzazioneOrdini f6;
        private static FormVisualizzazioneProdottiOrdine f7;
        private static FormTracciamentoOrdine f8;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetCompatibleTextRenderingDefault(false);
            f1 = new FormAccedi();
            f2 = new FormRegistrazione();
            f3 = new FormInserimentoProd();
            f4 = new FormSceltaCategoria();
            f5 = new FormVisualizzazioneCarrello();
            f6 = new FormVisualizzazioneOrdini();
            f7 = new FormVisualizzazioneProdottiOrdine();
            f8 = new FormTracciamentoOrdine();

            Application.EnableVisualStyles();

            Application.Run(f1);
        }

        public static Form GetForm1()
        {
            return f1; 
        }
        public static Form GetForm2()
        {
            return f2;
        }
        public static Form GetForm3()
        {
            return f3;
        }
        public static Form GetForm4()
        {
            return f4;
        }
        public static Form GetForm5()
        {
            return f5;
        }
        public static Form GetForm6()
        {
            return f6;
        }
        public static Form GetForm7()
        {
            return f7;
        }
        public static Form GetForm8()
        {
            return f8;
        }
    }
}
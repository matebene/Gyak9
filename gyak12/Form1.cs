using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace gyak12
{
    public partial class Form1 : Form
    {
        Excel.Application xlApp; //Microsoft excel alkalmaz�s
        Excel.Workbook xlWB; //Munkaf�zet l�trehoz�sa
        Excel.Worksheet xlSheet; //Munnkalap munkaf�zeten bel�l
         
        
        void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application(); //Applik�ci� adatbet�lt�s�nek ind�t�sa
                xlWB = xlApp.Workbooks.Add(Missing.Value); //�j munkaf�zet hozz�ad�sa
                xlSheet = xlWB.ActiveSheet; //�j munkalap

                CreateTable(); //T�blal�trehoz�sa
                //Controll �tad�sa a felhaszn�l�nak
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Error: {0}\nline {1}", ex.Message, ex.Source);
                MessageBox.Show(errmsg, "Error");
                
                //Hiba eset�n excel bez�r�sa
                xlWB.Close(false,Type.Missing,Type.Missing);
                xlApp.Quit();
                xlWB=null;
                xlApp=null;
            }
        }
            void CreateTable()
            {
                string[] fejl�cek = new string[] {
                "K�rd�s",
                "1. v�lasz",
                "2. v�lasz",
                "3. v�lasz",
                "Helyes v�lasz",
                "k�p"};
            
            Models.HajosContext hajosContext = new Models.HajosContext();
            var mindenK�rd�s = hajosContext.Questions.ToList();
            object[,] adatT�mb = new object[mindenK�rd�s.Count(), fejl�cek.Count()];
            for (int i = 0; i < mindenK�rd�s.Count(); i++)
            {
                adatT�mb[i, 0] = mindenK�rd�s[i].Question1;
                adatT�mb[i, 1] = mindenK�rd�s[i].Answer1;
                adatT�mb[i, 2] = mindenK�rd�s[i].Answer2;
                adatT�mb[i, 3] = mindenK�rd�s[i].Answer3;
                adatT�mb[i, 4] = mindenK�rd�s[i].CorrectAnswer;
                adatT�mb[i, 5] = mindenK�rd�s[i].Image;
            }
            int sorokSz�ma = adatT�mb.GetLength(0);
            int oszlopokSz�ma = adatT�mb.GetLength(1);
            Excel.Range adatRange = xlSheet.get_Range("A2", Type.Missing).get_Resize(sorokSz�ma, oszlopokSz�ma);
            adatRange.Value2 = adatT�mb;
            adatRange.Columns.AutoFit();
          

        }
        
        public Form1()
        {
            InitializeComponent();
            CreateExcel();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
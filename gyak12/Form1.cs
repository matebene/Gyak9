using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace gyak12
{
    public partial class Form1 : Form
    {
        Excel.Application xlApp; //Microsoft excel alkalmazás
        Excel.Workbook xlWB; //Munkafüzet létrehozása
        Excel.Worksheet xlSheet; //Munnkalap munkafüzeten belül
         
        
        void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application(); //Applikáció adatbetöltésének indítása
                xlWB = xlApp.Workbooks.Add(Missing.Value); //Új munkafüzet hozzáadása
                xlSheet = xlWB.ActiveSheet; //Új munkalap

                CreateTable(); //Táblalétrehozása
                //Controll átadása a felhasználónak
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errmsg = string.Format("Error: {0}\nline {1}", ex.Message, ex.Source);
                MessageBox.Show(errmsg, "Error");
                
                //Hiba esetén excel bezárása
                xlWB.Close(false,Type.Missing,Type.Missing);
                xlApp.Quit();
                xlWB=null;
                xlApp=null;
            }
        }
            void CreateTable()
            {
                string[] fejlécek = new string[] {
                "Kérdés",
                "1. válasz",
                "2. válasz",
                "3. válasz",
                "Helyes válasz",
                "kép"};
            
            Models.HajosContext hajosContext = new Models.HajosContext();
            var mindenKérdés = hajosContext.Questions.ToList();
            object[,] adatTömb = new object[mindenKérdés.Count(), fejlécek.Count()];
            for (int i = 0; i < mindenKérdés.Count(); i++)
            {
                adatTömb[i, 0] = mindenKérdés[i].Question1;
                adatTömb[i, 1] = mindenKérdés[i].Answer1;
                adatTömb[i, 2] = mindenKérdés[i].Answer2;
                adatTömb[i, 3] = mindenKérdés[i].Answer3;
                adatTömb[i, 4] = mindenKérdés[i].CorrectAnswer;
                adatTömb[i, 5] = mindenKérdés[i].Image;
            }
            int sorokSzáma = adatTömb.GetLength(0);
            int oszlopokSzáma = adatTömb.GetLength(1);
            Excel.Range adatRange = xlSheet.get_Range("A2", Type.Missing).get_Resize(sorokSzáma, oszlopokSzáma);
            adatRange.Value2 = adatTömb;
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
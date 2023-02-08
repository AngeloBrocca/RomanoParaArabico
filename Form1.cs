namespace RomToDecC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int GetSym(char sym) 
        {
            IDictionary<char, int> numberCs = new Dictionary<char, int>();
            numberCs.Add('I', 1);
            numberCs.Add('V', 5);
            numberCs.Add('X', 10);
            numberCs.Add('L', 50);
            numberCs.Add('C', 100);
            numberCs.Add('D', 500);
            numberCs.Add('M', 1000);

            return numberCs.SingleOrDefault(s=>s.Key==sym).Value;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            

            int total = 0;
            char[] romArr = textR.Text.ToArray();
            for (int i = 0; i < romArr.Length; i++)
            {
                int value1 = GetSym(romArr[i]);
                if (i+1 < romArr.Length) 
                {
                    int value2 = GetSym(romArr[i+1]);
                    if (value1 >= value2) 
                    { 
                        total = total + value1; 
                    }
                    else
                    {
                        total = total + value2 - value1;
                        i++;
                    }
                }
                else
                {
                    total = total + value1;
                }
            }

            string t = total.ToString();
            MessageBox.Show("Número traduzido: "+t, "Resultado",
                MessageBoxButtons.OK);

        }
    }
}
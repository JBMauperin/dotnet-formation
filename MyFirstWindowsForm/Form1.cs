namespace MyFirstWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void JeClickBoutonLinux(object sender, EventArgs e)
        {
            var monButton = (Button)sender;
            
            if(monButton.Text == "J'aime Linux")
            {
                monButton.Text = "J'aime Windows";
            }
            else
            {
                monButton.Text = "J'aime Linux";
            }
        }
    }
}

namespace WindowsFormsBasics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Hellow Windows";
            //BackColor = Color.Green ;
            //BackColor = Color.FromArgb(200,140,100);
            Load += Form1_Load;
            //MouseEnter += Form1_MouseEnter;
            //MouseLeave += Form1_MouseLeave;
            Button button =  new();
            button.Text = "click";
            button.Location = new(100, 40);
            Controls.Add(button);
            button.Click += Button_Click;


        }

        private void Button_Click(object? sender, EventArgs e)
        {
            BackColor = Color.FromArgb(104, 170, 220); ;
        }

        private void Form1_MouseLeave(object? sender, EventArgs e)
        {
            BackColor = Color.FromArgb(230, 240, 150);
        }

        private void Form1_MouseEnter(object? sender, EventArgs e)
        {
            BackColor = Color.FromArgb(200, 140, 100);
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            Console.WriteLine("Form loaded");
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(100, 180, 200);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Random random = new Random();
            //BackColor = Color.FromArgb(random.Next(257), random.Next(257), random.Next(257));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}

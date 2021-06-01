using System;
using System.Windows.Forms;
using CubicBoard;

namespace WindowGameF
{
    public partial class FormGame15 : Form
    {
        const int size = 4;
        GameLogic game;
        public FormGame15()
        {
            InitializeComponent();
            game = new GameLogic(size);
            HideButtons();
        }

     
       

        void HideButtons() {
            for (int x=0; x<size; ++x) {
                for (int y=0; y<size; ++y) {
                    ShowDigitAt(0, x, y);
                }
            }
        }

        void ShowButtons() {
            for (int x = 0; x < size; ++x)
            {
                for (int y = 0; y < size; ++y)
                {
                    ShowDigitAt(game.GetDigitAt(x, y), x, y);
                }
            }
            labelMoves.Text = game.moves.ToString();
        }
        
        void ShowDigitAt(int digit, int x, int y) {
            Button button = (Button)Controls["b"+x+y];
            button.Text = digit.ToString();
            button.Visible = digit > 0;
        }

      

        private void Start_Click(object sender, EventArgs e)
        {
            Quantity.Text = "Количество ходов:";
            game.Start(1000 + DateTime.Now.Second);
            ShowButtons();
        }

        private void b00_Click_1(object sender, EventArgs e)
        {
            if (game.Solved()) return;
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Substring(1, 1));
            int y = int.Parse(button.Name.Substring(2, 1));
            game.PressAt(x, y);
            ShowButtons();
            if (game.Solved())
            {
                Quantity.Text = "           Победа!!!";  
            }
        }
    }
}

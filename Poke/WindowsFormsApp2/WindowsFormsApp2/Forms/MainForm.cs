using System;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        private Button[] gameButtons;
        private bool isPlayerXTurn = true;
        private int movesCount = 0;
        private int highscoreX = 0;
        private int highscoreO = 0;
        private string difficulty = "Einfach";
        private GameLogic gameLogic;
        private Timer blinkTimer;
        private bool blinkState = false;
        private int[] winningLine;

        public MainForm()
        {
            InitializeComponent();
            gameLogic = new GameLogic();
            InitializeGame();
            CustomizeButtonAppearance();
            SetupBlinkTimer();
        }

        private void InitializeGame()
        {
            gameButtons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            
            foreach (Button btn in gameButtons)
            {
                btn.Text = "";
                btn.Enabled = true;
                btn.Click += GameButton_Click;
                btn.MouseEnter += Button_MouseEnter;
                btn.MouseLeave += Button_MouseLeave;
            }

            button12.Text = "Neues Spiel";
            button12.Click += NeuesSpiel_Click;
            button10.Text = $"Highscore\nX: {highscoreX} O: {highscoreO}";
            button11.Click += Button11_Click;
            difficultyComboBox.Items.AddRange(new object[] { "Einfach", "Mittel", "Schwer" });
            difficultyComboBox.SelectedIndex = 0;
            difficultyComboBox.SelectedIndexChanged += DifficultyComboBox_SelectedIndexChanged;
        }

        private void CustomizeButtonAppearance()
        {
            foreach (Button btn in gameButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.WhiteSmoke;
                btn.ForeColor = isPlayerXTurn ? Color.FromArgb(231, 76, 60) : Color.FromArgb(41, 128, 185);
                btn.Font = new Font("Segoe UI", 24, FontStyle.Bold);
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            }

            button12.FlatStyle = FlatStyle.Flat;
            button12.BackColor = Color.MediumSeaGreen;
            button12.ForeColor = Color.White;
            button12.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            button12.FlatAppearance.BorderSize = 1;
            button12.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);

            button10.FlatStyle = FlatStyle.Flat;
            button10.BackColor = Color.CornflowerBlue;
            button10.ForeColor = Color.White;
            button10.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            button10.FlatAppearance.BorderSize = 1;
            button10.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);

            button11.FlatStyle = FlatStyle.Flat;
            button11.BackColor = Color.Orange;
            button11.ForeColor = Color.White;
            button11.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            button11.FlatAppearance.BorderSize = 1;
            button11.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);

            difficultyComboBox.FlatStyle = FlatStyle.Flat;
            difficultyComboBox.BackColor = Color.FromArgb(200, 200, 200);
            difficultyComboBox.ForeColor = Color.Black;
            difficultyComboBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            BackColor = Color.FromArgb(245, 245, 245);
        }

        private void SetupBlinkTimer()
        {
            blinkTimer = new Timer();
            blinkTimer.Interval = 300;
            blinkTimer.Tick += (s, e) =>
            {
                if (winningLine != null)
                {
                    foreach (var index in winningLine)
                    {
                        gameButtons[index].BackColor = blinkState ? Color.FromArgb(39, 174, 96) : Color.WhiteSmoke;
                    }
                    blinkState = !blinkState;
                }
            };
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled)
            {
                btn.BackColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled)
            {
                btn.BackColor = Color.WhiteSmoke;
            }
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "")
            {
                try
                {
                    using (var player = new SoundPlayer(@"C:\Users\IT\Desktop\CSHARP-Grundlagen\Poke\WindowsFormsApp2\WindowsFormsApp2\Forms\why.wav"))
                    {
                        player.Play();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing why.wav: {ex.Message}", "Error");
                }
                btn.Text = "X";
                btn.ForeColor = Color.FromArgb(231, 76, 60);
                btn.Enabled = false;
                movesCount++;
                winningLine = gameLogic.CheckWin(gameButtons.Select(b => b.Text).ToArray());
                if (winningLine != null)
                {
                    highscoreX++;
                    button10.Text = $"Highscore\nX: {highscoreX} O: {highscoreO}";
                    MessageBox.Show("Spieler X gewinnt!", "Spielende");
                    blinkTimer.Start();
                    DisableAllButtons();
                }
                else if (movesCount == 9)
                {
                    MessageBox.Show("Unentschieden!", "Spielende");
                }
                else
                {
                    isPlayerXTurn = false;
                    ComputerMove();
                }
            }
        }

        private void ComputerMove()
        {
            var availableButtons = gameButtons.Where(b => b.Text == "" && b.Enabled).ToList();
            if (availableButtons.Count == 0) return;

            Button computerChoice = null;
            switch (difficulty)
            {
                case "Einfach":
                    computerChoice = gameLogic.GetRandomMove(availableButtons);
                    break;
                case "Mittel":
                    computerChoice = gameLogic.GetWinningMove(gameButtons, "O") ?? gameLogic.GetBlockingMove(gameButtons, "X") ?? gameLogic.GetRandomMove(availableButtons);
                    break;
                case "Schwer":
                    computerChoice = gameLogic.GetWinningMove(gameButtons, "O") ?? gameLogic.GetBlockingMove(gameButtons, "X") ?? gameLogic.GetStrategicMove(gameButtons) ?? gameLogic.GetRandomMove(availableButtons);
                    break;
            }

            try
            {
                using (var player = new SoundPlayer(@"C:\Users\IT\Desktop\CSHARP-Grundlagen\Poke\WindowsFormsApp2\WindowsFormsApp2\Forms\Huh.wav"))
                {
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing Huh.wav: {ex.Message}", "Error");
            }
            computerChoice.Text = "O";
            computerChoice.ForeColor = Color.FromArgb(41, 128, 185);
            computerChoice.Enabled = false;
            movesCount++;
            winningLine = gameLogic.CheckWin(gameButtons.Select(b => b.Text).ToArray());
            if (winningLine != null)
            {
                highscoreO++;
                button10.Text = $"Highscore\nX: {highscoreX} O: {highscoreO}";
                try
                {
                    using (var player = new SoundPlayer(@"C:\Users\IT\Desktop\CSHARP-Grundlagen\Poke\WindowsFormsApp2\WindowsFormsApp2\Forms\gay.wav"))
                    {
                        player.Play();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing gay.wav: {ex.Message}", "Error");
                }
                MessageBox.Show("Computer O gewinnt!", "Spielende");
                blinkTimer.Start();
                DisableAllButtons();
            }
            else if (movesCount == 9)
            {
                MessageBox.Show("Unentschieden!", "Spielende");
            }
            else
            {
                isPlayerXTurn = true;
            }
        }

        private void NeuesSpiel_Click(object sender, EventArgs e)
        {
            foreach (Button btn in gameButtons)
            {
                btn.Text = "";
                btn.Enabled = true;
                btn.BackColor = Color.WhiteSmoke;
            }
            isPlayerXTurn = true;
            movesCount = 0;
            winningLine = null;
            blinkTimer.Stop();
        }

        private void DisableAllButtons()
        {
            foreach (Button btn in gameButtons)
            {
                btn.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Aktueller Highscore:\nSpieler X: {highscoreX}\nComputer O: {highscoreO}", "Highscore");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NeuesSpiel_Click(sender, e);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anmeldung noch nicht implementiert!", "Info");
        }

        private void DifficultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            difficulty = difficultyComboBox.SelectedItem.ToString();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (gameButtons != null)
            {
                float fontSize = Math.Max(12, Math.Min(ClientSize.Width / 20, 24));
                foreach (var btn in gameButtons)
                {
                    btn.Font = new Font("Segoe UI", fontSize, FontStyle.Bold);
                }
                button12.Font = new Font("Segoe UI", fontSize / 2, FontStyle.Bold);
                button10.Font = new Font("Segoe UI", fontSize / 2.4f, FontStyle.Regular);
                button11.Font = new Font("Segoe UI", fontSize / 2, FontStyle.Bold);
                difficultyComboBox.Font = new Font("Segoe UI", fontSize / 2.4f, FontStyle.Regular);
            }
        }
    }
}
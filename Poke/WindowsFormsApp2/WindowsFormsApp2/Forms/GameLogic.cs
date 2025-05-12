using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class GameLogic
    {
        private Random random = new Random();

        public int[] CheckWin(string[] board)
        {
            int[][] winConditions = new int[][]
            {
                new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 },
                new[] { 0, 3, 6 }, new[] { 1, 4, 7 }, new[] { 2, 5, 8 },
                new[] { 0, 4, 8 }, new[] { 2, 4, 6 }
            };

            foreach (var condition in winConditions)
            {
                if (board[condition[0]] != "" && board[condition[0]] == board[condition[1]] && board[condition[1]] == board[condition[2]])
                {
                    return condition;
                }
            }
            return null;
        }

        public Button GetRandomMove(List<Button> availableButtons)
        {
            return availableButtons[random.Next(availableButtons.Count)];
        }

        public Button GetWinningMove(Button[] buttons, string player)
        {
            foreach (var btn in buttons.Where(b => b.Text == ""))
            {
                btn.Text = player;
                bool win = CheckWin(buttons.Select(b => b.Text).ToArray()) != null;
                btn.Text = "";
                if (win) return btn;
            }
            return null;
        }

        public Button GetBlockingMove(Button[] buttons, string opponent)
        {
            return GetWinningMove(buttons, opponent);
        }

        public Button GetStrategicMove(Button[] buttons)
        {
            if (buttons[4].Text == "") return buttons[4];
            var corners = new[] { buttons[0], buttons[2], buttons[6], buttons[8] };
            var availableCorners = corners.Where(b => b.Text == "").ToList();
            if (availableCorners.Count > 0) return availableCorners[random.Next(availableCorners.Count)];
            return null;
        }
    }
}
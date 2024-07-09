using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class TicTacToeGame : MonoBehaviour
    {
        public Button[] buttons;
        public TextMeshProUGUI[] buttonTexts;
        public TextMeshProUGUI resultText;

        private readonly char[] board = new char[9];
        private readonly char player = 'X';
        private readonly char ai = 'O';

        private void Start()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i;
                buttons[i].onClick.AddListener(() => OnButtonClick(index));
            }
            ResetBoard();
        }

        private void OnButtonClick(int index)
        {
            if (board[index] == ' ')
            {
                MakeMove(index, player);
                if (WinnerDeterminer(player))
                {
                    ShowMessage("Player Wins");
                    DisableButtons();
                    Invoke(nameof(ResetBoard), 1f);
                }

                else if (IsBoardFull())
                {
                    ShowMessage("Draw");
                    Invoke(nameof(ResetBoard), 1f);
                }

                else
                {
                    MakeMove(MinimaxMove(), ai);
                    if (WinnerDeterminer(ai))
                    {
                        ShowMessage("AI Wins!");
                        DisableButtons();
                        Invoke(nameof(ResetBoard), 1f);
                    }
                    else if (IsBoardFull())
                    {
                        ShowMessage("Draw");
                        Invoke(nameof(ResetBoard), 1f);
                    }
                }
            }
        }

        private void MakeMove(int index, char currentPlayer)
        {
            board[index] = currentPlayer;
            buttonTexts[index].text = currentPlayer.ToString();
            buttons[index].interactable = false;
        }

        private int MinimaxMove()
        {
            int bestScore = int.MinValue;
            int move = -1;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == ' ')
                {
                    board[i] = ai;
                    int score = Minimax(board, 0, false);
                    board[i] = ' ';
                    if (score > bestScore)
                    {
                        bestScore = score;
                        move = i;
                    }
                }
            }
            return move;
        }

        private int Minimax(char[] newBoard, int depth, bool isMaximizing)
        {
            if (WinnerDeterminer(ai)) return 10 - depth;
            if (WinnerDeterminer(player)) return depth - 10;
            if (IsBoardFull()) return 0;

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < newBoard.Length; i++)
                {
                    if (newBoard[i] == ' ')
                    {
                        newBoard[i] = ai;
                        int score = Minimax(newBoard, depth + 1, false);
                        newBoard[i] = ' ';
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < newBoard.Length; i++)
                {
                    if (newBoard[i] == ' ')
                    {
                        newBoard[i] = player;
                        int score = Minimax(newBoard, depth + 1, true);
                        newBoard[i] = ' ';
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
                return bestScore;
            }
        }

        private bool WinnerDeterminer(char currentPlayer)
        {
            int[,] winPatterns = WinPattern();

            for (int i = 0; i < winPatterns.GetLength(0); i++)
            {
                if (board[winPatterns[i, 0]] == currentPlayer &&
                    board[winPatterns[i, 1]] == currentPlayer &&
                    board[winPatterns[i, 2]] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        private int[,] WinPattern()
        {
            int[,] winPatterns = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Rows
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Columns
                {0, 4, 8}, {2, 4, 6}             // Diagonals
            };

            return winPatterns;
        }

        private bool IsBoardFull()
        {
            foreach (char c in board)
            {
                if (c == ' ')
                    return false;
            }
            return true;
        }

        private void DisableButtons()
        {
            foreach (Button btn in buttons)
            {
                btn.interactable = false;
            }
        }

        private void ResetBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
                buttonTexts[i].text = "";
                buttons[i].interactable = true;
            }
            ShowMessage(string.Empty);
        }

        private void ShowMessage(string message)
        {
            resultText.text = message;
        }

        public void OnResetButtonClick()
        {
            ResetBoard();
        }
    }
}
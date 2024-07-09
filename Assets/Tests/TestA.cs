using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class TestA : MonoBehaviour
    {
        public Button[] buttons;
        private void Start()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i;
                buttons[i].onClick.AddListener(() => OnButtonClick(index));
            }
        }

        private void OnButtonClick(int index)
        {
            print(index);
        }
    }
}
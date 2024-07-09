using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class UILobbyManager : UIManager
    {
        public void OnOressPlay()
        {
            Events_TicTacToe.UI.OnPressPlay.Dispatch(Scenes.GamePlay);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TicTacToe
{
    public class UIGamePlayManager : UIManager
    {
        [Header("Asset References")]
        [SerializeField] private Sprite musicOn;
        [SerializeField] private Sprite musicOff;
        [SerializeField] private Sprite soundOn;
        [SerializeField] private Sprite soundOff;
        [SerializeField] private Sprite circle;
        [SerializeField] private Sprite cross;
        [SerializeField] private Image tilePrefabImage;
        [SerializeField] private Image musicImage;
        [SerializeField] private Image soundImage;
        [SerializeField] private TextMeshProUGUI notificationText;
        [SerializeField] private Image notificationImage;

        public void OnPressHome()
        {
            Events_TicTacToe.UI.OnPressHome.Dispatch(Scenes.Lobby);
        }
    }
}
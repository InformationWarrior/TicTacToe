using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace TicTacToe
{
    public class Tile : MonoBehaviour
    {
        [Header("Component References")]
        [SerializeField] private Image playerImage;
        [SerializeField] private Button buttonInteractivity;
        [SerializeField] private TextMeshProUGUI buttonText;
        public string playerSide;

        private void Start()
        {
            buttonInteractivity = GetComponent<Button>();
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
        }

        //Difference between isActiveAndEnabled and IsActive()

        /*IsActive():

Definition: This is a method of the GameObject class.
Usage: It checks whether the GameObject itself is active in the hierarchy.
Returns: A boolean value indicating whether the GameObject is active (true) or not (false).
Syntax: gameObject.IsActive()
isActiveAndEnabled:

Definition: This is a property of the Component class, which includes MonoBehaviour and derived classes like Image.
Usage: It checks whether the component is both active in the hierarchy and enabled.
Returns: A boolean value indicating whether the component is active and enabled (true) or not (false).
Syntax: component.isActiveAndEnabled
In your specific case, playerImage is an Image component, so isActiveAndEnabled is appropriate. The IsActive() method would apply if you were checking the status of the GameObject directly.
        
         Explanation:
playerImage.isActiveAndEnabled: Checks if the Image component is both active in the hierarchy and enabled. This ensures that the component is ready to display the sprite.
playerImage.gameObject.SetActive(true): Activates the GameObject to which the Image component is attached if it is not already active.
Summary
Use isActiveAndEnabled to check the state of a component (like Image, Button, etc.).
Use IsActive() to check the active state of a GameObject in the hierarchy.*/



        /*To activate or enable a component like an Image, you can use the enabled property directly, rather than activating the entire GameObject. This is often more efficient and precise if you only need to enable or disable a specific component.
         
         
         Explanation:
playerImage.enabled: This property enables or disables the Image component. When set to true, the Image component becomes active and can render the sprite.
Check and set enabled: This ensures that the Image component is enabled if it was previously disabled.
This approach focuses on enabling the Image component itself rather than the entire GameObject, providing more granular control.

If you still need to use SetActive(true) for some reason, like ensuring the entire GameObject is active (not just the Image component), you can retain that line. However, using enabled directly on the Image component is often the better approach if your primary concern is whether the Image can render.*/


        public void SetPlayerTileSprite(Sprite sprite)
        {
            if (sprite == null) return;

            if (!playerImage.isActiveAndEnabled)
                playerImage.enabled = true;

            playerImage.sprite = sprite;
        }

        
    }
}
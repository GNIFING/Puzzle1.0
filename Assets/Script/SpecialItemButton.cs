using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemButton : MonoBehaviour
{
    public GameObject textPanel;
    public GameObject parentObject;
    public PlayerMovement player;

    public void ClosePanel()
    {
        if (textPanel != null)
        {
            textPanel.SetActive(false);
            Time.timeScale = 1;
            player.AddScore(20);
            Destroy(parentObject);
        }
    }
}

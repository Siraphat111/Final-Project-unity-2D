using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuCon : MonoBehaviour
{
    public GameObject menuCanvas;

    void Start()
    {
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.tabKey.wasPressedThisFrame)
        {
            if (menuCanvas != null)
            {
                menuCanvas.SetActive(!menuCanvas.activeSelf);
            }
        }
    }
}

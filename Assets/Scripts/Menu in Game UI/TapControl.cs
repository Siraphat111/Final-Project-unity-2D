using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapControl : MonoBehaviour
{
    public Image[] TabImages;
    public GameObject[] pages;
    void Start()
    {
        Activatetab(0);
    }

    public void Activatetab(int tabNo)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            TabImages[i].color = new Color(0.5f, 0.5f, 0.5f, 1); // gray
        }
        pages[tabNo].SetActive(true);
        TabImages[tabNo].color = new Color(1, 1, 1, 1); // white
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] GameObject panelOptions;
    // [SerializeField] GameObject player;
    private bool isPause;
    // Update is called once per frame
    void Update()
    {
        if (panelOptions.activeSelf)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }

    private void Pause()
    {
        isPause = true;
        Time.timeScale = 0f;

        // player.active = false;

    }

    private void Unpause()
    {
        isPause = false;
        Time.timeScale = 1f;
    }

}

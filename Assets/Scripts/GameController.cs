using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool activePanelTooltip;

    void Start()
    {
        activePanelTooltip = false;
        panel.SetActive(false);
    }
    public void showTooltip()
    {
        panel.SetActive(true);
        activePanelTooltip = true;
    }

    public void hideTooltip()
    {
        panel.SetActive(false);
        activePanelTooltip = false;
    }

    public void TooltipButton()
    {
        if (activePanelTooltip)
        {
            hideTooltip();
        }
        else
        {
            showTooltip();
        }
    }

    public void gameRestart()
    {
        SceneManager.LoadScene("main");
    }

}

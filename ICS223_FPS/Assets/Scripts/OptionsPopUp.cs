using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopUp : BasePopup
{
    [SerializeField] SettingsPopUp settings;

    public void OnSettingsButton()
    {
        Debug.Log("settings clicked");
        settings.Open();
        Close();
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        Close();
    }
}

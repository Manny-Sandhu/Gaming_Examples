using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopUp : MonoBehaviour
{
    [SerializeField] Slider difficultySlider;
    [SerializeField] TextMeshProUGUI difficultyLabel;
    [SerializeField] OptionsPopUp options;

    public void OnOKButton()
    {
        Close();
        options.Open();
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
    }
    public void OnCancelButton()
    {
        Close();
        options.Open();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.SetText("Difficulty: " +((int)difficulty).ToString());
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }
}

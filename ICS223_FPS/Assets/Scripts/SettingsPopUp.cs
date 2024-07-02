using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopUp : BasePopup
{
    [SerializeField] Slider difficultySlider;
    [SerializeField] TextMeshProUGUI difficultyLabel;
    [SerializeField] OptionsPopUp options;

    public void OnOKButton()
    {
        Close();
        options.Open();
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);

    }
    public void OnCancelButton()
    {
        Close();
        options.Open();
    }

    override public void Open()
    {
        base.Open();
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
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

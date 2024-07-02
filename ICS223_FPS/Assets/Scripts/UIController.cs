using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopUp optionsPopup;
    [SerializeField] private SettingsPopUp settingsPopup;

    private int popupsActive = 0;

    //private int score = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChange);
        Messenger.AddListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChange);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
    }

    void Start()
    {
        //UpdateScore(score);
        UpdateHealth(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && popupsActive == 0)
        {
            SetGameActive(false);
            optionsPopup.Open();
        }
    }

    // update score display
    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
            crossHair.gameObject.SetActive(true); // show the crosshair
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
    }

    public void OnHealthChange(float healthPercent)
    {
        UpdateHealth(healthPercent);
        /*if(healthPecent >= 0.6)
        {
            healthBar.color = Color.green;
        } else if(healthPecent >= 0.4)
        {
            healthBar.color = Color.yellow;
        } else
        {
            healthBar.color = Color.red;
        }*/
    }

    public void UpdateHealth(float healthPercent)
    {
        healthBar.fillAmount = healthPercent;
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercent);
    }

    public void OnPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
    }

    public void OnPopupClosed()
    {
        popupsActive--;
        if(popupsActive == 0)
        {
            SetGameActive(true);
        }
    }
}

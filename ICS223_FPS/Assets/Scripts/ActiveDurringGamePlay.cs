using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDurringGamePlay : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnGameInactive);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnGameInactive);
    }

    public void OnGameActive()
    {
        this.enabled = true;
    }

    public void OnGameInactive()
    {
        this.enabled = false;
    }
}

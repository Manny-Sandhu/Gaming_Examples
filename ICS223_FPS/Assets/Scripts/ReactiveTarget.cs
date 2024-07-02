using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit()
    {
        WanderingAI enemyAI = GetComponent<WanderingAI>();
        if(enemyAI != null) {
            if(enemyAI.GetState() == EnemyStates.alive)
            {
                enemyAI.ChangeState(EnemyStates.dead);
                Messenger.Broadcast(GameEvent.ENEMY_DEAD);
            }
           
            Animator enemyAnimator = GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Die");
            }
        }
        //StartCoroutine(Die());

    }
    private IEnumerator Die()
    {
        // Enemy falls over and disappears after two seconds
        //iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);     
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void DeadEvent()
    {
        Destroy(this.gameObject);
    }
}

using System.Collections;
using UnityEngine;
using ObjectPooling;
public class EnemyStatus : MonoBehaviour
{
    [SerializeField] float enemyHealty;
    //[SerializeField] EnemyAnimations enemyAnimations;
    public void DealDamage(int damage)
    {
        enemyHealty -= damage;
        if (enemyHealty <= 0)
        {

           // enemyAnimations.DieAnimation();
            StartCoroutine(WaitForAnimationToEnd());
        }

    }
    IEnumerator WaitForAnimationToEnd()
    {
        //yield return new WaitForSeconds(enemyAnimations.enemyAnimator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(1);   
        ObjectPooler.instance.ReturnToPool("Enemy", gameObject);
    }
}

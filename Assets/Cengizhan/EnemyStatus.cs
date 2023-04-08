using System.Collections;
using UnityEngine;
using ObjectPooling;
public class EnemyStatus : MonoBehaviour
{
    public float enemyHealty;
    public GameObject exp;
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
        Instantiate(exp, transform.position, Quaternion.identity);
        ObjectPooler.instance.ReturnToPool("Enemy", gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ProjectileController projectileController))
        {
            DealDamage(50);
            

        }
    }

}

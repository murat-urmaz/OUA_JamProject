using System.Collections;
using UnityEngine;
using ObjectPooling;
public class EnemyStatus : MonoBehaviour
{
    public float enemyHealty;
    public GameObject exp;
    public GameObject damageTextPrefab;
    [SerializeField] AudioSource audioSource;
    //[SerializeField] EnemyAnimations enemyAnimations;
    public void DealDamage(int damage)
    {
        enemyHealty -= damage;
        if (enemyHealty <= 0)
        {
           // enemyAnimations.DieAnimation();
            StartCoroutine(WaitForAnimationToEnd());
        }
        else if(damageTextPrefab!=null){
            var text = Instantiate(damageTextPrefab,transform.position + new Vector3(0,1.2f,0), Quaternion.identity, transform);
            text.GetComponent<TextMesh>().text = damage.ToString();
        }

    }
    IEnumerator WaitForAnimationToEnd()
    {
        //yield return new WaitForSeconds(enemyAnimations.enemyAnimator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(0.1f);
        Instantiate(exp, transform.position, Quaternion.identity);
        ObjectPooler.instance.ReturnToPool("Enemy", gameObject);
        audioSource.Play();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ProjectileController projectileController))
        {
            DealDamage(50);
            

        }
        if (collision.gameObject.CompareTag("Pencil"))
        {
            DealDamage(50);
            Debug.Log("kalemle vurdum hehe");
        }
    }

}

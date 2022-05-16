using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    Animation ani;
    //as it is a sword I only assign how much damage it deals
    public weaponData wData;
    [SerializeField] float hitSphereSize = 2;

    private void Awake()
    {
        ani = GetComponent<Animation>();
        wData = GetComponent<weaponData>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwordAttack();
        }
        
    }

    public void SwordAttack()
    {
        ani.Play();
        
        Collider2D[] swordHits = Physics2D.OverlapCircleAll(transform.position + transform.up, hitSphereSize, wData.enemyLayer);

        foreach(Collider2D Enemyhit in swordHits)
        {
            Debug.Log("you hit: " + Enemyhit);
            //if its a corspe, send it flying because its fun
            if (Enemyhit.CompareTag("DeadEnemy"))
            {
                Enemyhit.GetComponent<Rigidbody2D>().AddForce(transform.right * wData.damage, ForceMode2D.Impulse);
                return;
            }

            Enemyhit.GetComponent<enemyData>().dealDamage(wData.damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + transform.up, hitSphereSize);
    }

}

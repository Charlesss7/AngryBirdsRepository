using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBird : Bird
{
    [SerializeField]
    public float fieldImpact;
    public float force;

    public LayerMask LayerToHit;
    public GameObject ExplosionEffect;
    void explode()
    {
        Collider2D[] objects= Physics2D.OverlapCircleAll(transform.position, fieldImpact, LayerToHit);
        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 0.1f);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldImpact);
    }
    public override void OnExplode()
    {
        explode();
    }
}

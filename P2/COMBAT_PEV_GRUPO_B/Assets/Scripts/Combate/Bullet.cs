using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float damage;
    float _destroyTime = 5;
    public void Init(float speed)
    {
        GetComponent<Rigidbody>().velocity =
            transform.forward * speed;

        Invoke("KillMySelf", _destroyTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        var damageReciever = other.GetComponent<ITakeDamage>();
        if (damageReciever != null)
        {
            damageReciever.TakeDamage(damage);
            Destroy(gameObject);

        }
        
    }

    void KillMySelf()
    {
        Destroy(gameObject);
    }
}

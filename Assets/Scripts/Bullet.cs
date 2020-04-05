using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // metod que devolve um IEnumerator
        StartCoroutine(DestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    IEnumerator DestroyCoroutine()
    {
        // permite código assincrono que não bloqueia
        yield return new WaitForSeconds(3.0f);

        Destroy(gameObject);
    }

    // para funcionar o OnCollision, os elementos têm que ter um rigid bullet
    private void OnCollisionEnter(Collision collision)
    {
        Tank tank = collision.gameObject.GetComponent<Tank>();

        if (tank != null)
        {
            tank.TakeDamage();
        }

        Destroy(gameObject);
    }
}

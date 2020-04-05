using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{
    private GameObject bulletPrefab;
    private Transform spawnPos;

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/bullet");
        spawnPos = transform.Find("frame/barrel/bullet_spawn");

        Init();
    }

    protected abstract void Init();

    protected void Move(float x, float y)
    {
        Vector3 fw = new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed * y;
        transform.Translate(fw);

        float rotation = rotationSpeed * x;
        transform.Rotate(0, rotation, 0);
    }

    protected void Shoot()
    {
        Instantiate(bulletPrefab, spawnPos.position, transform.rotation);
    }

    public virtual void TakeDamage()
    {
        DestroyTank();
    }

    protected void DestroyTank()
    {
        GameController.instance.RegisterTankDown();
        Destroy(gameObject);
    }
}

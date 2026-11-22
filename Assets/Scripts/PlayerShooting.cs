using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    float fireForce = 5f;
    [SerializeField]
    GameObject bulletPrefab;
    FirePointCheck firePointCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firePointCheck = firePoint.GetComponent<FirePointCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && firePointCheck.canFire)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce((bullet.transform.position - transform.position).normalized * fireForce);
            bullet.GetComponent<Bullet>().forceConstraint = fireForce*Mathf.Sqrt(2);
        }
    }
}

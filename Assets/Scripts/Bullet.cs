using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ObjectProperties>() != null)
        {
            if (collision.GetComponent<ObjectProperties>().doesNotDestroyBullets)
            {
                return;
            }
        }
         Destroy(gameObject);
    }
}

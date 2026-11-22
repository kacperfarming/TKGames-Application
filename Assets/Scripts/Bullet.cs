using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    int bouncesLeft = 2;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ObjectProperties>() != null)
        {
            if (collision.gameObject.GetComponent<ObjectProperties>().doesNotDestroyBullets)
            {
                return;
            }
            if (collision.gameObject.GetComponent<ObjectProperties>().score != 0)
            {
                GameManager.Instance.score += collision.gameObject.GetComponent<ObjectProperties>().score;
                Destroy(collision.gameObject);
            }
        }
        if (bouncesLeft > 0)
        {
            Vector2 bounceVector = (new Vector2(transform.position.x, transform.position.y) - collision.ClosestPoint(transform.position)).normalized;
            if (Mathf.Abs(bounceVector.x) >= 0.5f)
            {
                rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
            }
            if (Mathf.Abs(bounceVector.y) >= 0.5f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -rb.linearVelocity.y);
            }

            bouncesLeft -= 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class FirePointCheck : MonoBehaviour
{
    [HideInInspector]
    public bool canFire = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        canFire = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canFire = true;
    }
}

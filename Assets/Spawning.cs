using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField]
    int desiredTargetCount;
    [SerializeField]
    GameObject shootingTarget;
    [SerializeField]
    Transform spawnZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < desiredTargetCount)
        {
            Vector2 creationPos = new Vector2(Random.Range(spawnZone.position.x - (spawnZone.localScale.x / 2), spawnZone.position.x + (spawnZone.localScale.x / 2)), Random.Range(spawnZone.position.y - (spawnZone.localScale.y / 2), spawnZone.position.y + (spawnZone.localScale.y / 2)));
            while (Physics2D.OverlapCircle(creationPos, 1f) != null)
            {
                creationPos = new Vector2(Random.Range(spawnZone.position.x - (spawnZone.localScale.x / 2), spawnZone.position.x + (spawnZone.localScale.x / 2)), Random.Range(spawnZone.position.y - (spawnZone.localScale.y / 2), spawnZone.position.y + (spawnZone.localScale.y / 2)));
            }
            Instantiate(shootingTarget, creationPos, transform.rotation, transform);
        }
    }
}

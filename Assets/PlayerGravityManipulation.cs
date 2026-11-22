using UnityEngine;

public class PlayerGravityManipulation : MonoBehaviour
{
    public GameObject gravityWell;
    [HideInInspector]
    public bool gravityFieldActive;

    public static PlayerGravityManipulation Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 desiredPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gravityWell.transform.position = new Vector2(desiredPos.x, desiredPos.y);
        if (Input.GetButton("Fire2"))
        {
            gravityFieldActive = true;
        }
        else
        {
            gravityFieldActive = false;
        }
        gravityWell.GetComponent<SpriteRenderer>().enabled = gravityFieldActive;
    }
}

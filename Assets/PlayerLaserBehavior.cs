using UnityEngine;

public class PlayerLaserBehavior : MonoBehaviour
{
    public int speed = 5;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}

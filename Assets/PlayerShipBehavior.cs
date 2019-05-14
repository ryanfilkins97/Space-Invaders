using UnityEngine;

public class PlayerShipBehavior : MonoBehaviour
{
    private readonly float shipSpeed = 5.0f;
    private int health = 1;

    public GameObject laser;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            DestroyShip();
            return;
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if ((screenPos.x - 25) < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Vector3 position = transform.position;
            position.x += .01f;
            transform.position = position;
        }
        else if ((screenPos.x + 25) > Screen.width)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Vector3 position = transform.position;
            position.x -= .01f;
            transform.position = position;
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 5, 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health--;
        }
        if (collision.tag == "EnemyBomb")
        {
            health--;
        }
    }

    private void DestroyShip()
    {
        GameObject explosionAnimation = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosionAnimation, 0.25f);
        Destroy(gameObject);
        GameManager.PlayerDead();
    }
}

using System.Collections;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    public float speed;
    public int health;
    bool canSwitch = true;
    bool waitActive = false;

    public float timeBetweenShots;
    public float nextShot = -1;

    public GameObject explosion;

    private bool movingDown;
    private Vector3 pivotPosition;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            DestroyShip();
            return;
        }

        if (!canSwitch)
        {
            if (pivotPosition.x > 0)
            {
                if (transform.position.x < 0)
                {
                    canSwitch = true;
                }
            }
            else if (pivotPosition.x < 0)
            {
                if (transform.position.x > 0)
                {
                    canSwitch = true;
                }
            }
        }

        if (movingDown)
        {
            if (Mathf.Abs(pivotPosition.y - transform.position.y) > 1.0f)
            {
                if (pivotPosition.x > 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                    canSwitch = false;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                    canSwitch = false;
                }

                movingDown = false;
            }
        }
        else
        {
            if (transform.position.x >= 8 && canSwitch)
            {
                pivotPosition = transform.position;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                movingDown = true;
            }
            else if (transform.position.x <= -8 && canSwitch)
            {
                pivotPosition = transform.position;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                movingDown = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerLaser")
        {
            health--;
        } 
        else if (collision.tag == "Player")
        {
            health = 0;
        }
    }

    private void DestroyShip()
    {
        GameObject explosionAnimation = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosionAnimation, 0.25f);
        Destroy(gameObject);
        Score.updateScore();
    }
}

using UnityEngine;

public class EnemyShipFiringBehavior : MonoBehaviour { 

    public float timeBetweenShots;
    public float nextShot = -1;
    public GameObject bullet;
    public int speed = 5;
    public int damage;
    public string target;

    // Start is called before the first frame update
    void Start()
    {
        nextShot = Random.Range(1, 3.0f);
        timeBetweenShots = Random.Range(3, 6.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextShot = Time.time + timeBetweenShots;
        }
    }
}

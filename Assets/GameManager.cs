using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    static bool isPlayerDead;
    public Text loserText;
    public GameObject loseScreen;

    bool lossMusicPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerDead = false;
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            loseScreen.SetActive(true);

            if (!lossMusicPlaying)
            {
                GetComponent<AudioSource>().mute = true;
                lossMusicPlaying = true;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public static void PlayerDead()
    {
        isPlayerDead = true;
    }
}

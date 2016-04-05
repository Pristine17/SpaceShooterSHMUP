using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameHazard;
    public Vector3 spawnValues;
    public int hazardPerWave;
    public float timeBetweenAsteroid;
    public float timeBetweenWaves;
    public float startTime;
    private int score;
    public Text scoreText;
    public Text endText;
    public Text restartText;
    private bool flag;

    void Start()
    {
        StartCoroutine (spawnWaves());
        score = 0;
        flag = false;
        scoreText.text = "Score : " + score;
        endText.text = "";
        restartText.text = "";
    }

    void Update()
    {
        if(flag&&Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    IEnumerator spawnWaves()
    {

        while (true)
        {
            yield return new WaitForSeconds(startTime);
            for (int i = 0; i < hazardPerWave; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, +spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(gameHazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(timeBetweenAsteroid);
                if(flag==true)
                {
                    break;
                }
            }
            if(flag==true)
            {
                break;
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public void updateScore(int scoreVal)
    {
        score = score + scoreVal;
        scoreText.text = "Score : " + score;
    }

    public void endGame()
    {
        flag = true;
        restartText.text = "Press 'R' to restart";
        endText.text = "GAME OVER!";
    }
}

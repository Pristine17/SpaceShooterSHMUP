using UnityEngine;
using System.Collections;

public class DestroyAsteroid : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int asteroidVal;
    private GameController Control;

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        if (obj != null)
        {
            Control = obj.GetComponent<GameController>();
        }
       

    }
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag != "Boundary")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if(other.gameObject.tag=="Player")
            {
                 Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                 Control.endGame();               
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
            Control.updateScore(asteroidVal);

        }
    }

}

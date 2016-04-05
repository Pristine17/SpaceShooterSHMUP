using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
 public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float tilt;
    private float nextFire;
    public float fireRate;
   

    public Boundary bound = new Boundary();
    public GameObject shot;
    public GameObject shotSpawn;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        nextFire = 0.0F;    
    }

     void Update()
    {
        
         
 
        if (Input.GetButton("Jump") && Time.time > nextFire) 
         {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            AudioSource ac = GetComponent<AudioSource>();
            ac.Play();
        }
    }
	void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity=movement*speed;
        Vector3 clampMovement=new Vector3(Mathf.Clamp(rb.position.x,bound.xMin,bound.xMax),0.0f,Mathf.Clamp(rb.position.z,bound.zMin,bound.zMax));
        rb.position = (clampMovement);
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}

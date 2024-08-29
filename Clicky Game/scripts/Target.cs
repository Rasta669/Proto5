using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Dont forget to cleanup code
public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager manager;
    public ParticleSystem explosion;
    public int hitScore;
    // Start is called before the first frame update
    void Start()
    {   //Getting a rigid body component
        rb = GetComponent<Rigidbody>();
        
        //Getting the game manager script access
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // defining original position of the target
        transform.position = new Vector3(Random.Range(-4, 4), -3);
        // Adding an upward force to the target
        rb.AddForce(Vector3.up * Random.Range(12,18), ForceMode.Impulse);
        //Adding torque to the target
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        

    }

    private void OnMouseDown()
    {
        if (manager.gameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            manager.UpdateScore(hitScore);
        }
    }
   
     private void OnTriggerEnter(Collider other){
        if (rb.CompareTag("good"))
        {
            Destroy(gameObject);
            manager.EndGame();
        }
        Destroy(gameObject);
        
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}

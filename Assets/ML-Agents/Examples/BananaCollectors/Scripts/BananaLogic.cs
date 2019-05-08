using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaLogic : MonoBehaviour {

    public bool respawn;
    public BananaArea myArea;
    public Vector3 vector;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    public void OnEaten() {
        if (respawn) 
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
             transform.position = new Vector3(vector.x, 
                                             transform.position.y + 20f, 
                                             vector.z);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    public float forceJump = 1;
    private Rigidbody2D rbPlayer;
    private Animator animPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){
           
            rbPlayer.velocity = transform.up * forceJump;
        }
    }
}

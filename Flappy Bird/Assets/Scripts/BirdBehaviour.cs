using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class BirdBehaviour : MonoBehaviour
{
    private GameController GameController;
    public float forceJump = 1;
    private Rigidbody2D rbPlayer;
    private Animator animPlayer;

    public int currentScore;
    
    void Start()
    {
        GameController = FindObjectOfType(typeof(GameController)) as GameController;
        rbPlayer = GetComponent<Rigidbody2D>();    
    }
   
    void Update(){

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){

            if (GameController.currentState != MachineState.GameOver)
            {
                rbPlayer.gravityScale = 0.3f;
                rbPlayer.velocity = transform.up * forceJump;
                GameController.currentState = MachineState.InGame;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision){

        switch (collision.tag){
            case "Pipe":
                GameController.OpenGameOver();
                break;
            case "Score":
                GameController.currentScore++;
                break;
        }
    }
}

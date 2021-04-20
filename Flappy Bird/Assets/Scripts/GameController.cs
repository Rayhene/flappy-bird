using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MachineState{
    FirstTap,
    InGame,
    GameOver
}

public class GameController : MonoBehaviour
{

    public SpriteRenderer bgRender;
    public SpriteRenderer groundRender;
    public float speedParallax;

    public MachineState currentState;

    public GameObject pipe;
    public float speedPipe;

    public float timeToSpawn;
    private float currentTimeToSpawn;

    public Transform spawnPosTop, spawnPosBot, spawnPos;

    public int currentScore;
    public Text scoreTxt;
    public Text finalScoreTxt;

    public GameObject gameOverPanel;


    void Update(){
        float parallaX = bgRender.size.x;
        parallaX += 0.003f * speedParallax;
        bgRender.size = new Vector2(parallaX, bgRender.size.y);
        groundRender.size = new Vector2(parallaX, groundRender.size.y);

        currentTimeToSpawn += Time.deltaTime;

        if(currentState == MachineState.InGame)
        {
            if (currentTimeToSpawn >= timeToSpawn)
            {
                SpawnPipe();
                currentTimeToSpawn = 0;
            }
        }
      

        scoreTxt.text = currentScore.ToString();
    }

    public void OpenGameOver()
    {
        finalScoreTxt.text = currentScore.ToString();
        gameOverPanel.SetActive(true);
        currentState = MachineState.GameOver;

    }

    void SpawnPipe() {

        GameObject tempPipe = Instantiate(pipe);
        float posYSpawn = Random.Range(spawnPosBot.position.y, spawnPosTop.position.y);
        tempPipe.transform.position = new Vector2(spawnPosTop.position.x, posYSpawn);
        tempPipe.GetComponent<Rigidbody2D>().velocity = -tempPipe.transform.right * speedPipe;
        Destroy(tempPipe, 5);

    }


}

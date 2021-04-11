using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public SpriteRenderer bgRender;
    public SpriteRenderer groundRender;
    public float speedParallax;

    public GameObject pipe;
    public float speedPipe;

    public float timeToSpawn;
    private float currentTimeToSpawn;

    public Transform spawnPosTop, spawnPosBot, spawnPos;


    void Update(){
        float parallaX = bgRender.size.x;
        parallaX += 0.003f * speedParallax;
        bgRender.size = new Vector2(parallaX, bgRender.size.y);
        groundRender.size = new Vector2(parallaX, groundRender.size.y);

        currentTimeToSpawn += Time.deltaTime;

        if (currentTimeToSpawn >= timeToSpawn) { 
            SpawnPipe();
            currentTimeToSpawn = 0;
        }
    }

    void SpawnPipe() {

        GameObject tempPipe = Instantiate(pipe);
        float posYSpawn = Random.Range(spawnPosBot.position.y, spawnPosTop.position.y);
        tempPipe.transform.position = new Vector2(spawnPosTop.position.x, posYSpawn);
        tempPipe.GetComponent<Rigidbody2D>().velocity = -tempPipe.transform.right * speedPipe;
        Destroy(tempPipe, 3);

    }


}

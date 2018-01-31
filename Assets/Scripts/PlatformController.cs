using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    [Header("Script setup")]
    public GameObject platformPrefab;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform player;
    [Header("Spawn pref")]
    public List<GameObject> platformPool;
    public int numberOfPrefab;
    public float spawnY;
    public float timeBetweenPlatformSpawn1 = 2f;
    private int tempNumSpawn;
    private int numSpawn;
    public bool coroutineSpawnLock1 = false;
    public float speedVelocity=1f;


    // Use this for initialization
    void Start () {
        InitializePlatforms();
	}
	
	// Update is called once per frame
	void Update () {
        if (!coroutineSpawnLock1) {
            coroutineSpawnLock1 = true;
            StartCoroutine(Spawn1( spawnY));
        }
       

    }
    private void SpawnSwitch(int randomSpawn,float playerPosition) {
        float randomX;
        switch (randomSpawn)
        {
            case 1:
                randomX = Random.Range(-7f, -3f);
                MovePlatform(randomX,spawn1, playerPosition);
                break;
            case 2:
                randomX = Random.Range(-3f, 3f);
                MovePlatform(randomX, spawn2, playerPosition);
                break;
            case 3:
                randomX = Random.Range(-3f, 7f);
                MovePlatform(randomX,spawn3, playerPosition);
                break;
            case 4:
               // MovePlatform(spawn4);
                break;
            default:
                break;
        }
    }
    private void InitializePlatforms()
    {

        for (int i=0; i < numberOfPrefab; i++)
        {
            platformPool.Add(Instantiate(platformPrefab));
            platformPool[i].SetActive(false);
            

        }
    }
    void MovePlatform(float randomX,Transform spaw, float playerPosition)
    {
        for (int i = 0; i < platformPool.Count; i++)
        {
            if (platformPool[i].activeSelf==false){
                Vector3 randomPosition = new Vector3(randomX, playerPosition, 0f);
                platformPool[i].gameObject.SetActive(true);
                platformPool[i].GetComponent<Rigidbody2D>().gravityScale= 0;
                platformPool[i].GetComponent<Rigidbody2D>().velocity=new Vector2(0,-speedVelocity);
                platformPool[i].GetComponent<Transform>().SetParent(spaw);
                platformPool[i].GetComponent<Transform>().position = randomPosition;
                i=platformPool.Count ;
            }
        }
    }
    IEnumerator Spawn1(float playerPosition)
    {
        // int randomSpawn = Random.Range(1,4);
        
        /* if (numSpawn < 4 )
         {
             numSpawn++;

         }
         else
         {
             randomSpawn = -4;
         }
         if (randomSpawn < 0)
         {
             randomSpawn = -randomSpawn;
         }*/

        //Debug.Log(randomSpawn);
        yield return new WaitForSeconds(timeBetweenPlatformSpawn1);
        // SpawnSwitch(randomSpawn,playerPosition);
        //MovePlatform(randomX,spawn1, playerPosition);
        SpawnRandom(playerPosition);
        coroutineSpawnLock1 = false;
        
    }
   
    public void SpawnRandom(float playerPosition)
    {
        float randomSpawn = Random.Range(-6f, 6f);
        MovePlatform(randomSpawn, spawn1, playerPosition);
    }
}

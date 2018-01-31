using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    public GameObject platformPrefab;
    public Transform spawn;
    public List<GameObject> platformPool;
    public int numberOfPrefab;
    public float timeBetweenPlatform=2f;
    private bool coroutineLock=false;



    private int randomSpawn;

    // Use this for initialization
    void Start () {
        InitializePlatforms();
	}
	
	// Update is called once per frame
	void Update () {
        if (!coroutineLock) {
            coroutineLock = true;
            StartCoroutine(Spawn());
        }
        
        
    }
    private void SpawnSwitch(int randomSpawn) {
        switch (randomSpawn)
        {
            case 1:
                //MovePlatform(spawn1);
                break;
            case 2:
               // MovePlatform(spawn2);
                break;
            case 3:
               // MovePlatform(spawn3);
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
    void MovePlatform(float randomX)
    {
        for (int i = 0; i < platformPool.Count; i++)
        {
            
            if (platformPool[i].activeSelf==false){
                Vector3 randomPosition = new Vector3(randomX, spawn.position.y, 0f);
                platformPool[i].gameObject.SetActive(true);
                platformPool[i].GetComponent<Rigidbody2D>().mass=Random.Range(10000f,20000f);
                platformPool[i].GetComponent<Transform>().SetParent(spawn);
                platformPool[i].GetComponent<Transform>().position = randomPosition;
                i=platformPool.Count ;
            }
        }
    }
    IEnumerator Spawn()
    {
        float randomX = Random.Range(-7.41f, 7.42f);
        yield return new WaitForSeconds(timeBetweenPlatform);
        MovePlatform(randomX);
        coroutineLock = false;
    }
    }

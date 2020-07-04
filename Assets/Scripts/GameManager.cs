using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
	public Transform spawnPoint;
	
	private Vector3 spawnPosition;
	private bool hasStarted = false;
	
	// Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0) && hasStarted == false)
		{
			SpawnObstacle();
			hasStarted = true;
		}
    }
	
	public void SpawnObstacle()
	{
		Debug.Log("Enter SpawnObstacle");
		spawnPosition = spawnPoint.position;
		spawnPosition.y += (float) (Random.value * 3.6f - 2.2f);
		//spawnPosition.y += -2.2f;
		Debug.Log(spawnPosition.y);
		GameObject.Instantiate(obstaclePrefab, 
							spawnPosition, 
							obstaclePrefab.transform.rotation);
	}
	
}

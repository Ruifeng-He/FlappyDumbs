using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
	public float movementSpeed = 3;
	public Transform spawnPoint;
	public Transform destroyPoint;
	public Transform oneIntervalPoint;
	
	private bool hasReached = false;
	private bool hasCreated = false;
	private Vector3 targetPos;
	
	// Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
		destroyPoint = GameObject.Find("DestroyPoint").transform;
		oneIntervalPoint = GameObject.Find("OneIntervalPoint").transform;
		targetPos = destroyPoint.position;
		targetPos.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
		if (hasReached == false)
		{
			transform.position = Vector3.MoveTowards(transform.position, 
													targetPos, 
													movementSpeed * Time.deltaTime);
			if (Mathf.Abs(transform.position.x - oneIntervalPoint.position.x) < 0.1f 
					&& hasCreated == false)
			{
				GameObject.Find("GameManager").GetComponent<GameManager>().SpawnObstacle();
				hasCreated = true;
				Debug.Log("Create new obstacle");
			}
			if (Mathf.Abs(transform.position.x - destroyPoint.position.x) < 0.1f)
			{
				Debug.Log("hasReached");
				hasReached = true;
			}
		}
		else
		{
			Destroy(this.gameObject);
		}
    }
}

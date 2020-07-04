using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public float speed = 9;
	
	private bool isActivated = false;
	
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			if (isActivated == false)
			{
				this.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
				isActivated = true;
			}
			this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed, 0);
		}
    }
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
			Debug.Log("Game Over");
	}
	
}

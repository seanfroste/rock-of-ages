using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A rock spawner
/// </summary>
public class RockSpawner : MonoBehaviour
{
	//spawning necessity
	[SerializeField]
	GameObject prefabRock;

	[SerializeField]
	Sprite whiterock;
	
	[SerializeField]
	Sprite greenrock;
	
	[SerializeField]
	Sprite magentarock;

	// spawn delay
	const float SpawnDelay = 1f;
	Timer spawnTimer;

	//spawn boundaries
	int minX;
	int maxX;
	int minY;
	int maxY;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		//spawn area constraints
		minX = 0;
		maxX = Screen.width;
		minY = 0;
		maxY = Screen.height;

		//create and start timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Duration = SpawnDelay;
		spawnTimer.Run();
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// check for time to spawn a new rock
		if (spawnTimer.Finished)
		{
			if (GameObject.FindGameObjectsWithTag("rock").Length < 3)
			{
				SpawnRock();

				// change spawn timer duration and restart
				spawnTimer.Duration = SpawnDelay;
				spawnTimer.Run();
			}
		}
	}

	/// <summary>
	/// Spawns a new rock in the center of the screen
	/// </summary>
	void SpawnRock()
	{
		// generate random location and create another rock
		Vector3 location = new Vector3((minX + maxX) / 2, (minY + maxY) / 2, -Camera.main.transform.position.z);
		Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
		GameObject rock = Instantiate(prefabRock) as GameObject;
		rock.transform.position = worldLocation;

		// set sprite for new rock prefab
		SpriteRenderer spriteRenderer = rock.GetComponent<SpriteRenderer>();
		int spriteNum = Random.Range(0, 3);
		if (spriteNum == 0)
		{
			spriteRenderer.sprite = whiterock;
		}
		else if (spriteNum == 1)
		{
			spriteRenderer.sprite = greenrock;
		}
		else if (spriteNum == 2)
		{
			spriteRenderer.sprite = magentarock;
		}
	}
}
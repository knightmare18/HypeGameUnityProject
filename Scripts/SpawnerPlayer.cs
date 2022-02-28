using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public void Spawner()
    {
        player.transform.position = new Vector2(transform.position.x, transform.position.y);
        player.SetActive(true);
        
    }
}

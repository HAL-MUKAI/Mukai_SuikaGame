using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextSpriteShower : MonoBehaviour
{
    [SerializeField] SpawnPoint spawnPoint;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = spawnPoint.fluitGameObjs[spawnPoint.rondomNum].GetComponent<SpriteRenderer>().sprite;
    }
}

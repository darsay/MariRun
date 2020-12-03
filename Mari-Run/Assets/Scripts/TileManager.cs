using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject [] tiles;
    public float zSpawn = 0;
    public float tileLength = 10;
    public int numberOfTiles = 15;
    public Transform player;
    private List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< numberOfTiles; i++)
        {
            SpawnTile(0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        int tileIdx = Random.Range(0, tiles.Length);
        if(player.transform.position.z -10>zSpawn-(numberOfTiles*tileLength))
        {
                SpawnTile(tileIdx);
                DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex){
        GameObject tile = Instantiate(tiles[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(tile);
        zSpawn +=tileLength;
    }

    private void DeleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkCreator : MonoBehaviour
{
    
    public Tile[] tilePrefabs;

    public Tile StartingTile;

    public float TileWidth = 8f;

    public int GridWidthX = 11;
    public int GridLengthY = 11;
    
    public int TileSpawn = 11;

    int midX;
    int midY;

    Tile[ , ] SpawnedTiles;
    // Start is called before the first frame update
  //  IEnumerator 
        void Start()
    {
       midX = GridWidthX / 2;
       midY = GridLengthY / 2;

        SpawnedTiles = new Tile[GridWidthX, GridLengthY];

        SpawnedTiles[midX, midY] = StartingTile;

        for (int i = 0; i < TileSpawn; i++) 
        {
            PlaceTile();
           // yield return new WaitForSecondsRealtime(0.3f);
        }

       
    }

    void PlaceTile()
    {
        HashSet<Vector2Int> VacantPloaces = new HashSet<Vector2Int>();

 

        for (int x = 0; x < SpawnedTiles.GetLength(0); x++)
        {
            for (int y = 0; y < SpawnedTiles.GetLength(1); y++)
            {
                if (SpawnedTiles[x, y] == null) continue;

                int max_X = SpawnedTiles.GetLength(0) - 1;
                int max_Y = SpawnedTiles.GetLength(1) - 1;

                if (x > 0 && SpawnedTiles[x - 1, y] == null) VacantPloaces.Add(new Vector2Int(x - 1, y));
                if (x < max_X && SpawnedTiles[x + 1, y] == null) VacantPloaces.Add(new Vector2Int(x + 1, y));
                if (y > 0 && SpawnedTiles[x, y - 1] == null) VacantPloaces.Add(new Vector2Int(x, y - 1));
                if (y < max_Y && SpawnedTiles[x, y + 1] == null) VacantPloaces.Add(new Vector2Int(x, y + 1));
            }
        }

        Tile _tile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)]);
        Vector2Int _position = VacantPloaces.ElementAt(Random.Range(0, VacantPloaces.Count));
        _tile.transform.position = new Vector3(_position.x - midX , 0, _position.y - midY ) * TileWidth;

        SpawnedTiles[_position.x, _position.y] = _tile;
    }


}

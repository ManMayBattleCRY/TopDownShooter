using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class Chunk : MonoBehaviour
{
    [HideInInspector]
    public GameObject DoorU;
    [HideInInspector]
    public GameObject DoorD;
    [HideInInspector]
    public GameObject DoorR;
    [HideInInspector]
    public GameObject DoorL;

    [HideInInspector]
    public byte TileSpawned = 0;

    public Tile[] tilePrefabs;

    Tile StartingTile;
    public float TileWidth = 8f;

    public int GridWidthX = 11;
    public int GridLengthY = 11;
    
    public int TileSpawn = 11;

    int midX;
    int midY;

    Tile[ , ] SpawnedTiles;


 
        void Start()
        {

         StartCoroutine(ChunkCreate());
        Debug.Log(SpawnedTiles.GetLongLength(0));
    }
        
    void PlaceTile()
    {
        HashSet<Vector2Int> VacantPloaces = new HashSet<Vector2Int>();

 

        for (int x = 0; x < SpawnedTiles.GetLength(0) ; x++)
        {
            for (int y = 0; y < SpawnedTiles.GetLength(1) ; y++)
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
        _tile._creator = this;
        _tile.transform.parent = transform;
        SpawnedTiles[_position.x, _position.y] = _tile;
    }



    public void ActivateDoor()
    {

        for (int x = 0; x < SpawnedTiles.GetLength(0); x++)
        {
            for (int y = 0; y < SpawnedTiles.GetLength(1); y++)
            {
                if (SpawnedTiles[x, y] == null) continue;

                int max_X = SpawnedTiles.GetLength(0) - 1;
                int max_Y = SpawnedTiles.GetLength(1) - 1;

                if (x > 0 && SpawnedTiles[x - 1, y] == null && SpawnedTiles[x, y] != null) SpawnedTiles[x,y].WallL.SetActive(true);
                if (x < max_X && SpawnedTiles[x + 1, y] == null && SpawnedTiles[x, y] != null) SpawnedTiles[x, y].WallR.SetActive(true);
                if (y > 0 && SpawnedTiles[x, y - 1] == null && SpawnedTiles[x, y] != null) SpawnedTiles[x, y].WallD.SetActive(true);
                if (y < max_Y && SpawnedTiles[x, y + 1] == null && SpawnedTiles[x, y] != null) SpawnedTiles[x, y].WallU.SetActive(true);
            }
        }

            for (int y = 0; y < GridLengthY; y++)
            {
                if (SpawnedTiles[0, y] != null) SpawnedTiles[0, y].WallL.SetActive(true); 
            }

            for (int y = 0; y < GridLengthY; y++)
            {
                if (SpawnedTiles[GridWidthX-1, y] != null) SpawnedTiles[GridWidthX-1, y].WallR.SetActive(true);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////

            for (int x = 0; x < GridWidthX; x++)
            {
                if (SpawnedTiles[x, 0] != null) SpawnedTiles[x, 0].WallD.SetActive(true); 
            }

            for (int x = 0; x < GridWidthX; x++)
            {
                if (SpawnedTiles[x, GridLengthY - 1] != null) SpawnedTiles[x, GridLengthY - 1].WallU.SetActive(true);
            }

        if (SpawnedTiles[0, 0] != null) { SpawnedTiles[0, 0].WallL.SetActive(true); SpawnedTiles[0, 0].WallD.SetActive(true); }
        if (SpawnedTiles[GridWidthX-1, GridLengthY-1] != null) { SpawnedTiles[GridWidthX - 1, GridLengthY - 1].WallR.SetActive(true); 
                                                                 SpawnedTiles[GridWidthX -1, GridLengthY - 1].WallU.SetActive(true); }
        if (SpawnedTiles[0, GridLengthY - 1] != null) { SpawnedTiles[0, GridLengthY - 1].WallL.SetActive(true); SpawnedTiles[0, GridLengthY - 1].WallU.SetActive(true); }
        if (SpawnedTiles[GridWidthX - 1, 0] != null) { SpawnedTiles[GridWidthX - 1, 0].WallR.SetActive(true); SpawnedTiles[GridWidthX - 1, 0].WallD.SetActive(true); }

    }

    IEnumerator ChunkCreate()
    {
        transform.position = Vector3.zero;
        StartingTile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)]);
        StartingTile.transform.position = Vector3.zero;
        StartingTile._creator = this;
        StartingTile.transform.parent = transform;
        midX = GridWidthX / 2;
        midY = GridLengthY / 2;

        SpawnedTiles = new Tile[GridWidthX, GridLengthY];

        SpawnedTiles[midX, midY] = StartingTile;

        for (int i = 0; i < TileSpawn; i++)
        {
            PlaceTile();
        }
        int counter = 0;
        while (TileSpawned < TileSpawn && counter <= 120)
        {
            yield return null;
            counter++;
        }

        ActivateDoor();
        OpenTheDoors();
    }

    void OpenTheDoors()
    {
        int maxY = midY;
        int maxX = midX;
        int minY = midY;
        int minX = midX;

        int maxY_X = midY;
        int maxX_Y = midX;
        int minY_X = midY;
        int minX_Y = midX;



        for (int x = 0; x < SpawnedTiles.GetLength(0) ; x++)
        {
            for (int y = midY; y < SpawnedTiles.GetLength(1) ; y++)
            {
                if (SpawnedTiles[x, y] != null && y > maxY) { maxY = y; maxY_X = x; }
            }
        }

        for (int y = 0; y < SpawnedTiles.GetLength(1) ; y++)
        {
            for (int x = midX; x < SpawnedTiles.GetLength(0) ; x++)
            {
                if (SpawnedTiles[x, y] != null && x > maxX) { maxX = x; maxX_Y = y; }
            }
        }

        for (int x = 0; x < SpawnedTiles.GetLength(0) ; x++)
        {
            for (int y = midY; y >= 0; y--)
            {
                if (SpawnedTiles[x, y] != null && y< minY) { minY = y; minY_X = x; }
            }
        }

        for (int y = 0; y < SpawnedTiles.GetLength(1); y++)
        {
            for (int x = midX; x > 0; x--)
            {
                if (SpawnedTiles[x, y] != null && x < minX) { minX = x; minX_Y = y; }
            }
        }

        SpawnedTiles[maxX,maxX_Y].WallR.SetActive(false);
        SpawnedTiles[maxX, maxX_Y].DoorR.SetActive(true);
        DoorR = SpawnedTiles[maxX, maxX_Y].DoorR;

        SpawnedTiles[maxY_X, maxY].WallU.SetActive(false);
        SpawnedTiles[maxY_X, maxY].DoorU.SetActive(true);
        DoorU = SpawnedTiles[maxY_X, maxY].DoorU;

        SpawnedTiles[minX, minX_Y].WallL.SetActive(false);
        SpawnedTiles[minX, minX_Y].DoorL.SetActive(true);
        DoorL = SpawnedTiles[minX, minX_Y].DoorL;

        SpawnedTiles[minY_X, minY].WallD.SetActive(false);
        SpawnedTiles[minY_X, minY].DoorD.SetActive(true);
        DoorD = SpawnedTiles[minY_X, minY].DoorD;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public Chunk[] chunks;

    Chunk[ , ] SpawnedChunks;
    Chunk StartChunk;

    [Range(1, 30)]
    public byte ChunkCountWidth;

    [Range(1, 30)]
    public byte ChunkCountLength;

    [Range(1,30)]
    public byte ChunkCount;
    void Start()
    {
        SpawnedChunks = new Chunk[ChunkCountWidth, ChunkCountLength];
        
    }

    void PlaceChunk()
    {
        HashSet<Vector2Int> VacantPlaces = new HashSet<Vector2Int>();



        for (int x = 0; x < SpawnedChunks.GetLength(0); x++)
        {
            for (int y = 0; y < SpawnedChunks.GetLength(1); y++)
            {
                if (SpawnedChunks[x, y] == null) continue;

                int max_X = SpawnedChunks.GetLength(0) - 1;
                int max_Y = SpawnedChunks.GetLength(1) - 1;

                if (x > 0 && SpawnedChunks[x - 1, y] == null) VacantPlaces.Add(new Vector2Int(x - 1, y));
                if (x < max_X && SpawnedChunks[x + 1, y] == null) VacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y > 0 && SpawnedChunks[x, y - 1] == null) VacantPlaces.Add(new Vector2Int(x, y - 1));
                if (y < max_Y && SpawnedChunks[x, y + 1] == null) VacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        //Chunk _chunk = Instantiate(chunks[Random.Range(0, SpawnedChunks.Length)]);
        //Vector2Int _position = VacantPlaces.ElementAt(Random.Range(0, VacantPlaces.Count));
        //_chunk.transform.position = new Vector3(_position.x - midX, 0, _position.y - midY) * TileWidth;
        //_chunk._creator = this;
        //_chunk.transform.parent = transform;
        //SpawnedChunks[_position.x, _position.y] = _chunk;
    }
}

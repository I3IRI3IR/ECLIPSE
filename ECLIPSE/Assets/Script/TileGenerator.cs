using System;
using UnityEngine;

public class TileGenerator: MonoBehaviour
{
    [SerializeField] private Tile TilePrefab;
    private int SIZE = 7; // SIZE/2 = 3

    void Start() {
        GenerateTile();
    }

    void GenerateTile() {
        for(int j = 0; j<SIZE; j++) {
            int dj = Math.Abs(SIZE/2 - j);
            for(int i = 0; i<SIZE-dj; i++) {
                int di = Mathf.CeilToInt(Mathf.Abs((SIZE - dj - 1) / 2.0f - i)) + dj/2;
                var spawnedTile = Instantiate(TilePrefab, new Vector3(i + 0.5f*dj - SIZE/2, j - SIZE/2), Quaternion.identity);
                spawnedTile.name = $"Tile {i} {j}";
                spawnedTile.Init(Math.Max(di, dj));
            }
        }
    }
    
}

using System;
using UnityEngine;

public class Tile: MonoBehaviour
{
    // Static variable
    public static TileInformationManager TileUIManager;
    // For each tile
    [SerializeField] private Color[] Back;
    public TileData data;

    public void Init(int type) {
        this.GetComponent<SpriteRenderer>().color = Back[type];
        data.Resources = new int[] {0, 1, 2, 3, 2, 1, 0};
        data.Facility = new int[] {0, 0, 0};
    }

    public void Reveal(int ID) {
        // Set up the data upon reveal
    }
    void OnMouseDown() {
        TileUIManager.ShowPanel(data);
    }
}
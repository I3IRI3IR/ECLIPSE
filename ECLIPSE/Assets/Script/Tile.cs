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
        Reveal(1234);
    }

    public void Reveal(int ID) {
        // Set up the data upon reveal
        data.ID = ID;
        data.ancient = 1;
        data.star = true;
        data.prize = 5;
        data.score = 4;
        data.Resources = new int[] {0, 1, 2, 3, 2, 1, 0};
        data.Facility = new bool[] {true, true, true};
    }
    void OnMouseDown() {
        TileUIManager.ShowPanel(data);
    }
}
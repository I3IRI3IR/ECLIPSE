using System;
using UnityEngine;
using TMPro;

public class Tile: MonoBehaviour
{
    // Static variable
    public static TileInformationManager UIManager;
    // For each tile
    [SerializeField] private Color[] Back;
    [SerializeField] private SpriteRenderer Renderer;
    public TileData data;

    public void Init(int type) {
        Renderer.color = Back[type];
    }

    public void Reveal(int ID) {
        // Set up the data upon reveal
    }
    void OnMouseDown() {
        UIManager.TileID.text = data.ID.ToString();
        UIManager.InfoPanel.SetActive(true);
    }
}
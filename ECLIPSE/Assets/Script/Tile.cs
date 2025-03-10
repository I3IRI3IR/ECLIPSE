using System;
using UnityEngine;

public class Tile: MonoBehaviour
{
    [SerializeField] private Color[] Back;
    [SerializeField] private SpriteRenderer Renderer;

    public void Init(int type) {
        Renderer.color = Back[type];
    }
    void OnMouseDown() {
        Debug.Log($"Clicked on tile: {gameObject.name} at {transform.position}");
    }
}
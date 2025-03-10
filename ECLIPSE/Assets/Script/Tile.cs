using System;
using UnityEngine;

public class Tile: MonoBehaviour
{
    [SerializeField] private Color[] Back;
    [SerializeField] private SpriteRenderer Renderer;

    public void Init(int type) {
        Debug.Log(type);
        Renderer.color = Back[type];
    }
}

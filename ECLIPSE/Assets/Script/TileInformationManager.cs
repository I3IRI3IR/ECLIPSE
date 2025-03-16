using UnityEngine;
using TMPro;

public class TileInformationManager : MonoBehaviour
{
    //public static TileInformationManager Instance;
    public GameObject InfoPanel;
    public TMP_Text TileID;
    void Start()
    {
        Tile.UIManager = this;
    }
    public void OnCloseButtonPress()
    {
        InfoPanel.SetActive(false);
    }
}

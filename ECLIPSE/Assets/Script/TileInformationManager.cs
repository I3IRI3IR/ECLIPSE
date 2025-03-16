using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileInformationManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public TMP_Text TileID;
    [SerializeField] private GameObject ResourceButton;
    [SerializeField] private Transform ResourcePanel;
    [SerializeField] private Color[] ResourceColor; 
    void Start()
    {
        Tile.TileUIManager = this;
    }
    public void OnCloseButtonPress()
    {
        UIManager.GamePaused = false;
        InfoPanel.SetActive(false);
    }
    public void ShowPanel(TileData data)
    {
        if(! UIManager.GamePaused)
        {
            UIManager.GamePaused = true;
            TileID.text = data.ID.ToString();
            // Initialize resource list
            foreach (Transform child in ResourcePanel) Destroy(child.gameObject);
            for(int i = 0; i<data.Resources.Length; i++)
            {
                for(int j = 0; j<data.Resources[i]; j++) {
                    GameObject newButton = Instantiate(ResourceButton, ResourcePanel);
                    newButton.GetComponent<Image>().color = ResourceColor[i%4];
                    int deref = i; // To pass by local value instead of reference, may be replace for more delicate approach
                    newButton.GetComponent<Button>().onClick.AddListener(() => OnResourceClick(deref));
                }
            }
            InfoPanel.SetActive(true);
        }
    }
    void OnResourceClick(int type)
    {
        Debug.Log($"Button '{type}' clicked!");
    }
}



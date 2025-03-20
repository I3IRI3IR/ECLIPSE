using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileInformationManager : MonoBehaviour
{
    public GameObject InfoPanel;
    [SerializeField] private GameObject ResourceButton;
    [SerializeField] private GameObject PrizeButton;
    // Should be refactored
    private Transform ResourcePanel;
    private Transform PrizePanel;
    private GameObject Ancient;
    private GameObject Star;
    private GameObject Starbase;
    private GameObject Orbital;
    private GameObject Monolith;
    private TMP_Text Score;
    private TMP_Text TileID;
    [SerializeField] private Color[] ResourceColor; 
    void Awake()
    {
        Tile.TileUIManager = this;
        ResourcePanel = InfoPanel.transform.Find("ResourcePanel");
        PrizePanel = InfoPanel.transform.Find("PrizePanel");
        Ancient = InfoPanel.transform.Find("Ancient").gameObject;
        Star = InfoPanel.transform.Find("Star").gameObject;
        Starbase = InfoPanel.transform.Find("Starbase").gameObject;
        Orbital = InfoPanel.transform.Find("Orbital").gameObject;
        Monolith = InfoPanel.transform.Find("Monolith").gameObject;
        Score = InfoPanel.transform.Find("Score").GetComponentInChildren<TMP_Text>();
        TileID = InfoPanel.GetComponentInChildren<TMP_Text>();
    }
    public void ShowPanel(TileData data)
    {
        if(! UIManager.GamePaused)
        {
            UIManager.GamePaused = true;
            TileID.text = data.ID.ToString();
            Ancient.SetActive(data.ancient > 0);
            Star.SetActive(data.star);
            Starbase.SetActive(data.Facility[0]);
            Orbital.SetActive(data.Facility[1]);
            Monolith.SetActive(data.Facility[2]);
            Score.text = data.score.ToString();
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
            // Initialize Prize
            foreach (Transform child in PrizePanel) Destroy(child.gameObject);
            for(int i = 0; i<data.prize; i++) {
                GameObject newButton = Instantiate(PrizeButton, PrizePanel);
                newButton.GetComponent<Button>().onClick.AddListener(() => OnPrizeClick());
            }
            InfoPanel.SetActive(true);
        }
    }
    public void OnResourceClick(int type = 8) // Default for orbital
    {
        Debug.Log($"Button '{type}' clicked!");
    }
    void OnPrizeClick()
    {
        Debug.Log($"Prize clicked!");
    }
    public void OnPlatePress()
    {
        Debug.Log($"Plate clicked!");
    }
    public void OnAncientPress()
    {
        Debug.Log($"Ancient clicked!");
    }
    public void OnStarbasePress()
    {
        Debug.Log($"Starbase clicked!");
    }
    public void OnCloseButtonPress()
    {
        UIManager.GamePaused = false;
        InfoPanel.SetActive(false);
    }
}
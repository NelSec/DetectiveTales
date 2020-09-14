using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject inspectionPanel;
    public GameObject inspectionPanel2;
    public GameObject inspectionPanel3;
    public GameObject inspectionPanel4;
    public GameObject inspectionPanel5;
    public GameObject inspectionPanel6;
    public GameObject inspectionPanel7;
    public GameObject inspectionPanel8;
    public GameObject inspectionPanel9;
    public GameObject inspectionPanel10;
    public GameObject inspectionPanel11;
    public GameObject inspectionPanel12;
    public GameObject thoughtPanel;
    public TextMeshProUGUI inspectionText;
    public TextMeshProUGUI inspectionText2;
    public TextMeshProUGUI inspectionText3;
    public TextMeshProUGUI inspectionText4;
    public TextMeshProUGUI inspectionText5;
    public TextMeshProUGUI inspectionText6;
    public TextMeshProUGUI inspectionText7;
    public TextMeshProUGUI inspectionText8;
    public TextMeshProUGUI inspectionText9;
    public TextMeshProUGUI inspectionText10;
    public TextMeshProUGUI inspectionText11;
    public TextMeshProUGUI inspectionText12;
    public Text thoughtText;
    public Image[] inventoryIcons;

    public int currentPanel = 0;

    public void Start()
    {
        //HideInteractionPanels();
    }

    public void Update()
    {
        if (SceneController.instance.objetiveDone == true)
            currentPanel++;
    }

    public void ShowInteractionPanel(string inspectionMessage)
    {
        inspectionText.text = inspectionMessage;
        inspectionText2.text = inspectionMessage;
        switch (currentPanel)
        {
            case (1):
                inspectionPanel.SetActive(true);
                break;
            case (2):
                inspectionPanel2.SetActive(true);
                break;
            case (3):
                inspectionPanel3.SetActive(true);
                break;
            case (4):
                inspectionPanel4.SetActive(true);
                break;
            case (5):
                inspectionPanel5.SetActive(true);
                break;
            case (6):
                inspectionPanel6.SetActive(true);
                break;
            case (7):
                inspectionPanel7.SetActive(true);
                break;
            case (8):
                inspectionPanel8.SetActive(true);
                break;
            case (9):
                inspectionPanel9.SetActive(true);
                break;
            case (10):
                inspectionPanel10.SetActive(true);
                break;
            case (11):
                inspectionPanel11.SetActive(true);
                break;
            case (12):
                inspectionPanel12.SetActive(true);
                break;
        }       
    }

    public void HideInteractionPanels()
    {
        thoughtPanel.SetActive(false);
        switch (currentPanel)
        {
            case (2):
                inspectionPanel.SetActive(false);
                break;
            case (3):
                inspectionPanel2.SetActive(false);
                break;
            case (4):
                inspectionPanel3.SetActive(false);
                break;
            case (5):
                inspectionPanel4.SetActive(false);
                break;
            case (6):
                inspectionPanel5.SetActive(false);
                break;
            case (7):
                inspectionPanel6.SetActive(false);
                break;
            case (8):
                inspectionPanel7.SetActive(false);
                break;
            case (9):
                inspectionPanel8.SetActive(false);
                break;
            case (10):
                inspectionPanel9.SetActive(false);
                break;
            case (11):
                inspectionPanel10.SetActive(false);
                break;
            case (12):
                inspectionPanel11.SetActive(false);
                break;
        }     
    }

    public void ClearInventoryIcons()
    {
        for (int i = 0; i < inventoryIcons.Length; ++i)
        {
            inventoryIcons[i].sprite    = null;
            inventoryIcons[i].color     = Color.clear;
        }
    }

    public void SetInventoryIcon(int i, Sprite icon)
    {
        inventoryIcons[i].sprite    = icon;
        inventoryIcons[i].color     = Color.white;
    }
}

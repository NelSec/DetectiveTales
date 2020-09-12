using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject inspectionPanel;
    public GameObject inspectionPanel2;
    public GameObject thoughtPanel;
    public TextMeshProUGUI inspectionText;
    public TextMeshProUGUI inspectionText2;
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

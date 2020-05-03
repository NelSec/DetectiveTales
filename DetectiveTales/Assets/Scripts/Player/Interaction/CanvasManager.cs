using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject inspectionPanel;
    public GameObject thoughtPanel;
    public Text inspectionText;
    public Text thoughtText;
    public Image[] inventoryIcons;

    public void Start()
    {
        HideInteractionPanels();
    }

    public void ShowInteractionPanel(string inspectionMessage)
    {
        inspectionText.text = inspectionMessage;
        inspectionPanel.SetActive(true);
    }

    public void HideInteractionPanels()
    {
        inspectionPanel.SetActive(false);
        thoughtPanel.SetActive(false);
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

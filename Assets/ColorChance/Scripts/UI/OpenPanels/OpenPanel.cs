using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void OpeningPanel()
    {
        _panel.SetActive(true);
    }

    public void ClosingdPanel() 
    {
        _panel.SetActive(false);
    }

}

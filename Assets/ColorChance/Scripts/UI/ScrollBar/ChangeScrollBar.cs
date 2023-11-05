using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeScrollBar : MonoBehaviour
{
    public int _counterTimeline { get; set; } = 60;

    private float _fill = 1;
    public float Fill
    {
        get
        {
            return _fill;
        }
        set
        {
            if (_fill >= 0)
                _fill = value;
        }
    }

    [SerializeField] private OpenPanel _openPanel;
    [SerializeField] private Image _scrollBar;
    [SerializeField] private TMP_Text _scrollText;

    private void Update()
    {
        if(_counterTimeline >= 0)
        {
            _scrollBar.fillAmount = _fill;
            _counterTimeline = Mathf.RoundToInt(_fill * 100);
            _scrollText.text = _counterTimeline + "";
            _fill -= Time.deltaTime * 0.010f;
        }
        else
        {
            _fill = 1;
            _openPanel.OpeningPanel();
        }
    }
}

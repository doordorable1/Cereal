using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TempletTooltip : MonoBehaviour
{
    CanvasGroup m_canvasGroup;
    TextMeshProUGUI m_titleText;
    TextMeshProUGUI m_detailText;
    Image m_image;
    Sprite m_noImageSprite;

    public void Show(bool show) => m_canvasGroup.alpha = (show) ? 1f : 0f;


    private void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();
        m_titleText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        m_image = transform.GetChild(1).GetComponent<Image>();
        m_detailText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        Show(false);
    }

    public void SetData(string id, bool isActive)
    {
        ActiveSO activeSO = Manager.Card.ActiveLapidaries.Find(elem => elem.cardInfo.Id == id)?.cardInfo;
        PassiveSO passiveSO = Manager.Card.ActiveLapidaries.Find(elem => elem.cardInfo.Id == id)?.cardInfo2;
        if (isActive && !activeSO.IsUnityNull())
        {
            SetData(activeSO);
        }
        else if (!passiveSO.IsUnityNull())
        {
            SetData(passiveSO);
        }
        else
        {
            SetData("Not Found", 0, -1, null, "ID Not Found");
        }
    }

    public void SetData(ScriptableObject cardSO)
    {
        if(cardSO is ActiveSO)
        {
            ActiveSO activeSO = (ActiveSO)cardSO;
            SetData(activeSO.Name, 0, activeSO.rarity, null, activeSO.Ability);
        }
        else if (cardSO is PassiveSO)
        {
            PassiveSO passiveSO  = (PassiveSO)cardSO;
            SetData(passiveSO.Name, 0, passiveSO.rarity, null, passiveSO.Ability);
        }
        else
        {
            SetData("Not Found", 0, -1, null, "cardSO Not Active/Passive");
        }
    }

    public void SetData(string name, int level, int rarity, Sprite sprite, string detail)
    {
        m_titleText.text = name + ((level > 0) ? " +" + level : "");
        switch(rarity)
        {
            case 1:
                m_titleText.color = Color.white;
                break;
            case 2:
                m_titleText.color = Color.green;
                break;
            case 3:
                m_titleText.color = Color.blue;
                break;
            case 4:
                m_titleText.color = new Color(0.7f, 0f, 1f);
                break;
            case 5:
                m_titleText.color = Color.yellow;
                break;
            default:
                m_titleText.color = Color.gray;
                break;
        }
        m_image.sprite = (sprite != null) ? sprite : m_noImageSprite;
        m_detailText.text = detail;
    }
}

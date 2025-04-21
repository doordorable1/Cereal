using TMPro;
using System.Linq;
using UnityEngine;

public class InfoBowlController : MonoBehaviour
{
    public void UpdateInputInfo() => UpdateInfo(inputInfoDataTexts);
    public void UpdateOutputInfo() => UpdateInfo(outputInfoDataTexts);
    public void ResetInputInfo() => ResetData(inputInfoDataTexts);
    public void ResetOutputInfo() => ResetData(outputInfoDataTexts);

    //TextMeshProUGUI[][] textMeshProUGUIs;
    TextMeshProUGUI[] inputInfoDataTexts;
    TextMeshProUGUI[] outputInfoDataTexts;
    private void Awake()
    {
        //int cerealTypeLen = Enum.GetValues(typeof(CerealType)).Length;
        //textMeshProUGUIs = new TextMeshProUGUI[cerealTypeLen][];
        //for(int i = 0; i < cerealTypeLen; i++)
        //{
        //    TextMeshProUGUI[] count GetComponentsInChildren<TextMeshProUGUI>();
        //    textMeshProUGUIs[i] = new TextMeshProUGUI[] = 
        //}

        inputInfoDataTexts = transform.GetChild(0).GetChild(1).GetComponentsInChildren<TextMeshProUGUI>();
        outputInfoDataTexts = transform.GetChild(1).GetChild(1).GetComponentsInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (StageManager.Instance != null)
        {
            StageManager.Instance.OnRoundStart.AddListener(UpdateInputInfo);
            StageManager.Instance.OnRoundStart.AddListener(ResetOutputInfo);
            StageManager.Instance.OnRoundCalculateFinoshed.AddListener(UpdateOutputInfo);
        }

        ResetInputInfo();
        ResetOutputInfo();
    }


    void UpdateInfo(TextMeshProUGUI[] targetInfo)
    {
        var list = Manager.Data.CerealBowlControl.CerealBowl.ToList();
        ResetData(targetInfo);
        for (int i = 0; i < list.Count; i++)
        {
            Cereal cereal = list[i].Key;
            SetData(targetInfo, cereal, list[i].Value);
        }
    }

    void SetData(TextMeshProUGUI[] targetInfo, Cereal cereal, int count)
    {
        int idx = (cereal.cerealRank - 1) + (3 * (int)(cereal.cerealType));
        targetInfo[idx].text = count.ToString("0");
    }

    void ResetData(TextMeshProUGUI[] targetInfo)
    {
        for(int i = 0; i < targetInfo.Length; i++)
        {
            targetInfo[i].text = "0";
        }
    }


}

using System.Collections;
using System.Linq;
using UnityEngine;

public class VisualCerealBowlController : MonoBehaviour
{
    public void ClearInputBowl() => ClearBowl(inputBowl);
    public void ClearOutputBowl() => ClearBowl(outputBowl);
    public void AddCerealObjectInputBowl(Cereal cereal, int num) => AddCerealObject(cereal, num, inputBowl);
    public void AddCerealObjectOutputBowl(Cereal cereal, int num) => AddCerealObject(cereal, num, outputBowl);
    public void ReplaceInputBowl() => Replace(inputBowl, outputBowl);

    public int GetCurrentCerealScore() { Manager.Data.CalculateScore(); return Manager.Data.Score; }

    public void SetStageScore() => StageManager.Instance.ScoreRenew(GetCurrentCerealScore());

    [Header("Cereal")]
    [SerializeField] private GameObject oreoPrefab;
    [SerializeField] private GameObject chexPrefab;
    [SerializeField] private GameObject frootPrefab;
    [SerializeField] private GameObject CocoPrefab;
    private Transform inputBowl;
    private Transform outputBowl;


    private void Awake()
    {
        inputBowl = transform.GetChild(0);
        outputBowl = transform.GetChild(1);
    }

    private void Start()
    {
        if(StageManager.Instance != null)
        {
            StageManager.Instance.OnRoundStart.AddListener(SetInputBowl);
            StageManager.Instance.OnRoundCalculateFinoshed.AddListener(SetOutputBowl);
            StageManager.Instance.OnRoundCalculateFinoshed.AddListener(SetStageScore);
        }
    }

    void AddCerealObject(Cereal cereal, int num, Transform parentTr)
    {
        GameObject cerealPrefab = null;
        switch (cereal.cerealType)
        {
            case CerealType.Oreo:
                cerealPrefab = oreoPrefab;
                break;
            case CerealType.Chex:
                cerealPrefab = chexPrefab;
                break;
            case CerealType.Froot:
                cerealPrefab = frootPrefab;
                break;
            case CerealType.Coco:
                cerealPrefab = CocoPrefab;
                break;
            default:
                return;
        }

        StartCoroutine(AddCerealObjectCoroutine(num, cerealPrefab, cereal.cerealRank, parentTr));
    }

    IEnumerator AddCerealObjectCoroutine(int num, GameObject cerealPrefab, int rank, Transform parent)
    {
        float randomSpawmOffsetX = 2.2f;
        int scale = 10;
        int compressionSize = 100;
        int compressionCount = num / compressionSize;
        float compressCerealScale = 4f;

        for (int i = 0; i < compressionCount; i++)
        {
            Vector3 randomSpawmOffset = new Vector3(Random.Range(-randomSpawmOffsetX, randomSpawmOffsetX), 0f, 0f);
            Vector2 randomVector2 = new Vector2(Random.Range(-0.5f, 0.5f), -1f);

            GameObject obj = Instantiate(cerealPrefab, parent);
            obj.transform.position = parent.position + randomSpawmOffset;
            obj.GetComponentInChildren<VisualRankCerealModel>().SetRank(rank);
            obj.GetComponent<Rigidbody2D>().AddForce(randomVector2.normalized);

            obj.name = obj.name + "-" + compressionSize;
            obj.transform.localScale *= compressCerealScale;

            num -= compressionSize;
        }

        for(int i = 0; i < scale; i++)
        {
            int repeatCount = (num / scale) + (((num % scale) > i) ? 1 : 0);
            for(int j = 0; j < repeatCount; j++)
            {
                Vector3 randomSpawmOffset = new Vector3(Random.Range(-randomSpawmOffsetX, randomSpawmOffsetX), 0f, 0f);
                Vector2 randomVector2 = new Vector2(Random.Range(-0.5f, 0.5f), -1f);
                //float randomAngle = Random.Range()

                GameObject obj = Instantiate(cerealPrefab, parent);
                obj.transform.position = parent.position + randomSpawmOffset;
                obj.GetComponentInChildren<VisualRankCerealModel>().SetRank(rank);
                obj.GetComponent<Rigidbody2D>().AddForce(randomVector2.normalized);

                obj.name = obj.name + i.ToString() + "-" + j.ToString();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    GameObject CreateVisualCereal(GameObject cerealPrefab, int rank, Transform parent)
    {
        float randomSpawmOffsetX = 2.2f;

        Vector3 randomSpawmOffset = new Vector3(Random.Range(-randomSpawmOffsetX, randomSpawmOffsetX), 0f, 0f);
        //Vector2 randomVector2 = new Vector2(Random.Range(-0.5f, 0.5f), -1f);
        //float randomAngle = Random.Range()

        return Instantiate(cerealPrefab, parent);
    }

    void ClearBowl(Transform bowl)
    {
        for(int i = 1; i < bowl.childCount; i++)
        {
            Destroy(bowl.GetChild(i).gameObject);
        }
    }


    void Replace(Transform targetBowl, Transform sourceBowl)
    {
        StartCoroutine(ReplaceCoroutine(targetBowl, sourceBowl));
    }

    IEnumerator ReplaceCoroutine(Transform targetBowl, Transform sourceBowl)
    {
        ClearBowl(targetBowl);
        yield return null;

        int cerealNum = sourceBowl.childCount;
        for (int i = 1; i < cerealNum; i++)
        {
            Vector3 localPos = sourceBowl.GetChild(1).localPosition;
            sourceBowl.GetChild(1).parent = targetBowl;
            targetBowl.GetChild(i).localPosition = localPos;
        }
    }



    void SetOutputBowl()
    {
        string msg = StageManager.Instance.round + " -Output Cereal-";
        var list = Manager.Data.CerealBowlControl.CerealBowl.ToList();
        for (int i = 0; i < list.Count; i++)
        {
            Cereal cereal = list[i].Key;
            AddCerealObjectOutputBowl(cereal, list[i].Value);
            //SMGDebug.Log("[Cereal]" + cereal.cerealType.ToString() + " / " + cereal.cerealRank.ToString() + " / " + list[i].Value + "cnt");
            msg += "\n\t" + "[Cereal]" + cereal.cerealType.ToString() + " / " + cereal.cerealRank.ToString() + " / " + list[i].Value + "cnt";
        }
        SMGDebug.Log(msg);
    }

    void SetInputBowl()
    {
        if (outputBowl.childCount > 1)
        {
            ReplaceInputBowl();
        }
        else
        {
            //SMGDebug.Log("=New Input Cereal=");
            var list = Manager.Data.CerealBowlControl.CerealBowl.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Cereal cereal = list[i].Key;                
                AddCerealObjectInputBowl(cereal, list[i].Value);
                //SMGDebug.Log("[Cereal]" + cereal.cerealType.ToString() + " / " + cereal.cerealRank.ToString() + " / "  + list[i].Value + "cnt");
            }
        }
        //SMGDebug.Log("Round: " + StageManager.Instance.round);
    }

#if UNITY_EDITOR
    [Header("Context Menu")]
    public Cereal testCereal;
    public int testNum = 0;
    [ContextMenu("AddCerealObject(testCereal, testNum, inputBowl)")]
    void TestAddCerealObjectInputBowl()
    {
        AddCerealObject(testCereal, testNum, inputBowl);
    }
    [ContextMenu("AddCerealObject(testCereal, testNum, outputBowl)")]
    void TestAddCerealObjectOutputBowl()
    {
        AddCerealObject(testCereal, testNum, outputBowl);
    }

    [ContextMenu("ClearBowl(inputBowl)")]
    void TestClearInputBowl()
    {
        ClearBowl(inputBowl);
    }
    [ContextMenu("ClearBowl(outputBowl)")]
    void TestClearOutputBowl()
    {
        ClearBowl(outputBowl);
    }

    [ContextMenu("Replace(inputBowl, outputBowl)")]
    void ReplaceOutToIn()
    {
        //Replace(inputBowl, outputBowl);
        ReplaceInputBowl();
    }

    [ContextMenu("Replace(outputBowl, inputBowl)")]
    void ReplaceInToOut()
    {
        Replace(outputBowl, inputBowl);
    }

    [ContextMenu("GetCurrentCerealScore()")]
    void TestGetCurrentCerealScore()
    {
        Debug.Log("GetCurrentCerealScore(): " + GetCurrentCerealScore());
    }
#endif
}

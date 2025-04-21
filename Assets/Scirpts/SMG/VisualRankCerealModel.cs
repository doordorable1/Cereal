using UnityEngine;

public class VisualRankCerealModel : MonoBehaviour
{    
    public void SetRank(int rank)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = (i < rank) ? true : false;
        }
    }
}

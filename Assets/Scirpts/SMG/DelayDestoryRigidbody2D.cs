using UnityEngine;

public class DelayDestoryRigidbody2D : MonoBehaviour
{
    float disableTime = 3f;
    float deltaTime;

    private void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= disableTime)
        {
            Destroy(GetComponent<Rigidbody2D>());
            enabled = false;
        }
    }
}

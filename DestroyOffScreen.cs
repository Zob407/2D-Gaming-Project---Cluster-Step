using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    // destroys object off screen for optimization 
    public float bottomY = -10f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }
    }
}

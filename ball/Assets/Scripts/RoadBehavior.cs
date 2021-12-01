using UnityEngine;

public class RoadBehavior : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Transform playerTransform;
    void Start()
    {
        playerTransform = Player.transform;
    }
    void Update()
    {
        SetScaleRoad();
    }
    void SetScaleRoad()
    {
        Vector3 thisScale = transform.localScale;
        thisScale.x = playerTransform.localScale.x;
        transform.localScale = thisScale;
    }
}

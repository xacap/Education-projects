using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] public GameObject CloseDoor;
    [SerializeField] public GameObject OpenDoor;

    public void SetOpenDoor()
    {
        CloseDoor.transform.position = new Vector3(-30, 0, 0);
        OpenDoor.SetActive(true);
    }
}

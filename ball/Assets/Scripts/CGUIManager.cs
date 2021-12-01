using UnityEngine;

public class CGUIManager : MonoBehaviour
{
    PlayerController mPlayerController;
    
    public void ShowGameFinishWindow()
    {
        mPlayerController = CGameManager.Instance.mPlayerController;

        if (mPlayerController.mState == EPlayerState.ePlayerWinner)
        {
            GameObject go = Instantiate(Resources.Load("CanvasFinishWindow")) as GameObject;
            go.GetComponent<RectTransform>().localPosition = new Vector3(960f, 540f, 0);
        }

        if (mPlayerController.mState == EPlayerState.ePlayerLost)
        {
            GameObject go = Instantiate(Resources.Load("CanvasLostWindow")) as GameObject;
            go.GetComponent<RectTransform>().localPosition = new Vector3(960f, 540f, 0);
        }
    }
}

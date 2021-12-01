using UnityEngine;

public enum EPlayerState
{
    ePlayerActive,
    ePlayerWinner,
    ePlayerLost
}

public class PlayerController : MonoBehaviour
{
    public EPlayerState mState = EPlayerState.ePlayerActive;
        
    private Vector3 setScale = new Vector3(1, 1, 1);
    [SerializeField] private Vector3 minScale = new Vector3(0.7f, 0.7f, 0.7f);
    [SerializeField] private float speedScale = 0.1f;

    [SerializeField] GameObject PlayerPoint;
    [SerializeField] GameObject Road;
    [SerializeField] GameObject Door;

    private GameObject bulletPrefab;

    Vector3 rayDirection;
    float rayDistance;
    Rigidbody _rb;
    Renderer _rend;

    private bool isDown = false; 
    public bool IsDown { get { return isDown; } }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rend = GetComponent<Renderer>();
    }

    void Start()
    {
        SetPlayerPosition();

        var headingRay = Door.transform.position - transform.position;
        rayDistance = headingRay.magnitude;
        rayDirection = headingRay / rayDistance;
    }

    void Update()
    {
        if (isDown) PlayerScale();
    }
   
    private void FixedUpdate()
    {
        ChekDoor();
        DoorOpening();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "finish")
        {
            mState = EPlayerState.ePlayerWinner;
            CGameManager.Instance.GetNotificationManager().Invoke(EEventType.eRestartGameEvent);
        }
    }

    void ChekDoor()
    {
        Ray playerRay = new Ray(this.transform.position, rayDirection);
        Debug.DrawRay(this.transform.position, rayDirection * rayDistance);

        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, rayDirection, out hit, rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("door"))
            {
                PlayerRun();
            }
        }
    }

    void DoorOpening()
    {
        var heading = this.transform.position - Door.transform.position;
        float maxRange = 5f;

        if (heading.sqrMagnitude < maxRange * maxRange)
        {
            CGameManager.Instance.mStageManager.SetOpenDoor();
        }
    }

    void PlayerRun()
    {
        _rb.useGravity = true;
        _rb.AddForce(rayDirection * 2 );
    }

    void SetPlayerPosition()
    {
        Vector3 playerPosition = PlayerPoint.transform.position;
        Vector3 playerRotation = new Vector3(0, 0, 0);
        playerRotation.y += Road.transform.eulerAngles.y;

        transform.position = playerPosition;
        transform.rotation = Quaternion.Euler(playerRotation);
    }
    void PlayerScale()
    {
        if (transform.localScale.x >= minScale.x)
        {
            transform.localScale -= setScale * (Time.deltaTime * speedScale);
            
        }
        else
        {
            mState = EPlayerState.ePlayerLost;
            Color colorLoså = Color.red;
            _rend.material.color = colorLoså;
            CGameManager.Instance.GetNotificationManager().Invoke(EEventType.eRestartGameEvent);
        }
    }
    void BulletSpawning()   
    {
        if (GameObject.FindGameObjectWithTag("bullet") == null)
        {
            bulletPrefab = Resources.Load<GameObject>("Bullet");
            Vector3 CurrentRotation = transform.eulerAngles;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(CurrentRotation));
        }
    }
   
    public void Down()
    {
        isDown = true;
        BulletSpawning();
    }
    public void Drop()
    {
        isDown = false;
    }
}

/*
  void SetPlayerSpawnerPosition()
    {
        Vector3 CurrentRotation = transform.eulerAngles;

        playerSpawner.transform.eulerAngles = CurrentRotation;
        Vector3 targetPos = new Vector3(0, 0, 0);
        targetPos.z += transform.localScale.z / 2;
        playerSpawner.transform.position = this.transform.position + targetPos;
        //playerSpawner.transform.rotation = this.transform.rotation;
    }

void BulletSpawning()   
    {
        bulletPrefab = Resources.Load<GameObject>("Bullet");

        if (bulletPrefab != null)
        {
            //Vector3 targetPos = new Vector3(0,0,0);
            //targetPos.z += transform.localScale.z / 2;
            //bulletPrefab.transform.position = this.transform.position + targetPos;
        }

        Vector3 CurrentRotation = transform.eulerAngles;
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(CurrentRotation));

        //Instantiate(bulletPrefab);
        
    }
 */

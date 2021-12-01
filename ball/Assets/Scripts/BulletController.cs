using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speedUp = 5f;
    [SerializeField] private float speedScaleBullet = 0.3f;
    [SerializeField] GameObject Infectoin;
    Rigidbody _rb;
    private Vector3 bulletScale = new Vector3(1, 1, 1);
    private float moveSpeed = 3f;
    GameObject player;    
    bool shot = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        BulletDestroy();

        if (CGameManager.Instance.mPlayerController.IsDown && !shot)
        {
            Move();
            BulletScale();
        }
        else Shot();
    }
    private void BulletDestroy()
    {
        if (CGameManager.Instance.mPlayerController.mState == EPlayerState.ePlayerLost)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            var collider = Infectoin.GetComponent<SphereCollider>();
            collider.radius = this.transform.localScale.x * 2;
            Infectoin.transform.position = transform.position;
            Instantiate(Infectoin);
            
            Destroy(this.gameObject);
        }
    }

    void BulletScale()
    {
         transform.localScale += bulletScale * (Time.deltaTime * speedScaleBullet);
    }

    void Shot()
    {
        Vector3 forwardUp = this.transform.position + transform.forward * speedUp * Time.fixedDeltaTime;
        _rb.transform.position = forwardUp;
        shot = true;
    }

    void Move()
    {
        if (player != null)
        {
            var heading = this.transform.position - player.transform.position;
            float maxRange = player.transform.localScale.x / 2f;

            if (heading.sqrMagnitude < maxRange * maxRange)
            {
                Vector3 forwardUp = this.transform.position + transform.forward * moveSpeed * Time.fixedDeltaTime;
                _rb.transform.position = forwardUp;
            }
        }
    }
}
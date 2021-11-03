using Constants;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip bounce;
    [SerializeField] private AudioClip burst;
    
    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isBallActive = false;
    private float moveSpeed = ProjectConstants.BallMoveSpeed;
    private Vector3 lastFrameVelocity;
    private float minVelocity = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PrepForLaunch()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        moveDirection = new Vector3(Random.value < 0.5f ? -1f : 1f, 0,
            Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f));
    }

    public void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    public void Freeze()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }
    
    private void Bounce(Vector3 collisionNormal)
    {
        audioSource.PlayOneShot(bounce);
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        rb.velocity = direction * speed;
    }

    public void PlayBurst()
    {
        audioSource.PlayOneShot(burst);    
    }
    
    public void Hide()
    {
        Freeze();
        transform.position = new Vector3(0, -20, 0);
    }

    public void Launch()
    {
        isBallActive = true;
        rb.AddForce(moveDirection * moveSpeed);
    }

    public void ChangeDirection(Vector3 direction)
    {
        rb.AddForce(direction * moveSpeed);
    }
}

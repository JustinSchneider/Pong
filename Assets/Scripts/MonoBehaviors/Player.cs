using Constants;
using Controllers;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerId;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    
    private Rigidbody rb;
    private readonly float moveSpeed = ProjectConstants.PlayerMoveSpeed;

    private Vector3 startingPos;
    private Vector3 moveDirection;
    private MeshRenderer meshRenderer;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        startingPos = transform.position;
    }

    private void Update()
    {
        if (CoreController.Instance.GameManager.isGameActive)
        {
            if (Input.GetKey(upKey))
            {
                moveDirection = transform.forward;
            } else if (Input.GetKey(downKey))
            {
                moveDirection = -transform.forward;
            }
            else
            {
                moveDirection = Vector3.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        if (moveDirection.sqrMagnitude != 0)
        {
            rb.AddForce(moveDirection * moveSpeed);
        }
    }

    public void Hide()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.DOFade(0f, 0f);
        }
    }

    public void Show()
    {
        meshRenderer.material.DOFade(1f, 1f);
    }

    public void ResetState()
    {
        transform.position = startingPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}


using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    const KeyCode LEFT = KeyCode.A;
    const KeyCode RIGHT = KeyCode.D;
    const KeyCode UP = KeyCode.W;
    const KeyCode DOWN = KeyCode.S;
    const int GROUND_LAYER = 6;
    const int OBSTACLE_LAYER = 7;
    const int LANE_COUNT = 3;
    const string ANIM_BOOL = "Ducking";
    public float JumpForce;

    Rigidbody rB;
    CapsuleCollider c;
    Animator a;
    int targetLane;
    bool onGround;
    bool sliding;

    private void Awake() => Instance = Instance ?? this;
    private void OnDestroy() => Instance = Instance == this ? null : Instance;
    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        c = GetComponent<CapsuleCollider>();
        a = transform.GetChild(0).GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == GROUND_LAYER)
        {
            onGround = true;
        }
        if (collision.gameObject.layer == OBSTACLE_LAYER)
        {
            GameManager.Instance.RunEnd();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == GROUND_LAYER)
        {
            onGround = false;
        }
    }

    private void Update()
    {
        LaneSwap();
        Jump();
        Slide();
        HandleGravity();
    }
    void LaneSwap()
    {
        if (Input.GetKeyDown(LEFT) && targetLane > -Mathf.RoundToInt((LANE_COUNT - 1) * .5f))
        {
            targetLane--;
            Swap();
        }
        if (Input.GetKeyDown(RIGHT) && targetLane < Mathf.RoundToInt((LANE_COUNT - 1) * .5f))
        {
            targetLane++;
            Swap();
        }
    }
    void Swap()
    {
        DOTween.Kill(transform.position.x);
        DOTween.To(() => transform.position.x, (x) => transform.position = new Vector3(x, transform.position.y, transform.position.z), targetLane * 2, .25f);
    }
    void Jump()
    {
        if (Input.GetKeyDown(UP) && onGround)
        {
            DOTween.Kill(c.height);
            DOTween.Kill(c.center.y);
            CancelInvoke(nameof(SlideUp));
            c.height = 2;
            sliding = false;
            a?.SetBool(ANIM_BOOL, false);
            rB.AddForce(Vector3.up * JumpForce);
        }
    }
    #region Slide
    void Slide()
    {
        if (Input.GetKeyDown(DOWN) && !sliding)
        {
            sliding = true;
            SlideDown();
        }
    }
    void SlideDown()
    {
        a?.SetBool(ANIM_BOOL, true);
        DOTween.To(() => c.height, (float y) => c.height = y, 1, .1f).SetEase(Ease.Linear).OnComplete(SlideWait);
        DOTween.To(() => c.center.y, (float y) => c.center = new Vector3(c.center.x, y, c.center.z), .5f, .1f).SetEase(Ease.Linear);
    }
    void SlideWait() => Invoke(nameof(SlideUp), 1);
    void SlideUp()
    {
        a?.SetBool(ANIM_BOOL, false);
        DOTween.To(() => c.height, (float y) => c.height = y, 2, .1f).SetEase(Ease.Linear).OnComplete(SlideDone);
        DOTween.To(() => c.center.y, (float y) => c.center = new Vector3(c.center.x, y, c.center.z), 1, .1f).SetEase(Ease.Linear);
    }
    void SlideDone() => sliding = false;
    void HandleGravity()
    {
        if (sliding && !onGround)
        {
            rB.AddForce(Vector3.down * 100);
        }
    }
    #endregion
}
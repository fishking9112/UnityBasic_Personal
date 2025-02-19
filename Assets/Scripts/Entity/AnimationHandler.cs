using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    protected Animator animator;
    public Animator Anim { get { return animator; } }

    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    private static readonly int IsJump = Animator.StringToHash("IsJump");

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > 0.5f);
    }
    public void Damage()
    {
        animator.SetBool(IsDamage , true);
    }
    public void Jump(bool _isJump)
    {
        animator.SetBool (IsJump , _isJump);
    }

    public void InvincibilityEnd()
    {
        animator.SetBool(IsDamage, false);
    }
}

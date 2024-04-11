using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampline : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _animator;
    [SerializeField] private float jumpVelocity = 10f;
    private float waitBeforJump = 1f;

    private bool isJump;
    // [SerializeField] private Animator _animator;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _animator.Play("Tramplin");
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            StartCoroutine(TrampolineEffect(rb));
        }
    }

    public void ActivateTrampline(Rigidbody2D rb)
    {
        _animator.Play("Tramplin");
        StartCoroutine(TrampolineEffect(rb));
    }


    IEnumerator TrampolineEffect(Rigidbody2D rb)
    {
        isJump = true;
        // Time to wait before applying the trampoline effect
        yield return new WaitForSeconds(waitBeforJump);

        // Adjust the Y velocity of the player to create the trampoline effect
        if (isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isJump = false;
        }
    }
}
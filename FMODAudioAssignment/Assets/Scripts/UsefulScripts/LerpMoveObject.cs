using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveObject : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    private Vector3 currentTarget;
    private bool lerping;
    [Range(0,0.5f)] public float lerpSpeed;

    public bool lerpEndOnAwake = false;
    
    private void Start() {
        transform.position = startPos.position;

        if (lerpEndOnAwake) {
            LerpToEnd();
        }
    }

    public void LerpToEnd() {
        currentTarget = endPos.position;
        lerping = true;
    }

    public void LerpToStart() {
        currentTarget = startPos.position;
        lerping = true;
    }

    private void Update() {
        if (lerping) {
            transform.position = Vector3.Lerp(transform.position, currentTarget, lerpSpeed);

            if (Vector3.Distance(transform.position, currentTarget) <= 0.05) {
                transform.position = currentTarget;
                lerping = false;
            }
        }
        
    }
}

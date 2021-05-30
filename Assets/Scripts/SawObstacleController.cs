using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawObstacleController : MonoBehaviour
{
    [SerializeField] private Transform sawBladeTransform;

    [SerializeField] private Transform startPointTransform;

    [SerializeField] private Transform endPointTransform;

    [SerializeField] private SawController sawControllerCS;

    private bool startToEnd = true;
    [SerializeField] private float sawSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sawBladeTransform.localPosition = startPointTransform.localPosition;

        StartCoroutine(InitSawObstacleMovementStartToEnd());

    }

    private IEnumerator InitSawObstacleMovementStartToEnd()
    {
        float timeSinceStartedMoving = 0.0f;

        sawControllerCS.sawSpeed = sawControllerCS.sawSpeed * 1;

        while (true)
        {
            timeSinceStartedMoving += Time.deltaTime;

            sawBladeTransform.localPosition = Vector3.MoveTowards(sawBladeTransform.localPosition, endPointTransform.localPosition, timeSinceStartedMoving * sawSpeed);

            if (sawBladeTransform.localPosition == endPointTransform.localPosition)
            {
                StartCoroutine(InitSawObstacleMovementEndToStart());

                yield break;

            }

            yield return null;

        }

    }

    private IEnumerator InitSawObstacleMovementEndToStart()
    {
        float timeSinceStartedMoving = 0.0f;

        sawControllerCS.sawSpeed = sawControllerCS.sawSpeed * 1;

        while (true)
        {
            timeSinceStartedMoving += Time.deltaTime;

            sawBladeTransform.localPosition = Vector3.MoveTowards(sawBladeTransform.localPosition, startPointTransform.localPosition, timeSinceStartedMoving * sawSpeed);

            if (sawBladeTransform.localPosition == startPointTransform.localPosition)
            {
                StartCoroutine(InitSawObstacleMovementStartToEnd());

                yield break;

            }

            yield return null;

        }

    }

}

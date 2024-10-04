using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSliderBar : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(direction);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthGauge : MonoBehaviour
{
    [SerializeField] private Transform _gaugeHandleTrm;

    public void RefreshGauge(float fill)
    {
        fill = Mathf.Clamp01(fill);
        _gaugeHandleTrm.localScale = new Vector3(fill, 1, 1);
    }
}

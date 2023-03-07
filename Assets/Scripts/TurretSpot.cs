using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSpot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Turret prefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

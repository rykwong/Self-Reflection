using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject item;
    public bool done = false;

    public void Enable()
    {
        GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        item.GetComponent<Destroy>().destroyObject();
        done = true;
    }
}

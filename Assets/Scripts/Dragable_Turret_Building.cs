using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable_Turret_Building : MonoBehaviour {

    [SerializeField]
    GameObject TurretPrefab;
    [SerializeField]
    Turrets.TurretType Type;
    [SerializeField]
    int Price = 100;

    bool ObjectAttached = false;
    bool CanBuildHere = true;
    Vector3 myPosition;
    Vector3 myHomePosition;
    Transform TurretsParentObject;
    GameObject RangeIndicator;
    private void Start()
    {
        myHomePosition = transform.position;
        RangeIndicator = transform.GetChild(0).gameObject;
        TurretsParentObject = GameObject.Find("Turrets").transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && ObjectAttached)
        {
            ObjectAttached = false;
            RangeIndicator.SetActive(false);
            if (CanBuildHere){ Build(); }
            transform.position = myHomePosition;
        }

        if (ObjectAttached)
        {
            myPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            myPosition.z = -2f;
            transform.position = myPosition;
            RangeIndicator.SetActive(true);
            if (Upgrading_Controller.ChosenTurret != null)
            Upgrading_Controller.ChosenTurret.GetRangeIndicator().SetActive(false);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && Upgrading_Controller.HyperTokens >= Price)
            ObjectAttached = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanBuildHere = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanBuildHere = true;
    }

    void Build()
    {
        GameObject tmpTurret = Instantiate(TurretPrefab, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
        tmpTurret.transform.SetParent(TurretsParentObject);
        Upgrading_Controller.HyperTokens -= Price;
    }
}

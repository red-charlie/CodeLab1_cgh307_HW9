using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{

    public Material[] materials;
    public int gridX, gridY;

    public GameObject randomblock;
    private Material original;
    private bool isRed = false;

    void Awake()
    {
        //Set all cubes to blue
        GetComponent<MeshRenderer>().material =
    materials[0];
        original = GetComponent<MeshRenderer>().material;
    }

    // Start is called before the first frame update
    public void SetPos(int x, int y)
    {
        gridX = x;
        gridY = y;

        name = "X: " + x + " Y: " + y;
    }
    void Update()
    {
        
    }

    public void ChangeToRed()
    {
        GetComponent<MeshRenderer>().material = materials[3]; // change block color to red
        isRed = true;
        Debug.Log("change to red");
    }

    public void ReturnColor()
    {
        GetComponent<MeshRenderer>().material =
            original;
    }

    void OnMouseDown()
    {
        if (isRed)
        {
            Debug.Log("You Wacked a Mole!");
            GridManager.instance.ReturnColor();
            //GridManager.instance.RandomChoose();
            GameManager.instance.AddScore();
            GameManager.instance.AddTimeToTimer();
        }
        //Old Swap stuff from class
        //if(GridManager.instance.selected == null){
        //    GridManager.instance.selected = this;
        //    transform.localScale = new Vector3(1, 1, 1);
        //} else {
        //    GridManager.instance.Swap(this);
        //}

        print(name);
    }
}

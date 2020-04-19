using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridManager : MonoBehaviour
{
    public int width;
    public int height;

    public GameObject cube; //The cube object this is assigned to

    GameObject[,] grid; //2d array

    public static GridManager instance; //making this the only insance

    public GridItem selected;

    public float timeTochange = 1f; //how often block colors change
    private float StartTime = 0f;  //when to start count time

    private GridItem previousRedCude = null; //previous cube that has turned red


    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    } //to make sure it is only obj

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[width, height];//defineing 2d array

        GameObject gridHolder = new GameObject("Grid Holder");//making a new obj called Grid Holder, put all the boxes in that

        //creating a grid in the gridholder 
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = Instantiate<GameObject>(cube);
                grid[x, y].transform.position = 
                    new Vector3(x, y, 0);

                grid[x, y].transform.parent = gridHolder.transform;
                grid[x, y].GetComponent<GridItem>().SetPos(x, y);
            }
        
        }

        Camera.main.transform.position = 
            new Vector3(width / 2, height / 2, -10);

        RandomChoose();
      
    }
    private void Update()
    {
        StartTime += Time.deltaTime;

        if (StartTime >= timeTochange) //change color when it's time
        {
            ReturnColor();  // return to original color
            RandomChoose();
        }

    }

    public void RandomChoose() //Chossing a random cube
    {
        System.Random r1 = new System.Random();
        System.Random r2 = new System.Random();
        int row = r1.Next(0, grid.GetLength(0));
        int column = r2.Next(0, grid.GetLength(1));
        var value = grid[row, column];

        Debug.Log("choose a random block");

        previousRedCude = value.GetComponent<GridItem>();

        previousRedCude.ChangeToRed();
        StartTime = 0f;  //reset the start time to 0
    }

    public void ReturnColor()
    {
        previousRedCude.ReturnColor();
    }
    

    //swapping the two items clicked (we're removing this for our whack a mole)
    //public void Swap(GridItem newItem)
    //{
    //    int tempX = newItem.gridX;
    //    int tempY = newItem.gridY;

    //    newItem.SetPos(selected.gridX, selected.gridY);
    //    newItem.transform.position =
    //                new Vector2(selected.gridX, selected.gridY);
    //    grid[tempX, tempY] = newItem.gameObject;

    //    selected.SetPos(tempX, tempY);
    //    selected.transform.position =
    //                new Vector2(tempX, tempY);
    //    grid[tempX, tempY] = selected.gameObject;

    //    selected.transform.localScale = new Vector3(.75f, .75f, .75f);
    //    selected = null;
    //}
}

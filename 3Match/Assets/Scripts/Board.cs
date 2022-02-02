using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject block_1;
    public GameObject block_2;
    public GameObject block_3;
    public int col;
    public int row;
    public int[,] initBoard;

    private void Start()
    {
        BuildBoard();        
    }

    private void Update()
    {
        



    }
    void BuildBoard()
    {
        initBoard = new int[col, row];
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                GameObject cellObj;
                GameObject blockObj;
                cellObj = Instantiate(cellPrefab, new Vector3((float)i - (col / 2), (float)j - (row / 2), 0), Quaternion.identity);
                initBoard[i, j] = Random.Range(0, 3);
                CheckBlock(i,j);
                blockObj = MakeBlock(initBoard[i,j]);
                blockObj.transform.SetParent(cellObj.transform, false);
            }
        }
    }
    GameObject MakeBlock(int num)
    {
        GameObject block=null;
        if (num == 0)
        {
            block = Instantiate(block_1);
        }
        else if (num == 1)
        {
            block =Instantiate(block_2);
        }
        else if (num == 2)
        {
            block = Instantiate(block_3);
        }
        return block;
    }
    void CheckBlock(int i, int j)
    {

        if (j > 1)
        {
            while (initBoard[i, j] == initBoard[i, j - 1] && initBoard[i, j] == initBoard[i, j - 2])
            {
                initBoard[i, j] = Random.Range(0, 3);
            }
        }
        if (i > 1)
        {
            while (initBoard[i, j] == initBoard[i - 1, j] && initBoard[i, j] == initBoard[i - 2, j])
            {
                initBoard[i, j] = Random.Range(0, 3);
            }
        }
    }

}

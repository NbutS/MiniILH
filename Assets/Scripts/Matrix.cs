using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matrix : MonoBehaviour
{

    public static Matrix instance;
    private bool hadChoice = false;
    private Vector2Int matr1;
    private Vector2Int matr2;
    private bool allowMove = false;
    private bool check = false;
    private float time = 0f;
    [SerializeField] private float posXStart;
    [SerializeField] private float posYStart;
    [SerializeField] private float posXStart1;
    [SerializeField] private float posYStart1;
    [SerializeField] private float posXStart2;
    [SerializeField] private float posYStart2;
    [SerializeField] private GameObject animHeart;
    [SerializeField] private GameObject animBlack;
    [SerializeField] private GameObject animBlack1;
    [SerializeField] private GameObject winGameScreen;
    [SerializeField] private GameObject gamePlay;
    [SerializeField] private Text stepText;
    private int step = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private ChangeColor[,] matrixSquare = new ChangeColor[7,5];
    private GameObject[,] matrixCircle = new GameObject[7,5];
    private bool[,] bariersLocation = new bool[7,5];
    [SerializeField] private ChangeColor squarePrefab;
    [SerializeField] private GameObject blackCirle;

    private void Update()
    {
        if ( CheckIfSquareMove() && !allowMove)
        {
            allowMove = true;
        }
        if ( allowMove )
        {
            matrixSquare[matr1.x,matr1.y].DirMove = CalculateDir(matr1,matr2 );
            matrixSquare[matr1.x, matr1.y].AllowMove = true;
            Vector2Int tmp = matrixSquare[matr1.x, matr1.y].GetTmpIJ();
            matrixSquare[matr1.x, matr1.y].SetTmpIJ(matrixSquare[matr2.x, matr2.y].GetTmpIJ().x, matrixSquare[matr2.x, matr2.y].GetTmpIJ().y);
            matrixSquare[matr1.x, matr1.y].SetConditionToMove();
            matrixSquare[matr1.x, matr1.y].TargetPos = matrixSquare[matr2.x, matr2.y].transform.position;
            matrixSquare[matr2.x,matr2.y].DirMove = CalculateDir(matr2 ,matr1 );
            matrixSquare[matr2.x, matr2.y].SetTmpIJ(tmp.x, tmp.y);
            matrixSquare[matr2.x, matr2.y].AllowMove = true;
            matrixSquare[matr2.x, matr2.y].SetConditionToMove();
            matrixSquare[matr2.x, matr2.y].TargetPos = matrixSquare[matr1.x, matr1.y].transform.position;
            Debug.Log("TmpI " + matrixSquare[matr2.x, matr2.y].GetTmpIJ().x);
            Debug.Log("TmpJ " + matrixSquare[matr2.x, matr2.y].GetTmpIJ().y);
            step++;
            allowMove = false;
            SetPosMatr12();
        }

        if ( CheckWin() && !check)
        {
            Debug.Log("Step" + step);
            time += Time.deltaTime;
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if ( time > 9.6f )
                        {
                            stepText.text = "STEPS " + step.ToString();
                            animBlack1.SetActive(true);
                            winGameScreen.SetActive(true);
                            
                            time = 0f;
                            check = true;
                        }
                        if ( time > 4.5f && animHeart.active == false )
                        {
                            gamePlay.SetActive(false);
                            animHeart.SetActive(true);
                            Debug.Log("Animation Heart");
                        }
                        else if ( time >= 1.5f  && time <= 1.55f)
                        {
                            if (matrixCircle[i, j] != null )
                            {
                                Color tmp = matrixCircle[i, j].GetComponent<SpriteRenderer>().color;
                                matrixCircle[i, j].GetComponent<SpriteRenderer>().color = new Color(tmp.r, tmp.g, tmp.b, 0f);

                            }
                            if ( matrixSquare[i,j] != null )
                                matrixSquare[i,j].IsFaded = true;
                        }
                        else if (time > 0.2f && time < 1.5f)
                        {
                            if (bariersLocation[i, j] == true)
                            {
                                Color tmp = matrixCircle[i, j].GetComponent<SpriteRenderer>().color;
                                tmp = new Color(tmp.r, tmp.g, tmp.b, tmp.a - 0.008f);
                                matrixCircle[i, j].GetComponent<SpriteRenderer>().color = tmp;
                            }
                            if ( matrixSquare[i,j] != null )
                                matrixSquare[i, j].GetComponent<BoxCollider2D>().enabled = false;
                        }
                    }
                }
            }
            
        }
    }

    private void Start()
    {
        
        winGameScreen.SetActive(false);
        animBlack.SetActive(true);
        SetPosMatr12();
        Debug.Log("Level" + PlayerPrefs.GetInt("Level"));
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            SpawnSquareLevel();
            SetUpLevel12();
        }
        else if (PlayerPrefs.GetInt("Level") == 2)
        {
            SpawnSquareLevel();
            SetUpLevel11();
        }
        else if (PlayerPrefs.GetInt("Level") == 3)
        {
            SpawnSquareLevel11();
            SetUpLevel13();
        }
        else if (PlayerPrefs.GetInt("Level") == 4)
        {
            SpawnSquareLevel11();
            SetUpLevel14();
        }
        else if (PlayerPrefs.GetInt("Level") == 5)
        {
            SpawnSquareLevel11();
            SetUpLevel15();
        }
        else if (PlayerPrefs.GetInt("Level") == 6 )
        {
            SpawnSquareLevel12();
            SetUpLevel1();
        }
        else if ( PlayerPrefs.GetInt("Level") == 7 )
        {
            SpawnSquareLevel12();
            SetUpLevel2();
        }
        else if (PlayerPrefs.GetInt("Level") == 8)
        {
            SpawnSquareLevel12();
            SetUpLevel3();
        }
        else if ( PlayerPrefs.GetInt("Level") == 9 )
        {
            SpawnSquareLevel12();
            SetUpLevel4();
        }
        else if (PlayerPrefs.GetInt("Level") == 10)
        {
            SpawnSquareLevel12();
            SetUpLevel5();
        }
        else if (PlayerPrefs.GetInt("Level") == 11)
        {
            SpawnSquareLevel12();
            SetUpLevel6();
        }
        else if (PlayerPrefs.GetInt("Level") == 12)
        {
            SpawnSquareLevel12();
            SetUpLevel7();
        }
        else if (PlayerPrefs.GetInt("Level") == 13)
        {
            SpawnSquareLevel12();
            SetUpLevel8();
        }
        else if (PlayerPrefs.GetInt("Level") == 14)
        {
            SpawnSquareLevel12();
            SetUpLevel9();
        }
        else
        {
            SpawnSquareLevel12();
            SetUpLevel10();
        }
        
    }

    public void SetUpLevel1()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0 || i == 6)
                {
                    bariersLocation[i, j] = true;
                }
                else if (j == 0 || j == 1 || j == 3 || j == 4)
                {
                    bariersLocation[i, j] = true;
                }
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 5; i++)
        {
            int num1 = Random.Range(0, 5);
            int num2 = Random.Range(0, 5);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }
    public void SetUpLevel2()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0 || i == 6)
                {
                    bariersLocation[i, j] = true;
                }
                else if (j == 1 || j == 2 || j == 3)
                {
                    bariersLocation[i, j] = true;
                }
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 8; i++)
        {
            int num1 = Random.Range(0, 10);
            int num2 = Random.Range(0, 10);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }    
    public void SetUpLevel3()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0 && j == 0 || i == 6 && j == 0 || i == 0 && j == 4 || i == 6 && j == 4 )
                {
                    bariersLocation[i, j] = true;
                }
                else if (i >= 1 && i <= 5 && j >= 1 && j <= 3)
                {
                    bariersLocation[i, j] = true;
                }
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 15; i++)
        {
            int num1 = Random.Range(0, 15);
            int num2 = Random.Range(0, 15);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }
    public void SetUpLevel4()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0 || i == 6 || j == 0 || j == 4)
                {
                    bariersLocation[i, j] = true;
                }

            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 9; i++)
        {
            int num1 = Random.Range(0, 15);
            int num2 = Random.Range(0, 15);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }
    public void SetUpLevel5()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i != 3 && j != 2 )
                {
                    bariersLocation[i, j] = true;
                }
                
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 8; i++)
        {
            int num1 = Random.Range(0, 8);
            int num2 = Random.Range(0, 8);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SetUpLevel8()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j == 1 && (i > 0 && i < 6 ))
                {
                    continue;
                }
                else if ( j == 3 && (i > 0 && i < 6))
                {
                    continue;
                }    
                else if ( i == 3 && (j > 0 || j < 3))
                {
                    continue;   
                }
                else if ( i == 3 && j == 2 )
                {
                    continue ;
                }    
                else
                {
                    bariersLocation[i, j] = true;
                }
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 8; i++)
        {
            int num1 = Random.Range(0, 8);
            int num2 = Random.Range(0, 8);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SetUpLevel9()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j == 1 && (i > 0 && i < 6))
                {
                    continue;
                }
                else if (j == 3 && (i > 0 && i < 6))
                {
                    continue;
                }
                else if (i == 3 || i == 1 || i == 5 )
                {
                    continue;
                }
                else if (i == 3 && j == 2)
                {
                    continue;
                }
                else
                {
                    bariersLocation[i, j] = true;
                }
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 8; i++)
        {
            int num1 = Random.Range(0, 8);
            int num2 = Random.Range(0, 8);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SetUpLevel6()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 1 && j != 2)
                {
                    continue;
                }
                else if (i == 5 && j != 2)
                {
                    continue;
                }
                else if (j == 2 && i > 1 && i < 5)
                {
                    continue;
                }
                
                else
                {
                    bariersLocation[i, j] = true;
                }
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 8; i++)
        {
            int num1 = Random.Range(0, 8);
            int num2 = Random.Range(0, 8);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SetUpLevel7()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 1 || i == 5 )
                {
                    continue;
                }
                else if (j == 0 && (i > 0 && i < 6))
                {
                    continue;
                }
                else if (j == 4 && (i > 0 && i < 6))
                {
                    continue;
                }
                else
                {
                    bariersLocation[i, j] = true;
                }
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 8; i++)
        {
            int num1 = Random.Range(0, 8);
            int num2 = Random.Range(0, 8);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }
    public void SetUpLevel10()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 3)
                {
                    continue;
                }
                else if (i == 1 && j != 2 )
                {
                    continue;
                }
                else if (i == 2 && j > 0 && j < 4 )
                {
                    continue;
                }
                else if (i == 5 && j != 2)
                {
                    continue;
                }
                else if (i == 4 && j > 0 && j < 4)
                {
                    continue;
                }
                else if ( i == 3 && j == 2)
                {
                    continue;
                }    
                else
                {
                    bariersLocation[i, j] = true;
                }
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 12; i++)
        {
            int num1 = Random.Range(0, 12);
            int num2 = Random.Range(0, 12);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SetUpLevel11()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == 0 || i == 3)
                {
                    bariersLocation[i, j] = true;
                }
                
            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 6; i++)
        {
            int num1 = Random.Range(0, 5);
            int num2 = Random.Range(0, 5);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }
    public void SetUpLevel12()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == j || i == 4 - j - 1)
                {
                    continue;
                }
                else
                {
                    bariersLocation[i, j] = true;
                }

            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 6; i++)
        {
            int num1 = Random.Range(0, 5);
            int num2 = Random.Range(0, 5);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SetUpLevel13()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == 0 || i == 4 || j == 0 || j == 3 )
                {
                    bariersLocation[i, j] = true;
                }
                

            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 6; i++)
        {
            int num1 = Random.Range(0, 5);
            int num2 = Random.Range(0, 5);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SetUpLevel14()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (j == 0 && ( i >0 && i < 4 ))
                {
                    continue;
                    
                }
                else if (j == 3 && (i > 0 && i < 4))
                {
                    continue;
                }
                else
                    bariersLocation[i, j] = true;


            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 6; i++)
        {
            int num1 = Random.Range(0, 5);
            int num2 = Random.Range(0, 5);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SetUpLevel15()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (j == 0 && (i > 0 && i < 4))
                {
                    continue;

                }
                else if (j == 3 && (i > 0 && i < 4))
                {
                    continue;
                }
                else if ( i == 0 && (j > 0 && j < 3))
                {
                    continue;
                }
                else if (i == 4 && (j > 0 && j < 3))
                {
                    continue;
                }
                else
                    bariersLocation[i, j] = true;


            }
        }
        List<Vector2Int> sqs = new List<Vector2Int>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bariersLocation[i, j])
                {
                    matrixSquare[i, j].IsBarier = true;
                    SpawCirle(i, j, matrixSquare[i, j].transform.position);
                }
                else
                    sqs.Add(new Vector2Int(i, j));
            }
        }
        for (int i = 0; i < 9; i++)
        {
            int num1 = Random.Range(0, 5);
            int num2 = Random.Range(0, 5);
            Vector2Int sq1, sq2, ij;
            sq1 = sqs[num1];
            sq2 = sqs[num2];
            Vector3 tmp = matrixSquare[sq1.x, sq1.y].transform.position;
            ij = new Vector2Int(matrixSquare[sq1.x, sq1.y].GetTmpIJ().x, matrixSquare[sq1.x, sq1.y].GetTmpIJ().y);
            matrixSquare[sq1.x, sq1.y].transform.position = matrixSquare[sq2.x, sq2.y].transform.position;
            matrixSquare[sq1.x, sq1.y].SetTmpIJ(matrixSquare[sq2.x, sq2.y].GetTmpIJ().x, matrixSquare[sq2.x, sq2.y].GetTmpIJ().y);
            matrixSquare[sq2.x, sq2.y].transform.position = tmp;
            matrixSquare[sq2.x, sq2.y].SetTmpIJ(ij.x, ij.y);
            matrixSquare[sq1.x, sq1.y].OriPos = matrixSquare[sq1.x, sq1.y].transform.position;
            matrixSquare[sq2.x, sq2.y].OriPos = matrixSquare[sq2.x, sq2.y].transform.position;

        }
    }

    public void SpawCirle(int i, int j, Vector3 pos)
    {
        matrixCircle[i,j] = Instantiate(blackCirle,pos,Quaternion.identity);
    }
    public void SpawnSquareLevel12()
    {
        float deltaY;
        float deltaX;
        deltaX = 0.83f;
        deltaY = 0.83f;
        Vector3 pos;
        pos = new Vector3(posXStart, posYStart, 0f);
        // GREEN
        matrixSquare[0, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 0].OriPos = pos;
        Color myColor = new Color(153f / 255, 255f / 255, 204f / 255);
        matrixSquare[0, 0].SetColor(myColor);
        matrixSquare[0, 0].SetIJ(0, 0);
        matrixSquare[0, 0].SetTmpIJ(0, 0);

        pos = new Vector3(posXStart, posYStart - deltaY, 0f);
        matrixSquare[1, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 0].OriPos = pos;
        myColor = new Color(102f / 255, 255f / 255, 153f / 255);
        matrixSquare[1, 0].SetColor(myColor);
        matrixSquare[1, 0].SetIJ(1, 0);
        matrixSquare[1, 0].SetTmpIJ(1, 0);

        pos = new Vector3(posXStart, posYStart - 2f * deltaY, 0f);
        matrixSquare[2, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 0].OriPos = pos;
        myColor = new Color(102f / 255, 255f / 255, 103f / 255);
        matrixSquare[2, 0].SetColor(myColor);
        matrixSquare[2, 0].SetIJ(2, 0);
        matrixSquare[2, 0].SetTmpIJ(2, 0);

        pos = new Vector3(posXStart, posYStart - 3f * deltaY, 0f);
        matrixSquare[3, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 0].OriPos = pos;
        myColor = new Color(102f / 255, 255f / 255, 51f / 255);
        matrixSquare[3, 0].SetColor(myColor);
        matrixSquare[3, 0].SetIJ(3, 0);
        matrixSquare[3, 0].SetTmpIJ(3, 0);

        pos = new Vector3(posXStart, posYStart - 4f * deltaY, 0f);
        matrixSquare[4, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 0].OriPos = pos;
        myColor = new Color(51f / 255, 204f / 255, 51f / 255);
        matrixSquare[4, 0].SetColor(myColor);
        matrixSquare[4, 0].SetIJ(4, 0);
        matrixSquare[4, 0].SetTmpIJ(4, 0);

        pos = new Vector3(posXStart, posYStart - 5f * deltaY, 0f);
        matrixSquare[5, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[5, 0].OriPos = pos;
        myColor = new Color(0f / 255, 153f / 255, 51f / 255);
        matrixSquare[5, 0].SetColor(myColor);
        matrixSquare[5, 0].SetIJ(5, 0);
        matrixSquare[5, 0].SetTmpIJ(5, 0);

        pos = new Vector3(posXStart, posYStart - 6f * deltaY, 0f);
        matrixSquare[6, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[6, 0].OriPos = pos;
        myColor = new Color(0f / 255, 51f / 255, 0f / 255);
        matrixSquare[6, 0].SetColor(myColor);
        matrixSquare[6, 0].SetIJ(6, 0);
        matrixSquare[6, 0].SetTmpIJ(6, 0);

        // Blue
        pos = new Vector3(posXStart + deltaX, posYStart, 0f);
        matrixSquare[0, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 1].OriPos = pos;
        myColor = new Color(102f / 255, 255f / 255, 255f / 255);
        matrixSquare[0, 1].SetColor(myColor);
        matrixSquare[0, 1].SetIJ(0, 1);
        matrixSquare[0, 1].SetTmpIJ(0, 1);

        pos = new Vector3(posXStart + deltaX, posYStart - deltaY, 0f);
        matrixSquare[1, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 1].OriPos = pos;
        myColor = new Color(51f / 255, 204f / 255, 255f / 255);
        matrixSquare[1, 1].SetColor(myColor);
        matrixSquare[1, 1].SetIJ(1, 1);
        matrixSquare[1, 1].SetTmpIJ(1, 1);

        pos = new Vector3(posXStart + deltaX, posYStart - deltaY - deltaY, 0f);
        matrixSquare[2, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 1].OriPos = pos;
        myColor = new Color(0f / 255, 153f / 255, 255f / 255);
        matrixSquare[2, 1].SetColor(myColor);
        matrixSquare[2, 1].SetIJ(2, 1);
        matrixSquare[2, 1].SetTmpIJ(2, 1);

        pos = new Vector3(posXStart + deltaX, posYStart - 3f * deltaY, 0f);
        matrixSquare[3, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 1].OriPos = pos;
        myColor = new Color(0f / 255, 102f / 255, 255f / 255);
        matrixSquare[3, 1].SetColor(myColor);
        matrixSquare[3, 1].SetIJ(3, 1);
        matrixSquare[3, 1].SetTmpIJ(3, 1);

        pos = new Vector3(posXStart + deltaX, posYStart - 4f * deltaY, 0f);
        matrixSquare[4, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 1].OriPos = pos;
        myColor = new Color(0f / 255, 51f / 255, 204f / 255);
        matrixSquare[4, 1].SetColor(myColor);
        matrixSquare[4, 1].SetIJ(4, 1);
        matrixSquare[4, 1].SetTmpIJ(4, 1);

        pos = new Vector3(posXStart + deltaX, posYStart - 5f * deltaY, 0f);
        matrixSquare[5, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[5, 1].OriPos = pos;
        myColor = new Color(0f / 255, 51f / 255, 153f / 255);
        matrixSquare[5, 1].SetColor(myColor);
        matrixSquare[5, 1].SetIJ(5, 1);
        matrixSquare[5, 1].SetTmpIJ(5, 1);

        pos = new Vector3(posXStart + deltaX, posYStart - 6f * deltaY, 0f);
        matrixSquare[6, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[6, 1].OriPos = pos;
        myColor = new Color(0f / 255, 0f / 255, 153f / 255);
        matrixSquare[6, 1].SetColor(myColor);
        matrixSquare[6, 1].SetIJ(6, 1);
        matrixSquare[6, 1].SetTmpIJ(6, 1);

        // YELLOW
        pos = new Vector3(posXStart + 2f * deltaX, posYStart, 0f);
        matrixSquare[0, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 2].OriPos = pos;
        myColor = new Color(255f / 255, 255f / 255, 204f / 255);
        matrixSquare[0, 2].SetColor(myColor);
        matrixSquare[0, 2].SetIJ(0, 2);
        matrixSquare[0, 2].SetTmpIJ(0, 2);

        pos = new Vector3(posXStart + 2f * deltaX, posYStart - deltaY, 0f);
        matrixSquare[1, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 2].OriPos = pos;
        myColor = new Color(255f / 255, 255f / 255, 153f / 255);
        matrixSquare[1, 2].SetColor(myColor);
        matrixSquare[1, 2].SetIJ(1, 2);
        matrixSquare[1, 2].SetTmpIJ(1, 2);

        pos = new Vector3(posXStart + 2f * deltaX, posYStart - 2f * deltaY, 0f);
        matrixSquare[2, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 2].OriPos = pos;
        myColor = new Color(255f / 255, 255f / 255, 102f / 255);
        matrixSquare[2, 2].SetColor(myColor);
        matrixSquare[2, 2].SetIJ(2, 2);
        matrixSquare[2, 2].SetTmpIJ(2, 2);

        pos = new Vector3(posXStart + 2f * deltaX, posYStart - 3f * deltaY, 0f);
        matrixSquare[3, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 2].OriPos = pos;
        myColor = new Color(255f / 255, 255f / 255, 0f / 255);
        matrixSquare[3, 2].SetColor(myColor);
        matrixSquare[3, 2].SetIJ(3, 2);
        matrixSquare[3, 2].SetTmpIJ(3, 2);

        pos = new Vector3(posXStart + 2f * deltaX, posYStart - 4f * deltaY, 0f);
        matrixSquare[4, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 2].OriPos = pos;
        myColor = new Color(255f / 255, 204f / 255, 0f / 255);
        matrixSquare[4, 2].SetColor(myColor);
        matrixSquare[4, 2].SetIJ(4, 2);
        matrixSquare[4, 2].SetTmpIJ(4, 2);

        pos = new Vector3(posXStart + 2f * deltaX, posYStart - 5f * deltaY, 0f);
        matrixSquare[5, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[5, 2].OriPos = pos;
        myColor = new Color(255f / 255, 153f / 255, 0f / 255);
        matrixSquare[5, 2].SetColor(myColor);
        matrixSquare[5, 2].SetIJ(5, 2);
        matrixSquare[5, 2].SetTmpIJ(5, 2);

        pos = new Vector3(posXStart + 2f * deltaX, posYStart - 6f * deltaY, 0f);
        matrixSquare[6, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[6, 2].OriPos = pos;
        myColor = new Color(255f / 255, 51f / 255, 0f / 255);
        matrixSquare[6, 2].SetColor(myColor);
        matrixSquare[6, 2].SetIJ(6, 2);
        matrixSquare[6, 2].SetTmpIJ(6, 2);

        // Red
        pos = new Vector3(posXStart + 3f * deltaX, posYStart, 0f);
        matrixSquare[0, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 3].OriPos = pos;
        myColor = new Color(255f / 255, 204f / 255, 204f / 255);
        matrixSquare[0, 3].SetColor(myColor);
        matrixSquare[0, 3].SetIJ(0, 3);
        matrixSquare[0, 3].SetTmpIJ(0, 3);

        pos = new Vector3(posXStart + 3f * deltaX, posYStart - deltaY, 0f);
        matrixSquare[1, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 3].OriPos = pos;
        myColor = new Color(255f / 255, 153f / 255, 204f / 255);
        matrixSquare[1, 3].SetColor(myColor);
        matrixSquare[1, 3].SetIJ(1, 3);
        matrixSquare[1, 3].SetTmpIJ(1, 3);

        pos = new Vector3(posXStart + 3f * deltaX, posYStart - 2f * deltaY, 0f);
        matrixSquare[2, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 3].OriPos = pos;
        myColor = new Color(255f / 255, 102f / 255, 204f / 255);
        matrixSquare[2, 3].SetColor(myColor);
        matrixSquare[2, 3].SetIJ(2, 3);
        matrixSquare[2, 3].SetTmpIJ(2, 3);

        pos = new Vector3(posXStart + 3f * deltaX, posYStart - 3f * deltaY, 0f);
        matrixSquare[3, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 3].OriPos = pos;
        myColor = new Color(255f / 255, 51f / 255, 204f / 255);
        matrixSquare[3, 3].SetColor(myColor);
        matrixSquare[3, 3].SetIJ(3, 3);
        matrixSquare[3, 3].SetTmpIJ(3, 3);

        pos = new Vector3(posXStart + 3f * deltaX, posYStart - 4f * deltaY, 0f);
        matrixSquare[4, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 3].OriPos = pos;
        myColor = new Color(255f / 255, 51f / 255, 153f / 255);
        matrixSquare[4, 3].SetColor(myColor);
        matrixSquare[4, 3].SetIJ(4, 3);
        matrixSquare[4, 3].SetTmpIJ(4, 3);

        pos = new Vector3(posXStart + 3f * deltaX, posYStart - 5f * deltaY, 0f);
        matrixSquare[5, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[5, 3].OriPos = pos;
        myColor = new Color(255f / 255, 0f / 255, 102f / 255);
        matrixSquare[5, 3].SetColor(myColor);
        matrixSquare[5, 3].SetIJ(5, 3);
        matrixSquare[5, 3].SetTmpIJ(5, 3);

        pos = new Vector3(posXStart + 3f * deltaX, posYStart - 6f * deltaY, 0f);
        matrixSquare[6, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[6, 3].OriPos = pos;
        myColor = new Color(204f / 255, 0f / 255, 51f / 255);
        matrixSquare[6, 3].SetColor(myColor);
        matrixSquare[6, 3].SetIJ(6, 3);
        matrixSquare[6, 3].SetTmpIJ(6, 3);


        // VIOLET

        pos = new Vector3(posXStart + 4f * deltaX, posYStart, 0f);
        matrixSquare[0, 4] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 4].OriPos = pos;
        myColor = new Color(204f / 255, 153f / 255, 255f / 255);
        matrixSquare[0, 4].SetColor(myColor);
        matrixSquare[0, 4].SetIJ(0, 4);
        matrixSquare[0, 4].SetTmpIJ(0, 4);

        pos = new Vector3(posXStart + 4f * deltaX, posYStart - deltaY, 0f);
        matrixSquare[1, 4] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 4].OriPos = pos;
        myColor = new Color(204f / 255, 102f / 255, 255f / 255);
        matrixSquare[1, 4].SetColor(myColor);
        matrixSquare[1, 4].SetIJ(1, 4);
        matrixSquare[1, 4].SetTmpIJ(1, 4);

        pos = new Vector3(posXStart + 4f * deltaX, posYStart - 2f * deltaY, 0f);
        matrixSquare[2, 4] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 4].OriPos = pos;
        myColor = new Color(204f / 255, 51f / 255, 255f / 255);
        matrixSquare[2, 4].SetColor(myColor);
        matrixSquare[2, 4].SetIJ(2, 4);
        matrixSquare[2, 4].SetTmpIJ(2, 4);

        pos = new Vector3(posXStart + 4f * deltaX, posYStart - 3f * deltaY, 0f);
        matrixSquare[3, 4] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 4].OriPos = pos;
        myColor = new Color(204f / 255, 0f / 255, 255f / 255);
        matrixSquare[3, 4].SetColor(myColor);
        matrixSquare[3, 4].SetIJ(3, 4);
        matrixSquare[3, 4].SetTmpIJ(3, 4);

        pos = new Vector3(posXStart + 4f * deltaX, posYStart - 4f * deltaY, 0f);
        matrixSquare[4, 4] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 4].OriPos = pos;
        myColor = new Color(204f / 255, 0f / 255, 204f / 255);
        matrixSquare[4, 4].SetColor(myColor);
        matrixSquare[4, 4].SetIJ(4, 4);
        matrixSquare[4, 4].SetTmpIJ(4, 4);

        pos = new Vector3(posXStart + 4f * deltaX, posYStart - 5f * deltaY, 0f);
        matrixSquare[5, 4] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[5, 4].OriPos = pos;
        myColor = new Color(204f / 255, 0f / 255, 153f / 255);

        matrixSquare[5, 4].SetColor(myColor);
        matrixSquare[5, 4].SetIJ(5, 4);
        matrixSquare[5, 4].SetTmpIJ(5, 4);

        pos = new Vector3(posXStart + 4f * deltaX, posYStart - 6f * deltaY, 0f);
        matrixSquare[6, 4] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[6, 4].OriPos = pos;
        myColor = new Color(204f / 255, 0f / 255, 102f / 255);
        matrixSquare[6, 4].SetColor(myColor);
        matrixSquare[6, 4].SetIJ(6, 4);
        matrixSquare[6, 4].SetTmpIJ(6, 4);
    }

    public void SpawnSquareLevel()
    {
        float deltaY;
        float deltaX;
        deltaX = 0.83f;
        deltaY = 0.83f;
        Vector3 pos;
        pos = new Vector3(posXStart1, posYStart1, 0f);
        // BLUE
        matrixSquare[0, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 0].OriPos = pos;
        Color myColor = new Color(0f / 255, 255f / 255, 204f / 255);
        matrixSquare[0, 0].SetColor(myColor);
        matrixSquare[0, 0].SetIJ(0, 0);
        
        
        pos = new Vector3(posXStart1, posYStart1 - deltaY, 0f);
        matrixSquare[1, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 0].OriPos = pos;
        myColor = new Color(0f / 255, 255f / 255, 255f / 255);
        matrixSquare[1, 0].SetColor(myColor);
        matrixSquare[1, 0].SetIJ(1, 0);
        matrixSquare[1, 0].SetTmpIJ(1, 0);
        
        pos = new Vector3(posXStart1, posYStart1 - 2f * deltaY, 0f);
        matrixSquare[2, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 0].OriPos = pos;
        myColor = new Color(51f / 255, 204f / 255, 255f / 255);
        matrixSquare[2, 0].SetColor(myColor);
        matrixSquare[2, 0].SetIJ(2, 0);
        matrixSquare[2, 0].SetTmpIJ(2, 0);

        pos = new Vector3(posXStart1, posYStart1 - 3f * deltaY, 0f);
        matrixSquare[3, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 0].OriPos = pos;
        myColor = new Color(51f / 255, 153f / 255, 255f / 255);
        matrixSquare[3, 0].SetColor(myColor);
        matrixSquare[3, 0].SetIJ(3, 0);
        matrixSquare[3, 0].SetTmpIJ(3, 0);
        
        

        // PURPLE


        pos = new Vector3(posXStart1 + deltaX, posYStart1, 0f);
        matrixSquare[0, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 1].OriPos = pos;
        myColor = new Color(204f / 255, 153f / 255, 255f / 255);
        matrixSquare[0, 1].SetColor(myColor);
        matrixSquare[0, 1].SetIJ(0, 1);
        matrixSquare[0, 1].SetTmpIJ(0, 1);
        
        pos = new Vector3(posXStart1 + deltaX, posYStart1 - deltaY, 0f);
        matrixSquare[1, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 1].OriPos = pos;
        myColor = new Color(204f / 255, 102f / 255, 255f / 255);
        matrixSquare[1, 1].SetColor(myColor);
        matrixSquare[1, 1].SetIJ(1, 1);
        matrixSquare[1, 1].SetTmpIJ(1, 1);

        pos = new Vector3(posXStart1 + deltaX, posYStart1 - deltaY - deltaY, 0f);
        matrixSquare[2, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 1].OriPos = pos;
        myColor = new Color(204f / 255, 51f / 255, 255f / 255);
        matrixSquare[2, 1].SetColor(myColor);
        matrixSquare[2, 1].SetIJ(2, 1);
        matrixSquare[2, 1].SetTmpIJ(2, 1);

        pos = new Vector3(posXStart1 + deltaX, posYStart1 - 3f * deltaY, 0f);
        matrixSquare[3, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 1].OriPos = pos;
        myColor = new Color(153f / 255, 0f / 255, 204f / 255);
        matrixSquare[3, 1].SetColor(myColor);
        matrixSquare[3, 1].SetIJ(3, 1);
        matrixSquare[3, 1].SetTmpIJ(3, 1);
       
        
        // YELLOW
        pos = new Vector3(posXStart1 + 2f * deltaX, posYStart1, 0f);
        matrixSquare[0, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 2].OriPos = pos;
        myColor = new Color(255f / 255, 204f / 255, 0f / 255);
        matrixSquare[0, 2].SetColor(myColor);
        matrixSquare[0, 2].SetIJ(0, 2);
        matrixSquare[0, 2].SetTmpIJ(0, 2);

        pos = new Vector3(posXStart1 + 2f * deltaX, posYStart1 - deltaY, 0f);
        matrixSquare[1, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 2].OriPos = pos;
        myColor = new Color(255f / 255, 153f / 255, 51f / 255);
        matrixSquare[1, 2].SetColor(myColor);
        matrixSquare[1, 2].SetIJ(1, 2);
        matrixSquare[1, 2].SetTmpIJ(1, 2);

        pos = new Vector3(posXStart1 + 2f * deltaX, posYStart1 - 2f * deltaY, 0f);
        matrixSquare[2, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 2].OriPos = pos;
        myColor = new Color(255f / 255, 102f / 255, 0f / 255);
        matrixSquare[2, 2].SetColor(myColor);
        matrixSquare[2, 2].SetIJ(2, 2);
        matrixSquare[2, 2].SetTmpIJ(2, 2);

        pos = new Vector3(posXStart1 + 2f * deltaX, posYStart1 - 3f * deltaY, 0f);
        matrixSquare[3, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 2].OriPos = pos;
        myColor = new Color(255f / 255, 80f / 255, 80f / 255);
        matrixSquare[3, 2].SetColor(myColor);
        matrixSquare[3, 2].SetIJ(3, 2);
        matrixSquare[3, 2].SetTmpIJ(3, 2);

        
        
      
       // Red
       pos = new Vector3(posXStart1 + 3f * deltaX, posYStart1, 0f);
       matrixSquare[0, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
       matrixSquare[0, 3].OriPos = pos;
       myColor = new Color(255f / 255, 51f / 255, 0f / 255);
       matrixSquare[0, 3].SetColor(myColor);
       matrixSquare[0, 3].SetIJ(0, 3);
       matrixSquare[0, 3].SetTmpIJ(0, 3);

       pos = new Vector3(posXStart1 + 3f * deltaX, posYStart1 - deltaY, 0f);
       matrixSquare[1, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
       matrixSquare[1, 3].OriPos = pos;
       myColor = new Color(204f / 255, 0f / 255, 0f / 255);
       matrixSquare[1, 3].SetColor(myColor);
       matrixSquare[1, 3].SetIJ(1, 3);
       matrixSquare[1, 3].SetTmpIJ(1, 3);

       pos = new Vector3(posXStart1 + 3f * deltaX, posYStart1 - 2f * deltaY, 0f);
       matrixSquare[2, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
       matrixSquare[2, 3].OriPos = pos;
       myColor = new Color(153f / 255, 0f / 255, 0f / 255);
       matrixSquare[2, 3].SetColor(myColor);
       matrixSquare[2, 3].SetIJ(2, 3);
       matrixSquare[2, 3].SetTmpIJ(2, 3);

       pos = new Vector3(posXStart1 + 3f * deltaX, posYStart1 - 3f * deltaY, 0f);
       matrixSquare[3, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
       matrixSquare[3, 3].OriPos = pos;
       myColor = new Color(102f / 255, 0f / 255, 0f / 255);
       matrixSquare[3, 3].SetColor(myColor);
       matrixSquare[3, 3].SetIJ(3, 3);
       matrixSquare[3, 3].SetTmpIJ(3, 3);
        
    }

    public void SpawnSquareLevel11()
    {
        float deltaY;
        float deltaX;
        deltaX = 0.83f;
        deltaY = 0.83f;
        Vector3 pos;
        pos = new Vector3(posXStart2, posYStart2, 0f);
        // BLUE
        matrixSquare[0, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 0].OriPos = pos;
        Color myColor = new Color(0f / 255, 255f / 255, 204f / 255);
        matrixSquare[0, 0].SetColor(myColor);
        matrixSquare[0, 0].SetIJ(0, 0);


        pos = new Vector3(posXStart2 ,posYStart2 - deltaY, 0f);
        matrixSquare[1, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 0].OriPos = pos;
        myColor = new Color(0f / 255, 255f / 255, 255f / 255);
        matrixSquare[1, 0].SetColor(myColor);
        matrixSquare[1, 0].SetIJ(1, 0);
        matrixSquare[1, 0].SetTmpIJ(1, 0);

        pos = new Vector3(posXStart2, posYStart2 - 2f * deltaY, 0f);
        matrixSquare[2, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 0].OriPos = pos;
        myColor = new Color(51f / 255, 204f / 255, 255f / 255);
        matrixSquare[2, 0].SetColor(myColor);
        matrixSquare[2, 0].SetIJ(2, 0);
        matrixSquare[2, 0].SetTmpIJ(2, 0);

        pos = new Vector3(posXStart2, posYStart2 - 3f * deltaY, 0f);
        matrixSquare[3, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 0].OriPos = pos;
        myColor = new Color(51f / 255, 153f / 255, 255f / 255);
        matrixSquare[3, 0].SetColor(myColor);
        matrixSquare[3, 0].SetIJ(3, 0);
        matrixSquare[3, 0].SetTmpIJ(3, 0);

        pos = new Vector3(posXStart2, posYStart2 - 4f * deltaY, 0f);
        matrixSquare[4, 0] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 0].OriPos = pos;
        myColor = new Color(0f / 255, 0f / 255, 255f / 255);
        matrixSquare[4, 0].SetColor(myColor);
        matrixSquare[4, 0].SetIJ(3, 0);
        matrixSquare[4, 0].SetTmpIJ(3, 0);

        // PURPLE


        pos = new Vector3(posXStart2 + deltaX, posYStart2, 0f);
        matrixSquare[0, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 1].OriPos = pos;
        myColor = new Color(204f / 255, 153f / 255, 255f / 255);
        matrixSquare[0, 1].SetColor(myColor);
        matrixSquare[0, 1].SetIJ(0, 1);
        matrixSquare[0, 1].SetTmpIJ(0, 1);

        pos = new Vector3(posXStart2 + deltaX, posYStart2 - deltaY, 0f);
        matrixSquare[1, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 1].OriPos = pos;
        myColor = new Color(204f / 255, 102f / 255, 255f / 255);
        matrixSquare[1, 1].SetColor(myColor);
        matrixSquare[1, 1].SetIJ(1, 1);
        matrixSquare[1, 1].SetTmpIJ(1, 1);

        pos = new Vector3(posXStart2 + deltaX, posYStart2 - deltaY - deltaY, 0f);
        matrixSquare[2, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 1].OriPos = pos;
        myColor = new Color(204f / 255, 51f / 255, 255f / 255);
        matrixSquare[2, 1].SetColor(myColor);
        matrixSquare[2, 1].SetIJ(2, 1);
        matrixSquare[2, 1].SetTmpIJ(2, 1);

        pos = new Vector3(posXStart2 + deltaX, posYStart2 - 3f * deltaY, 0f);
        matrixSquare[3, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 1].OriPos = pos;
        myColor = new Color(153f / 255, 0f / 255, 204f / 255);
        matrixSquare[3, 1].SetColor(myColor);
        matrixSquare[3, 1].SetIJ(3, 1);
        matrixSquare[3, 1].SetTmpIJ(3, 1);

        pos = new Vector3(posXStart2 + deltaX, posYStart2 - 4f * deltaY, 0f);
        matrixSquare[4, 1] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 1].OriPos = pos;
        myColor = new Color(102f / 255, 0f / 255, 102f / 255);
        matrixSquare[4, 1].SetColor(myColor);
        matrixSquare[4, 1].SetIJ(3, 1);
        matrixSquare[4, 1].SetTmpIJ(3, 1);


        // YELLOW
        pos = new Vector3(posXStart2 + 2f * deltaX, posYStart2, 0f);
        matrixSquare[0, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 2].OriPos = pos;
        myColor = new Color(255f / 255, 204f / 255, 0f / 255);
        matrixSquare[0, 2].SetColor(myColor);
        matrixSquare[0, 2].SetIJ(0, 2);
        matrixSquare[0, 2].SetTmpIJ(0, 2);

        pos = new Vector3(posXStart2 + 2f * deltaX, posYStart2 - deltaY, 0f);
        matrixSquare[1, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 2].OriPos = pos;
        myColor = new Color(255f / 255, 153f / 255, 51f / 255);
        matrixSquare[1, 2].SetColor(myColor);
        matrixSquare[1, 2].SetIJ(1, 2);
        matrixSquare[1, 2].SetTmpIJ(1, 2);

        pos = new Vector3(posXStart2 + 2f * deltaX, posYStart2 - 2f * deltaY, 0f);
        matrixSquare[2, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 2].OriPos = pos;
        myColor = new Color(255f / 255, 102f / 255, 0f / 255);
        matrixSquare[2, 2].SetColor(myColor);
        matrixSquare[2, 2].SetIJ(2, 2);
        matrixSquare[2, 2].SetTmpIJ(2, 2);

        pos = new Vector3(posXStart2 + 2f * deltaX, posYStart2 - 3f * deltaY, 0f);
        matrixSquare[3, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 2].OriPos = pos;
        myColor = new Color(255f / 255, 80f / 255, 80f / 255);
        matrixSquare[3, 2].SetColor(myColor);
        matrixSquare[3, 2].SetIJ(3, 2);
        matrixSquare[3, 2].SetTmpIJ(3, 2);

        pos = new Vector3(posXStart2 + 2f * deltaX, posYStart2 - 4f * deltaY, 0f);
        matrixSquare[4, 2] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 2].OriPos = pos;
        myColor = new Color(204f / 255, 0f / 255, 0f / 255);
        matrixSquare[4, 2].SetColor(myColor);
        matrixSquare[4, 2].SetIJ(3, 2);
        matrixSquare[4, 2].SetTmpIJ(3, 2);


        // Red
        pos = new Vector3(posXStart2 + 3f * deltaX, posYStart2, 0f);
        matrixSquare[0, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[0, 3].OriPos = pos;
        myColor = new Color(255f / 255, 51f / 255, 0f / 255);
        matrixSquare[0, 3].SetColor(myColor);
        matrixSquare[0, 3].SetIJ(0, 3);
        matrixSquare[0, 3].SetTmpIJ(0, 3);

        pos = new Vector3(posXStart2 + 3f * deltaX, posYStart2 - deltaY, 0f);
        matrixSquare[1, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[1, 3].OriPos = pos;
        myColor = new Color(204f / 255, 0f / 255, 0f / 255);
        matrixSquare[1, 3].SetColor(myColor);
        matrixSquare[1, 3].SetIJ(1, 3);
        matrixSquare[1, 3].SetTmpIJ(1, 3);

        pos = new Vector3(posXStart2 + 3f * deltaX, posYStart2 - 2f * deltaY, 0f);
        matrixSquare[2, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[2, 3].OriPos = pos;
        myColor = new Color(153f / 255, 0f / 255, 0f / 255);
        matrixSquare[2, 3].SetColor(myColor);
        matrixSquare[2, 3].SetIJ(2, 3);
        matrixSquare[2, 3].SetTmpIJ(2, 3);

        pos = new Vector3(posXStart2 + 3f * deltaX, posYStart2 - 3f * deltaY, 0f);
        matrixSquare[3, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[3, 3].OriPos = pos;
        myColor = new Color(102f / 255, 0f / 255, 0f / 255);
        matrixSquare[3, 3].SetColor(myColor);
        matrixSquare[3, 3].SetIJ(3, 3);
        matrixSquare[3, 3].SetTmpIJ(3, 3);

        pos = new Vector3(posXStart2 + 3f * deltaX, posYStart2 - 4f * deltaY, 0f);
        matrixSquare[4, 3] = Instantiate(squarePrefab, pos, Quaternion.identity);
        matrixSquare[4, 3].OriPos = pos;
        myColor = new Color(60f / 255, 0f / 255, 0f / 255);
        matrixSquare[4, 3].SetColor(myColor);
        matrixSquare[4, 3].SetIJ(3, 3);
        matrixSquare[4, 3].SetTmpIJ(3, 3);

    }

    public Vector3 CalculateDir(Vector2Int pos1, Vector2Int pos2)
    {
        Vector3 dir = Vector3.zero;
        dir.x = matrixSquare[pos2.x, pos2.y].transform.position.x - matrixSquare[pos1.x, pos1.y].transform.position.x;
        dir.y = matrixSquare[pos2.x, pos2.y].transform.position.y - matrixSquare[pos1.x, pos1.y].transform.position.y;
        return dir;

    }



    public bool CheckWin()
    {
        for ( int i = 0; i < 7; i++ )
        {
            for ( int j = 0; j < 5; j++)
            {
                if ( matrixSquare[i, j] != null)
                    if ( matrixSquare[i, j].GetTmpIJ().x != matrixSquare[i, j].I || matrixSquare[i, j].GetTmpIJ().y != matrixSquare[i, j].J)
                    {
                        return false;
                    }
            }
        }
        return true;
    }

    public Vector3 PosOfSquare( ChangeColor changeColor )
    {
        return changeColor.transform.position;
    }
    public bool HadChoice
    {
        get { return hadChoice; }
        set { hadChoice = value; }
    }

    public Vector2Int Matr1
    {
        get { return matr1; }
        set { matr1 = value; }
    }
    public Vector2Int Matr2
    {
        get { return matr2; }
        set { matr2 = value; }
    }
    public void SetPosMatr12()
    {
        matr1 = new Vector2Int(-1, -1);
        matr2 = new Vector2Int(-1, -1);
    }

    public bool CheckIfSquareMove()
    {
        if ( matr1.x == -1 || matr1.y == -1 || matr2.x == -1 || matr2.y == -1)
            return false;
        return true;
    }

}

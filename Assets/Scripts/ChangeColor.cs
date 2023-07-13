using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject sprite;
    private SpriteRenderer _renderer;
    private int i;
    private int j;
    private int tmpI;
    private int tmpJ;
    private bool isChoosed = false;
    private bool allowMove;
    private Vector3 targetPos;
    private Vector3 oriPos;
    private Vector3 dirMove;
    private bool isBarier;
    private bool isFaded = false;
    private float time = 0f;
    private void Start()
    {
        
    }

    private void Update()
    {
        if ( allowMove)
        {
            transform.Translate(dirMove*2.5f*Time.deltaTime);
            if (oriPos.x < targetPos.x)
            {
                if (transform.position.x > targetPos.x)
                {
                    Renew();
                }
            }
            else if (oriPos.x > targetPos.x)
            {
                if (transform.position.x < targetPos.x)
                {
                    Renew();
                }
            }
            else if (oriPos.y < targetPos.y)
            {
                if (transform.position.y > targetPos.y)
                {
                    Renew();
                }
            }
            else if (oriPos.y > targetPos.y)
            {
                if (transform.position.y < targetPos.y)
                {
                    Renew();
                }
            }
        }

        if ( isFaded)
        {
            time += Time.deltaTime;
            if ( time >= 0.5f && time <= 2.5f )
            {
                Color tmp = sprite.GetComponent<SpriteRenderer>().color;
                tmp = new Color(tmp.r,tmp.g,tmp.b,tmp.a-0.00265f);
                sprite.GetComponent<SpriteRenderer>().color = tmp;
                Debug.Log("Square Faded");
            }
            else if ( time > 2.5f )
            {
                Color tmp = sprite.GetComponent<SpriteRenderer>().color;
                tmp = new Color(tmp.r, tmp.g, tmp.b, 0.05f);
                sprite.GetComponent<SpriteRenderer>().color = tmp;
                time = 0f;
                isFaded = false;
            }
        }
    }


    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        if ( isChoosed && !isBarier )
        {
            _animator.SetTrigger("isFreeze");
            isChoosed = false;
            Matrix.instance.Matr1 = new Vector2Int(-1, -1);
            Matrix.instance.HadChoice = false;
            Debug.Log(Matrix.instance.Matr1);
        }
        else if ( isBarier )
        {
            _animator.SetTrigger("isRotate");
        }
        else if (!isChoosed && !Matrix.instance.HadChoice)
        {
            _animator.SetTrigger("isZoom");
            isChoosed = true;
            Matrix.instance.Matr1 = new Vector2Int(i, j);
            Matrix.instance.HadChoice = true;
            Debug.Log("mart1" + Matrix.instance.Matr1);
        }

        else if ( !isChoosed && Matrix.instance.HadChoice )
        {
            Matrix.instance.Matr2 = new Vector2Int(i, j);
            Matrix.instance.HadChoice = false;
            Debug.Log("mart2" + Matrix.instance.Matr2);
        }

        
    }

    public void Renew()
    {
        
        transform.position = targetPos;
        oriPos = transform.position;
        isChoosed = false;
        allowMove = false;
    }
    public void SetConditionToMove()
    {
        isChoosed = false;
        _animator.SetTrigger("isFreeze");
    }

    public void SetColor( Color color )
    {
        sprite.GetComponent<SpriteRenderer>().color = color;
    }

    public void SetIJ(int _i, int _j )
    {
        i = _i;
        j = _j;
    }
    public void SetTmpIJ(int _i, int _j )
    {
        tmpI = _i;
        tmpJ = _j;
    }
    public int I
    {
        get { return i; }
        set { i = value; }
    }
    public int J
    {
        get { return j; }
        set { j = value; }
    }
    public bool AllowMove
    {
        get { return allowMove; }
        set { allowMove = value; }
    }
    public Vector3 DirMove
    {
        get { return dirMove; }
        set { dirMove = value; }
    }
    public Vector3 TargetPos
    {
        get { return targetPos; }
        set { targetPos = value; }
    }
    public Vector3 OriPos
    {
        get { return oriPos; }
        set { oriPos = value; }
    }
    public bool IsBarier
    {
        get { return isBarier; }
        set { isBarier = value; }
    }

    public Vector2Int GetTmpIJ()
    {
        return new Vector2Int(tmpI,tmpJ);
    }
    
    public bool IsFaded
    {
        get { return isFaded; }
        set { isFaded = value; }
    }

}

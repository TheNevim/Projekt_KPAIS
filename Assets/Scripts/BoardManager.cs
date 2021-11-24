using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private FigureSlot[] _boardRow0;
    [SerializeField] private FigureSlot[] _boardRow1;
    [SerializeField] private FigureSlot[] _boardRow2;
    [SerializeField] private FigureSlot[] _boardRow3;
    [SerializeField] private FigureSlot[] _boardRow4;
    [SerializeField] private FigureSlot[] _boardRow5;
    [SerializeField] private FigureSlot[] _boardRow6;
    [SerializeField] private FigureSlot[] _boardRow7;

    public FigureSlot[][] board = new FigureSlot[8][];
    
    public FigureSlot[][] Board => board;

    #region Singleton

    public static BoardManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
    }

    #endregion

    private void Start()
    {
        FillBoard(_boardRow0,0);
        FillBoard(_boardRow1,1);
        FillBoard(_boardRow2,2);
        FillBoard(_boardRow3,3);
        FillBoard(_boardRow4,4);
        FillBoard(_boardRow5,5);
        FillBoard(_boardRow6,6);
        FillBoard(_boardRow7,7);
    }

    void FillBoard(FigureSlot[] row, int rowNumber)
    {
        board[rowNumber] = new FigureSlot[8];
        Array.Copy(row, board[rowNumber], 8);
    }
    
    public bool IsSlotOccupied(int xPosition, int zPosition, FigureColor color)
    {
        if (board[zPosition][xPosition].FigureInSlot != null && board[zPosition][xPosition].FigureInSlot.FigureColor != color)
        {
            return true;
        }
        return false;
    }
    
    public bool IsSlotOccupied(int xPosition, int zPosition)
    {
        if (board[zPosition][xPosition].FigureInSlot != null)
        {
            return true;
        }
        return false;
    }

    public void SetSlotColor(int xPosition, int zPosition)
    {
        if (IsSlotOccupied(xPosition, zPosition))
        {
            board[zPosition][xPosition].SetColor(SlotColor.Red);
        }
        else
        {
            board[zPosition][xPosition].SetColor(SlotColor.Green);
        }
    }
    
    
    public void SetSlotColor(int xPosition, int zPosition, SlotColor color)
    {
        board[zPosition][xPosition].SetColor(SlotColor.Default);

    }
    

    public delegate void SwapTurns();

    public SwapTurns swapTurns;
    
    
    public void  PlaceFigure(Figure figure, int xPosition, int zPosition)
    {
        
        if (board[zPosition][xPosition].FigureInSlot == null && board[zPosition][xPosition].IsSlotGreen())
        {
           board[Mathf.RoundToInt(figure.gameObject.transform.position.z)][Mathf.RoundToInt(figure.gameObject.transform.position.x)].DeSetFigureInSlot();
               
            if (figure.FigureType == FigureType.Pawn && figure.PawnPromotion(zPosition))
            {
                StartCoroutine(Promote(figure,xPosition, zPosition));
            }
            else
            {
                board[zPosition][xPosition].SetFigureInSlot(figure);
                figure.gameObject.transform.position = new Vector3(xPosition,0,zPosition);
                figure.HideMove();
                figure.hasMoved = true;

                if (figure.FigureType == FigureType.King )
                {
                    PlayerManager.Instance.SetKingNewPosition(xPosition,zPosition, figure.FigureColor);
                }
                swapTurns?.Invoke();
            }
            
        }else
        {
            if (board[zPosition][xPosition].FigureInSlot != null && board[zPosition][xPosition].IsSlotRed())
            {
                board[Mathf.RoundToInt(figure.gameObject.transform.position.z)][Mathf.RoundToInt(figure.gameObject.transform.position.x)].DeSetFigureInSlot();

                Figure dumpFigure = board[zPosition][xPosition].FigureInSlot;
                PlayerManager.Instance.RemoveEnemyFigure(dumpFigure);
                
                board[zPosition][xPosition].DeSetFigureInSlot();
                dumpFigure.gameObject.SetActive(false);
                
                
                if (figure.FigureType == FigureType.Pawn && figure.PawnPromotion(zPosition))
                {
                    StartCoroutine(Promote(figure,xPosition, zPosition));
                }
                else
                {
                    board[zPosition][xPosition].SetFigureInSlot(figure);
                    figure.gameObject.transform.position = new Vector3(xPosition,0,zPosition);
                    figure.HideMove();
                    figure.hasMoved = true;

                    if (figure.FigureType == FigureType.King )
                    {
                        PlayerManager.Instance.SetKingNewPosition(xPosition,zPosition, figure.FigureColor);
                    }
                    swapTurns?.Invoke();
                }
            }
        }

    }
    
 
    IEnumerator Promote(Figure figure, int xPosition, int zPosition) {
        IUManager.Instance.ActivatePromotionPanel();
        
        while(GameManager.Instance.FocusedFigure.promteToFigure == FigureType.Pawn)       
            yield return new WaitForSeconds(0.2f);
        
        IUManager.Instance.DeactivatePromotionPanel();
        figure.HideMove();

        GameObject newFigureObject = figure.GetPromotedFigure(figure.promteToFigure);
        Figure newFigureScript = newFigureObject.GetComponent<Figure>();
        
        board[zPosition][xPosition].SetFigureInSlot(newFigureScript);
        newFigureObject.transform.position = new Vector3(xPosition,1,zPosition);
        
        PlayerManager.Instance.RemoveMyFigure(figure);
        PlayerManager.Instance.AddFigure(newFigureScript);
        
        figure.gameObject.SetActive(false);
        
        print(GameManager.Instance.FocusedFigure.promteToFigure);
        swapTurns?.Invoke();
    }

    
   
    
}

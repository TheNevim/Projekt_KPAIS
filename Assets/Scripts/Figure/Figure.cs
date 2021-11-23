using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FigureColor{White,Black,None}
public enum FigureType{Pawn, Bishop, Knight, Rook, King, Queen}

public class Figure : MonoBehaviour
{
    public bool hasMoved = false;
    //public bool isKing;
    public bool canMove;
    public bool canJump = true;
    public bool canDunk = false;

    [SerializeField] private float jumpPower;
    [SerializeField] private float dunkPower;
    [SerializeField] private float speed;
    
    [SerializeField] private FigureColor _figureColor;
    [SerializeField] private FigureType figureType;
    public FigureType promteToFigure;

    protected List<Vector2Int> slotPositionMoves = new List<Vector2Int>();
    
    
    public FigureColor FigureColor
    {
        get => _figureColor;
        private set{}
    }

    public FigureType FigureType
    {
        get => figureType;
    }
    
    #region BoardControlAndMovement

     protected SlotColor CanMoveToPositionB(int xNewPosition, int zNewPosition)
    {
        if (!BoardManager.Instance.IsSlotOccupied(xNewPosition,zNewPosition))
        {
            return SlotColor.Green;
        }
        else
        {
            if (BoardManager.Instance.IsSlotOccupied(xNewPosition,zNewPosition,FigureColor))
            {
                return SlotColor.Red;
            }

            return SlotColor.Default;
        }
    }

    
    public virtual void ShowMove(){}
    public virtual void ShowSimulatedMove(){}

    public virtual bool PawnPromotion(int zPosition) { return false; }

    public virtual int NumberOfPossibleMoves() { return 0;}
    
    public virtual GameObject GetPromotedFigure(FigureType type) { return null;}

    protected void ColorAvailableMoves()
    {
        
        for (int i = 0; i < slotPositionMoves.Count ; i++)
        {
            BoardManager.Instance.SetSlotColor(slotPositionMoves[i].x,slotPositionMoves[i].y);
        }
    }

    public void HideMove()
    {
        for (int i = 0; i < slotPositionMoves.Count ; i++)
        {
            BoardManager.Instance.SetSlotColor(slotPositionMoves[i].x,slotPositionMoves[i].y, SlotColor.Default);
        }
        slotPositionMoves.Clear();
    }

    public void ClearMoves()
    {
        slotPositionMoves.Clear();
    }

    private Figure currentFigure;
    private Figure tmpFigure;
    private Vector2Int KingPosition = new Vector2Int();
    private bool isThreated = false;
    
    
    
    public bool SimulateTurn(int xCurrentPos, int zCurrentPos, int xNewPos, int zNewPos)
    {
        isThreated = false;
        List<Vector2Int> thrMove = new List<Vector2Int>();
       
        //Simulate figure move (Mozem prepisat inu, moze byt problem)
        currentFigure = BoardManager.Instance.board[zCurrentPos][xCurrentPos].FigureInSlot;
        tmpFigure = null;
        
        if (currentFigure.figureType == FigureType.King && currentFigure.FigureColor == FigureColor.White)
        {
            KingPosition = PlayerManager.Instance.WhiteKingPosition;
            PlayerManager.Instance.SetKingNewPosition(xNewPos,zNewPos,currentFigure.FigureColor);
        }
        if (currentFigure.figureType == FigureType.King  && currentFigure.FigureColor == FigureColor.Black)
        {
            KingPosition = PlayerManager.Instance.BlackKingPosition;
            PlayerManager.Instance.SetKingNewPosition(xNewPos,zNewPos,currentFigure.FigureColor);
        }
        
        if (BoardManager.Instance.IsSlotOccupied(xNewPos, zNewPos))
        {
            tmpFigure = BoardManager.Instance.board[zNewPos][xNewPos].FigureInSlot;
        }
        else
        {
            tmpFigure = null;
        }
        
       BoardManager.Instance.board[zNewPos][xNewPos]
           .SetFigureInSlot(BoardManager.Instance.board[zCurrentPos][xCurrentPos].FigureInSlot);
       BoardManager.Instance.board[zCurrentPos][xCurrentPos].DeSetFigureInSlot();
       
       if (PlayerManager.Instance.PlayerTurn == FigureColor.White)
       {
           foreach (Figure figure in PlayerManager.Instance.BlackFigures)
           {
               if (figure == tmpFigure)
               {
                   continue;
               }
                figure.ShowSimulatedMove();

               /* foreach (Vector2Int position in figure.slotPositionMoves)
                {
                    thrMove.Add(position);
                }*/
                
                if (figure.slotPositionMoves.Contains(PlayerManager.Instance.WhiteKingPosition))
                {
                    isThreated = true;
                    break;
                }
                
                figure.slotPositionMoves.Clear();
           }
           BoardManager.Instance.board[zCurrentPos][xCurrentPos]
               .SetFigureInSlot(BoardManager.Instance.board[zNewPos][xNewPos].FigureInSlot);
           BoardManager.Instance.board[zNewPos][xNewPos].DeSetFigureInSlot();
           if (tmpFigure != null)
           {
               BoardManager.Instance.board[zNewPos][xNewPos]
                   .SetFigureInSlot(tmpFigure);
           }
           
           if (isThreated)
           {
               if (currentFigure.figureType == FigureType.King )
               {
                   PlayerManager.Instance.SetKingNewPosition(KingPosition.x,KingPosition.y,currentFigure.FigureColor);
               }
               return true;
           }
           if (currentFigure.figureType == FigureType.King )
           {
               PlayerManager.Instance.SetKingNewPosition(KingPosition.x,KingPosition.y,currentFigure.FigureColor); 
           }
           
       }
       else
       {
           foreach (Figure figure in PlayerManager.Instance.WhiteFigures)
           {
               if (figure == tmpFigure)
               {
                   continue;
               }
               figure.ShowSimulatedMove();
               if (figure.slotPositionMoves.Contains(PlayerManager.Instance.BlackKingPosition))
               {
                   isThreated = true;
                   break;
               }
               
               figure.slotPositionMoves.Clear();
           }
           BoardManager.Instance.board[zCurrentPos][xCurrentPos]
               .SetFigureInSlot(BoardManager.Instance.board[zNewPos][xNewPos].FigureInSlot);
           BoardManager.Instance.board[zNewPos][xNewPos].DeSetFigureInSlot();
           if (tmpFigure != null)
           {
               BoardManager.Instance.board[zNewPos][xNewPos]
                   .SetFigureInSlot(tmpFigure);
           }
           
           if (isThreated)
           {
               if (currentFigure.figureType == FigureType.King )
               {
                   PlayerManager.Instance.SetKingNewPosition(KingPosition.x,KingPosition.y,currentFigure.FigureColor); 
               }
               return true;
           }
           if (currentFigure.figureType == FigureType.King )
           {
               PlayerManager.Instance.SetKingNewPosition(KingPosition.x,KingPosition.y,currentFigure.FigureColor); 
           }
       }
       
       return false;
    }
    

    #endregion
    
    
    
    

}

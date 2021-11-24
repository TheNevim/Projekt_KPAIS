using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pawn : Figure
{
    [SerializeField] int startMovement;
    [SerializeField] int basicMovement;
    private SlotColor color;

    [Header("Do not touch")]
    [SerializeField] int promotionPosition;
    
    [Header("Promotion Figures")]
    [SerializeField] GameObject bishop;
    [SerializeField] GameObject knight;
    [SerializeField] GameObject queen;
    [SerializeField] GameObject rook;

    private int possibleMoves;
    private int xNewPosition;
    private int zNewPosition;
    
    int BoardAttack(int xPosition, int zPosition, bool isSimulated)
    {
         possibleMoves = 0;
        
         xNewPosition = xPosition + 1;
         zNewPosition = zPosition + basicMovement;
         if (xNewPosition < 8 && zNewPosition >= 0 && zNewPosition <8)
         {
             color = CanMoveToPositionB(xNewPosition, zNewPosition);
             if (color == SlotColor.Red)
             {
                 if (isSimulated)
                 {
                     slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                 }else
                 {
                     if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                     {
                         possibleMoves++;
                         slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                     }  
                 }
             }
         }
         
         xNewPosition = xPosition -1;
         zNewPosition = zPosition + basicMovement;
         if (xNewPosition >= 0 && zNewPosition >= 0 && zNewPosition <8)
         {
             color = CanMoveToPositionB(xNewPosition, zNewPosition);
             if (color == SlotColor.Red)
             {
                 if (isSimulated)
                 {
                     slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                 }else
                 {
                     if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                     {
                         possibleMoves++;
                         slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                     }  
                 }
             }
         }

         return possibleMoves;
    }
    
    
    int Movement(int xPosition, int zPosition, bool isSimulated)
    {
        possibleMoves = 0;
        xNewPosition = xPosition;
        zNewPosition = zPosition + basicMovement;
        
        if (zNewPosition >= 0 && zNewPosition < 8)
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default && color != SlotColor.Red)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                    }  
                }

                if (!hasMoved && zPosition + startMovement >= 0 && zPosition + startMovement < 8)
                {
                    xNewPosition = xPosition;
                    zNewPosition = zPosition + startMovement;
                    color = CanMoveToPositionB(xNewPosition, zNewPosition);
                    if (color != SlotColor.Default && color != SlotColor.Red)
                    {
                        if (isSimulated)
                        {
                             
                            slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                        }else
                        {
                            if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                            {
                                possibleMoves++;
                                slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                            }  
                        }
                    }
                }
                 
            }
        }
        return possibleMoves;
    }


    public override bool PawnPromotion(int zPosition)
    {
        if (zPosition == promotionPosition)
        {
            return true;
        }
        return false;
    }

    public override GameObject GetPromotedFigure(FigureType type)
    {
        switch (type)
        {
          case  FigureType.Bishop:
              return Instantiate(bishop, bishop.transform.position, bishop.transform.rotation);
          case FigureType.Knight:
              return Instantiate(knight, knight.transform.position, knight.transform.rotation);
          case FigureType.Queen:
              return Instantiate(queen, queen.transform.position, queen.transform.rotation);
          case FigureType.Rook:
             return Instantiate(rook, rook.transform.position, rook.transform.rotation);
        }

        return null;
    }


    public override void ShowMove()
    {
        var position = gameObject.transform.position;
        int xPosition = (int)Math.Round(position.x);
        int zPosition = (int)Math.Round(position.z);
        
        BoardAttack(xPosition, zPosition, false);
        Movement(xPosition, zPosition, false);
        ColorAvailableMoves();
    }
    
    
    public override void ShowSimulatedMove()
    {
        var position = gameObject.transform.position;
        int xPosition = (int)Math.Round(position.x);
        int zPosition = (int)Math.Round(position.z);
        
        BoardAttack(xPosition,zPosition,true);
    }
    
    public override int NumberOfPossibleMoves()
    {
        var position = gameObject.transform.position;
        int xPosition = (int)Math.Round(position.x);
        int zPosition = (int)Math.Round(position.z);
        
        return BoardAttack(xPosition,zPosition,false) + Movement(xPosition, zPosition, false);;
    }
}


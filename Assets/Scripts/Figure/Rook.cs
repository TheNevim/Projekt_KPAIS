using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Figure
{
    SlotColor color;

    private int i = 0;

    private int possibleMoves;
    //All movements from black site view
    int BoardAttack(int xPosition, int zPosition, bool isSimulated)
    {
         possibleMoves = 0;
        //Move Right
        for (i = xPosition+1; i < 8; i++)
        {
            color = CanMoveToPositionB(i, zPosition);
            if (color == SlotColor.Default)
            {
                break; 
            }
                
            if (isSimulated)
            {
                slotPositionMoves.Add(new Vector2Int (i, zPosition));
                if (color == SlotColor.Red)
                {
                    break;
                }
                continue;
            }
                
            if(!SimulateTurn(xPosition,zPosition,i,zPosition))
            {
                possibleMoves++;
                slotPositionMoves.Add(new Vector2Int(i, zPosition));
            }
            
            if (color == SlotColor.Red)
            {
                break;
            }
        }
        
        //Move left
        for ( i = xPosition-1; i >= 0; i--)
        {
            color = CanMoveToPositionB(i, zPosition);
            if (color == SlotColor.Default)
            {
                break; 
            }
                
            if (isSimulated)
            {
                slotPositionMoves.Add(new Vector2Int(i, zPosition));
                if (color == SlotColor.Red)
                {
                    break;
                }
                continue;
            }
                
            if(!SimulateTurn(xPosition,zPosition,i,zPosition))
            {
                possibleMoves++;
                slotPositionMoves.Add(new Vector2Int(i, zPosition));
            }
            
            if (color == SlotColor.Red)
            {
                break;
            }
        }
        
        //Move Down
        for ( i = zPosition-1; i >= 0; i--)
        {
            color = CanMoveToPositionB(xPosition, i);
            if (color == SlotColor.Default)
            {
                break; 
            }
                
            if (isSimulated)
            {
                slotPositionMoves.Add(new Vector2Int(xPosition, i));
                if (color == SlotColor.Red)
                {
                    break;
                }
                continue;
            }
                
            if(!SimulateTurn(xPosition,zPosition,xPosition,i))
            {
                possibleMoves++;
                slotPositionMoves.Add(new Vector2Int(xPosition, i));
            }
            
            if (color == SlotColor.Red)
            {
                break;
            }
        }
        
        //Move Up
        for ( i = zPosition+1; i < 8; i++)
        {
            color = CanMoveToPositionB(xPosition, i);
            if (color == SlotColor.Default)
            {
                break; 
            }
                
            if (isSimulated)
            {
                slotPositionMoves.Add(new Vector2Int(xPosition, i));
                if (color == SlotColor.Red)
                {
                    break;
                }
                continue;
            }
                
            if(!SimulateTurn(xPosition,zPosition,xPosition,i))
            {
                possibleMoves++;
                slotPositionMoves.Add(new Vector2Int(xPosition, i));
            }
            
            if (color == SlotColor.Red)
            {
                break;
            }
        }

        return possibleMoves;
    }
    

    public override void ShowMove()
    {
        var position = gameObject.transform.position;
        int xPosition = (int)Math.Round(position.x);
        int zPosition = (int)Math.Round(position.z);
        
        BoardAttack(xPosition,zPosition, false);
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
        
        return BoardAttack(xPosition,zPosition,false);
    }
}

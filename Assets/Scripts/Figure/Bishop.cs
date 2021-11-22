using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Figure
{
    SlotColor color;
    int xNewPosition;
    int zNewPosition;
    private int possibleMoves;

    private int i = 0;
    //All movements from black site view
    private int BoardAttack(int xPosition, int zPosition, bool isSimulated)
    {
         possibleMoves = 0;
      
        //Move UP RIGHT diagonal
        for ( i = 1; i < 8; i++)
        {
            xNewPosition = xPosition + i;
            zNewPosition = zPosition + i;

            if (xNewPosition < 8 && zNewPosition < 8)
            {
                color = CanMoveToPositionB(xNewPosition, zNewPosition);
                if (color == SlotColor.Default)
                {
                    break; 
                }
                
                if (isSimulated)
                {
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                    if (color == SlotColor.Red)
                    {
                        break;
                    }
                    continue;
                }
                
                if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                {
                    possibleMoves++;
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                }
                
                if (color == SlotColor.Red)
                {
                    break;
                }
                
            }
        }
        
        //Move DOWN LEFT diagonal
        for ( i = -1; i > -8; i--)
        {
            xNewPosition = xPosition + i;
            zNewPosition = zPosition + i;
            
            
            if (xNewPosition >= 0 && zNewPosition >= 0)
            {
                color = CanMoveToPositionB(xNewPosition, zNewPosition);
                if (color == SlotColor.Default)
                {
                    break; 
                }
                
                if (isSimulated)
                {
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                    if (color == SlotColor.Red)
                    {
                        break;
                    }
                    continue;
                }
                
                if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                {
                    possibleMoves++;
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                }
                if (color == SlotColor.Red)
                {
                    break;
                }
            }
        }
        
        //Move UP LEFT diagonal
        for ( i = 1; i < 8; i++)
        {
            xNewPosition = xPosition - i;
            zNewPosition = zPosition + i;
            
            if (xNewPosition >= 0 && zNewPosition < 8)
            {
                color = CanMoveToPositionB(xNewPosition, zNewPosition);
                if (color == SlotColor.Default)
                {
                    break; 
                }
                
                if (isSimulated)
                {
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                    if (color == SlotColor.Red)
                    {
                        break;
                    }
                    continue;
                }
                
                if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                {
                    possibleMoves++;
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                }
                if (color == SlotColor.Red)
                {
                    break;
                }
            }
        }
        
        //Move DOWN RIGHT diagonal
        for (i = 1; i < 8; i++)
        {
            xNewPosition = xPosition + i;
            zNewPosition = zPosition - i;
            
            if (xNewPosition < 8 && zNewPosition >= 0)
            {
                color = CanMoveToPositionB(xNewPosition, zNewPosition);
                if (color == SlotColor.Default)
                {
                    break; 
                }
                
                if (isSimulated)
                {
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                    if (color == SlotColor.Red)
                    {
                        break;
                    }
                    continue;
                }
                
                if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                {
                    possibleMoves++;
                    slotPositionMoves.Add(new Vector2Int(xNewPosition, zNewPosition));
                }
                if (color == SlotColor.Red)
                {
                    break;
                }
            }
        }

        return possibleMoves;
    }
    
    public override void ShowMove()
    {
        var position = gameObject.transform.position;
        int xPosition = (int)Math.Round(position.x);
        int zPosition = (int)Math.Round(position.z);
        
        BoardAttack(xPosition,zPosition,false);
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

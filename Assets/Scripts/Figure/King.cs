using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Figure
{
    private SlotColor color;
    private int possibleMoves;
    private int xNewPosition;
    private int zNewPosition;
    private int BoardAttack(int xPosition, int zPosition, bool isSimulated)
    {
        possibleMoves = 0;
        xNewPosition = xPosition;
        zNewPosition  = zPosition + 1;
        //Move UP 
        if (zNewPosition < 8)
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
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
        
        xNewPosition = xPosition + 1;
        zNewPosition = zPosition + 1;
        //Move UP RIGHT 
        if (xNewPosition < 8 && zNewPosition < 8)
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
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
        
        xNewPosition = xPosition + 1;
        zNewPosition = zPosition;
        //Move RIGHT 
        if (xNewPosition < 8)
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
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
        
        xNewPosition = xPosition + 1;
        zNewPosition = zPosition - 1;
        //Move DOWN RIGHT 
        if (xNewPosition < 8 && zNewPosition >= 0)
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
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
        
        xNewPosition = xPosition;
        zNewPosition = zPosition -1;
        //Move DOWN  
        if (zNewPosition >= 0)
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
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
        
        xNewPosition = xPosition - 1;
        zNewPosition = zPosition - 1;
        //Move DOWN LEFT 
        if (zNewPosition >= 0 && xNewPosition >= 0) 
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
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
        
        xNewPosition = xPosition - 1;
        zNewPosition = zPosition ;
        //Move LEFT 
        if (xNewPosition >= 0) 
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
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
        
        xNewPosition = xPosition - 1;
        zNewPosition = zPosition + 1;
        //Move UP LEFT 
        if (xNewPosition >= 0 && zNewPosition < 8)
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
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

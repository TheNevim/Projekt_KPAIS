using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Figure
{
    
    SlotColor color;
    //All movements from black site view
    private int BoardAttack(int xPosition, int zPosition, bool isSimulated)
    {
        int possibleMoves = 0;
        int xNewPosition = xPosition + 1;
        int zNewPosition = zPosition + 2;
        
        //Move UP RIGHT diagonal
        for (int i = 1; i < 8; i++)
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
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    if (color == SlotColor.Red)
                    {
                        break;
                    }
                    continue;
                }
                
                if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                {
                    possibleMoves++;
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }
                if (color == SlotColor.Red)
                {
                    break;
                }
            }
        }
        
        //Move DOWN LEFT diagonal
        for (int i = -1; i > -8; i--)
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
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    if (color == SlotColor.Red)
                    {
                        break;
                    }
                    continue;
                }
                
                if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                {
                    possibleMoves++;
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }
                if (color == SlotColor.Red)
                {
                    break;
                }
            }
        }
        
        //Move UP LEFT diagonal
        for (int i = 1; i < 8; i++)
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
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    if (color == SlotColor.Red)
                    {
                        break;
                    }
                    continue;
                }
                
                if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                {
                    possibleMoves++;
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                } 
                if (color == SlotColor.Red)
                {
                    break;
                }
            }
        }
        
        //Move DOWN RIGHT diagonal
        for (int i = 1; i < 8; i++)
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
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    if (color == SlotColor.Red)
                    {
                        break;
                    }
                    continue;
                }
                
                if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                {
                    possibleMoves++;
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }
                
                if (color == SlotColor.Red)
                {
                    break;
                }
            }
        }
        
        //Move Right
        for (int i = xPosition+1; i < 8; i++)
        {
            color = CanMoveToPositionB(i, zPosition);
            if (color == SlotColor.Default)
            {
                break; 
            }
                
            if (isSimulated)
            {
                slotPositionMoves.Add(new BoardPosition(i, zPosition, color));
                if (color == SlotColor.Red)
                {
                    break;
                }
                continue;
            }
                
            if(!SimulateTurn(xPosition,zPosition,i,zPosition))
            {
                possibleMoves++;
                slotPositionMoves.Add(new BoardPosition(i, zPosition, color));
            }
            if (color == SlotColor.Red)
            {
                break;
            }
        }
        
        //Move left
        for (int i = xPosition-1; i >= 0; i--)
        {
            color = CanMoveToPositionB(i, zPosition);
            if (color == SlotColor.Default)
            {
                break; 
            }
                
            if (isSimulated)
            {
                slotPositionMoves.Add(new BoardPosition(i, zPosition, color));
                if (color == SlotColor.Red)
                {
                    break;
                }
                continue;
            }
                
            if(!SimulateTurn(xPosition,zPosition,i,zPosition))
            {
                possibleMoves++;
                slotPositionMoves.Add(new BoardPosition(i, zPosition, color));
            }
            
            if (color == SlotColor.Red)
            {
                break;
            }
        }
        
        //Move Down
        for (int i = zPosition-1; i >= 0; i--)
        {
            color = CanMoveToPositionB(xPosition, i);
            if (color == SlotColor.Default)
            {
                break; 
            }
                
            if (isSimulated)
            {
                slotPositionMoves.Add(new BoardPosition(xPosition, i, color));
                if (color == SlotColor.Red)
                {
                    break;
                }
                continue;
            }
                
            if(!SimulateTurn(xPosition,zPosition,xPosition,i))
            {
                possibleMoves++;
                slotPositionMoves.Add(new BoardPosition(xPosition, i, color));
            }
            
            if (color == SlotColor.Red)
            {
                break;
            }
        }
        
        //Move Up
        for (int i = zPosition+1; i < 8; i++)
        {
            color = CanMoveToPositionB(xPosition, i);
            if (color == SlotColor.Default)
            {
                break; 
            }
                
            if (isSimulated)
            {
                slotPositionMoves.Add(new BoardPosition(xPosition, i, color));
                if (color == SlotColor.Red)
                {
                    break;
                }
                continue;
            }
                
            if(!SimulateTurn(xPosition,zPosition,xPosition,i))
            {
                possibleMoves++;
                slotPositionMoves.Add(new BoardPosition(xPosition, i, color));
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

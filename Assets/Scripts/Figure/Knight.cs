using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knight : Figure
{
    
    SlotColor color;
    //All movements from black site view
    private int BoardAttack(int xPosition, int zPosition, bool isSimulated)
    {
        int possibleMoves = 0;
        //Move UP RIGHT
        int xNewPosition = xPosition + 1;
        int zNewPosition = zPosition + 2;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    }  
                }
            }
            //CanMoveToPosition(xNewPosition, zNewPosition);
                
           
        }
        
        //Move UP LEFT
        xNewPosition = xPosition - 1;
        zNewPosition = zPosition + 2;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    }  
                }
            }
        }
        
        //Move DOWN LEFT
        xNewPosition = xPosition - 1;
        zNewPosition = zPosition - 2;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    }  
                }
            }
        }
        
        //Move DOWN RIGHT
        xNewPosition = xPosition + 1;
        zNewPosition = zPosition - 2;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    }  
                }
            }
        }
        
        //Move RIGHT UP
        xNewPosition = xPosition + 2;
        zNewPosition = zPosition + 1;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    }  
                }
            }
        }
        
        //Move RIGHT DOWN
        xNewPosition = xPosition + 2;
        zNewPosition = zPosition - 1;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    }  
                }
            }
        }
        
        //Move LEFT DOWN
        xNewPosition = xPosition - 2;
        zNewPosition = zPosition - 1;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                    }  
                }
            }
        }
        
        //Move LEFT UP
        xNewPosition = xPosition - 2;
        zNewPosition = zPosition + 1;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
        {
            color = CanMoveToPositionB(xNewPosition, zNewPosition);
            if (color != SlotColor.Default)
            {
                if (isSimulated)
                {
                    slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
                }else
                {
                    if(!SimulateTurn(xPosition,zPosition,xNewPosition,zNewPosition))
                    {
                        possibleMoves++;
                        slotPositionMoves.Add(new BoardPosition(xNewPosition, zNewPosition, color));
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

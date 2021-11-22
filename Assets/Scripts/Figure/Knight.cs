using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knight : Figure
{
    
    SlotColor color;
    private int possibleMoves;
    private int xNewPosition;
    private int zNewPosition;
    //All movements from black site view
    private int BoardAttack(int xPosition, int zPosition, bool isSimulated)
    {
         possibleMoves = 0;
        //Move UP RIGHT
         xNewPosition = xPosition + 1;
         zNewPosition = zPosition + 2;

        if (Enumerable.Range(0, 8).Contains(xNewPosition) && Enumerable.Range(0, 8).Contains(zNewPosition))
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

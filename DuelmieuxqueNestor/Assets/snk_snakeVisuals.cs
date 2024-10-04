using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

public class snk_snakeVisuals : MonoBehaviour
{

    [SerializeField] private Tilemap tm ;
    [Tooltip("up,down,left,right")]
    Dictionary<Vector2Int, byte> VectorToMask = new Dictionary<Vector2Int, byte>()
    {
        {Vector2Int.up,Convert.ToByte("00001000", 2)},
        {Vector2Int.down,Convert.ToByte("00000100", 2)},
        {Vector2Int.left,Convert.ToByte("00000010", 2)},
        {Vector2Int.right,Convert.ToByte("00000001", 2)},
        {Vector2Int.zero,Convert.ToByte("00000000", 2)}
    };

    Dictionary<byte, int> MaskToArrayIndex = new Dictionary<byte, int>()
    {
        { Convert.ToByte("00000000", 2),0 },
        { Convert.ToByte("00000100", 2),1 },
        { Convert.ToByte("00001100", 2),2 },
        { Convert.ToByte("00001000", 2),3 },
        { Convert.ToByte("00000010", 2),4 },
        { Convert.ToByte("00000011", 2),5 },
        { Convert.ToByte("00000001", 2),6 },
        { Convert.ToByte("00000101", 2),7 },
        { Convert.ToByte("00000110", 2),8 },
        { Convert.ToByte("00001010", 2),9 },
        { Convert.ToByte("00001001", 2),10 }
    };

    public List<TileBase> tiles = new List<TileBase>();

    public void Redraw(Queue<Vector2Int> queue )
    {
        Vector2Int[] ar = queue.ToArray();
        for(int i = 0; i < ar.Length; i++)
        {
            Vector2Int ToNext = ar[Mathf.Clamp( i+1,0,ar.Length-1)] - ar[i] ;
            Vector2Int ToPrevious = ar[Mathf.Clamp(i - 1, 0, ar.Length-1)] -ar[i] ;

            byte Mask = (byte) (VectorToMask[ToNext] ^ VectorToMask[ToPrevious]);
            //print($"U: {ToNext} , V: {ToPrevious} , Mask: {ByteToBinaryString(Mask)} , Index : {MaskToArrayIndex[Mask]}");

            tm.SetTile((Vector3Int)ar[i], tiles[ MaskToArrayIndex[Mask]]);
        }

    }
    public static string ByteToBinaryString(byte byteIn)
    {
        StringBuilder out_string = new StringBuilder();
        byte mask = 128;
        for (int i = 7; i >= 0; --i)
        {
            out_string.Append((byteIn & mask) != 0 ? "1" : "0");
            mask >>= 1;
        }
        return out_string.ToString();
    }
}

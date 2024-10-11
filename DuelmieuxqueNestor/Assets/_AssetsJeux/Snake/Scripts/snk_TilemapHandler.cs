using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Snake
{
    public class snk_TilemapHandler : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [HideInInspector] public List<Vector2Int> freeTiles = new List<Vector2Int>();

        public static snk_TilemapHandler Instance { get; private set; }

        // Start is called before the first frame update
        void Awake()
        {
            if (Instance == null) Instance = this; else Destroy(this);
            CheckForFreeTiles();
        }

        public void RemoveTileAt(Vector2Int pose)
        {
            _tilemap.SetTile((Vector3Int)pose, null);
            freeTiles.Add(pose);
        }

        public void SetTileAt(Vector2Int pose, TileBase tile)
        {
            _tilemap.SetTile((Vector3Int)pose, tile);
            freeTiles.Remove(pose);
        }

        public TileBase GetTileAt(Vector2Int pose)
        {
            return _tilemap.GetTile((Vector3Int)pose);
        }


        void CheckForFreeTiles()
        {
            freeTiles.Clear();
            for (int x = -17; x <= 17; x++) //au secours
            {
                for (int y = -9; y <= 9; y++)
                {
                    //Debug.DrawRay(new Vector3Int(x, y), Vector3.up * 0.5f, Color.red, 1);
                    if (_tilemap.GetTile(new Vector3Int(x, y)) == null) freeTiles.Add(new Vector2Int(x, y));
                }
            }
        }
    }
}
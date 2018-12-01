using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelImporter : MonoBehaviour {

    [SerializeField] List<TextAsset> LevelsJSON;
    [SerializeField] List<GameObject> TilesPrefabs;
    [SerializeField] Transform game;

    List<Level> Levels = new List<Level>();

    const uint FLIPPED_HORIZONTALLY_FLAG = 0x80000000;
    const uint FLIPPED_VERTICALLY_FLAG = 0x40000000;
    const uint FLIPPED_DIAGONALLY_FLAG = 0x20000000;

    struct Extents {
        public int width;
        public int height;

        public Extents(int _width, int _height) {
            width = _width;
            height = _height;
        }
    };

    List<Extents> TilesExtents = new List<Extents>() {
        new Extents(128,128),
        new Extents(128,128),
        new Extents(128,128),
        new Extents(128,128),
        new Extents(128,128),
        new Extents(128,128),
        new Extents(128,128),
        new Extents(128,128),
        new Extents(128,128),
        new Extents(640,384),
        new Extents(1664,640),
        new Extents(1408,1088),
        new Extents(1792,1088),
        new Extents(1024,384)
    }; 

    // Use this for initialization
    void Start () {

        foreach (TextAsset json in LevelsJSON) {
            Level level = Level.CreateFromJSON(json.text);
            Levels.Add(level);
        }

        // Spawn just firt level for test
        SpawnLevel(Levels[0], new Vector2(0,0));

    }

    void SpawnLevel(Level level, Vector2 startingPos) {

        List<uint> levelData = level.layers[0].data;

        for (int y = 0; y < level.height; ++y) {
            for (int x = 0; x < level.width; ++x) {
                uint tileValue = levelData[y * level.width + x];
                Debug.Log(tileValue);
                TileInfo ti = GetInfoOfTile(tileValue);
                if (ti.value > 0) {
                    int index = ti.value - 1;
                    float offset = TilesExtents[index].width != 128 ? 0.5f : 0.0f;
                    GameObject tile = Instantiate(TilesPrefabs[index], new Vector3(x - offset, -y, 0), Quaternion.identity, game);
                    

                    if (ti.flippedDiagonally) {
                        Vector3 localScale = tile.transform.localScale;
                        localScale.x *= -1;
                        localScale.y *= -1;
                        tile.transform.localScale = localScale;
                    }

                    if (ti.flippedHorizontally) {
                        // Flip
                        Vector3 localScale = tile.transform.localScale;
                        localScale.x *= -1;
                        tile.transform.localScale = localScale;

                        // Transform
                        Vector3 pos = tile.transform.position;
                        pos.x += TilesExtents[index].width / 128 - 1;
                        tile.transform.position = pos;
                    }

                    if (ti.flippedVertically) {
                        // Flip
                        Vector3 localScale = tile.transform.localScale;
                        localScale.y *= -1;
                        tile.transform.localScale = localScale;

                        // Transform
                        Vector3 pos = tile.transform.position;
                        pos.y += TilesExtents[index].height / 128 - 1;
                        tile.transform.position = pos;
                    }
                    
                }
            }
        }
    }


    TileInfo GetInfoOfTile(uint tileValue) {
        // Read out the flags
        bool flippedHorizontally = (tileValue & FLIPPED_HORIZONTALLY_FLAG) == FLIPPED_HORIZONTALLY_FLAG;
        bool flippedVertically = (tileValue & FLIPPED_VERTICALLY_FLAG) == FLIPPED_VERTICALLY_FLAG;
        bool flippedDiagonally = (tileValue & FLIPPED_DIAGONALLY_FLAG) == FLIPPED_DIAGONALLY_FLAG;

        // Clear the flags
        tileValue &= ~(FLIPPED_HORIZONTALLY_FLAG |
                            FLIPPED_VERTICALLY_FLAG |
                            FLIPPED_DIAGONALLY_FLAG);
        int value = (int)tileValue;
        return new TileInfo(value, flippedHorizontally, flippedVertically, flippedDiagonally);
    }

    void FlipRotateObject() {

    }
}

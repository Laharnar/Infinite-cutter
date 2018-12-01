using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelImporter : MonoBehaviour {

    [SerializeField] List<TextAsset> LevelsJSON;

    List<Level> Levels = new List<Level>();

    const uint FLIPPED_HORIZONTALLY_FLAG = 0x80000000;
    const uint FLIPPED_VERTICALLY_FLAG = 0x40000000;
    const uint FLIPPED_DIAGONALLY_FLAG = 0x20000000;

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
                Debug.Log(GetInfoOfTile(tileValue).value);
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
        return new TileInfo(tileValue, flippedHorizontally, flippedVertically, flippedDiagonally);
    }
}

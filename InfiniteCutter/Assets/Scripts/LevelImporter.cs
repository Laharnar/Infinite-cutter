using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelImporter : MonoBehaviour {
    [SerializeField] TextAsset LevelsIntroJSON;
    [SerializeField] List<TextAsset> LevelsJSON;
    
    [SerializeField] Camera MainCamera;
    [SerializeField] List<GameObject> TilesPrefabs;
    [SerializeField] Transform game;

    Level levelIntro;
    List<Level> Levels = new List<Level>();
    List<GameObject> activeTiles = new List<GameObject>();

    float CurrentChunkLocation = -20;

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
        new Extents(1536,640),
        new Extents(1536,640),
        new Extents(1536,640),
        new Extents(1536,640)
    }; 

    // Use this for initialization
    void Start () {

        foreach (TextAsset json in LevelsJSON) {
            Level level = Level.CreateFromJSON(json.text);
            Levels.Add(level);
        }
        levelIntro = Level.CreateFromJSON(LevelsIntroJSON.text);
        // Spawn just firt level for test
        //SpawnLevel(Levels[0], new Vector2(-10, 2.5f));

    }

    public void SpawnFirstChunk() {
        
        SpawnLevel(levelIntro, new Vector2(CurrentChunkLocation, 2.5f));
        CurrentChunkLocation += levelIntro.width;
    }

    public void Reset() {
        CurrentChunkLocation = -20;
        foreach (GameObject go in activeTiles) {
            Destroy(go.gameObject);
        }

        activeTiles.Clear();
    }


    private void Update() {
        while (Time.timeScale > 0 &&  CurrentChunkLocation < MainCamera.transform.position.x + 2.5f * MainCamera.orthographicSize) {
            int index = Random.Range(0, Levels.Count);
            SpawnLevel(Levels[index], new Vector2(CurrentChunkLocation, 2.5f));
            CurrentChunkLocation += Levels[0].width;
        }
        
    }

    void SpawnLevel(Level level, Vector2 startingPos) {

        List<uint> levelData = level.layers[0].data;

        for (int y = 0; y < level.height; ++y) {
            for (int x = 0; x < level.width; ++x) {
                uint tileValue = levelData[y * level.width + x];
                //Debug.Log(tileValue);
                TileInfo ti = GetInfoOfTile(tileValue);
                if (ti.value > 0) {
                    int index = ti.value - 1;
                    float offsetX = TilesExtents[index].width != 128 ? 0.5f : 0.0f;
                    float offsetY = TilesExtents[index].width != 128 ? 1.5f : 0.0f;
                    GameObject tile = Instantiate(TilesPrefabs[index], new Vector3(startingPos.x + x - offsetX, startingPos.y - y - offsetY, 0), Quaternion.identity, game);
                    activeTiles.Add(tile);

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

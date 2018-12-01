public class TileInfo {
    public uint value;
    public bool flippedHorizontally;
    public bool flippedVertically;
    public bool flippedDiagonally;

    public TileInfo(uint _value, bool _flippedHorizontally, bool _flippedVertically, bool _flippedDiagonally) {
        value = _value;
        flippedHorizontally = _flippedHorizontally;
        flippedVertically = _flippedVertically;
        flippedDiagonally = _flippedDiagonally;
    }
}
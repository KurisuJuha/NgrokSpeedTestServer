using Fleck;

public class Client
{
    public readonly int maxInputSize;
    public IWebSocketConnection lastSocket;
    public byte[] lastInput
    {
        get => _lastInput;
        set => _lastInput = value[0..maxInputSize];
    }

    private byte[] _lastInput;

    public Client(IWebSocketConnection socket, int maxInputSize)
    {
        this.lastSocket = socket;
        this.maxInputSize = maxInputSize;
        this._lastInput = new byte[maxInputSize];
    }
}
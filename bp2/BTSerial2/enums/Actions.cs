namespace BTSerial2.enums
{
    public enum Actions
    {
        //TODO Add to protocol document 
        HEARTBEAT = 1,
        HEARTBEAT_ACK,
        HANDSHAKE_START,
        HANDSHAKE_ACK,
        GET_PRESSURE,
        SET_PRESSURE,
        SET_PUMP,
        SET_VALVE,
        RESET,
        OVERRIDE,
        SET_BAR,
        UPDATE_VAL
    };
}

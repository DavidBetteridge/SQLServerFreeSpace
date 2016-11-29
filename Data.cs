using ProtoBuf;

namespace DisplayFreeSpace
{
    [ProtoContract]
    public class Data
    {
        [ProtoMember(1)]
        public bool[] Extents;
    }
}

using System;
using System.Collections.Generic;
using MessagePack;
using ProtoBuf;

namespace serializationBenchmarks
{

    [Serializable]
    [MessagePackObject(true)]
    [ProtoContract]
    public class Friend
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public string name { get; set; }
    }

    [Serializable]
    [MessagePackObject(true)]
    [ProtoContract]
    public class RootObject
    {
        [ProtoMember(1)]
        public string _id { get; set; }

        [ProtoMember(2)]
        public int index { get; set; }

        [ProtoMember(3)]
        public string guid { get; set; }

        [ProtoMember(4)]
        public bool isActive { get; set; }

        [ProtoMember(5)]
        public string balance { get; set; }

        [ProtoMember(6)]
        public string picture { get; set; }

        [ProtoMember(7)]
        public int age { get; set; }

        [ProtoMember(8)]
        public string eyeColor { get; set; }

        [ProtoMember(9)]
        public string name { get; set; }

        [ProtoMember(10)]
        public string gender { get; set; }

        [ProtoMember(11)]
        public string company { get; set; }

        [ProtoMember(12)]
        public string email { get; set; }

        [ProtoMember(13)]
        public string phone { get; set; }

        [ProtoMember(14)]
        public string address { get; set; }

        [ProtoMember(15)]
        public string about { get; set; }

        [ProtoMember(16)]
        public string registered { get; set; }

        [ProtoMember(17)]
        public double latitude { get; set; }

        [ProtoMember(18)]
        public double longitude { get; set; }

        [ProtoMember(19)]
        public List<string> tags { get; set; }

        [ProtoMember(20)]
        public List<Friend> friends { get; set; }

        [ProtoMember(21)]
        public string greeting { get; set; }

        [ProtoMember(22)]
        public string favoriteFruit { get; set; }
    }
}
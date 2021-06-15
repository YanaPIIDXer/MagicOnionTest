using System;
using MessagePack;

namespace MagicOnionCommon
{
    /// <summary>
    /// プレイヤーの情報
    /// </summary>
    [MessagePackObject]
    public class Player
    {
        /// <summary>
        /// 名前
        /// </summary>
        [Key(0)]
        public string Name { get; set; } = "";

        /// <summary>
        /// X座標
        /// </summary>
        [Key(1)]
        public float X { get; set; } = 0.0f;

        /// <summary>
        /// Y座標
        /// </summary>
        [Key(2)]
        public float Y { get; set; } = 0.0f;

        /// <summary>
        /// Z座標
        /// </summary>
        [Key(3)]
        public float Z { get; set; } = 0.0f;
    }
}

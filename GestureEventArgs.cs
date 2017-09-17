using System;


namespace Kinectt {
    /// <summary>
    /// The gesture event arguments.
    /// </summary>
    public class GestureEventArgs : EventArgs
    {

        public GestureType Type { get; private set; }
        public string Name { get; private set; }
        public int TrackingID { get; private set; }


        public GestureEventArgs()
        {
        }

        public GestureEventArgs(GestureType type, int trackingID)
        {
            Type = type;
            TrackingID = trackingID;
        }


        public GestureEventArgs(string name, int trackingID)
        {
            Name = name;
            TrackingID = trackingID;
        }

    }
}

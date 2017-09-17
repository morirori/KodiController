using Microsoft.Kinect;

namespace Kinectt {
    /// <summary>
    /// Represents a single gesture segment which uses relative positioning of body parts to detect a gesture.
    /// </summary>
    public interface IGestureSegment
    {
        GesturePartResult Update(Skeleton skeleton);
    }
}

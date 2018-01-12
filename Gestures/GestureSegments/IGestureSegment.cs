using Microsoft.Kinect;

namespace KodiController.Gestures.GestureSegments {
    public interface IGestureSegment
    {
        GesturePartResult Update(Skeleton skeleton);
    }
}

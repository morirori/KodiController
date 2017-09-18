using Microsoft.Kinect;

namespace KodiController.Gestures.GestureSegments {

    /// <summary>
    /// The first part of the swipe down gesture with the right hand
    /// </summary>

    public class SwipeDownSegment1 : IGestureSegment
    {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        public GesturePartResult Update(Skeleton skeleton)
        {
            // //Right hand in front of right Shoulder
            if (skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y)
            {
                // right hand below hip
                if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.HipRight].Position.Y)
                {

                    // right hand right of right shoulder
                    if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X && skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X) {
                        return GesturePartResult.Succeeded;
                    }
                    return GesturePartResult.Undetermined;

                }

                // Debug.WriteLine("GesturePart 2 - right hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Failed;
            }

            // Debug.WriteLine("GesturePart 2 - Right hand in front of right Shoulder - FAIL");
            return GesturePartResult.Failed;
        }
    }

}
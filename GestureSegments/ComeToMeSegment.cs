using Microsoft.Kinect;

namespace Kinectt {

    public class ComeToMeSegmtnt1 : IGestureSegment {
        public GesturePartResult Update(Skeleton skeleton) {
            // Right and Left Hand in front of elblows
            if (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z) {

                // Hands above hip
                if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) {
                    // Hands between shoulders
                    return GesturePartResult.Succeeded;

                }
                return GesturePartResult.Undetermined;
            }

            return GesturePartResult.Failed;
        }
    }

    public class ComeToMeSegmtnt2 : IGestureSegment {
        public GesturePartResult Update(Skeleton skeleton) {
            // Right and Left Hand behind elblows 
            if (skeleton.Joints[JointType.HandLeft].Position.Z > skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Z > skeleton.Joints[JointType.ElbowRight].Position.Z) {
                // Hands above hip
                if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.ShoulderCenter].Position.Y) {


                    return GesturePartResult.Succeeded;
                }
                return GesturePartResult.Undetermined;
            }

            return GesturePartResult.Failed;
        }
    }
}



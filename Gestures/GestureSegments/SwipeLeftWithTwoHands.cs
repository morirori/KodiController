using Microsoft.Kinect;

namespace KodiController.Gestures.GestureSegments {
 
        public class SwipeLeftWithTwoHands1 : IGestureSegment {

            public GesturePartResult Update(Skeleton skeleton) {

                // right and left hand in front of right shoulder and below shoulder center height
                if (skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y
                   && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y) {
                    // right and left hand below shoulder height but above hip height
                    if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y
                        && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) {
                        // right hand right of right shoulder and left hand right of shoulder center
                        if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X
                            && skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderCenter].Position.X) {
                            return GesturePartResult.Succeeded;
                        }
                        return GesturePartResult.Undetermined;
                    }
                    return GesturePartResult.Failed;
                }
                return GesturePartResult.Failed;
            }
        }


        public class SwipeLeftWithTwoHands2 : IGestureSegment {
            public GesturePartResult Update(Skeleton skeleton) {
            // right and left hand in front of right shoulder and below shoulder center height
            if (skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y
              && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y) {
                // right and left  hand below shoulder height but above hip height
                if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y
                   && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) {
                    // right hand left of right shoulder & right of left shoulder
                    if (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X && skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X
                        && skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X && skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X) {
                            return GesturePartResult.Succeeded;
                        }
                        return GesturePartResult.Undetermined;
                    }
                    return GesturePartResult.Failed;
                }
                return GesturePartResult.Failed;
            }
        }


        public class SwipeLeftWithTwoHands3 : IGestureSegment {

            public GesturePartResult Update(Skeleton skeleton) {
            // Right hand in front of right Shoulder
            if (skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y
                 && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y) {

                // right hand below shoulder height but above hip height
                if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y
                   && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.Head].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) {
                    // right hand left of center hip
                    if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderLeft].Position.X
                        && skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderCenter].Position.X) {
                            return GesturePartResult.Succeeded;
                        }

                        return GesturePartResult.Undetermined;
                    }

                    return GesturePartResult.Failed;
                }

                return GesturePartResult.Failed;
            }
        }
    }

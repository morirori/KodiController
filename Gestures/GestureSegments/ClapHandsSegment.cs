using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiController.Gestures.GestureSegments {

    public class ClapHandsSegment1 : IGestureSegment {
        public GesturePartResult Update(Skeleton skeleton) {
            // Right and Left Hand in front of Shoulders
            if (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z) {
                // Hands between shoulder and hip
                if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) {
                    // Hands outside elbows
                    if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X && skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ElbowLeft].Position.X) {
                        return GesturePartResult.Succeeded;
                    }

                    return GesturePartResult.Undetermined;
                }

                return GesturePartResult.Failed;
            }

            return GesturePartResult.Failed;
        }
    }

    public class ClapHandsSegment2 : IGestureSegment {
        public GesturePartResult Update(Skeleton skeleton) {
            // Right and Left Hand in front of Shoulders
            if (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z) {
                // Hands between shoulder and hip
                if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) {
                    // Hands outside shoulders
                    if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X && skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderLeft].Position.X) {
                        return GesturePartResult.Succeeded;
                    }

                    return GesturePartResult.Undetermined;
                }

                return GesturePartResult.Failed;
            }

            return GesturePartResult.Failed;
        }
    }


    public class ClapHandsSegment3 : IGestureSegment {
        public GesturePartResult Update(Skeleton skeleton) {
            // Right and Left Hand in front of Shoulders
            if (skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z) {
                //Debug.WriteLine("Zoom 0 - Right hand in front of right shoudler - PASS");

                // Hands between shoulder and hip
                if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y && skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y) {
                    // Hands between shoulders
                    if (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X && skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                        skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X && skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X) {
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

﻿using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinectt.GestureSegments {
 
        public class SwipeLeftWithTwoHands1 : IGestureSegment {
            /// <summary>
            /// Updates the current gesture.
            /// </summary>
            /// <param name="skeleton">The skeleton.</param>
            /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
            public GesturePartResult Update(Skeleton skeleton) {

                // right and left hand in front of right shoulder and below shoulder center height
                if (skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y
                   && skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y) {
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

        /// <summary>
        /// The second part of the swipe left gesture
        /// </summary>
        public class SwipeLeftWithTwoHands2 : IGestureSegment {
            /// <summary>
            /// Updates the current gesture.
            /// </summary>
            /// <param name="skeleton">The skeleton.</param>
            /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
            public GesturePartResult Update(Skeleton skeleton) {
            // right and left hand in front of right shoulder and below shoulder center height
            if (skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y
              && skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y) {
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

        /// <summary>
        /// The third part of the swipe left gesture
        /// </summary>
        public class SwipeLeftWithTwoHands3 : IGestureSegment {
            /// <summary>
            /// Updates the current gesture.
            /// </summary>
            /// <param name="skeleton">The skeleton.</param>
            /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
            public GesturePartResult Update(Skeleton skeleton) {
            // Right hand in front of right Shoulder
            if (skeleton.Joints[JointType.HandRight].Position.Z < skeleton.Joints[JointType.ElbowRight].Position.Z && skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y
                && skeleton.Joints[JointType.HandLeft].Position.Z < skeleton.Joints[JointType.ElbowLeft].Position.Z && skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y) {

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

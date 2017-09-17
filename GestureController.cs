using Kinectt.GestureSegments;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;


namespace Kinectt {
    public class GestureController {


        private List<Gesture> gestures = new List<Gesture>();


        public GestureController() {
        }


        public event EventHandler<GestureEventArgs> GestureRecognized;

        public void Update(Skeleton skeleton) {
            foreach (Gesture gesture in gestures) {
                gesture.Update(skeleton);
            }
        }

        public void AddGesture(GestureType type) {
            IGestureSegment[] segments = null;

            switch (type) {
                case GestureType.SwipeDown:

                    segments = new IGestureSegment[1];
                    segments[0] = new SwipeDownSegment1();
                    break;

                case GestureType.SwipeLeft:

                    segments = new IGestureSegment[3];
                    segments[0] = new SwipeLeftSegment1();
                    segments[1] = new SwipeLeftSegment2();
                    segments[2] = new SwipeLeftSegment3();
                    break;

                case GestureType.SwipeRight:

                    segments = new IGestureSegment[3];
                    segments[0] = new SwipeRightSegment1();
                    segments[1] = new SwipeRightSegment2();
                    segments[2] = new SwipeRightSegment3();
                    break;

                case GestureType.SwipeUp:

                    segments = new IGestureSegment[1];
                    segments[0] = new SwipeUpSegment1();
                    break;


                case GestureType.ComeToMe:

                    segments = new IGestureSegment[2];
                    segments[0] = new ComeToMeSegmtnt1();
                    segments[1] = new ComeToMeSegmtnt2();
                    break;

                case GestureType.ClapHands:

                    segments = new IGestureSegment[3];
                    segments[0] = new ClapHandsSegment1();
                    segments[1] = new ClapHandsSegment2();
                    segments[2] = new ClapHandsSegment3();
                    break;

                case GestureType.SwipeLeftWithTwoHands:

                    segments = new IGestureSegment[3];
                    segments[0] = new SwipeLeftWithTwoHands1();
                    segments[1] = new SwipeLeftWithTwoHands2();
                    segments[2] = new SwipeLeftWithTwoHands3();
                    break;

                default:
                    break;
            }

            if (type != GestureType.None) {
                Gesture gesture = new Gesture(type, segments);
                gesture.GestureRecognized += OnGestureRecognized;

                gestures.Add(gesture);
            }
        }
        public void AddGesture(string name, IGestureSegment[] segments) {
            Gesture gesture = new Gesture(name, segments);
            gesture.GestureRecognized += OnGestureRecognized;

            gestures.Add(gesture);
        }

        private void OnGestureRecognized(object sender, GestureEventArgs e) {
            if (GestureRecognized != null) {
                GestureRecognized(this, e);
            }

            foreach (Gesture gesture in gestures) {
                gesture.Reset();
            }
        }

    }
}

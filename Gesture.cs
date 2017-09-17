using Microsoft.Kinect;
using System;

namespace Kinectt {

    /// <summary>
    /// Represents a Kinect <see cref="Gesture"/>.
    /// </summary>
    class Gesture
    {
       
        readonly int WINDOW_SIZE = 50; //okno
        readonly int MAX_PAUSE_COUNT = 10; // The maximum number of frames allowed for a paused gesture.
        IGestureSegment[] segments;
        int currentSegment = 0;
        int pausedFrameCount = 10;   // The number of frames to pause for when a pause is initiated.
        int frameCount = 0;       // The current frame.
        bool paused = false;     // Are we paused?

        string name;

        GestureType type;
        public event EventHandler<GestureEventArgs> GestureRecognized;        // Occurs when a gesture is recognised.
        public Gesture(string name, IGestureSegment[] segments)
        {
            this.name = name;
            this.segments = segments;
        }

        public Gesture(GestureType type, IGestureSegment[] segments)
        {
            this.type = type;
            name = type.ToString();
            this.segments = segments;

            name = type.ToString();
        }

 
        public void Update(Skeleton skeleton)
        {
            if (paused)
            {
                if (frameCount == pausedFrameCount)
                {
                    paused = false;
                }

                frameCount++;
            }

            GesturePartResult result = segments[currentSegment].Update(skeleton);

            if (result == GesturePartResult.Succeeded)
            {
                if (currentSegment + 1 < segments.Length)
                {
                    currentSegment++;
                    frameCount = 0;
                    pausedFrameCount = MAX_PAUSE_COUNT;
                    paused = true;
                }
                else
                {
                    if (GestureRecognized != null)
                    {
                        GestureRecognized(this, new GestureEventArgs(type, skeleton.TrackingId));
                        Reset();
                    }
                }
            }
            else if (result == GesturePartResult.Failed || frameCount == WINDOW_SIZE)
            {
                Reset();
            }
            else
            {
                frameCount++;
                pausedFrameCount = MAX_PAUSE_COUNT / 2;
                paused = true;
            }
        }


        public void Reset()
        {
            currentSegment = 0;
            frameCount = 0;
            pausedFrameCount = MAX_PAUSE_COUNT / 2;
            paused = true;
        }

 
    }
}

using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiController.Utills {
    class SkeltonCoordinatesContainer {

        private Skeleton skeleton;
        Dictionary<JointType, Dictionary<String, String>> skeltonJoints;

        public SkeltonCoordinatesContainer(Skeleton skelton) {
            this.skeltonJoints = new Dictionary<JointType, Dictionary<String, String>>();
            this.skeleton = skelton;
        }

        public void setSkeltonJoints(Skeleton skelton,  JointType jointType , KinectSensor sensor) {
            var jointDict = new Dictionary<String, String>();
            var mapper = new CoordinateMapper(sensor);
            var position = skelton.Joints[jointType].Position;
            var rightHand = mapper.MapSkeletonPointToDepthPoint(position,DepthImageFormat.Resolution640x480Fps30);
            jointDict.Add("X", rightHand.X.ToString());
            jointDict.Add("Y",rightHand.Y.ToString());
            jointDict.Add("Z",rightHand.Depth.ToString());
            this.skeltonJoints.Add(jointType, jointDict);
        }

        public Dictionary<JointType, Dictionary<String, String>> getSkeltonJoints() {
            return this.skeltonJoints;
        }



    }
}

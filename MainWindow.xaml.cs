using KodiController.Gestures;
using KodiController.Kodi;
using KodiController.Utills;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KodiController {
    public partial class MainWindow : Window {
        private static KinectSensor sensor;
        Dictionary<String, System.Windows.Controls.TextBox> textboxes;
        Dictionary<String, System.Windows.Controls.Label> jointsLabels;
        GestureController controller;
        FunctionController functionController;

        public MainWindow() {
            InitializeComponent();
            textboxes = new Dictionary<String, System.Windows.Controls.TextBox>();
            jointsLabels = new Dictionary<string, Label>();
            textboxes.Add("swipeDown", swipeDown);
            textboxes.Add("swipeLeft", swipeLeft);
            textboxes.Add("swipeRight", swipeRight);
            textboxes.Add("swipeUP", swipeUP);
            textboxes.Add("zoomIn", zoomIn);
            textboxes.Add("swipeWithTwo", swipeWithTwo);
            textboxes.Add("clapHands", clapHands);
            setBackgroundWhiite();
        }



        private void Start_Click(object sender, RoutedEventArgs e) {

            if (StartStartBtn.Content.ToString() == "Start") {
                sensor = KinectSensor.KinectSensors.Where(s => s.Status == KinectStatus.Connected).FirstOrDefault();

                if (sensor != null) {

                    sensor.Start();
                    ConnectionIDTB.Text = sensor.DeviceConnectionId;
                    sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    sensor.SkeletonStream.Enable();
                    sensor.SkeletonFrameReady += Sensor_SkeletonFrameReady;
                    controller = new GestureController();
                    controller.AddGesture(GestureType.SwipeUp);
                    controller.AddGesture(GestureType.SwipeLeft);
                    controller.AddGesture(GestureType.SwipeRight);
                    controller.AddGesture(GestureType.SwipeDown);
                    controller.AddGesture(GestureType.ComeToMe);
                    controller.AddGesture(GestureType.ClapHands);
                    controller.AddGesture(GestureType.SwipeLeftWithTwoHands);
                    controller.GestureRecognized += GestureController_GestureRecognized;
                    StartStartBtn.Content = "Stop";
                }
                else {
                    String message = "Kinect is not active";
                    String caption = "Error Detected in Input";
                    System.Windows.MessageBox.Show(message, caption, MessageBoxButton.OK);
                }
            }

            else {
                if (sensor != null && sensor.IsRunning) {
                    sensor.Stop();
                    StartStartBtn.Content = "Start";
                }
            }
        }



        private void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e) {
            using (var frame = e.OpenSkeletonFrame()) {

                if (frame == null) {
                    return;
                }

                var skeltons = new Skeleton[frame.SkeletonArrayLength];
                frame.CopySkeletonDataTo(skeltons);
                var skeleton = skeltons.FirstOrDefault(s => s.TrackingState == SkeletonTrackingState.Tracked);
                if (skeleton == null) {
                    return;
                }
                readJointsValues(skeleton);
                controller.Update(skeleton);

            }
        }


        private void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e) {
            StatusTB.Text = e.Sensor.Status.ToString();
        }

        private void angleDown_Click(object sender, RoutedEventArgs e) {
            var angle = sensor.ElevationAngle;
            Console.WriteLine(angle);
            if (angle > -27) {
                sensor.ElevationAngle = angle - 1;
            }
        }

        private void angleUp_Click(object sender, RoutedEventArgs e) {
            var angle = sensor.ElevationAngle;
            Console.WriteLine(angle);
            if (angle < 27) {
                sensor.ElevationAngle = angle + 1;
            }
        }

        private void waveStatusTxt_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void GestureController_GestureRecognized(object sender, GestureEventArgs e) {
            functionController = new FunctionController();
            var gesture = e.Type;
            setBackgroundWhiite();
            switch (gesture) {
                case (GestureType.ComeToMe): {
                    textboxes["zoomIn"].Background = Brushes.Green;
                   // functionController.select();
                    break;
                }
                case (GestureType.SwipeRight): {
                    textboxes["swipeRight"].Background = Brushes.Green;
                    functionController.swipeRight();
                    break;
                }
                case (GestureType.SwipeLeft): {
                    textboxes["swipeLeft"].Background = Brushes.Green;
                    functionController.swipeLeft();
                    break;
                }
                case (GestureType.SwipeUp): {
                    textboxes["swipeUP"].Background = Brushes.Green;
                    functionController.swipeUp();
                    Thread.Sleep(500);
                    break;
                }
                case (GestureType.SwipeDown): {
                    textboxes["swipeDown"].Background = Brushes.Green;
                    functionController.swipeDown();
                    Thread.Sleep(500);
                    break;
                }
                case (GestureType.ClapHands): {
                    textboxes["clapHands"].Background = Brushes.Green;
                    functionController.select();
                    break;
                }
                case (GestureType.SwipeLeftWithTwoHands): {
                    textboxes["swipeWithTwo"].Background = Brushes.Green;
                    functionController.back();
                    break;
                }
            }
        }
        private void setBackgroundWhiite() {
            foreach (KeyValuePair<string, System.Windows.Controls.TextBox> entry in this.textboxes) {
                entry.Value.Background = Brushes.White;
            }

        }   
        private void readJointsValues(Skeleton skelton) {
            var coordintaesMapper = new SkeltonCoordinatesContainer(skelton);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.HandRight, sensor);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.HandLeft, sensor);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.ShoulderCenter, sensor);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.ShoulderLeft, sensor);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.ShoulderRight, sensor);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.HipCenter, sensor);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.Head, sensor);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.ElbowLeft, sensor);
            coordintaesMapper.setSkeltonJoints(skelton, JointType.ElbowRight, sensor);
            var mappedCoordinates = coordintaesMapper.getSkeltonJoints();
            foreach (KeyValuePair<JointType, Dictionary<String, String>> entry in mappedCoordinates) {
                if (entry.Key == JointType.HandRight) {
                    rightHandX.Content = entry.Value["X"];
                    rightHandY.Content = entry.Value["Y"];
                    rightHandZ.Content = entry.Value["Z"];
                }
                if (entry.Key == JointType.HandLeft) {
                    leftHandX.Content = entry.Value["X"];
                    leftHandY.Content = entry.Value["Y"];
                    leftHandZ.Content = entry.Value["Z"];
                }
                if (entry.Key == JointType.ElbowLeft) {
                    leftElblowX.Content = entry.Value["X"];
                    leftElblowY.Content = entry.Value["Y"];
                    leftElblowZ.Content = entry.Value["Z"];
                }
                if (entry.Key == JointType.ElbowRight) {
                    rightElblowX.Content = entry.Value["X"];
                    rightElblowY.Content = entry.Value["Y"];
                    rightElblowZ.Content = entry.Value["Z"];
                }
                if (entry.Key == JointType.ShoulderCenter) {
                    shoulderCenterX.Content = entry.Value["X"];
                    shoulderCenterY.Content = entry.Value["Y"];
                    shoulderCenterZ.Content = entry.Value["Z"];
                }
                if (entry.Key == JointType.ShoulderRight) {
                    rightShoulderX.Content = entry.Value["X"];
                    rightShoulderY.Content = entry.Value["Y"];
                    rightShoulderZ.Content = entry.Value["Z"];
                }
                if (entry.Key == JointType.ShoulderLeft) {
                    leftShoulderX.Content = entry.Value["X"];
                    leftShoulderY.Content = entry.Value["Y"];
                    leftShoulderZ.Content = entry.Value["Z"];
                }
                if (entry.Key == JointType.Head) {
                    HeadX.Content = entry.Value["X"];
                    HeadY.Content = entry.Value["Y"];
                    HeadZ.Content = entry.Value["Z"];
                }
                if (entry.Key == JointType.HipCenter) {
                    HipX.Content = entry.Value["X"];
                    HipY.Content = entry.Value["Y"];
                    HipZ.Content = entry.Value["Z"];
                }


            }

        }


    }


}

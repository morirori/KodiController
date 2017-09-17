using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Coding4Fun.Kinect.Wpf;
using System.Windows.Forms;
using Kinectt.KodiFunctions;
using System.Threading;

namespace Kinectt {
    public partial class MainWindow : Window {

        private static KinectSensor sensor;
        Dictionary<String, System.Windows.Controls.TextBox> textboxes;
        GestureController controller;
        FunctionController functionController;
        
        public MainWindow() {
            InitializeComponent();
            textboxes = new Dictionary<String, System.Windows.Controls.TextBox>();
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
                    textboxes["zoomIn"].Background=Brushes.Green ;
                    functionController.select();
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
                    functionController.playAndPause();
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

        private void poistionZ_Copy8_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }

    
}

    



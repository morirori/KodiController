Synopsis

Kodi Controller is application which let you to controll Kodi using Microsoft Kinect for XBOX 360. Im using here Newtonsoft.Json --version 10.0.3. For gesture analysis i have based on Vitruvius project made by LightBuzz.  


Code Example

List of defined gestures are included in enum GestureType. When gesture will be recognized GestureController class will rise event GestureRecognized. 
Based on gestureType which every event contains. Program will execute KodiFunction. 

        private void GestureController_GestureRecognized(object sender, GestureEventArgs e) {
            functionController = new FunctionController();
            var gesture = e.Type;
            setBackgroundWhiite();
            switch (gesture) {
                case (GestureType.SwipeLeft): {
                    textboxes["swipeLeft"].Background = Brushes.Green;
                    functionController.swipeLeft();
                    break;
                }
	    }
	 }
For Kodi interactiong we are using FunctionController class, this class contains function which are executing correspdonding Kodi's action
for instance:

        FunctionController functionController;
        functionController.swipeRight();

		
		
		
Installation

To install this project you need Kinect SDK, you can download it from this page:https://www.microsoft.com/en-us/download/details.aspx?id=40278
and librare for json serialisation, type this in NuGet package manager: NU Get: Newtonsoft.Json --version 10.0.3

Testing

For propper gesture detection, you have to perform gesture in correct way:
swipe up - rise your right hand above your head
swipe down - rise your left hand below your hips
swipe right - move your left hand in right direction. Left hand starting position: Below arms and above hips, on the left side of your body. Left hand ending position. Hand below arms and above hips and on the right side of your body. For better performance keep your rigt hand around your stomach. 
swipe left - move your right hand in left direction. Right hand starting position: Below arms and above hips, on the right side of your body. Left hand ending position. Hand below arms and above hips and on the left side of your body. For better performance keep your left hand around your stomach. 
select - clap your hands, hands should be located in the hight of your chest
back - move your right and left hand in left direction. Right and left hand starting position: Below arms and above hips, on the right side of your body. Left and right hand ending position. Hands below arms and above hips and on the left side of your body.

Contributors
Morawiec Michal

License
GNU General Public License

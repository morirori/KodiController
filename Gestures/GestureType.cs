
namespace KodiController.Gestures {

    public enum GestureType
    {


        None,          // Undefined gesture.
        All,           // All of the predefined gestures.
        SwipeLeft,     // Hand moved horizontally from right to left.
        SwipeRight,    // Hand moved horizontally from left to right.
        SwipeUp,       // Hand moved vertically from hip center to head.
        SwipeDown,     // Hand moved vertically from head to hip center.
        ClapHands,     // Both hands extended closer to the chest.
        ComeToMe,      // 
        SwipeLeftWithTwoHands // Swiping left with two hands
    }
}

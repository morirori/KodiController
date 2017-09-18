using KodiController.Kodi.KodiFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiController.Kodi {
    class FunctionController {
        IKodiFunction kodiFunction;

        public void swipeUp() {
            kodiFunction = new UpFunction();
            kodiFunction.function();
        }

        public void swipeDown() {
            kodiFunction = new DownFunction();
            kodiFunction.function();
        }
        public void swipeLeft() {
            kodiFunction = new LeftFunction();
            kodiFunction.function();
        }
        public void swipeRight() {
            kodiFunction = new RightFunction();
            kodiFunction.function();
        }
        public void select() {
            kodiFunction = new SelectFunction();
            kodiFunction.function();
        }
        public void back() {
            kodiFunction = new BackFunction();
            kodiFunction.function();
        }
        public void playAndPause() {
            kodiFunction = new PlayPauseFunction();
            kodiFunction.function();
        }

    }
}

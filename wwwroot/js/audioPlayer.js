window.audioPlayer = {
    setupAudioEndedHandler: function (audioElement, dotNetReference) {
        audioElement.addEventListener('ended', function () {
            dotNetReference.invokeMethodAsync('OnAudioEnded');
        });
    },
    play: function (audioElement) {
        audioElement.play();
    },
    pause: function (audioElement) {
        audioElement.pause();
    },
    enableRepeat: function (audioElement) {
        audioElement.onended = function () {
            audioElement.play();
        };
    },
    disableRepeat: function (audioElement) {
        audioElement.onended = null;
    },
    enableAutoNext: function (audioElement, dotNetReference) {
        audioElement.onended = function () {
            dotNetReference.invokeMethodAsync('OnNextAyahAutoPlay');
        };
    },
    disableAutoNext: function (audioElement) {
        audioElement.onended = null;
    }
};

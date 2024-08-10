let videoStream;
const videoElement = document.getElementById('cameraStream');
const canvasElement = document.getElementById('cameraCanvas');

function openCameraModal() {
    navigator.mediaDevices.getUserMedia({ video: true })
        .then(stream => {
            videoStream = stream;
            videoElement.srcObject = stream;
            $('#cameraModal').modal('show');
        })
        .catch(error => {
            console.error("Error accessing the camera: ", error);
        });
}

function capturePhoto() {
    canvasElement.width = videoElement.videoWidth;
    canvasElement.height = videoElement.videoHeight;
    const context = canvasElement.getContext('2d');
    context.drawImage(videoElement, 0, 0, canvasElement.width, canvasElement.height);
    canvasElement.toBlob(blob => {
        const fileInput = document.querySelector('input[type=file]');
        const file = new File([blob], "webcam-photo.jpg", { type: "image/jpeg" });
        const dataTransfer = new DataTransfer();
        dataTransfer.items.add(file);
        fileInput.files = dataTransfer.files;
    }, 'image/jpeg');
    stopCamera();
    $('#cameraModal').modal('hide');
}

function stopCamera() {
    if (videoStream) {
        const tracks = videoStream.getTracks();
        tracks.forEach(track => track.stop());
    }
}

$('#cameraModal').on('hidden.bs.modal', stopCamera);
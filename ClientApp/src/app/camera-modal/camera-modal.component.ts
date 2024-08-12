import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-camera-modal',
  templateUrl: './camera-modal.component.html',
  styleUrls: ['./camera-modal.component.css']
})
export class CameraModalComponent {
  @ViewChild('videoElement') videoElement!: ElementRef;
  @ViewChild('canvasElement') canvasElement!: ElementRef;

  isOpen = false;
  stream!: MediaStream;

  openCameraModal() {
    this.isOpen = true;
    navigator.mediaDevices.getUserMedia({ video: true }).then(stream => {
      this.stream = stream;
      this.videoElement.nativeElement.srcObject = stream;
    });
  }

  capturePhoto() {
    const video = this.videoElement.nativeElement;
    const canvas = this.canvasElement.nativeElement;
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;
    const context = canvas.getContext('2d');
    context.drawImage(video, 0, 0, canvas.width, canvas.height);

    // Convert to data URL or Blob for upload
    canvas.toBlob((blob: Blob) => {
      // Handle the blob, e.g., upload it or save it
    }, 'image/jpeg');
  }

  closeModal() {
    this.isOpen = false;
    this.stopCamera();
  }

  stopCamera() {
    if (this.stream) {
      const tracks = this.stream.getTracks();
      tracks.forEach(track => track.stop());
    }
  }
}

import { Component, Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import Axios from 'axios'
import Recorder from 'recorder-js';
import { environment } from 'src/environments/environment';



declare var MediaRecorder: any;
const httpOptions = {
  headers: new HttpHeaders({
    responseType: 'blob as json',
    'Content-Type': 'application/json',
    Accept: 'application/json',
  }),
};

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
})

@Injectable({
  providedIn : 'root'
})
export class EmployeeComponent implements OnInit {
  blobFile;
  recordAudio;
  sendObj;
  audioContext = new AudioContext({ sampleRate: 16000 });
  recorder = new Recorder(this.audioContext, {});
  title = 'ClientApp';
  voiceActiveSectionDisabled: boolean = true;
  nameString:string;
  phonetics:string;

  constructor(private http: HttpClient) {}
  ngOnInit() {
    this.sendObj = {
      audio: this.blobFile,
    };
    this.recordAudio = () => {
      return new Promise((resolve) => {
        navigator.mediaDevices.getUserMedia({ audio: true }).then((stream) => {
          const mediaRecorder = new MediaRecorder(stream, {
            mimeType: 'audio/webm',
            numberOfAudioChannels: 1,
            audioBitsPerSecond: 16000,
          });
          const audioChunks = [];

          mediaRecorder.addEventListener('dataavailable', (event) => {
            audioChunks.push(event.data);
          });

          const start = () => {
            mediaRecorder.start();
          };

          const stop = () => {
            return new Promise((resolve) => {
              mediaRecorder.addEventListener('stop', () => {
                const audioBlob = new Blob(audioChunks, {
                  type: 'audio/wav; codecs=MS_PCM',
                });
                const reader = new FileReader();
                reader.readAsDataURL(audioBlob);
                reader.addEventListener(
                  'load',
                  () => {
                   
                    const base64data = reader.result;
                    this.sendObj.audio = base64data;
                    this.http
                      .post('https://localhost:44346/api/NamePronunciation/CustomName/', this.sendObj, httpOptions)
                      .subscribe((data) => console.log(data));
                  },
                  false
                );
                const audioUrl = URL.createObjectURL(audioBlob);
                console.log('Audiourl', audioUrl);
                const audio = new Audio(audioUrl);
                const play = () => {
                  audio.play();
                };
                resolve({ audioBlob, audioUrl, play });
              });

              mediaRecorder.stop();
              this.voiceActiveSectionDisabled = true;
            });
          };
          resolve({ start, stop });
        });
      });
    };
  }
  async startPlay() {
    this.recorder = await this.recordAudio();
    this.recorder.start();
  }

  async stopPlay() {
    const audio = await this.recorder.stop();
    audio.play();
    
  }

  displayRecordButton()
  {
    this.voiceActiveSectionDisabled = false;
  }

  standardRecord()
  {
    const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');
    const requestOptions: Object = {
      headers: headers,
      responseType: 'text'
    }
    let phoneticParams = new HttpParams();
    phoneticParams = phoneticParams.append('Name', this.nameString);
     this.http
     .get<string>('https://localhost:44346/api/NamePronunciation/NamePhonetic?Name=' + this.nameString, requestOptions)
     .subscribe((data) => this.phonetics = data);
   
   let params = new HttpParams();
   params = params.append('Name', this.nameString);
    this.http
    .get('https://localhost:44346/api/NamePronunciation/NameStandard', {params: params})
    .subscribe((data) => console.log("222:" + data));
  }
}

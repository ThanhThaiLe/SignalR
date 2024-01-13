import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ChatService } from '../services/chat.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  userForm: FormGroup = new FormGroup({});
  submitted: boolean = false;
  openchat: boolean = false;
  apiErrorMessages: string[] = [];
  constructor(
    private formBuilder: FormBuilder,
    private chatService: ChatService
  ) {}
  ngOnInit() {
    this.initializeFormGroup();
  }
  initializeFormGroup() {
    this.userForm = this.formBuilder.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(15),
        ],
      ],
    });
  }
  closeChat() {
    this.openchat = false;
  }
  submitForm() {
    this.submitted = true;
    this.apiErrorMessages = [];
    if (this.userForm.valid) {
      this.chatService.registerUser(this.userForm.value).subscribe({
        next: (value) => {
          console.log('open chat');
          this.chatService.myName = this.userForm.get('name')?.value;
          this.openchat = true;
          this.userForm.reset();
          this.submitted = false;
        },
        error: (error) => {
          if (typeof error.error === 'object') {
            this.apiErrorMessages.push(error.error);
          }
        },
      });
    }
  }
}

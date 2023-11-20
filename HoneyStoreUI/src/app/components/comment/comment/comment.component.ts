import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService, CommentService } from '../../../services';
import { Comment } from '../../../models'
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';

@Component({
  selector: 'app-comment',
  standalone: true,
  imports: [CommonModule,
    MatButtonModule, 
    MatIconModule,
    MatDividerModule],
  templateUrl: './comment.component.html',
  styleUrl: './comment.component.css'
})
export class CommentComponent {
  @Input() comments: Comment[] = [];
  @Output() commentDeleted = new EventEmitter();

  constructor(private commentSvc: CommentService, private authSvc: AuthenticationService) { }

  userCanDelete(userId: number) {
    return this.authSvc.currentUserValue?.id === userId;
  }

  delete(id: number) {
    this.commentSvc.delete(id).subscribe(()=>{
      this.commentDeleted.emit();
    });
  }
}

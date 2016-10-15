import { Component } from '@angular/core';

import { LaptopDetails } from '../laptop-details';
import { CommentsService } from '../services/administration/comments.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/laptops/details.html',
    providers: [CommentsService]
})
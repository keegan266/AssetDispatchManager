import { Component } from "@angular/core";
import dayGridPlugin from '@fullcalendar/daygrid';

@Component ({
    selector: 'app-calendar',
    templateUrl: './calendar.component.html',
    styleUrls: ['./calendar.component.css']
})

export class CalendarComponent {
    calendarPlugins = [dayGridPlugin];
    constructor() {

    }
    
}
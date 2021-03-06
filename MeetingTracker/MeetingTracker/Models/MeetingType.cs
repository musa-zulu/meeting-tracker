﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingTracker.Models
{
    public class MeetingType
    {
        public int MeetingTypeId { get; set; }

        [Display(Name = "Meeting Type")]
        public string MeetingTypeDescription { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
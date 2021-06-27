using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class FeedbackTopic
    {
        public int FeedbackTopicId { get; set; }
        public string FeedbackTopicName { get; set; }
        public string FeedbackTopicDesc { get; set; }
        public int TopicOwnerId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

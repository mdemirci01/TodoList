using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class TodoItem:BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [StringLength(200)]
        public string Attachment { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int? SideId { get; set; }
        [ForeignKey("SideId")]
        public virtual Side Side { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Contact Manager { get; set; }

        public int? OrganizatorId { get; set; }
        [ForeignKey("OrganizatorId")]
        public virtual Contact Organizator { get; set; }

        public DateTime MeetingDate { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime ReviseDate { get; set; }
        public string ConversationSubject { get; set; }
        public string SupporterCompany { get; set; }
        public string SupporterDoctor { get; set; }
        public int ConversationAttendeeCount { get; set; }
        public DateTime ScheduledOrganizationDate { get; set; }
        public string MailingSubjects { get; set; }
        public string PosterSubject { get; set; }
        public int PosterCount { get; set; }
        public string Elearning { get; set; }
        public string TypesOfScans { get; set; }
        public string AsoCountInScans { get; set; }
        public string TypesOfOrganization { get; set; }
        public string AsoCountInOrganizations { get; set; }
        public string TypesOfVaccinationOrganization { get; set; }
        public string AsoCountInVaccinationOrganization { get; set; }
        public string AmountOfCompensationForPoster { get; set; }
        public string CorporateProductivityReport { get; set; }
    }
}
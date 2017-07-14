using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class TodoItem:BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        [DisplayName("Başlık")]
        public string Title { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Durum")]
        public Status Status { get; set; }
        [DisplayName("Kategori")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [DisplayName("Kategori")]
        public virtual Category Category { get; set; }
        [StringLength(200)]
        [DisplayName("Dosya Eki")]
        public string Attachment { get; set; }
        [DisplayName("Departman")]
        public int? DepartmentId { get; set; }
        [DisplayName("Departman")]
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        [DisplayName("Taraf")]
        public int? SideId { get; set; }
        [ForeignKey("SideId")]
        [DisplayName("Taraf")]
        public virtual Side Side { get; set; }
        [DisplayName("Müşteri")]
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [DisplayName("Müşteri")]
        public virtual Customer Customer { get; set; }
        [DisplayName("Yönetici")]
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        [DisplayName("Yönetici")]
        public virtual Contact Manager { get; set; }
        [DisplayName("Organizatör")]
        public int? OrganizatorId { get; set; }
        [ForeignKey("OrganizatorId")]
        [DisplayName("Organizatör")]
        public virtual Contact Organizator { get; set; }

        [DataType("datetime-local")]
        [DisplayName("Toplantı Tarihi")]
        [Required(ErrorMessage = "Toplantı tarihi alanı gereklidir.")]
        public DateTime MeetingDate { get; set; }
        [DataType("datetime-local")]
        [DisplayName("Planlanan Tarih")]
        [Required(ErrorMessage = "Planlanan tarih alanı gereklidir.")]
        public DateTime PlannedDate { get; set; }
        [DataType("datetime-local")]
        [DisplayName("Bitirilme Tarihi")]
        [Required(ErrorMessage = "Bitirilme tarihi alanı gereklidir.")]  
        public DateTime FinishDate { get; set; }
        [DataType("datetime-local")]
        [DisplayName("Revize Tarihi")]
        [Required(ErrorMessage = "Revize tarihi alanı gereklidir.")]
        public DateTime ReviseDate { get; set; }
        [DisplayName("Görüşme Konusu")]
        public string ConversationSubject { get; set; }
        [DisplayName("Destekleyen Firma")]
        public string SupporterCompany { get; set; }
        [DisplayName("Destekleyen Hekim")]
        public string SupporterDoctor { get; set; }
        [DisplayName("Görüşme Katılımcı Sayısı")]
        [Required(ErrorMessage = "Görüşme katılımcı sayısı alanı gereklidir.")]
        public int ConversationAttendeeCount { get; set; }
        [DataType("datetime-local")]
        [DisplayName("Planlanan Organizasyon Tarihi")]
        [Required(ErrorMessage = "Planlanan organizasyon tarihi alanı gereklidir.")]
        public DateTime ScheduledOrganizationDate { get; set; }
        [DisplayName("Mailing Konuları")]
        public string MailingSubjects { get; set; }
        [DisplayName("Afiş Konusu")]
        public string PosterSubject { get; set; }
        [DisplayName("Afiş Sayısı")]
        [Required(ErrorMessage = "Afiş sayısı alanı gereklidir.")]
        public int PosterCount { get; set; }
        [DisplayName("E-Learning")]
        public string Elearning { get; set; }
        [DisplayName("Yapılan Taramaların Türleri")]
        public string TypesOfScans { get; set; }
        [DisplayName("Yapılan Taramalardaki ASO Sayısı")]
        public string AsoCountInScans { get; set; }
        [DisplayName("Organizasyon Türleri")]
        public string TypesOfOrganization { get; set; }
        [DisplayName("Organizasyonlardaki ASO Sayısı")]
        public string AsoCountInOrganizations { get; set; }
        [DisplayName("Aşı Organizasyonu Türleri ")]
        public string TypesOfVaccinationOrganization { get; set; }
        [DisplayName("Aşı Organizasyonundaki ASO Sayısı")]
        public string AsoCountInVaccinationOrganization { get; set; }
        [DisplayName("Afiş İçin Tazminat Miktarı")]
        public string AmountOfCompensationForPoster { get; set; }
        [DisplayName("Kurumsal Verimlilik Raporu")]
        public string CorporateProductivityReport { get; set; }
    }
}
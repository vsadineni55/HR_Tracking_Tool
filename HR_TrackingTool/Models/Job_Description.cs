//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR_TrackingTool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Job_Description
    {
        public int Job_Id { get; set; }
        [Required]
        [DisplayName("Job Title:")]
        public string Job_Title { get; set; }
        [Required]
        [DisplayName("Skills:")]
        public string Skills { get; set; }
        [Required]
        [DisplayName("Roles & Responsibilities:")]
        public string Roles_Resposibilities { get; set; }
        [Required]
        [DisplayName("Email:")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Contact Number:")]
        [DataType(DataType.PhoneNumber)]
        public Nullable<long> contact_number { get; set; }
    }
}